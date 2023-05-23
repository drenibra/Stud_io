namespace Stud_io.Application.DTOs
{
    public class StudentDto
    {
        public string PersonalNo { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string ParentName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string City { get; set; } = null!;
        public double GPA { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; } = null!;
        public char Gender { get; set; }
        public int AcademicYear { get; set; }
        public string Status { get; set; } = null!;
        public string ProfilePicUrl { get; set; } = null!;
    }
    public class UpdateStudentDto
    {
        public string? PersonalNo { get; set; }
        public string? Name { get; set; }
        public string? ParentName { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public double? GPA { get; set; }
        public int? PhoneNo { get; set; }
        public string? Email { get; set; }
        public char? Gender { get; set; }
        public int? AcademicYear { get; set; }
        public string? Status { get; set; }
        public string? ProfilePicUrl { get; set; }
    }
}
