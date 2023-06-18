using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.StudyGroups.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public int LikesAmount { get; set; }
        public List<CommentLikes> CommentLikes { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
