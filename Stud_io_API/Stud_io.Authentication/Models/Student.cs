using Stud_io.Authentication.Models;
using Stud_io.Authentication.Models.ServiceCommunications.StudyGroup;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.Authentication.Models
{
    public class Student : AppUser
    {
        public string PersonalNo { get; set; } = null!;
        public string? CustomerId { get; set; }
        public string? ParentName { get; set; } = null!;
        public string? City { get; set; } = null!;
        public double? GPA { get; set; }
        public int? AcademicYear { get; set; }
        public int? Status { get; set; }
        public int? DormNumber { get; set; }
        [ForeignKey("Major")]
        public int? MajorId { get; set; }
        public Major? Major { get; set; }
        [ForeignKey("Faculty")]
        public int? FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public List<StudyGroupStudent>? StudyGroupStudents { get; set; }
        public List<GroupEventStudents>? GroupEventStudents { get; set; }
    }
}