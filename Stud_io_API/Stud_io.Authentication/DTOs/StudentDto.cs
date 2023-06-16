using Stud_io.Authentication.Models;

namespace Stud_io.Authentication.DTOs
{
    public class StudentDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? CustomerId { get; set; }
        public string? Username { get; set; }
        public char? Gender { get; set; }
        public string? Image { get; set; }
        public string? ParentName { get; set; }
        public string? City { get; set; }
        public double? GPA { get; set; }
        public string? Status { get; set; }
        public int? MajorId { get; set; }
        public Major? Major { get; set; }
        public int? DormNumber { get; set; }
    }
}
