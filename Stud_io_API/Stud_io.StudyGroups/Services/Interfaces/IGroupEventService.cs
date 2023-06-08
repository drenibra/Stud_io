using Microsoft.AspNetCore.Mvc;
using Stud_io.StudyGroups.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stud_io.StudyGroups.Services.Interfaces
{
    public interface IGroupEventService
    {
        Task<ActionResult<GroupEventDto>> GetGroupEventById(int id);
        Task<ActionResult<List<GroupEventDto>>> GetGroupEvents(FilterGroupEventDto filter);
        Task<ActionResult> CreateGroupEvent(CreateGroupEventDto dto);
        Task<ActionResult> UpdateGroupEvent(int id, UpdateGroupEventDto dto);
        Task<ActionResult> DeleteGroupEvent(int id);
        Task<ActionResult> AddAttendees(int groupEventId, List<string> studentIds);
        //Task<ActionResult> RemoveAttendees(int groupEventId, List<string> studentIds);
    }
}
