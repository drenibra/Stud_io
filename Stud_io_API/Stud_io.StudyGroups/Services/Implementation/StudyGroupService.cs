using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Configuration;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.DTOs.ServiceCommunication;
using Stud_io.StudyGroups.Models;
using Stud_io.StudyGroups.Services.Interfaces;
using System.Text;

namespace Stud_io.StudyGroups.Services.Implementation
{
    public class StudyGroupService : IStudyGroupService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public StudyGroupService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private async Task<string> UploadFile(IFormFile file)
        {
            var fileUrl = "";

            if (file == null)
                return fileUrl;

            var cloudinaryConfig = new Account(
                    _configuration["CloudinarySettings:CloudName"],
                    _configuration["CloudinarySettings:ApiKey"],
                    _configuration["CloudinarySettings:ApiSecret"]
                );

            var cloudinary = new Cloudinary(cloudinaryConfig);
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            if (uploadResult.Error != null)
                return fileUrl;

            fileUrl = uploadResult.SecureUrl.ToString();
            return fileUrl;
        }

        public async Task<ActionResult<List<StudyGroupDto>>> GetStudyGroupById(int id)
        {
            var studyGroup = await _context.StudyGroups.Where(x => x.Id == id).Select(x => new StudyGroupDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                GroupImageUrl = x.GroupImageUrl,
                MajorId = x.MajorId
            }).FirstOrDefaultAsync();


            return new OkObjectResult(studyGroup);
        }

        public async Task<ActionResult> CreateStudyGroup(CreateStudyGroupDto dto)
        {
            if (dto == null)
                return new BadRequestObjectResult("You can't add an empty study group!");

            var imageUrl = await UploadFile(dto.GroupImage);

            var studyGroup = new StudyGroup
            {
                Name = dto.Name,
                Description = dto.Description,
                GroupImageUrl = imageUrl,
                MajorId = dto.MajorId,
            };

            await _context.StudyGroups.AddAsync(studyGroup);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return new OkObjectResult("Study Group created succesfully!");

            return new BadRequestObjectResult("Something wrong happened.");
        }

        public async Task<ActionResult> AddMembers(int groupId, List<string> studentIds)
        {
            var dbGroup = await _context.StudyGroups.FindAsync(groupId);
            if (dbGroup == null)
                return new NotFoundObjectResult("Study Group wasn't found");

            dbGroup.Members = studentIds.Select(x => new StudyGroupMember()
            {
                StudentId = x
            }).ToList();

            var result = await _context.SaveChangesAsync();
            if (result >= 0)
                return new OkObjectResult("Members added succesfully!");

            return new BadRequestObjectResult("Something went wrong.");

        }

    }
}
