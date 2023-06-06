using System.ComponentModel.DataAnnotations;

namespace Stud_io.StudyGroups.DTOs
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileUrl { get; set; }
        public string StudentId { get; set; }
        public int StudyGroupId { get; set; }
    }

    public class CreateResourceDto
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public IFormFile File { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        public int StudyGroupId { get; set; }
    }

    public class UpdateResourceDto
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string StudentId { get; set; }
        public int StudyGroupId { get; set; }
    }
}