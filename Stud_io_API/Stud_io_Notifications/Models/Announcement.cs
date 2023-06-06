using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Notifications.Models
{
    public class Announcement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string DeadlineId { get; set; } = string.Empty;

        [BsonIgnore]
        public Deadline Deadline { get; set; }
    }
}