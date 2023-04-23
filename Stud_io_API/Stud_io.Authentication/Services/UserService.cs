using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Authentication.Interfaces;
using Stud_io.Configuration;
using Stud_io.Controllers;
using Stud_io.DTOs;
using Stud_io.Models;
using System.Security.Claims;

namespace Stud_io.Authentication.Services
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AccountController _accountController;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, AccountController accountController, IMapper mapper)
        {
            _userManager = userManager;
            _accountController = accountController;
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
            return _accountController.CreateUserObject(user);
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
