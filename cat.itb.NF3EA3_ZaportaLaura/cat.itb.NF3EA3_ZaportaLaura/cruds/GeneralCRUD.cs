using cat.itb.NF3EA3_ZaportaLaura.model;
using EA1.connections;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cat.itb.NF3EA3_ZaportaLaura.cruds
{
    public class GeneralCRUD
    {
        public static void DropCollection(string database, string collection)
        {
            var db = MongoLocalConnection.GetDatabase(database);
            var collectionBeforeDelete = db.GetCollection<BsonDocument>("products");

            int numDocs = collectionBeforeDelete.AsQueryable().Count();

            Console.WriteLine($"\n Number of documents of the collection: {numDocs}");

            db.DropCollection(collection);
            Console.WriteLine($"\n Collection deleted: {collection}");

            var colList = db.ListCollections().ToList();
            Console.WriteLine("\n The list of collection on this database is: ");
            foreach (var col in colList)
            {
                Console.WriteLine(col);
            }
        }
    }
}