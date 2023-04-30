using Microsoft.AspNetCore.Mvc;
using Stud_io_Notifications.DTOs;


namespace Stud_io_Notifications.Services.Interfaces
{
    public interface IAnnouncementService
    {
        public Task<ActionResult<List<AnnouncementDTO>>> GetAllAnnouncements();
        public Task<ActionResult<AnnouncementDTO>> GetAnnouncementById(int id);
        public Task<ActionResult> AddAnnouncement(AnnouncementDTO announcementDto);
        public Task<ActionResult> UpdateAnnouncement(int id, UpdateAnnouncementDTO updateAnnouncementDTO);
        public Task<ActionResult> DeleteAnnouncement(int id);
    }
}
