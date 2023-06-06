using Microsoft.AspNetCore.Mvc;
using Stud_io.DTOs;
using Stud_io.Authentication.Models;

namespace Stud_io.Authentication.Interfaces
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
