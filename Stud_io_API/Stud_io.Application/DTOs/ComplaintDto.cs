namespace Stud_io.Application.DTOs
{
    public class ComplaintDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Token { get; set; }
    }

    public class UpdateComplaintDto
    {
        public string? Description { get; set; }
        public string? StudentsId { get; set; }
    }

}
