using Microsoft.AspNetCore.Mvc;
using Stud_io.Authentication.ProfileSpace;

namespace Stud_io.Authentication.Interfaces
{
    public interface IProfilesController
    {
        Task<ActionResult<Profile>> GetProfile(string username);
    }
}
