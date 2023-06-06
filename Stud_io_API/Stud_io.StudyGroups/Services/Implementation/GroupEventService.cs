using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Configuration;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.DTOs.ServiceCommunication.Auth;
using Stud_io.StudyGroups.DTOs.ServiceCommunication.Auth.ApiModels;
using Stud_io.StudyGroups.Models;
using Stud_io.StudyGroups.Models.ServiceCommunication.Authentication;
using Stud_io.StudyGroups.Services.Interfaces;
using System.Text.Json;

namespace Stud_io.StudyGroups.Services.Implementation
{
    public class GroupEventService : IGroupEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMicroservicesRequestService _requestService;

        public GroupEventService(ApplicationDbContext context, IMicroservicesRequestService requestService)
        {
            _context = context;
            _requestService = requestService;
        }

        public async Task<ActionResult<GroupEventDto>> GetGroupEventById(int id)
        {
            var groupEvent = await _context.GroupEvents.FindAsync(id);

            if (groupEvent == null)
                return new NotFoundResult();

            var groupEventDto = new GroupEventDto
            {
                Id = groupEvent.Id,
                Title = groupEvent.Title,
                Description = groupEvent.Description,
                Location = groupEvent.Location,
                Capacity = groupEvent.Capacity,
                DateTime = groupEvent.DateTime.ToShortDateString(),
                Duration = groupEvent.Duration,
                StudyGroupId = groupEvent.StudyGroupId
            };

            //getting a serialized response from the api and then deserializing
            //StudentByIdJds is a class that contains the mapped attributes that come from the json response
            var groupEventStudentsSerialized = await _requestService.GetRequestAt("http://localhost:5274/api/v1/User/group-event-students/" + id);
            var groupEventStudents = JsonSerializer.Deserialize<List<MemberStudentJds>>(groupEventStudentsSerialized);

            var students = groupEventStudents.Select(x => new MemberStudentDto
            {
                Id = x.id,
                FirstName = x.firstName,
                LastName = x.lastName,
            }).ToList();

            groupEventDto.Attendees = students;

            return groupEventDto;
        }

        public async Task<ActionResult<IEnumerable<GroupEventDto>>> GetAllGroupEvents()
        {
            var groupEvents = await _context.GroupEvents.ToListAsync();

            var groupEventDtos = groupEvents.Select(groupEvent => new GroupEventDto
            {
                Id = groupEvent.Id,
                Title = groupEvent.Title,
                Description = groupEvent.Description,
                Location = groupEvent.Location,
                Capacity = groupEvent.Capacity,
                DateTime = groupEvent.DateTime.ToShortDateString(),
                Duration = groupEvent.Duration,
                StudyGroupId = groupEvent.StudyGroupId
            }).ToList();

            return groupEventDtos;
        }

        public async Task<ActionResult> CreateGroupEvent(CreateGroupEventDto dto)
        {
            if (dto == null)
                return new BadRequestObjectResult("You must provide valid data for creating a group event.");

            var groupEvent = new GroupEvent
            {
                Title = dto.Title,
                Description = dto.Description,
                Location = dto.Location,
                Capacity = dto.Capacity,
                DateTime = dto.DateTime,
                Duration = dto.Duration,
                StudyGroupId = dto.StudyGroupId
            };

            await _context.GroupEvents.AddAsync(groupEvent);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Group event created successfully!");
        }

        public async Task<ActionResult> UpdateGroupEvent(int id, UpdateGroupEventDto dto)
        {
            var groupEvent = await _context.GroupEvents.FindAsync(id);

            if (groupEvent == null)
                return new NotFoundResult();

            groupEvent.Title = dto.Title;
            groupEvent.Description = dto.Description;
            groupEvent.Location = dto.Location;
            groupEvent.Capacity = dto.Capacity;
            groupEvent.DateTime = dto.DateTime;
            groupEvent.Duration = dto.Duration;
            groupEvent.StudyGroupId = dto.StudyGroupId;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Group event updated successfully!");
        }

        public async Task<ActionResult> DeleteGroupEvent(int id)
        {
            var groupEvent = await _context.GroupEvents.FindAsync(id);

            if (groupEvent == null)
                return new NotFoundResult();

            _context.GroupEvents.Remove(groupEvent);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Group event deleted successfully!");
        }

        public async Task<ActionResult> AddAttendees(int groupEventId, List<string> studentIds)
        {
            var groupEvent = await _context.GroupEvents.FindAsync(groupEventId);

            if (groupEvent == null)
                return new NotFoundObjectResult("Group Event wasn't found.");

            groupEvent.Attendees = studentIds.Select(x => new GroupEventStudents()
            {
                StudentId = x
            }).ToList();


            var result = await _context.SaveChangesAsync();
            if (result >= 0)
                return new OkObjectResult("Attendees added succesfully!");

            return new OkObjectResult("Attendees added successfully!");
        }

        //public async Task<ActionResult> RemoveAttendees(int groupEventId, List<string> studentIds)
        //{
        //    var groupEvent = await _context.GroupEvents.FindAsync(groupEventId);

        //    if (groupEvent == null)
        //        return new NotFoundResult();

        //    var attendeesToRemove = await _context.GroupEventStudents
        //        .Where(a => a.GroupEventId == groupEventId && studentIds.Contains(a.StudentId))
        //        .ToListAsync();

        //    _context.GroupEventStudents.RemoveRange(attendeesToRemove);
        //    await _context.SaveChangesAsync();

        //    return new OkObjectResult("Attendees removed successfully!");
        //}
    }
}
