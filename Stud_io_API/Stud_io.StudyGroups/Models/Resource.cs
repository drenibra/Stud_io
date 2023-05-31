using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.StudyGroups.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileContents { get; set; }
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public Student Author { get; set; }
        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; }
    }
}