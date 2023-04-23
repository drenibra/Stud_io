using Microsoft.AspNetCore.Mvc;
using Stud_io.Maintenance.DTOs;

namespace Stud_io.Maintenance.Service.Interfaces
{
    public interface IDormComplaintService
    {
        Task<ActionResult<List<GetDormComplaintDto>>> GetDormComplaints(FilterDormComplaintDto filter, int? pageNumber);
        Task<ActionResult<GetDormComplaintDto>> GetDormComplaintById(int id);
        Task<ActionResult> CreateDormComplaint(CreateDormComplaintDto dto);
        Task<ActionResult> UpdateDormComplaint(int id, UpdateDormComplaintDto dto);
        Task<ActionResult> DeleteDormComplaint(int id);
        Task<ActionResult> ResolveDormComplaint(int id, bool status);
        
    }
}
