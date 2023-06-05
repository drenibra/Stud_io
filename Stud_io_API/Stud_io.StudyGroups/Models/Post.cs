using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.StudyGroups.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DatePosted { get; set; }

        public List<Resource>? Resources { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<PostLike>? Likes { get; set; }
        public string AuthorId { get; set; } //Student that created the post
        [ForeignKey("StudyGroup")]
        public int StudyGroupId { get; set; }
        public StudyGroup StudyGroup { get; set; }
    }
}