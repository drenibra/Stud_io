using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stud_io.Maintenance.Configurations;
using Stud_io.Maintenance.DTOs;
using Stud_io.Maintenance.Service.Interfaces;

namespace Stud_io.Maintenance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DTaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public DTaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTaskDto>> GetTaskById(int id)
        {
            return await _taskService.GetTaskById(id);
        }

        [HttpGet("dorm/{dormNo}/{pageNumber}")]
        public async Task<ActionResult<List<GetTaskDto>>> GetDormTasks(int dormNo, int? pageNumber)
        {
            return await _taskService.GetDormTasks(dormNo, pageNumber);
        }

        [HttpGet("maintenant/{maintenantId}/{pageNumber}")]
        public async Task<ActionResult<List<GetTaskDto>>> GetMaintenantsTasks(string maintenantId, int? pageNumber)
        {
            return await _taskService.GetMaintenantsTasks(maintenantId, pageNumber);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(CreateTaskDto taskDto)
        {
            if (taskDto == null)
                return BadRequest("You can't add an empty task.");

            return await _taskService.CreateTask(taskDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(int id, UpdateTaskDto taskDto)
        {
            if (taskDto == null)
                return BadRequest("You can't add an empty task.");

            return await _taskService.UpdateTask(id, taskDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            return await _taskService.DeleteTask(id);
        }

        [HttpPatch("{id}/{status}")]
        public async Task<ActionResult> ChangeTaskStatus(int id, bool status)
        {
            return await _taskService.ChangeTaskStatus(id, status);
        }
    }
}
