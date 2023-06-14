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
            var studyGroup = await _context.StudyGroups
                .Where(x => x.Id == id)
                .Select(x => new StudyGroupDto
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
                        DateStart = x.DateTimeStart.ToShortDateString(),
                        TimeStart = x.DateTimeEnd.ToShortTimeString(),
                        DateEnd = x.DateTimeEnd.ToShortDateString(),
                        TimeEnd = x.DateTimeEnd.ToShortTimeString(),
                        Description = x.Description,
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

            if (studyGroup == null)
                return new NotFoundObjectResult("No study groups.");

            //getting a serialized response from the api and then deserializing
            //StudentByIdJds is a class that contains the mapped attributes that come from the json response
            var studyGroupStudentsSerialized = await _requestService.GetRequestAt("http://localhost:5274/api/v1/User/study-group-students/" + id);
            var studyGroupStudents = JsonSerializer.Deserialize<List<MemberStudentJds>>(studyGroupStudentsSerialized);

            var students = studyGroupStudents.Select(x => new MemberStudentDto
            {
                Id = x.id,
                FirstName = x.firstName,
                LastName = x.lastName,
                ProfileImage = x.profileImage
            }).ToList();

            studyGroup.Students = students;

            return new OkObjectResult(studyGroup);
        }

        public async Task<ActionResult<List<StudyGroupsDto>>> GetStudyGroups(FilterStudyGroupDto filter)
        {
            var studyGroups = _context.StudyGroups
                                    .Include(x => x.Major)
                                    .Where(x => (filter.Name != "" ? true : x.Name.Contains(filter.Name))
                                                && (filter.Major != "" ? true : x.Major.Title.Contains(filter.Major))
                                                && x.Major.FacultyId == (filter.FacultyId ?? filter.FacultyId))
                                    .AsQueryable();

            if (studyGroups.Count() <= 0)
                return new NotFoundObjectResult("No study groups found with these parameters.");

            var studyGroupDto = await studyGroups.Select(x => new StudyGroupsDto
            {
                Id = x.Id,
                Description = x.Description,
                GroupImageUrl = x.GroupImageUrl,
                Major = x.Major.Title,
                Name = x.Name,
            }).ToListAsync();

            return new OkObjectResult(studyGroupDto);

            //var dtoTasks = _mapper.Map<List<GetTaskDto>>(await PaginatedList<DTask>.Create(tasks, pageNumber ?? 1, 10));
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
            var dbGroup = await _context.StudyGroups
                                        .Include(x => x.Members)
                                        .Where(x => x.Id == groupId)
                                        .FirstOrDefaultAsync();
            if (dbGroup == null)
                return new NotFoundObjectResult("Study Group wasn't found");

            if (dbGroup.Members.Any(x => studentIds.Contains(x.StudentId)))
                return new BadRequestObjectResult("Members already exist in the group.");

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
