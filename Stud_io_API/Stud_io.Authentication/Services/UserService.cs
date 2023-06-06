using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Authentication.DTOs.ServiceCommunication;
using Stud_io.Authentication.Interfaces;
using Stud_io.Configuration;
using Stud_io.Controllers;
using Stud_io.DTOs;
using Stud_io.Models;

namespace Stud_io.Authentication.Services
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public UserService(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            return Ok(userDtos);
        }
        public async Task<ActionResult<UserDto>> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName
            };
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return NoContent();
        }

        //public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        //{
        //    var recruiters = await _userManager.Users.ToListAsync();
        //    return recruiters.OfType<Student>().ToList();
        //}
        public async Task<Student> GetStudentById(string id)
        {
            var student = await _userManager.Users
                .OfType<Student>()
                .FirstOrDefaultAsync(user => user.Id.Equals(id));

            return student;
        }

        //gets all students from a certain study group that is on the study group microservice
        public async Task<ActionResult<List<StudyGroupStudentDto>>> GetStudyGroupStudents(int id)
        {
            var studyGroupStudents = await _context.StudyGroupStudents
                                                    .Include(x => x.Student)
                                                    .Where(x => x.StudyGroupId == id)
                                                    .Select(x => new StudyGroupStudentDto
                                                    {
                                                        Id = x.StudentId,
                                                        FirstName = x.Student.FirstName,
                                                        LastName = x.Student.LastName,
                                                    }).ToListAsync();

            return new OkObjectResult(studyGroupStudents);
        }
    }
}
