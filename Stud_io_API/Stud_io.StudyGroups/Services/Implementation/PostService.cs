using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Configuration;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.Models;
using Stud_io.StudyGroups.Services.Interfaces;

namespace Stud_io.StudyGroups.Services.Implementation
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<PostDto>> GetPostById(int id)
        {
            var post = await _context.Posts.Where(x => x.Id == id).Select(x => new PostDto
            {
                Id = x.Id,
                Title = x.Title,
                Text = x.Text,
                DatePosted = DateTime.Now.ToShortDateString(),
                AuthorId = x.AuthorId,
            }).FirstOrDefaultAsync();

            return new OkObjectResult(post);
        }

        public async Task<ActionResult> CreatePost(CreatePostDto dto)
        {
            if (dto == null)
            {
                return new BadRequestObjectResult("You can't add an empty post!");
            }

            var post = new Post
            {
                Title = dto.Title,
                Text = dto.Text,
                DatePosted = DateTime.Now,
                AuthorId = dto.AuthorId,
                StudyGroupId = dto.StudyGroupId,
            };

            await _context.Posts.AddAsync(post);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return new OkObjectResult("Post was created succesfully");

            return new BadRequestObjectResult("Something wrong happened.");
        }



    }
}
