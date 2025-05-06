using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA1.connections;
using MongoDB.Driver;

namespace cat.itb.NF3EA2_ZaportaLaura.cruds.others
{
    public class Database
    {
        protected static IMongoDatabase _database { get; set; } = MongoLocalConnection.GetDatabase("itb");
    }
}
