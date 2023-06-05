using Microsoft.AspNetCore.Mvc;
using Notifications.Models;
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

        [HttpGet("get-all-deadlines")]
        public ActionResult<List<DeadlineDto>> GetDeadlines() => _deadlineService.GetDeadlines();

        [HttpGet("get-deadline-by-id /{id}")]
        public ActionResult<DeadlineDto> GetDeadline(string id)
        {
            var deadline = _deadlineService.GetDeadline(id);

            if (deadline == null)
                return NotFound($"Deadline with Id = {id} not found");

            return deadline;
        }

        [HttpPost("add-deadline")]
        public ActionResult<DeadlineDto> PostDeadline([FromBody] DeadlineDto deadline)
        {
            if(deadline == null)
                return BadRequest("Deadline can't be null!");
            
            _deadlineService.CreateDeadline(deadline);

            return deadline;
        }


        [HttpPut("update-deadline-by-id/{id}")]
        public ActionResult PutDeadline(string id, [FromBody] UpdateDeadlineDto deadline)
        {
            var existingDeadline = _deadlineService.GetDeadline(id);

            if (existingDeadline == null)
                return NotFound($"Deadline with Id = {id} not found");

            _deadlineService.UpdateDeadline(id, deadline);

            return NoContent();
        }

        [HttpDelete("delete-deadline/{id}")]
        public ActionResult DeleteDeadline(string id)
        {
            var existingDeadline = _deadlineService.GetDeadline(id);

            if (existingDeadline == null)
                return NotFound($"Deadline with Id = {id} not found");

            _deadlineService.RemoveDeadline(id);

            return Ok($"Deadline with Id = {id} deleted");
        }
    }
}