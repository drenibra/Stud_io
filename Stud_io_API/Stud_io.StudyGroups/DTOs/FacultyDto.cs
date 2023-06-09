namespace Stud_io.StudyGroups.DTOs
{
    public class FacultyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateFacultyDto
    {
        public string? Name { get; set; }
        public string? Major { get; set; }
    }
}

