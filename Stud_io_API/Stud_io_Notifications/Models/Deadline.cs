using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Notifications.Models
{
    public class Deadline
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("openDate")]
        //[DataType(DataType.Date)]
        public DateTime OpenDate { get; set; }

        [BsonElement("closedDate")]
        //[DataType(DataType.Date)]
        public DateTime ClosedDate { get; set; }
    }
}