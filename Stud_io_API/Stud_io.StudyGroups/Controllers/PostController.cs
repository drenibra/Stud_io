﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.Services.Interfaces;

namespace Stud_io.StudyGroups.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostsDto>>> GetPosts([FromQuery] FilterPostsDto filter)
        {
            return await _postService.GetPosts(filter);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPostById(int id)
        {
            return await _postService.GetPostById(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost(CreatePostDto dto)
        {
            return await _postService.CreatePost(dto);
        }

        [HttpPost("likeOrUnlike")]
        public async Task<ActionResult> LikeOrUnlike(string studentId, int postId)
        {
            return await _postService.LikeOrUnlike(studentId, postId);
        }

        [HttpPost("create-comment")]
        public async Task<ActionResult> CreateComment(CreateCommentDto dto)
        {
            return await _postService.CreateComment(dto);
        }

        [HttpDelete("delete-comment/{commentId}")]
        public async Task<ActionResult> DeleteComment(int commentId)
        {
            return await _postService.DeleteComment(commentId);
        }
    }
}
