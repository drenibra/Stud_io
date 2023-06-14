using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Stud_io_Notifications.DTOs
{
    public class DeadlineDto
    {
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;


        [BsonElement("openDate")]
        [DataType(DataType.Date)]
        public DateTime OpenDate { get; set; }

        [BsonElement("closedDate")]
        [DataType(DataType.Date)]
        public DateTime ClosedDate { get; set; }
    }

    public class UpdateDeadlineDto
    {
        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("openDate")]
        [DataType(DataType.Date)]
        public DateTime? OpenDate { get; set; }

        [BsonElement("closedDate")]
        [DataType(DataType.Date)]
        public DateTime? ClosedDate { get; set; }
    }
}