using Notifications.Models;


namespace Stud_io_Notifications.Services.Interfaces
{
    public interface IAnnouncementService
    {
        List<Announcement> GetAnnouncements();
        Announcement GetAnnouncement(string id);
        Announcement CreateAnnouncement(Announcement announcement);
        void UpdateAnnouncement(string id, Announcement announcement);
        void RemoveAnnouncement(string id);
    }
}