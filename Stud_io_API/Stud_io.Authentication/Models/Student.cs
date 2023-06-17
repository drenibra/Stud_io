using Stud_io.Authentication.Models;
using Stud_io.Authentication.Models.ServiceCommunications.StudyGroup;

namespace Stud_io.Authentication.Models
{
    public class Student : AppUser
    {
        public string? ParentName { get; set; }
        public string? City { get; set; }
        public double? GPA { get; set; }
        public string? Status { get; set; }
        public int? MajorId { get; set; }
        public Major? Major { get; set; }
        public int? DormNumber { get; set; }
        public string? CustomerId { get; set; }
        public List<StudyGroupStudent>? StudyGroupStudents { get; set; }
        public List<GroupEventStudents>? GroupEventStudents { get; set; }
    }
}