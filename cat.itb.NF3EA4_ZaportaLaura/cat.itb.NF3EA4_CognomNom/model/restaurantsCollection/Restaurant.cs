using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EA1.model.restaurantsCollection
{
    public class Restaurant
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public Address? Address { get; set; }
        public string? Borough { get; set; }
        public string? Cuisine { get; set; }
        public IList<GradeRes> Grades { get; set; }
        public string? Name { get; set; }
        public string? Restaurant_id { get; set; }
    }
}