using Microsoft.AspNetCore.Mvc;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.Services.Interfaces;

namespace Stud_io.StudyGroups.Controllers
{
    [Route("")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet("GetFaculties")]
        public async Task<ActionResult<List<FacultyDto>>> GetFaculties()
        {
            return await _facultyService.GetFaculties();
        }

        [HttpGet("GetFacultyById/{id}")]
        public async Task<ActionResult<FacultyDto>> GetFacultyById(int id)
        {
            return await _facultyService.GetFacultyById(id);
        }


        [HttpPost("AddFaculty")]
        public async Task<ActionResult> AddFaculty(FacultyDto facultyDto)
        {
            return await _facultyService.AddFaculty(facultyDto);
        }

        [HttpPut("UpdateFaculty")]
        public async Task<ActionResult> UpdateFaculty(int id, UpdateFacultyDto facultyDto)
        {
            return await _facultyService.UpdateFaculty(id, facultyDto);
        }

        [HttpDelete("DeleteFaculty/{id}")]
        public async Task<ActionResult> DeleteFaculty(int id)
        {
            return await _facultyService.DeleteFaculty(id);
        }
    }
}
