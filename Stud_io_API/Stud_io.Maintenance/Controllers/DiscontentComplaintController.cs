using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stud_io.Maintenance.DTOs;
using Stud_io.Maintenance.Service.Interfaces;

namespace Stud_io.Maintenance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscontentComplaintController : ControllerBase
    {
        private readonly IDiscontentComplaintService _socialComplaintService;

        public DiscontentComplaintController(IDiscontentComplaintService socialComplaintService)
        {
            _socialComplaintService = socialComplaintService;
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult<GetDiscontentComplaintDto>> GetDiscontentComplaintById(int id)
        {
            return await _socialComplaintService.GetDiscontentComplaintById(id);
        }

        [HttpGet("Page/{pageNumber}")]
        public async Task<ActionResult<List<GetDiscontentComplaintDto>>> GetDiscontentComplaints([FromQuery] FilterDiscontentComplaintDto filter, int? pageNumber)
        {
            return await _socialComplaintService.GetDiscontentComplaints(filter, pageNumber);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDiscontentComplaint(CreateDiscontentComplaintDto complaintDto)
        {
            if (complaintDto == null)
                return BadRequest("You can't add an empty complaint.");

            return await _socialComplaintService.CreateDiscontentComplaint(complaintDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDiscontentComplaint(int id, UpdateDiscontentComplaintDto complaintDto)
        {
            if (complaintDto == null)
                return BadRequest("You can't add an empty discontent complaint.");

            return await _socialComplaintService.UpdateDiscontentComplaint(id, complaintDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiscontentComplaint(int id)
        {
            return await _socialComplaintService.DeleteDiscontentComplaint(id);
        }

        [HttpPatch("{id}/{status}")]
        public async Task<ActionResult> ResolveDiscontentComplaint(int id, bool status)
        {
            return await _socialComplaintService.ResolveDiscontentComplaint(id, status);
        }
    }
}
