using Microsoft.AspNetCore.Mvc;
using Stud_io.Maintenance.DTOs;
using Stud_io.Maintenance.Service.Interfaces;

namespace Stud_io.Maintenance.Controllers
{
    [Route("studio/[controller]")]
    [ApiController]
    public class SocialComplaintController : ControllerBase
    {
        private readonly ISocialComplaintService _socialComplaintService;

        public SocialComplaintController(ISocialComplaintService socialComplaintService)
        {
            _socialComplaintService = socialComplaintService;
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult<GetSocialComplaintDto>> GetSocialComplaintById(int id)
        {
            return await _socialComplaintService.GetSocialComplaintById(id);
        }

        [HttpGet("Page/{pageNumber}")]
        public async Task<ActionResult<List<GetSocialComplaintDto>>> GetSocialComplaints([FromQuery] FilterSocialComplaintDto filter, int? pageNumber)
        {
            return await _socialComplaintService.GetSocialComplaints(filter, pageNumber);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSocialComplaint(CreateSocialComplaintDto complaintDto)
        {
            if (complaintDto == null)
                return BadRequest("You can't add an empty complaint.");

            return await _socialComplaintService.CreateSocialComplaint(complaintDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSocialComplaint(int id, UpdateSocialComplaintDto complaintDto)
        {
            if (complaintDto == null)
                return BadRequest("You can't add an empty social complaint.");

            return await _socialComplaintService.UpdateSocialComplaint(id, complaintDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSocialComplaint(int id)
        {
            return await _socialComplaintService.DeleteSocialComplaint(id);
        }

        [HttpPatch("{id}/{status}")]
        public async Task<ActionResult> ResolveSocialComplaint(int id, bool status)
        {
            return await _socialComplaintService.ResolveSocialComplaint(id, status);
        }
    }
}