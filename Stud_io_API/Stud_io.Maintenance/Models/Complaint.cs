namespace Stud_io.Maintenance.Models
{
    public abstract class Complaint
    {
        public int Id { get; set; }
        public int DormNo { get; set; }
        public string StudentId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsResolved { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
