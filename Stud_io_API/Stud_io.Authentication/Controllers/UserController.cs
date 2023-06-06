using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Authentication.Interfaces;
using Stud_io.Authentication.Services;
using Stud_io.Controllers;
using Stud_io.DTOs;
using Stud_io.Authentication.Models;
using System.Data;
using System.Security.Claims;

namespace Stud_io.Authentication.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _contract;
        private readonly UserManager<AppUser> _userManager;
        public UserController(IUserService contract, UserManager<AppUser> userManager)
        {
            _contract = contract;
            _userManager = userManager;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            return Ok(await _contract.GetUsers());
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AppUser>> GetUserById(string id)
        {
            return Ok(await _contract.GetUserById(id));
        }
        [HttpPut]
        [Authorize(Roles = "Admin,Student")]
        public async Task<ActionResult<Student>> UpdateStudent(Student student)
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email)) as Student;

            if (user == null)
            {
                return BadRequest("Unauthorized");
            }

            user.FirstName = student.FirstName;
            user.LastName = student.LastName;
            user.Gender = student.Gender;

            user.FathersName = student.FathersName;
            user.City = student.City;
            user.GPA = student.GPA;
            user.Status = student.Status;
            user.MajorId = student.MajorId;
            user.Major = student.Major;
            user.DormNumber = student.DormNumber;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Student successfuly updated");
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            return Ok(await _contract.DeleteUser(id));
        }

        //[HttpGet("student")]
        //[Authorize(Roles = "Admin")]
        //public async Task<ActionResult<List<Student>>> GetStudents()
        //{
        //    return await _contract.GetStudents();
        //}
        //[HttpGet("applicant/{id}")]
        //public ActionResult<AppUser> GetStudentById(string id)
        //{
        //    return Ok(_contract.GetStudentById(id));
        //}
    }
}
