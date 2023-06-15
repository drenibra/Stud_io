using Microsoft.AspNetCore.Mvc;
using Stud_io.Authentication.DTOs;
using Stud_io.DTOs;

namespace Stud_io.Authentication.Interfaces
{
    public interface IAccountController
    {
        Task<ActionResult<UserDto>> Login(LoginDto loginDto);
        Task<ActionResult<UserDto>> Register(RegisterDto registerDto);
        Task<ActionResult<UserDto>> GetCurrentUser();
        Task<ActionResult<StudentDto>> GetCurrentStudent();
        Task<ActionResult<string>> GetCurrentUserId();
        Task<IList<string>> GetRoles();
    }
}
