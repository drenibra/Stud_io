using Microsoft.AspNetCore.Mvc;
using Stud_io_Notifications.DTOs;
using Stud_io_Notifications.Models;
using Stud_io_Notifications.Services.Interfaces;

namespace Stud_io_Notifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost("add-announcement")]
        public async Task<ActionResult> AddAnnouncement(AnnouncementDTO announcement)
        {
            return await _announcementService.AddAnnouncement(announcement);
        }

        [HttpGet("get-all-announcements")]
        public async Task<ActionResult<List<AnnouncementDTO>>> GetAll()
        {
            return await _announcementService.GetAllAnnouncements();

        }

        [HttpGet("get-announcement-by-id /{id}")]
        public async Task<ActionResult<AnnouncementDTO>> GetAnnouncementById(int id)
        {
            return await _announcementService.GetAnnouncementById(id);

        }

        [HttpPut("update-by-id/{id}")]
        public async Task<ActionResult> UpdateAnnouncement(int id, UpdateAnnouncementDTO announcement)
        {
            return await _announcementService.UpdateAnnouncement(id, announcement);

        }

        [HttpDelete("delete-announcement/{id}")]
        public async Task<ActionResult> DeleteAnnouncement(int id)
        {
            return await _announcementService.DeleteAnnouncement(id);
        }
    }
}
