namespace Stud_io.StudyGroups.Models
{
    public class CommentLikes
    {
        public int Id { get; set; }
        public string StudentId { get; set; } = null!;
        public int CommentId { get; set; }
    }
}
