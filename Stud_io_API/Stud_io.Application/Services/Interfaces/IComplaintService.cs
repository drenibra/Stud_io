using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.DTOs;

namespace Stud_io.Application.Services.Interfaces
{
    public interface IComplaintService
    {
        public Task<ActionResult<List<ComplaintDto>>> GetComplaints();
        public Task<ActionResult<ComplaintDetailsDto>> GetComplaintById (int id);
        public Task<ActionResult> AddComplaint(ComplaintDto facultyDto);
        public Task<ActionResult> UpdateComplaint(int id, UpdateComplaintDto updateFacultyDto);
        public Task<ActionResult> DeleteComplaint(int id);
    }
}
