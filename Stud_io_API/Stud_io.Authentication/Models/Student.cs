using Stud_io.Authentication.Models;

namespace Stud_io.Models
{
    public class Student : AppUser
    {
        public string? FathersName { get; set; }
        public string? City { get; set; }
        public double? GPA { get; set; }
        public string? Status { get; set; }
        public int? MajorId { get; set; }
        public Major? Major { get; set; }
        public int? DormNumber { get; set; }
    }
}
