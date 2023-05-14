namespace Stud_io.Maintenance.DTOs
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public int DormNo { get; set; }
        public string MaintenantId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int FloorNo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class CreateTaskDto
    {
        public int DormNo { get; set; }
        public string MaintenantId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int FloorNo { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    public class UpdateTaskDto
    {
        public int DormNo { get; set; }
        public string MaintenantId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int FloorNo { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class FilterTaskDto
    {
        public int? DormNo { get; set; }
        public string? MaintenantId { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
