using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Notifications.Models
{
    public class Deadline
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [BsonElement("openDate")]

        public DateTime OpenDate { get; set; }

        [DataType(DataType.Date)]
        [BsonElement("closedDate")]
        public DateTime ClosedDate { get; set; }
    }
}