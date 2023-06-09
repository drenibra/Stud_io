using Microsoft.AspNetCore.Mvc;
using Stud_io.StudyGroups.DTOs;

namespace Stud_io.StudyGroups.Services.Interfaces
{
    public interface IPostService
    {
        Task<ActionResult> CreatePost(CreatePostDto dto);
        Task<ActionResult<PostDto>> GetPostById(int id);
        Task<ActionResult<List<PostsDto>>> GetPosts(FilterPostsDto filter);
        Task<ActionResult> LikeOrUnlike(string studentId, int postId);
        Task<ActionResult> CreateComment(CreateCommentDto dto);
        Task<ActionResult> DeleteComment(int commentId);
        }
}
