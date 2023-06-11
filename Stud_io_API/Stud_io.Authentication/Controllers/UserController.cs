using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Authentication.DTOs.ServiceCommunication.StudyGroup;
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
        //[HttpPut]
        //[Authorize(Roles = "Admin,Student")]
        //public async Task<ActionResult<Student>> UpdateStudent(Student student)
        //{
        //    var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email)) as Student;

        //    if (user == null)
        //    {
        //        return BadRequest("Unauthorized");
        //    }

        //    user.FirstName = student.FirstName;
        //    user.LastName = student.LastName;
        //    user.Gender = student.Gender;

        //    user.FathersName = student.FathersName;
        //    user.City = student.City;
        //    user.GPA = student.GPA;
        //    user.Status = student.Status;
        //    user.MajorId = student.MajorId;
        //    user.Major = student.Major;
        //    user.DormNumber = student.DormNumber;

        //    var result = await _userManager.UpdateAsync(user);

        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result.Errors);
        //    }

        //    return Ok("Student successfuly updated");
        //}
        [HttpPut]
        [Authorize(Roles = "Admin,Student")]
        public async Task<ActionResult<Student>> UpdateStudent(Student updatedStudent)
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            if (user == null)
            {
                return BadRequest("Unauthorized");
            }

            var isStudent = await _userManager.IsInRoleAsync(user, "Student");
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (isStudent || isAdmin)
            {
                user.FirstName = updatedStudent.FirstName;
                user.LastName = updatedStudent.LastName;
                user.Gender = updatedStudent.Gender;
                user.UserName = updatedStudent.UserName;

                if (isStudent)
                {
                    var studentUser = user as Student;
                    studentUser.FathersName = updatedStudent.FathersName;
                    studentUser.City = updatedStudent.City;
                    studentUser.GPA = updatedStudent.GPA;
                    studentUser.Status = updatedStudent.Status;
                    studentUser.MajorId = updatedStudent.MajorId;
                    studentUser.Major = updatedStudent.Major;
                    studentUser.DormNumber = updatedStudent.DormNumber;

                    var studentResult = await _userManager.UpdateAsync(studentUser);

                    if (!studentResult.Succeeded)
                    {
                        return BadRequest(studentResult.Errors);
                    }
                }

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                return Ok("User successfully updated");
            }
            else
            {
                return BadRequest("Unauthorized");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            return Ok(await _contract.DeleteUser(id));
        }

        [HttpGet("study-group-students/{id}")]
        public async Task<ActionResult<List<MemberStudentDto>>> GetStudyGroupStudents(int id)
        {
            return await _contract.GetStudyGroupStudents(id);
        }

        [HttpGet("group-event-students/{id}")]
        public async Task<ActionResult<List<MemberStudentDto>>> GetGroupEventStudents(int id)
        {
            return await _contract.GetGroupEventStudents(id);
        }

        [HttpPost("study-group-member")]
        public async Task<ActionResult> AddStudyGroupMember(int groupId, List<string> studentIds)
        {
            return await _contract.AddStudyGroupMembers(groupId, studentIds);
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
