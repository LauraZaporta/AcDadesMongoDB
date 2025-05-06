using cat.itb.NF3EA3_ZaportaLaura.cruds.others;
using cat.itb.NF3EA3_ZaportaLaura.model;
using EA1.connections;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace cat.itb.NF3EA3_ZaportaLaura.cruds
{
    public class ProductsCRUD : Database
    {
        public static void LoadProductsObjectCollection()
        {
            _database.DropCollection("products");
            var collection = _database.GetCollection<Product>("products");

            FileInfo file = new FileInfo("../../../files/products.json");

            using (StreamReader sr = file.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Product product = JsonConvert.DeserializeObject<Product>(line);
                    Console.WriteLine(product.Name);
                    collection.InsertOne(product);
                }
            }
        }
        public static void SelectNameAndPriceFromMostExpensive()
        {
            IMongoCollection<Product2> collection = _database.GetCollection<Product2>("products");

            var query = collection.AsQueryable<Product2>();

            var maxPrice = query.Select(p => p.Price).Max();

            var product = query.Where(p => p.Price == maxPrice).Single();

            Console.WriteLine($"\n Nom producte: {product.Name}" +
                $"\n Preu producte: {product.Price}");
        }
        public static void SelectStockSum()
        {
            IMongoCollection<Product2> collection = _database.GetCollection<Product2>("products");

            var query = collection.AsQueryable<Product2>();

            var stock = query.Select(p => p.Stock);
            var stockSum = stock.Sum();

            Console.WriteLine($"\n Suma de tot l'stock: {stockSum}");
        }
    }
}
