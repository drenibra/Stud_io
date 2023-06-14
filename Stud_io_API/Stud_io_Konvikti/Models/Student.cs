namespace Stud_io.Dormitory.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string? ProfileImage { get; set; }
        public string? City { get; set; }
        public double? GPA { get; set; }
        public string? Status { get; set; }
        public Boolean isAccepted { get; set; }
        public int? DormNumber { get; set; }
    }
}
