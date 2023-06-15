using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.DTOs;
using Stud_io.Application.Services.Interfaces;
using System.Security.Claims;
using Stud_io.Authentication.Models;
using Stud_io.Authentication.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace Stud_io.Application.Controllers
{
    [Route("studio/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IServiceProvider _serviceProvider;
        public ApplicationController(IApplicationService applicationService, UserManager<AppUser> userManager, IServiceProvider serviceProvider)
        {
            _applicationService = applicationService;
            _userManager = userManager;
            _serviceProvider = serviceProvider;
        }

        [HttpGet("GetApplications")]
        public async Task<ActionResult<List<ApplicationDto>>> GetApplications()
        {
            return await _applicationService.GetApplications();
        }

        [HttpGet("GetApplicationById/{id}")]
        public async Task<ActionResult<ApplicationDetailsDto>> GetApplicationById(int id)
        {
            return await _applicationService.GetApplicationById(id);
        }
        [HttpPost("AddApplication")]
        public async Task<ActionResult> AddApplication(ApplicationDto applicationDto)
        {
            //var student = await _userManager.GetUserAsync(HttpContext.User) as Student;
            var userManager2 = _serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var student = await userManager2.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email)) as Student;
            var user = new StudentDto
            {
                PersonalNo = student.PersonalNo,
                ParentName = student.ParentName,
                City = student.City,
                GPA = student.GPA,
                AcademicYear = student.AcademicYear,
                Status = student.Status,
                DormNumber = student.DormNumber,
                MajorId = student.MajorId,
                Major = student.Major,
                FacultyId = student.FacultyId,
                Faculty = student.Faculty,
            };
            return await _applicationService.AddApplication(applicationDto, user);
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
