namespace Stud_io.Maintenance.DTOs
{
    public class DTaskDto
    {
        public int Id { get; set; }
        public int DormNo { get; set; }
        public string MaintenantId { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int FloorNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
