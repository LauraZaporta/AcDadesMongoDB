using cat.itb.NF3EA4_ZaportaLaura.cruds.others;
using EA1.model.countriesCollection;
using EA1.model.restaurantsCollection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cat.itb.NF3EA4_CognomNom.cruds
{
    public class RestaurantsCRUD : Database
    {
        private static IMongoCollection<Restaurant> _collection = _database.GetCollection<Restaurant>("restaurants");

        public static void SelectNumTimesEachScore() // 2e
        {
            var aggregate = _collection.Aggregate()
                .Unwind("Grades")
                .Group(new BsonDocument
                {
                    { "_id", "$Grades.Score" },
                    { "count", new BsonDocument("$sum", 1) }
                })
                .Sort(new BsonDocument("count", -1))
                .ToList();

            foreach (var score in aggregate)
            {
                Console.WriteLine($"\n Score: {score["_id"]} \t Count: {score["count"]}");
            }
        }
        public static void SelectZipcodesFromBoroughs() // 2f
        {
            var aggregate = _collection.Aggregate()
                .Group(new BsonDocument
                {
                    { "_id", "$Borough" },
                    { "zipcodes", new BsonDocument("$addToSet", "$Address.Zipcode") }
                })
                .ToList();

            foreach (var borough in aggregate)
            {
                Console.WriteLine($"\n Borough: {borough}");
            }
        }
        public static void SelectByCuisineDesc() // 2g
        {
            var aggregate = _collection.Aggregate()
                .Group(new BsonDocument
                {
                    { "_id", "$Cuisine" },
                    { "cuisineCount", new BsonDocument("$sum", 1) }
                })
                .Sort(new BsonDocument("count", -1))
                .ToList();

            foreach (var cuisine in aggregate)
            {
                Console.WriteLine($"\n Cuisine: {cuisine}");
            }
        }
        public static void SelectNumGrades() // 2h
        {
            var aggregate = _collection.Aggregate()
                .Project(new BsonDocument
                {
                    { "Name", 1 },
                    { "_id", 0 },
                    { "gradeCount", new BsonDocument("$size", "$Grades") }
                })
                .ToList();

            foreach (var grade in aggregate)
            {
                Console.WriteLine($"\n Grades: {grade}");
            }
        }
        public static void SelectCuisinesByBorough() // 2i
        {
            var aggregate = _collection.Aggregate()
                .Group(new BsonDocument
                {
                    { "_id", "$Borough" },
                    { "cuisineType", new BsonDocument("$addToSet", "$Cuisine") }
                })
                .ToList();
            foreach (var borough in aggregate)
            {
                Console.WriteLine($"\n Borough: {borough}");
            }
        }
        public static void SelectMaxScoreForEach() // 2j
        {
            var aggregate = _collection.Aggregate()
                .Unwind("Grades")
                .Group(new BsonDocument
                {
                    { "_id", "$Name" },
                    { "maxScore", new BsonDocument("$max", "$Grades.Score")}
                })
                .ToList();
            foreach(var restaurant in aggregate)
            {
                Console.WriteLine($"\n Restaurant: {restaurant}");
            }
        }
    }
}
