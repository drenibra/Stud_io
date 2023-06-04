using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Notifications.Models
{
    public class Deadline
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("openDate")]
        public DateTime OpenDate { get; set; }

        [BsonElement("closedDate")]
        public DateTime ClosedDate { get; set; }
    }
}