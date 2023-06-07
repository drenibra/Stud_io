using Microsoft.AspNetCore.Mvc;
using Stud_io_Notifications.DTOs;
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
        public ActionResult<List<AnnouncementDto>> GetAnnouncements() => _announcementService.GetAnnouncements();

        [HttpGet("get-announcement-by-id /{id}")]
        public ActionResult<AnnouncementDto> GetAnnouncement(string id)
        {
            var announcement = _announcementService.GetAnnouncement(id);

            if (announcement == null)
                return NotFound($"Announcement with Id = {id} not found");

            return announcement;
        }

        [HttpPost("add-announcement")]
        public ActionResult<AnnouncementDto> CreateAnnouncement(AnnouncementDto announcement)
        {
            var deadline = _deadlineService.GetDeadline(announcement.DeadlineId);

            if (deadline == null)
            {
                return NotFound("Deadline not found");
            }

            _announcementService.CreateAnnouncement(announcement);

            return announcement;
        }

        [HttpPut("update-announcement-by-id/{id}")]
        public ActionResult PutAnnouncement(string id, UpdateAnnouncementDto updateAnnouncementDto)
        {
            var existingAnnouncement = _announcementService.GetAnnouncement(id);

            if (existingAnnouncement == null)
                return NotFound($"Announcement with Id = {id} not found");

            _announcementService.UpdateAnnouncement(id, updateAnnouncementDto);

            return NoContent();
        }

        [HttpDelete("delete-announcement/{id}")]
        public ActionResult DeleteAnnouncement(string id)
        {
            var existingAnnouncement = _announcementService.GetAnnouncement(id);

            if (existingAnnouncement == null)
                return NotFound($"Deadline with Id = {id} not found");

            _announcementService.RemoveAnnouncement(id);

            return Ok($"Announcement with Id = {id} deleted");
        }
    }
}