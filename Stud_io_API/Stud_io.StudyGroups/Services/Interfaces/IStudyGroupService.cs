using Microsoft.AspNetCore.Mvc;
using Stud_io.StudyGroups.DTOs;

namespace Stud_io.StudyGroups.Services.Interfaces
{
    public interface IStudyGroupService
    {
        Task<ActionResult<StudyGroupDto>> GetStudyGroupById(int id);
        Task<ActionResult> CreateStudyGroup(CreateStudyGroupDto dto);
        Task<ActionResult> AddMembers(int groupId, List<string> studentIds);
    }
}
