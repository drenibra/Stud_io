using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stud_io.Authentication.DTOs.ServiceCommunication.Dormitory;
using Stud_io.Authentication.DTOs.ServiceCommunication.StudyGroup;
using Stud_io.Authentication.Interfaces;
using Stud_io.Authentication.Models;
using Stud_io.DTOs;
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

        [HttpPut("update-customer-id/{customerId}")]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> AddCustomerId(string customerId)
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email)) as Student;

            if (user == null)
                return BadRequest("Unauthorized");

            user.CustomerId = customerId;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Ok("Customer ID added.");
            return BadRequest("Customer ID failed to be added!");
        }

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
                    studentUser.ParentName = updatedStudent.ParentName;
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

        [HttpGet("students-customerId/{email}")]
        public async Task<ActionResult<string>> GetStudentsCustomerId(string email)
        {
            return await _contract.GetStudentsCustomerId(email);
        }

        [HttpPost("study-group-member")]
        public async Task<ActionResult> AddStudyGroupMember(int groupId, List<string> studentIds)
        {
            return await _contract.AddStudyGroupMembers(groupId, studentIds);
        }

        [HttpPost("group-event-student/{groupEventId}/{studentId}")]
        public async Task<ActionResult> AddGroupEventStudent(int groupEventId, string studentId)
        {
            return await _contract.AddGroupEventStudent(groupEventId, studentId);
        }

        [HttpGet("get-dormitory-students")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<DormitoryStudentDto>>> GetDormitoryStudents()
        {
            return await _contract.GetDormitoryStudents();
        }

        [HttpPut("add-dorm-number/{studentId}/{dormNumber}")]
        [Authorize(Roles = "Admin,Student")]
        public async Task<ActionResult> AddDormNumber(string studentId,int dormNumber)
        {
            var user = await _userManager.FindByIdAsync(studentId) as Student;

            if (user == null)
                return BadRequest("Unauthorized");

            user.DormNumber = dormNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Ok("Dormitory ID added.");
            return BadRequest("Dormitory ID failed to be added!");
        }

       [HttpPost("add-complaint/{studentId}/{description}")]
       public async Task<ActionResult> AddComplaint(string studentId, string description)
       {
            return await _contract.AddComplaint(studentId, description);
       }

    }
}