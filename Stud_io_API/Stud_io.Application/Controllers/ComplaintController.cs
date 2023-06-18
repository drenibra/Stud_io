using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.DTOs;
using Stud_io.Application.Services.Interfaces;

namespace Stud_io.Application.Controllers
{
    [Route("")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpGet("GetComplaints")]
        public async Task<ActionResult<List<ComplaintDto>>> GetComplaints()
        {
            return await _complaintService.GetComplaints();
        }

        [HttpGet("GetComplaintById/{id}")]
        public async Task<ActionResult<ComplaintDto>> GetComplaintById(int id)
        {
            return await _complaintService.GetComplaintById(id);
        }


        [HttpPost("AddComplaint")]
        public async Task<ActionResult> AddComplaint(ComplaintDto complaintDto)
        {
            return await _complaintService.AddComplaint(complaintDto);
        }

        [HttpPut("UpdateComplaint")]
        public async Task<ActionResult> UpdateComplaint(int id, UpdateComplaintDto complaintDto)
        {
            return await _complaintService.UpdateComplaint(id, complaintDto);
        }

        [HttpDelete("DeleteComplaint/{id}")]
        public async Task<ActionResult> DeleteComplaint(int id)
        {
            return await _complaintService.DeleteComplaint(id);
        }
    }
}

