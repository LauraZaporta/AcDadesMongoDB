using EA1.connections;
using MongoDB.Driver;

namespace cat.itb.NF3EA3_ZaportaLaura.cruds.others
{
    public class Database
    {
        protected static IMongoDatabase _database { get; set; } = MongoLocalConnection.GetDatabase("itb");
    }
}