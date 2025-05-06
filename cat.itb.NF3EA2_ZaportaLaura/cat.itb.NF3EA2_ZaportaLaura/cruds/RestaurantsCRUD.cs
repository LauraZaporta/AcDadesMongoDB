using System.IO;
using System.Reflection.Emit;
using cat.itb.NF3EA2_ZaportaLaura.cruds.others;
using EA1.connections;
using EA1.model.restaurantsCollection;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace cat.itb.NF3EA2_ZaportaLaura.cruds
{
    public class RestaurantsCRUD : Database
    {
        private static IMongoCollection<BsonDocument> _collection { get; set; } = _database.GetCollection<BsonDocument>("restaurants");
        public static void LoadRestaurantsCollection()
        {
            HelperClass.LoadCollection<Restaurant>("restaurants", "Restaurant");
        }
        public static void SelectNameAndCuisineByZipcode(string zipcode) // EX 2d
        {
            var zipcodeFilter = Builders<BsonDocument>.Filter.Eq("address.zipcode", zipcode);
            var restaurants = _collection.Find(zipcodeFilter).ToList();

            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"\n {restaurant.GetElement("name")}" +
                    $"\n {restaurant.GetElement("cuisine")}\n");
            }
        }
        public static void SelectAllByBoroughAndCuisine(string borough, string cuisine) // EX 2e
        {
            var boroughFilter = Builders<BsonDocument>.Filter.Eq("borough", borough);
            var cuisineFilter = Builders<BsonDocument>.Filter.Eq("cuisine", cuisine);

            var filters = Builders<BsonDocument>.Filter.And(boroughFilter, cuisineFilter);
            var restaurants = _collection.Find(filters).ToList();

            var settings = new JsonWriterSettings { Indent = true };

            Console.WriteLine();
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"{restaurant.ToJson(settings)}\n\n");
            }
        }
        public static void UpdateZipcodeByStreet(string street, string zipcode) // EX 3a
        {
            var settings = new JsonWriterSettings { Indent = true };

            var streetFilter = Builders<BsonDocument>.Filter.Eq("address.street", street);
            var update = Builders<BsonDocument>.Update.Set("address.zipcode", zipcode);

            var restaurantToUpdate = _collection.Find(streetFilter).FirstOrDefault();

            Console.WriteLine($"\n Restaurant a actualitzar: \n ------------------------- \n{restaurantToUpdate.ToJson(settings)}" +
                $"\n Zipcode nou: {zipcode}\n");

            _collection.UpdateOne(streetFilter, update);

            var restaurantUpdated = _collection.Find(streetFilter).FirstOrDefault();

            Console.WriteLine($"\n Restaurant actualitzat: \n ----------------------- \n{restaurantUpdated.ToJson(settings)}\n");
        }
        public static void DeleteFromXBorough(string borough) // EX 4a
        {
            var boroughFilter = Builders<BsonDocument>.Filter.Eq("borough", borough);

            var docsDeleted = _collection.DeleteMany(boroughFilter);
            Console.WriteLine($"\n Documents eliminats: {docsDeleted.DeletedCount}");
        }
    }
}