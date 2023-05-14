namespace Stud_io.Maintenance.DTOs
{
    public class GetComplaintDto
    {
        public int Id { get; set; }
        public int DormNo { get; set; }
        public string StudentId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsResolved { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class CreateComplaintDto
    {
        public int DormNo { get; set; }
        public string StudentId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsResolved { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }

    public class UpdateComplaintDto
    {
        public int DormNo { get; set; }
        public string StudentId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsResolved { get; set; }
    }
}
