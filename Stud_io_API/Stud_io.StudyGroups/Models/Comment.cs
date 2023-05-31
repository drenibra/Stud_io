using Microsoft.Extensions.Hosting;

namespace Stud_io.StudyGroups.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public List<Student> Likes { get; set; }
        public string AuthorId { get; set; }
        public Student Student { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
