namespace Stud_io.StudyGroups.Models
{
    public class PostLike
    {
        public int Id { get; set; }
        public string StudentId { get; set; } = null!;
        public int PostId { get; set; }
    }
}
