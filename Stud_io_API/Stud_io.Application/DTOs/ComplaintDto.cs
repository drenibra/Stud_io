namespace Stud_io.Application.DTOs
{
    public class ComplaintDto
    {
        public string Description { get; set; }
    }

    public class UpdateComplaintDto
    {
        public string? Description { get; set; }
        public string? StudentsId { get; set; }
    }

    public class ComplaintDetailsDto
    {
        public string Description { get; set; }  
        public string StudentsId { get; set; }
        public StudentDetailsDto StudentDetails { get; set; }

    }
}
