using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Authentication.Interfaces;
using Stud_io.Controllers;
using Stud_io.DTOs;
using Stud_io.Authentication.Models;

namespace Stud_io.Authentication.Services
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
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
        //public async Task<Student> GetStudentById(string id)
        //{
        //    var student = await _userManager.Users
        //        .OfType<Student>()
        //        .FirstOrDefaultAsync(user => user.Id.Equals(id));

        //    return student;
        //}
    }
}
