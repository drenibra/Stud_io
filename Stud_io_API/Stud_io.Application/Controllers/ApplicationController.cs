using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.DTOs;
using Stud_io.Application.Services.Interfaces;

namespace Stud_io.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet("GetApplications")]
        public async Task<ActionResult<List<ApplicationDto>>> GetApplications()
        {
            return await _applicationService.GetApplications();
        }

        [HttpGet("GetApplicationById/{id}")]
        public async Task<ActionResult<ApplicationDto>> GetApplicationById(int id)
        {
            return await _applicationService.GetApplicationById(id);
        }


        [HttpPost("AddApplication")]
        public async Task<ActionResult> AddApplication(ApplicationDto applicationDto)
        {
            return await _applicationService.AddApplication(applicationDto);
        }

        [HttpPut("UpdateApplication")]
        public async Task<ActionResult> UpdateApplication(int id, UpdateApplicationDto updateApplicationDto)
        {
            return await _applicationService.UpdateApplication(id, updateApplicationDto);
        }

        [HttpDelete("DeleteApplication/{id}")]
        public async Task<ActionResult> DeleteApplication(int id)
        {
            return await _applicationService.DeleteApplication(id);
        }
    }
}
