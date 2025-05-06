using System.Reflection.Emit;
using cat.itb.NF3EA2_ZaportaLaura.cruds.others;
using EA1.model.peopleCollection;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace cat.itb.NF3EA2_ZaportaLaura.cruds
{
    public class PeopleCRUD : Database
    {
        private static IMongoCollection<BsonDocument> _collection { get; set; } = _database.GetCollection<BsonDocument>("people");
        public static void LoadPeopleCollection()
        {
            HelperClass.LoadCollectionArray<Person>("people", "Person");
        }
        public static void SelectFriendsByPersonName(string name) // EX 2f
        {
            var nameFilter = Builders<BsonDocument>.Filter.Eq("name", name);
            var person = _collection.Find(nameFilter).FirstOrDefault();

            var settings = new JsonWriterSettings { Indent = true };

            Console.WriteLine($"\n {person.GetElement("friends").ToJson(settings)}");
        }
        public static void DeleteTagsFromTeachers() // EX 4g
        {
            var settings = new JsonWriterSettings { Indent = true };

            var filter = Builders<BsonDocument>.Filter.Eq("randomArrayItem", "teacher");
            var update = Builders<BsonDocument>.Update.Unset("tags");

            foreach (var person in _collection.Find(filter).ToList())
            {
                Console.WriteLine($"\n{person.ToJson(settings)}");
            }

            _collection.UpdateMany(filter, update);

            foreach (var person in _collection.Find(filter).ToList())
            {
                Console.WriteLine($"\n{person.ToJson(settings)}");
            }
        }
    }
}