using System.Reflection;

namespace Stud_io.Maintenance.Models
{
    public class DTask
    {
        public int Id { get; set; }
        public int DormNo { get; set; }
        public string MaintenantId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int FloorNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
