using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stud_io.Authentication.ProfileSpace;

namespace Stud_io.Authentication.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProfilesController : BaseController
    {
        [HttpGet("{username}")]
        public async Task<ActionResult<Profile>> GetProfile(string username)
        {
            return await (Mediator.Send(new Details.Query { Username = username }));
        }
    }
}
