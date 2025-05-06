using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace cat.itb.NF3EA4_CognomNom.model
{
    [Serializable]
    public class Product
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Picture { get; set; }
        public List<string> Categories { get; set; }
    }
}