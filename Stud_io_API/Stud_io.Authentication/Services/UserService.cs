using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Authentication.DTOs.ServiceCommunication.StudyGroup;
using Stud_io.Authentication.Interfaces;
using Stud_io.Authentication.Models.ServiceCommunications.StudyGroup;
using Stud_io.Configuration;
using Stud_io.Controllers;
using Stud_io.DTOs;
using Stud_io.Authentication.Models;
using System.Text.RegularExpressions;

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
                Username = user.UserName,
                Email = user.Email,
                ProfileImage = user.ProfileImage,
                Gender = user.Gender,
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
        public async Task<ActionResult<List<MemberStudentDto>>> GetStudyGroupStudents(int id)
        {
            var studyGroupStudents = await _context.StudyGroupStudents
                                                    .Include(x => x.Student)
                                                    .Where(x => x.StudyGroupId == id)
                                                    .Select(x => new MemberStudentDto
                                                    {
                                                        Id = x.StudentId,
                                                        FirstName = x.Student.FirstName,
                                                        LastName = x.Student.LastName,
                                                        ProfileImage = x.Student.ProfileImage,
                                                    }).ToListAsync();

            return new OkObjectResult(studyGroupStudents);
        }

        public async Task<ActionResult<List<MemberStudentDto>>> GetGroupEventStudents(int id)
        {
            var groupEventStudents = await _context.GroupEventStudents
                                                    .Include(x => x.Student)
                                                    .Where(x => x.GroupEventId == id)
                                                    .Select(x => new MemberStudentDto
                                                    {
                                                        Id = x.StudentId,
                                                        FirstName = x.Student.FirstName,
                                                        LastName = x.Student.LastName,
                                                        ProfileImage = x.Student.ProfileImage,
                                                    }).ToListAsync();

            return new OkObjectResult(groupEventStudents);
        }

        public async Task<ActionResult> AddStudyGroupMembers(int groupId, List<string> studentIds)
        {

            List<StudyGroupStudent> studyGroupStudents = new();
            foreach (var studentId in studentIds)
            {
                studyGroupStudents.Add(new StudyGroupStudent
                {
                    StudentId = studentId,
                    StudyGroupId = groupId,
                });
            }

            await _context.StudyGroupStudents.AddRangeAsync(studyGroupStudents);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<ActionResult> AddGroupEventStudent(int groupEventId, string studentId)
        {
            var groupEventStudy = new GroupEventStudents
            {
                GroupEventId = groupEventId,
                StudentId = studentId
            };

            await _context.GroupEventStudents.AddAsync(groupEventStudy);

            await _context.SaveChangesAsync();

            return new OkResult();
        }
    }
}
