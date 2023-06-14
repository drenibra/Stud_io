using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Notifications.Models;

namespace Stud_io_Notifications.DTOs
{
    public class AnnouncementDto
    {
        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string DeadlineId { get; set; } = string.Empty;

        [BsonIgnore]
        public Deadline? Deadline { get; set; }
    }

    public class UpdateAnnouncementDto
    {
        [BsonElement("title")]
        public string? Title { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? DeadlineId { get; set; }
    }

 


}