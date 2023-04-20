using Microsoft.AspNetCore.Mvc;
using Stud_io_Notifications.DTOs;
using Stud_io_Notifications.Services.Interfaces;

namespace Stud_io_Notifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeadlineController : ControllerBase
    {
        private readonly IDeadlineService _deadlineService;

        public DeadlineController(IDeadlineService deadlineService)
        {
            _deadlineService = deadlineService;
        }

        [HttpPost("add-deadline")]
        public async Task AddDeadline(DeadlineDTO deadline)
        {
            await _deadlineService.AddDeadline(deadline);
        }

        [HttpGet("get-all-deadlines")]
        public async Task<ActionResult<List<DeadlineDTO>>> GetAll()
        {
            return await _deadlineService.GetAllDeadlines();

        }

        [HttpGet("get-deadline-by-id /{id}")]
        public async Task<ActionResult<DeadlineDTO>> GetDeadlineById(int id)
        {
            return await _deadlineService.GetDeadlineById(id);

        }

        [HttpPut("update-deadline-by-id/{id}")]
        public async Task<ActionResult> UpdateDeadline(int id, UpdateDeadlineDTO deadline)
        {
            return await _deadlineService.UpdateDeadline(id, deadline);

        }

        [HttpDelete("delete-deadline/{id}")]
        public async Task<ActionResult> DeleteDeadline(int id)
        {
            return await _deadlineService.DeleteDeadline(id);
        }
    }
}
