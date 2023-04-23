using Microsoft.AspNetCore.Mvc;
using Stud_io.Maintenance.DTOs;

namespace Stud_io.Maintenance.Service.Interfaces
{
    public interface ISocialComplaintService
    {
        Task<ActionResult<List<GetSocialComplaintDto>>> GetSocialComplaints(FilterSocialComplaintDto filter, int? pageNumber);
        Task<ActionResult<GetSocialComplaintDto>> GetSocialComplaintById(int id);
        Task<ActionResult> CreateSocialComplaint(CreateSocialComplaintDto dto);
        Task<ActionResult> UpdateSocialComplaint(int id, UpdateSocialComplaintDto dto);
        Task<ActionResult> DeleteSocialComplaint(int id);
        Task<ActionResult> ResolveSocialComplaint(int id, bool status);
    }
}
