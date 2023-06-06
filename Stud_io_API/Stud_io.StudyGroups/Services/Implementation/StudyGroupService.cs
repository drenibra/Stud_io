using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Configuration;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.DTOs.ServiceCommunication;
using Stud_io.StudyGroups.DTOs.ServiceCommunication.Auth;
using Stud_io.StudyGroups.DTOs.ServiceCommunication.Auth.ApiModels;
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
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IMicroservicesRequestService _requestService;

        public StudyGroupService(ApplicationDbContext context, ICloudinaryService cloudinaryService, IMicroservicesRequestService requestService)
        {
            _context = context;
            _cloudinaryService = cloudinaryService;
            _requestService = requestService;
        }


        public async Task<ActionResult<StudyGroupDto>> GetStudyGroupById(int id)
        {
            var studyGroup = await _context.StudyGroups.Where(x => x.Id == id).Select(x => new StudyGroupDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                GroupImageUrl = x.GroupImageUrl,
                MajorId = x.MajorId,
                GroupEvents = x.GroupEvents.Select(x => new GroupEventDto
                {
                    Id = x.Id,
                    StudyGroupId = x.StudyGroupId,
                    Title = x.Title,
                    Capacity = x.Capacity,
                    DateTime = x.DateTime.ToShortDateString(),
                    Description = x.Description,
                    Duration = x.Duration,
                    Location = x.Location,
                }).ToList(),
                Posts = x.Posts.Select(x => new PostDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Text = x.Text,
                    StudyGroupId = x.StudyGroupId,
                    DatePosted = x.DatePosted.ToShortDateString(),
                    StudentId = x.StudentId,
                }).ToList(),
            }).FirstOrDefaultAsync();

            //getting a serialized response from the api and then deserializing
            //StudentByIdJds is a class that contains the mapped attributes that come from the json response
            var studyGroupStudentsSerialized = await _requestService.GetRequestAt("http://localhost:5274/api/v1/User/study-group-students/" + id);
            var studyGroupStudents = JsonSerializer.Deserialize<List<MemberStudentJds>>(studyGroupStudentsSerialized);

            var students = studyGroupStudents.Select(x => new MemberStudentDto
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

            string imageUrl = "";
            if (dto.GroupImage != null)
                imageUrl = await _cloudinaryService.UploadFile(dto.GroupImage);

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

            dbGroup.Members = studentIds.Select(x => new StudyGroupStudent()
            {
                StudentId = x
            }).ToList();

            var response = await _requestService.PostRequestAt("http://localhost:5274/api/v1/User/study-group-member?groupId=" + groupId, studentIds);

            var result = await _context.SaveChangesAsync();

            if (result >= 0)
                return new OkObjectResult("Members added succesfully!");

            return new BadRequestObjectResult("Something went wrong.");

        }

    }
}
