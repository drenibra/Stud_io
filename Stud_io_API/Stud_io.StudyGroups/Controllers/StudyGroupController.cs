using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.Services.Interfaces;

namespace Stud_io.StudyGroups.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyGroupController : ControllerBase
    {
        private readonly IStudyGroupService _studyGroupService;

        public StudyGroupController(IStudyGroupService studyGroupService)
        {
            _studyGroupService = studyGroupService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudyGroupDto>> GetStudyGroupById(int id)
        {
            return await _studyGroupService.GetStudyGroupById(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<StudyGroupsDto>>> GetStudyGroups([FromQuery] FilterStudyGroupDto filter)
        {
            return await _studyGroupService.GetStudyGroups(filter);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudyGroup(CreateStudyGroupDto dto)
        {
            return await _studyGroupService.CreateStudyGroup(dto);
        }

        [HttpPut("add-members/{groupId}")]
        public async Task<ActionResult> AddMembers(int groupId, List<string> studentIds)
        {
            return await _studyGroupService.AddMembers(groupId, studentIds);
        }

        [HttpGet("studio-gpt/{query}")]
        public async Task<IActionResult> StudioGPT(string query)
        {
            return await _studyGroupService.StudioGPT(query);
        }


    }
}
