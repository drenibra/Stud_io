namespace Stud_io.StudyGroups.DTOs
{
    public class MajorDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
    }

    public class CreateMajorDto
    {
        public string Title { get; set; }
        public int FacultyId { get; set; }
    }

    public class UpdateMajorDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FacultyId { get; set; }
    }
}