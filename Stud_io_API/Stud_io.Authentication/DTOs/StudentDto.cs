using Stud_io.Authentication.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.Authentication.DTOs
{
    public class StudentDto
    {
        public string? PersonalNo { get; set; }
        public string? ParentName { get; set; }
        public string? City { get; set; }
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
    }
}
