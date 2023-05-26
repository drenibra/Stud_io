using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Application.Configurations;
using Stud_io.Application.DTOs;
using Stud_io.Application.Models;
using Stud_io.Application.Services.Interfaces;

namespace Stud_io.Application.Services.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ApplicationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<ApplicationDto>>> GetApplications() =>
            _mapper.Map<List<ApplicationDto>>(await _context.Applications.ToListAsync());

        public async Task<ActionResult<ApplicationDto>> GetApplicationById(int id)
        {
            var mappedApplication = _mapper.Map<ApplicationDto>(await _context.Applications.FindAsync(id));
            return mappedApplication == null
                ? new NotFoundObjectResult("Application doesn't exist!!")
                : new OkObjectResult(mappedApplication);
        }

        public async Task<ActionResult> AddApplication(ApplicationDto applicationDto)
        {
            if (applicationDto == null)
                return new BadRequestObjectResult("Application can not be null!!");
            var mappedApplication = _mapper.Map<ApplicationForm>(applicationDto);
            await _context.Applications.AddAsync(mappedApplication);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Application added successfully!");
        }

        public async Task<ActionResult> UpdateApplication(int id, UpdateApplicationDto updateApplicationDto)
        {
            if (updateApplicationDto == null)
                return new BadRequestObjectResult("Application can not be null!!");

            var dbApplication = await _context.Applications.FindAsync(id);
            if (dbApplication == null)
                return new NotFoundObjectResult("Application doesn't exist!!");

            dbApplication.isSpecialCategory = updateApplicationDto.isSpecialCategory ?? dbApplication.isSpecialCategory;
            dbApplication.SpecialCategoryReason = updateApplicationDto.SpecialCategoryReason ?? dbApplication.SpecialCategoryReason;
            dbApplication.ApplyDate = updateApplicationDto.ApplyDate ?? dbApplication.ApplyDate;
            dbApplication.PersonalNo = updateApplicationDto.PersonalNo ?? dbApplication.PersonalNo;
            dbApplication.StudentId = updateApplicationDto.StudentId ?? dbApplication.StudentId;
            dbApplication.FileId = updateApplicationDto.FileId ?? dbApplication.FileId;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Application updated successfully!");
        }

        public async Task<ActionResult> DeleteApplication(int id)
        {
            var dbApplication = await _context.Applications.FindAsync(id);
            if (dbApplication == null)
                return new NotFoundObjectResult("Application doesn't exist!!");

            _context.Applications.Remove(dbApplication);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Application deleted successfully!");
        }
    }
}
