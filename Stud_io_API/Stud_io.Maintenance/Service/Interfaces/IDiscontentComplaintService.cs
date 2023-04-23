using Microsoft.AspNetCore.Mvc;
using Stud_io.Maintenance.DTOs;

namespace Stud_io.Maintenance.Service.Interfaces
{
    public interface IDiscontentComplaintService
    {
        Task<ActionResult<List<GetDiscontentComplaintDto>>> GetDiscontentComplaints(FilterDiscontentComplaintDto filter, int? pageNumber);
        Task<ActionResult<GetDiscontentComplaintDto>> GetDiscontentComplaintById(int id);
        Task<ActionResult> CreateDiscontentComplaint(CreateDiscontentComplaintDto dto);
        Task<ActionResult> UpdateDiscontentComplaint(int id, UpdateDiscontentComplaintDto dto);
        Task<ActionResult> DeleteDiscontentComplaint(int id);
        Task<ActionResult> ResolveDiscontentComplaint(int id, bool status);
    }
}
