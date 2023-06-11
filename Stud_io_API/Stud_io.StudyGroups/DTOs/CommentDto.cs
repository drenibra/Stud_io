using Stud_io.StudyGroups.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_io.StudyGroups.DTOs
{
    public class CommentDto
    {
            public int Id { get; set; }
            public string Text { get; set; }
            public string DateTime { get; set; }
            public int LikesAmount { get; set; }
            //public List<CommentLikes> CommentLikes { get; set; }
            public string Author { get; set; }
    }

    public class CreateCommentDto
    {
        public int PostId { get; set; }
        public string StudentId { get; set; }
        public string Text { get; set; }
    }
}
