using Microsoft.AspNetCore.Mvc;
using Notifications.Models;
using Stud_io_Notifications.Services.Interfaces;

namespace Notifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IDeadlineService _deadlineService;

        public AnnouncementController(IAnnouncementService announcementService, IDeadlineService deadlineService)
        {
            _announcementService = announcementService;
            _deadlineService = deadlineService;
        }

        [HttpGet("get-all-announcements")]
        public ActionResult<List<Announcement>> GetAnnouncements() => _announcementService.GetAnnouncements();

        /*[HttpGet("get-announcement-by-id /{id}")]
        public ActionResult<Announcement> GetAnnouncement(string id)
        {
            var announcement = _announcementService.GetAnnouncement(id);

            if (announcement == null)
                return NotFound($"Announcement with Id = {id} not found");

            // Retrieve the associated deadline
            var deadline = _deadlineService.GetDeadline(announcement.DeadlineId);

            if (deadline == null)
                return NotFound($"Deadline associated with the announcement not found");

            // Assign the retrieved deadline to the announcement
            announcement.Deadline = deadline;

            return announcement;
        }*/

        /*[HttpPost("add-announcement")]
        public IActionResult CreateAnnouncement([FromBody] Announcement announcement)
        {
            var deadline = _deadlineService.GetDeadline(announcement.DeadlineId);

            if (deadline == null)
            {
                return NotFound("Deadline not found");
            }

            // Assign the retrieved deadline to the announcement
            announcement.Deadline = deadline;

            // Create the announcement
            var createdAnnouncement = _announcementService.CreateAnnouncement(announcement);

            return CreatedAtAction(nameof(GetAnnouncements), new { id = createdAnnouncement.Id }, createdAnnouncement);
        }*/

        [HttpPut("update-announcement-by-id/{id}")]
        public ActionResult PutAnnouncement(string id, [FromBody] Announcement announcement)
        {
            var existingAnnouncement = _announcementService.GetAnnouncement(id);

            if (existingAnnouncement == null)
                return NotFound($"Announcement with Id = {id} not found");

            _announcementService.UpdateAnnouncement(id, announcement);

            return NoContent();
        }

        [HttpDelete("delete-announcement/{id}")]
        public ActionResult DeleteAnnouncement(string id)
        {
            var existingAnnouncement = _announcementService.GetAnnouncement(id);

            if (existingAnnouncement == null)
                return NotFound($"Deadline with Id = {id} not found");

            _announcementService.RemoveAnnouncement(existingAnnouncement.Id);

            return Ok($"Announcement with Id = {id} deleted");
        }
    }
}