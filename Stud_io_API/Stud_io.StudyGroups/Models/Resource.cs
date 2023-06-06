using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.StudyGroups.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileUrl { get; set; }
        public string StudentId { get; set; }
        [ForeignKey("StudyGroupId")]
        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; }
    }
}