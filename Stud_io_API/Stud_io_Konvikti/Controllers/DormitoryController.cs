using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stud_io_Dormitory.DTOs;
using Stud_io_Dormitory.Services.Interfaces;

namespace Stud_io_Dormitory.Controllers
{
    [Route("")]
    [ApiController]
    public class DormitoryController : ControllerBase
    {
        private readonly IDormitoryService _dormitoryService;

        public DormitoryController(IDormitoryService dormitoryService)
        {
            _dormitoryService = dormitoryService;
        }

        [HttpGet("GetDormitories")]
        public async Task<ActionResult<List<DormitoryDto>>> GetDormitories()
        {
            return await _dormitoryService.GetDormitories();
        }

        [HttpGet("GetDormitoryById/{id}")]
        public async Task<ActionResult<DormitoryDto>> GetDormitoryById(int id)
        {
            return await _dormitoryService.GetDormitoryById(id);
        }


        [HttpPost("AddDormitory")]
        public async Task<ActionResult> AddDormitory(DormitoryDto dormitoryDto)
        {
            return await _dormitoryService.AddDormitory(dormitoryDto);
        }

        [HttpPut("UpdateDormitory")]
        public async Task<ActionResult> UpdateDormitory(int id, UpdateDormitoryDto dormitoryDto)
        {
            return await _dormitoryService.UpdateDormitory(id, dormitoryDto);
        }

        [HttpDelete("DeleteDormitory/{id}")]
        public async Task<ActionResult> DeleteDormitory(int id)
        {
            return await _dormitoryService.DeleteDormitory(id);
        }

        [HttpPost("AssignStudentsToDormitories")]
        public async Task<ActionResult> AssignStudentsToDormitories()
        {
            try
            {
                await _dormitoryService.AssignStudentsToDormitories();
                return Ok("Students assigned to dormitories successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while assigning students to dormitories: {ex.Message}");
            }
        }
    }
}

