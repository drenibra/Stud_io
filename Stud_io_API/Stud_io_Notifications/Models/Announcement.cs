using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Notifications.Models
{
    public class Announcement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("title")]
        public string Title { get; set; } = String.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = String.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string DeadlineId { get; set; } = String.Empty;

        [BsonIgnore]
        public Deadline Deadline { get; set; }
    }
}