namespace Stud_io.Application.DTOs
{
    public class FacultyDto
    {
        public string FacultyName { get; set; }
        public string Major { get; set; }
    }

    public class UpdateFacultyDto
    {
        public string? FacultyName { get; set; }
        public string? Major { get; set; }
    }
}

