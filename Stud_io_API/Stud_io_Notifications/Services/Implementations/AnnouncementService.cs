using MongoDB.Driver;
using Notifications.Models;
using Stud_io_Notifications.Configurations;
using Stud_io_Notifications.Services.Interfaces;

namespace Notifications.Services.Implementations
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IMongoCollection<Announcement> _announcement;
        private readonly IMongoCollection<Deadline> _deadline;

        public AnnouncementService(INotificationsDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _announcement = database.GetCollection<Announcement>(settings.AnnouncementsCollectionName);
            _deadline = database.GetCollection<Deadline>(settings.DeadlinesCollectionName);
        }

        public Announcement CreateAnnouncement(Announcement announcement)
        {
            _announcement.InsertOne(announcement);
            return announcement;
        }

        public List<Announcement> GetAnnouncements()
        {
            var announcements = _announcement.Find(announcement => true).ToList();

            foreach (var announcement in announcements)
            {
                var deadline = _deadline.Find(d => d.Id == announcement.DeadlineId).FirstOrDefault();
                announcement.Deadline = deadline;
            }

            return announcements;
        }

        public Announcement GetAnnouncement(string id)
        {
            return _announcement.Find(announcement => announcement.Id == id).FirstOrDefault();
        }

        public void RemoveAnnouncement(string id)
        {
            _announcement.DeleteOne(announcement => announcement.Id == id);
        }

        public void UpdateAnnouncement(string id, Announcement announcement)
        {
            _announcement.ReplaceOne(announcement => announcement.Id == id, announcement);
        }
    }
}