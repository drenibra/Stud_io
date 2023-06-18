using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stud_io.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stud_io.Authentication.Photos;
using Polly;
using Stud_io.Authentication.Models;
using Stud_io.Photos;
using Microsoft.AspNetCore.Authorization;

namespace Stud_io.Authentication.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PhotosController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Photo>> Add([FromForm] Add.Command command)
        {
            return await Mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(string id)
        {
            return await Mediator.Send(new Delete.Command { Id = id });
        }
        [HttpPost("{id}/setMain")]
        public async Task<ActionResult<Unit>> SetMain(string id)
        {
            return await Mediator.Send(new SetMain.Command { Id = id });
        }
    }
}