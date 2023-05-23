using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.Application.Models
{
    public class Student
    {
        public int StudentId { get; set; }
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

        //Fakulteti 

        /*  public int FakultetiId { get; set; }
          public Fakulteti Fakulteti { get; set; }
        */
    }
}
