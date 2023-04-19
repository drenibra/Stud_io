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
        public async Task<ActionResult<DTaskDto>> GetTaskById(int id)
        {
            return await _taskService.GetTaskById(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<DTaskDto>>> GetTasks()
        {
            return await _taskService.GetTasks();
        }
    }
}
