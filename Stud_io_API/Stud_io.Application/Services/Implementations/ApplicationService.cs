using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
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
        private readonly IConfiguration _configuration;

        public ApplicationService(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
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

        // check if the student has already applied
        public async Task<bool> HasStudentAlreadyApplied(string personalNumber)
        {
            var existingApplication = await _context.Applications.FirstOrDefaultAsync(a => a.PersonalNo == personalNumber);
            return existingApplication != null;
        }

        public async Task<ActionResult> AddApplication(ApplicationDto applicationDto)
        {
            StudentService _studentService = new(_context, _mapper);
            if (applicationDto == null)
                return new BadRequestObjectResult("Application can not be null!!");

            bool hasAlreadyApplied = await HasStudentAlreadyApplied(applicationDto.PersonalNo);
            if (hasAlreadyApplied)
            {
                return new BadRequestObjectResult("You have already applied!");
            }

            var imageUrl = "";

            if (applicationDto.Document != null)
            {
                var cloudinaryConfig = new Account(
                    _configuration["CloudinarySettings:CloudName"],
                    _configuration["CloudinarySettings:ApiKey"],
                    _configuration["CloudinarySettings:ApiSecret"]
                );
                var cloudinary = new Cloudinary(cloudinaryConfig);

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(applicationDto.Document.FileName, applicationDto.Document.OpenReadStream())
                };

                var uploadResult = await cloudinary.UploadAsync(uploadParams);
                if (uploadResult.Error != null)
                    return new BadRequestObjectResult(uploadResult.Error.Message);

                imageUrl = uploadResult.SecureUrl.ToString();

            };

            var application = new ApplicationForm()
            {
                ApplyDate = DateTime.Now,
                PersonalNo = applicationDto.PersonalNo,
                isSpecialCategory = applicationDto.IsSpecialCategory,
                SpecialCategoryReason = applicationDto.SpecialCategoryReason,
                StudentId = applicationDto.StudentId,
                FileUrl = imageUrl,
            };

            await _context.Applications.AddAsync(application);
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
            //dbApplication.FileUrl = updateApplicationDto.FileUrl ?? dbApplication.FileUrl;

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
