using Stud_io.StudyGroups.Models;

namespace Stud_io.StudyGroups.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string DatePosted { get; set; }

        //public List<Resource>? Resources { get; set; }
        //public List<Comment>? Comments { get; set; }
        //public List<PostLike>? Likes { get; set; }
        public string AuthorId { get; set; } //Student that created the post
    }

    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int StudyGroupId { get; set; }
        public string AuthorId { get; set; } //Student that created the post
    }
}
