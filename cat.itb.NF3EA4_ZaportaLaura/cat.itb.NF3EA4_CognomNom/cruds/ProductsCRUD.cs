using cat.itb.NF3EA4_ZaportaLaura.cruds.others;
using EA1.model.restaurantsCollection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cat.itb.NF3EA4_CognomNom.cruds
{
    public class ProductsCRUD : Database
    {
        private static IMongoCollection<Restaurant> _collection = _database.GetCollection<Restaurant>("products");

        public static void SelectNumCategories() // 2k
        {
            var aggregate = _collection.Aggregate()
                .Project(new BsonDocument
                {
                    { "Name", 1 },
                    { "_id", 0 },
                    { "categoryCount", new BsonDocument("$size", "$Categories") }
                })
                .ToList();
            foreach (var product in aggregate) {
                Console.WriteLine($"\n Producte: {product}");
            }
        }
        public static void SelectCategoriesNoRep() // 2l
        {
            var aggregate = _collection.Aggregate()
                .Unwind("Categories")
                .Group(new BsonDocument
                {
                    { "_id", BsonNull.Value }, // Agrupa tot
                    { "AllCategories", new BsonDocument("$addToSet", "$Categories") }
                })
                .FirstOrDefault();
            Console.WriteLine($"\n Categories: {aggregate}");
        }
    }
}
