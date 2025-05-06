using System.Diagnostics.Metrics;
using cat.itb.NF3EA4_ZaportaLaura.cruds.others;
using EA1.model.countriesCollection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cat.itb.NF3EA4_CognomNom.cruds
{
    public class CountriesCRUD : Database
    {
        private static IMongoCollection<Country> _collection = _database.GetCollection<Country>("countries");
        public static void SelectHowManyCountriesWithLanguage(string language) // 2a
        {
            var matchFilter = Builders<Country>.Filter.Eq("Languages.Name", language);

            AggregateCountResult result = _collection.Aggregate()
                .Match(matchFilter)
                .Count()
                .Single();

            Console.WriteLine($"\n Num of countries that speak {language}: {result.Count}");
        }
        public static void SelectRegionWithMoreCountries() // 2b
        {
            var aggregate = _collection.Aggregate()
                .Group(new BsonDocument
                {
                    { "_id", "$Region" },
                    { "count", new BsonDocument("$sum", 1) }
                })
                .Sort(new BsonDocument("count", -1))
                .Limit(1)
                .ToList();
            Console.WriteLine("\n Region with more countries: {0}", aggregate[0]);
        }
        public static void SelectAllSubregionsWithNumCountries() // 2c
        {
            var aggregate = _collection.Aggregate()
                .Group(new BsonDocument
                {
                    { "_id", "$Subregion" },
                    { "count", new BsonDocument("$sum", 1) }
                })
                .Sort(new BsonDocument("count", -1))
                .ToList();

            foreach (var subregion in aggregate)
            {
                Console.WriteLine($"\n Subregion: {subregion}");
            }
        }
        public static void SelectCountryWithMoreLanguages() // 2d
        {
            var aggregate = _collection.Aggregate()
                .Unwind("Languages")
                .Group(new BsonDocument
                {
                    { "_id", "$Name" },
                    { "numLangs", new BsonDocument("$sum", 1) }
                })
                .Sort(new BsonDocument("numLangs", -1))
                .Limit(1)
            .ToList();

            Console.WriteLine($"\n Country with more languages: {aggregate[0]}");
        }
    }
}