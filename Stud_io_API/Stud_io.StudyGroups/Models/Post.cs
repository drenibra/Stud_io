using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.StudyGroups.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DatePosted { get; set; }
        public List<Resource>? Resource { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<PostLike>? Likes { get; set; }
        [ForeignKey("Author")]
        public string AuthorId { get; set; }
        public Student Author { get; set; }
        [ForeignKey("StudyGroup")]
        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; }
    }
}