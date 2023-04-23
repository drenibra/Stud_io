namespace Stud_io.Models
{
    public class Major
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}