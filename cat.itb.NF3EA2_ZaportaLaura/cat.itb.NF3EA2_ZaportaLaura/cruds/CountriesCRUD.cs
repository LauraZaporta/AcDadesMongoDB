using Amazon.Util.Internal;
using cat.itb.NF3EA2_ZaportaLaura.cruds.others;
using EA1.connections;
using EA1.model.countriesCollection;
using EA1.model.productsCollection;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace cat.itb.NF3EA2_ZaportaLaura.cruds
{
    public class CountriesCRUD : Database
    {
        private static IMongoCollection<BsonDocument> _collection {  get; set; } = _database.GetCollection<BsonDocument>("countries");

        public static void LoadCountriesCollection() // EX 1
        {
            HelperClass.LoadCollectionArray<Country>("countries", "Country");
        }
        public static void SelectPopulationByCountries(string region) // EX 2a
        {
            var regionFilter = Builders<BsonDocument>.Filter.Eq("region", region);
            var countries = _collection.Find(regionFilter).ToList();

            foreach (var country in countries)
            {
                Console.WriteLine($"\n {country.GetElement("name")}" +
                    $"\n {country.GetElement("population")}\n");
            }
        }
        public static void SelectCapitalPopulationAndLatln(string countryName) // EX 2b
        {
            var nameFilter = Builders<BsonDocument>.Filter.Eq("name", countryName);
            var country = _collection.Find(nameFilter).FirstOrDefault();

            Console.WriteLine($"\n {country.GetElement("name")}" +
                $"\n {country.GetElement("capital")}" +
                $"\n {country.GetElement("population")}" +
                $"\n {country.GetElement("latlng")}");
        }
        public static void UpdateAddCallingCodeToCountry(string country, int callingCode) // EX 3g
        {
            var settings = new JsonWriterSettings { Indent = true };
            var nameFilter = Builders<BsonDocument>.Filter.Eq("name", country);
            var update = Builders<BsonDocument>.Update.Push("callingCodes", callingCode);

            Console.WriteLine($"\n {_collection.Find(nameFilter).FirstOrDefault().ToJson(settings)}");

            _collection.UpdateOne(nameFilter, update);

            Console.WriteLine($"\n {_collection.Find(nameFilter).FirstOrDefault().ToJson(settings)}");
        }
        public static void DeleteIfThereIsXLanguage(string language) // EX 4f
        {
            var langFilter = Builders<BsonDocument>.Filter.Eq("languages.name", language);

            var docsDeleted = _collection.DeleteMany(langFilter);
            Console.WriteLine($"\n Documents eliminats: {docsDeleted.DeletedCount}");
        }
    }
}