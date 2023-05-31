using Microsoft.AspNetCore.Mvc;
using Stud_io.DTOs;
using Stud_io.StudyGroups.Models;

namespace Stud_io.StudyGroups.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<IEnumerable<UserDto>>> GetUsers();
        Task<ActionResult<UserDto>> GetUserById(string id);
        Task<IActionResult> DeleteUser(string id);

        //Task<ActionResult<IEnumerable<Student>>> GetStudents();
        //Task<Student> GetStudentById(string id);
    }
}
