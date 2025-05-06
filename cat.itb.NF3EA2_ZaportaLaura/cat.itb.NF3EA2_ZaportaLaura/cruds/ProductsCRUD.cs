using cat.itb.NF3EA2_ZaportaLaura.cruds.others;
using EA1.model.productsCollection;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace cat.itb.NF3EA2_ZaportaLaura.cruds
{
    public class ProductsCRUD : Database
    {
        private static IMongoCollection<BsonDocument> _collection { get; set; } = _database.GetCollection<BsonDocument>("products");

        public static void LoadProductsCollection()
        {
            HelperClass.LoadCollection<Product>("products", "Product");
        }
        public static void UpdateNewStockminimForPlusXPrice(int price, int stockMinValue) // EX 3b
        {
            var settings = new JsonWriterSettings { Indent = true };

            var priceFilter = Builders<BsonDocument>.Filter.Gt("price", price);
            var update = Builders<BsonDocument>.Update.Set("stockminim", stockMinValue);

            var updatedDocsInfo = _collection.UpdateMany(priceFilter, update);
            var productsUpdated = _collection.Find(priceFilter).ToList();

            Console.WriteLine($"\n Número de documents actualitzats: {updatedDocsInfo.ModifiedCount}\n");

            foreach (var product in productsUpdated)
            {
                Console.WriteLine($"{product.ToJson(settings)}\n");
            }
        }
        public static void UdpateNewGamaField() // EX 3d
        {
            var settings = new JsonWriterSettings { Indent = true };

            var gamaBaixaFilter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Gte("price", 1),
                Builders<BsonDocument>.Filter.Lte("price", 500)
                );
            var gamaAltaFilter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Gte("price", 501),
                Builders<BsonDocument>.Filter.Lte("price", 2000)
                );
            var updateGBaixa = Builders<BsonDocument>.Update.Set("gama", "baixa");
            var updateGAlta = Builders<BsonDocument>.Update.Set("gama", "alta");

            _collection.UpdateMany(gamaBaixaFilter, updateGBaixa);
            _collection.UpdateMany(gamaAltaFilter, updateGAlta);

            var allProducts = _collection.Find(new BsonDocument()).ToList();

            Console.WriteLine($"\n Productes amb gama afegida: \n ---------------------------");
            foreach (var product in allProducts) {
                Console.WriteLine(product.ToJson(settings));
            }
        }
        public static void UpdateCategorieFromMacBookPro(string name, string oldCat, string newCat) // EX 3e
        {
            var settings = new JsonWriterSettings { Indent = true };

            var nameFilter = Builders<BsonDocument>.Filter.Eq("name", name);
            var update = Builders<BsonDocument>.Update.Set("categories.$[cat]", newCat);
            var arrayFilter = new List<ArrayFilterDefinition>
            {
                new BsonDocumentArrayFilterDefinition<BsonDocument>(new BsonDocument("cat", oldCat))
            };
            var updateOptions = new UpdateOptions { ArrayFilters = arrayFilter };

            foreach (var product in _collection.Find(nameFilter).ToList())
            {
                Console.WriteLine($"\n {product.ToJson(settings)}");
            }

            _collection.UpdateMany(nameFilter, update, updateOptions);

            foreach (var product in _collection.Find(nameFilter).ToList())
            {
                Console.WriteLine($"\n {product.ToJson(settings)}");
            }
        }
        public static void UpdateStockForPriceBetweenXAndY(int min, int max, int stock) // EX 3f
        {
            var settings = new JsonWriterSettings { Indent = true };
            var rangeFilter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Gte("price", min),
                Builders<BsonDocument>.Filter.Lte("price", max)
                );
            var update = Builders<BsonDocument>.Update.Set("stock", stock);

            var updatedDocsInfo = _collection.UpdateMany(rangeFilter, update);
            var updatedProducts = _collection.Find(rangeFilter).ToList();

            Console.WriteLine($"\n Número de productes actualitats: {updatedDocsInfo.ModifiedCount}");
            foreach (var product in updatedProducts)
            {
                Console.WriteLine($"\n {product.ToJson(settings)}");
            }
        }
        public static void DeleteFirstCategoryFromXName(string name) // EX 4b
        {
            var nameFilter = Builders<BsonDocument>.Filter.Eq("name", name);
            var update = Builders<BsonDocument>.Update.PopFirst("categories");

            var docToUpdate = _collection.Find(nameFilter).FirstOrDefault();
            Console.WriteLine($"\n {docToUpdate}");

            _collection.UpdateOne(nameFilter, update);

            var docUpdated = _collection.Find(nameFilter).FirstOrDefault();
            Console.WriteLine($"\n {docUpdated}");
        }
        public static void DeleteByName(string name) // EX 4d
        {
            var nameFilter = Builders<BsonDocument>.Filter.Eq("name", name);

            _collection.DeleteOne(nameFilter);

            Console.WriteLine("\n Document deleted!");
        }
        public static void DeleteByCategory(string category) // EX 4f
        {
            var catFilter = Builders<BsonDocument>.Filter.Eq("categories", category);

            var docsDeleted = _collection.DeleteMany(catFilter);
            Console.WriteLine($"\n Documents eliminats: {docsDeleted.DeletedCount}");
        }
    }
}