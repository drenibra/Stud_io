using Stud_io.StudyGroups.Models;

namespace Stud_io.StudyGroups.DTOs
{

    public class FilterPostsDto
    {
        public int StudyGroupId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; } //Student that created the post
    }

    public class PostDto
    {
        public int Id { get; set; }
        public int StudyGroupId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string DatePosted { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }

        //public List<Resource>? Resources { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<PostLike>? Likes { get; set; }
    }
        

    public class PostsDto
    {
        public int Id { get; set; }
        public int StudyGroupId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string DatePosted { get; set; }
        public int LikesCount { get; set; }
        public string Author { get; set; } //Student that created the post
    }

    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int StudyGroupId { get; set; }
        public string StudentId { get; set; } //Student that created the post
    }
}
