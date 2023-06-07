using Stud_io_Notifications.DTOs;

namespace Stud_io_Notifications.Services.Interfaces
{
    public interface IAnnouncementService
    {
        List<AnnouncementDto> GetAnnouncements();
        AnnouncementDto GetAnnouncement(string id);
        AnnouncementDto CreateAnnouncement(AnnouncementDto announcementDto);
        void UpdateAnnouncement(string id, UpdateAnnouncementDto updateAnnouncementDto);
        void RemoveAnnouncement(string id);
    }
}