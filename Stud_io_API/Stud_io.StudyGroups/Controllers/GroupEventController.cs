using Microsoft.AspNetCore.Mvc;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stud_io.StudyGroups.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupEventController : ControllerBase
    {
        private readonly IGroupEventService _groupEventService;

        public GroupEventController(IGroupEventService groupEventService)
        {
            _groupEventService = groupEventService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupEventDto>> GetGroupEventById(int id)
        {
            return await _groupEventService.GetGroupEventById(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<GroupEventDto>>> GetGroupEvents([FromQuery] FilterGroupEventDto filter)
        {
            return await _groupEventService.GetGroupEvents(filter);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGroupEvent(CreateGroupEventDto dto)
        {
            return await _groupEventService.CreateGroupEvent(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGroupEvent(int id, UpdateGroupEventDto dto)
        {
            return await _groupEventService.UpdateGroupEvent(id, dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGroupEvent(int id)
        {
            return await _groupEventService.DeleteGroupEvent(id);
        }

        [HttpPost("confirm-going/{groupEventId}/{studentId}")]
        public async Task<ActionResult> AddAttendees(int groupEventId, string studentId)
        {
            return await _groupEventService.ConfirmGoing(groupEventId, studentId);
        }

        //[HttpPost("remove-attendees/{groupEventId}")]
        //public async Task<ActionResult> RemoveAttendees(int groupEventId, List<string> studentIds)
        //{
        //    return await _groupEventService.RemoveAttendees(groupEventId, studentIds);
        //}
    }
}
