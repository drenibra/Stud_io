using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Configuration;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.DTOs.ServiceCommunication;
using Stud_io.StudyGroups.Models;
using Stud_io.StudyGroups.Models.ServiceCommunication.Authentication;
using Stud_io.StudyGroups.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Stud_io.StudyGroups.Services.Implementation
{
    public class StudyGroupService : IStudyGroupService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public StudyGroupService(ApplicationDbContext context, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
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

        private async Task<string> CommunicateWithUser(string uri)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var authentication = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJkZTI4ODI4My1lZTI5LTRiNzMtYjk1Ny1iZjIwNmNmMWE0YjQiLCJ1bmlxdWVfbmFtZSI6InJyZXppIiwiZW1haWwiOiJyaDUyNzQxQHVidC11bmkubmV0Iiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjg1ODI4Njc0LCJleHAiOjE2ODY0MzM0NzQsImlhdCI6MTY4NTgyODY3NH0.45JHMBXwjfQcxAuWr1BYCZLogzmgFB2oVFdi6ThArKY");
            httpClient.DefaultRequestHeaders.Authorization = authentication;

            var response = await httpClient.GetAsync(uri);
            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        public async Task<ActionResult<StudyGroupDto>> GetStudyGroupById(int id)
        {
            var studyGroup = await _context.StudyGroups.Where(x => x.Id == id).Select(x => new StudyGroupDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                GroupImageUrl = x.GroupImageUrl,
                MajorId = x.MajorId
            }).FirstOrDefaultAsync();

            //getting a serialized response from the api and then deserializing
            var studyGroupStudentsSerialized = await CommunicateWithUser("http://localhost:5274/api/v1/User/study-group-students/" + id);
            var studyGroupStudents = JsonSerializer.Deserialize<List<Models.ServiceCommunication.Authentication.StudyGroupStudent>>(studyGroupStudentsSerialized);

            var students = studyGroupStudents.Select(x => new GroupStudyStudentDto
            {
                Id = x.id,
                FirstName = x.firstName,
                LastName = x.lastName,
            }).ToList();

            studyGroup.Students = students;

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

            dbGroup.Members = studentIds.Select(x => new Models.StudyGroupStudent()
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
