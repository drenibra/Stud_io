namespace Stud_io.Authentication.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Major> Majors { get; set; }
    }
}