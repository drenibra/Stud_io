using Stud_io.StudyGroups.Models;

namespace Stud_io.StudyGroups.DTOs
{
    public class StudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }
        public string FathersName { get; set; }
        public string City { get; set; }
        public double GPA { get; set; }
        public string Status { get; set; }
        public int MajorId { get; set; }
        public Major Major { get; set; }
        public int DormNumber { get; set; }
    }
}
