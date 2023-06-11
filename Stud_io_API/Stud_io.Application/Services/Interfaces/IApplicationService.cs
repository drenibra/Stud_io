using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.DTOs;

namespace Stud_io.Application.Services.Interfaces
{
    public interface IApplicationService
    {
        public Task<ActionResult<List<ApplicationDto>>> GetApplications();
        //public Task<ActionResult<ApplicationDto>> GetApplicationById(int id);
        Task<ActionResult<ApplicationDetailsDto>> GetApplicationById(int id);
        public Task<ActionResult> AddApplication(ApplicationDto applicationDto);
        public Task<ActionResult> UpdateApplication(int id, UpdateApplicationDto updateApplicationDto);
        public Task<ActionResult> DeleteApplication(int id);
    }
}
