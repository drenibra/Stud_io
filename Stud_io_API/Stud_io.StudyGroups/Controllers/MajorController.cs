using Microsoft.AspNetCore.Mvc;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.Services;
using Stud_io.StudyGroups.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stud_io.StudyGroups.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MajorController : ControllerBase
    {
        private readonly IMajorService _majorService;

        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MajorDto>>> GetAllMajors()
        {
            var majors = await _majorService.GetAllMajors();
            return majors;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MajorDto>> GetMajorById(int id)
        {
            var major = await _majorService.GetMajorById(id);
            return major;
        }

        [HttpPost]
        public async Task<ActionResult<MajorDto>> CreateMajor(CreateMajorDto createDto)
        {
            var major = await _majorService.CreateMajor(createDto);
            return major;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MajorDto>> UpdateMajor(int id, UpdateMajorDto updateDto)
        {
            var major = await _majorService.UpdateMajor(id, updateDto);
            return major;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteMajor(int id)
        {
            var result = await _majorService.DeleteMajor(id);
            return result;
        }
    }
}
