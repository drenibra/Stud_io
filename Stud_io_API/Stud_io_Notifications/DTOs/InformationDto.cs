using MongoDB.Bson.Serialization.Attributes;

namespace Stud_io_Notifications.DTOs
{
    public class InformationDto
    {
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("link")]
        public string Link { get; set; } = string.Empty;
    }
    public class UpdateInformationDto
    {
        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("link")]
        public string? Link { get; set; }
    }
}
