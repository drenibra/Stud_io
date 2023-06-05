using Microsoft.Extensions.Hosting;

namespace Stud_io.StudyGroups.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public int LikesAmount { get; set; }
        public List<CommentLikes> CommentLikes { get; set; }
        public string AuthorId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
