using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Notifications.Models
{
    public class Information
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("link")]
        public string Link { get; set; } = String.Empty;
    }
}
