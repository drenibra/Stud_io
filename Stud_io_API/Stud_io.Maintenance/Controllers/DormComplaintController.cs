using Microsoft.AspNetCore.Mvc;
using Stud_io.Maintenance.DTOs;
using Stud_io.Maintenance.Service.Interfaces;

namespace Stud_io.Maintenance.Controllers
{
    [Route("studio/[controller]")]
    [ApiController]
    public class DormComplaintController : ControllerBase
    {
        private readonly IDormComplaintService _dormComplaintService;

        public DormComplaintController(IDormComplaintService dormComplaintService)
        {
            _dormComplaintService = dormComplaintService;
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult<GetDormComplaintDto>> GetDormComplaintById(int id)
        {
            return await _dormComplaintService.GetDormComplaintById(id);
        }

        [HttpGet("Page/{pageNumber}")]
        public async Task<ActionResult<List<GetDormComplaintDto>>> GetDormComplaints([FromQuery]FilterDormComplaintDto filter, int? pageNumber)
        {
            return await _dormComplaintService.GetDormComplaints(filter, pageNumber);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDormComplaint(CreateDormComplaintDto complaintDto)
        {
            if (complaintDto == null)
                return BadRequest("You can't add an empty complaint.");

            return await _dormComplaintService.CreateDormComplaint(complaintDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateComplaint(int id, UpdateDormComplaintDto complaintDto)
        {
            if (complaintDto == null)
                return BadRequest("You can't add an empty dorm complaint.");

            return await _dormComplaintService.UpdateDormComplaint(id, complaintDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDormComplaint(int id)
        {
            return await _dormComplaintService.DeleteDormComplaint(id);
        }

        [HttpPatch("{id}/{status}")]
        public async Task<ActionResult> ResolveDormComplaint(int id, bool status)
        {
            return await _dormComplaintService.ResolveDormComplaint(id, status);
        }
    }
}
