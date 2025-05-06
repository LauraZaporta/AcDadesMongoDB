using cat.itb.NF3EA2_ZaportaLaura.cruds.others;
using EA1.connections;
using MongoDB.Driver;

namespace cat.itb.NF3EA2_ZaportaLaura.cruds
{
    public class GeneralCRUD
    {
        public static void DropCollection(string database, string collection)
        {
            var db = MongoLocalConnection.GetDatabase(database);

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
