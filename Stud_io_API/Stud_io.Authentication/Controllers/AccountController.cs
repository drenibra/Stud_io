using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Authentication.DTOs;
using Stud_io.DTOs;
using Stud_io.Extensions;
using Stud_io.Authentication.Models;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using Stud_io.Authentication.Interfaces;
using Stud_io.Authentication.ProfileSpace;

namespace Stud_io.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IProfilesController _profilesController;
        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            TokenService tokenService
         )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.Include(p => p.Photos).FirstOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                return CreateUserObject(user);
            };

            return Unauthorized();
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                return BadRequest("Email taken!");
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
            {
                return BadRequest("Username taken!");
            }

            var user = new Student
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Gender = registerDto.Gender,
                Email = registerDto.Email,
                UserName = registerDto.Username
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
                return CreateUserObject(user);
            }

            return BadRequest("Problem registering user!");
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.Users.Include(p => p.Photos).FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

            return CreateUserObject(user);
        }
        [Authorize]
        [HttpGet("student")]
        public async Task<ActionResult<StudentDto>> GetCurrentStudent()
        {
            var student = await _userManager.Users.Include(p => p.Photos).FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email)) as Student;
            return new StudentDto
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Username = student.UserName,
                Email = student.Email,
                CustomerId = student.CustomerId,
                Gender = student.Gender,
                ParentName = student.ParentName,
                City = student.City,
                GPA = student.GPA,
                Status = student.Status,
                MajorId = student.MajorId,
                Major = student.Major,
                DormNumber = student.DormNumber,
                Image = student?.Photos?.FirstOrDefault(p => p.IsMain)?.Url,
                ImageId = student?.Photos?.FirstOrDefault(p => p.IsMain)?.Id,
            };
        }
        [Authorize]
        [HttpGet("currentId")]
        public async Task<ActionResult<string>> GetCurrentUserId()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            return Ok(user.Id);
        }
        [Authorize]
        [HttpGet("roles")]
        public async Task<IList<string>> GetRoles()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
            var roles = _userManager.GetRolesAsync(user).Result;

            return roles;
        }
        private UserDto CreateUserObject(AppUser user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName,
                Email = user.Email,
                Gender = user.Gender,
                Image = user?.Photos?.FirstOrDefault(x => x.IsMain)?.Url,
                ImageId = user?.Photos?.FirstOrDefault(x => x.IsMain)?.Id,
            };
        }
    }
}
