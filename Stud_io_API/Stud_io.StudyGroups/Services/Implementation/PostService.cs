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

        public async Task<ActionResult<List<PostsDto>>> GetPosts(FilterPostsDto filter)
        {
            var posts = _context.Posts
                                    .Include(x => x.Likes)
                                    .Where(x => filter.StudyGroupId == x.StudyGroupId
                                                && (filter.Title != "" ? true : x.Title.Contains(filter.Title)))
                                                //&& (filter.Author != "" ? true : x.Major.Title.Contains(filter.Major)) find a way to get the student's info
                                    .AsQueryable();

            if (posts.Count() <= 0)
                return new NotFoundObjectResult("No study groups found with these parameters.");

            var postsDto = await posts.Select(x => new PostsDto
            {
                Id = x.Id,
                StudyGroupId = x.StudyGroupId,
                Title = x.Title,
                Text = x.Text,
                DatePosted = x.DatePosted.ToShortDateString(),
                Author = "Endrit Jashari",
            }).ToListAsync();

            return new OkObjectResult(postsDto);

            //var dtoTasks = _mapper.Map<List<GetTaskDto>>(await PaginatedList<DTask>.Create(tasks, pageNumber ?? 1, 10));
        }

        public async Task<ActionResult<PostDto>> GetPostById(int id)
        {
            var post = await _context.Posts.Where(x => x.Id == id).Select(x => new PostDto
            {
                Id = x.Id,
                Title = x.Title,
                Text = x.Text,
                DatePosted = DateTime.Now.ToShortDateString(),
                StudentId = x.StudentId,
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
                StudentId = dto.StudentId,
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
