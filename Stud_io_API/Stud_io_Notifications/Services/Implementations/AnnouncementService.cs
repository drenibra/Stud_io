using AutoMapper;
using MongoDB.Driver;
using Notifications.Models;
using Stud_io_Notifications.Configurations;
using Stud_io_Notifications.DTOs;
using Stud_io_Notifications.Services.Implementations;
using Stud_io_Notifications.Services.Interfaces;

namespace Notifications.Services.Implementations
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IMongoCollection<Announcement> _announcement;
        private readonly IMongoCollection<Deadline> _deadline;
        private readonly IMapper _mapper;

        public AnnouncementService(INotificationsDatabaseSettings settings, IMongoClient mongoClient, IMapper mapper)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _announcement = database.GetCollection<Announcement>(settings.AnnouncementsCollectionName);
            _deadline = database.GetCollection<Deadline>(settings.DeadlinesCollectionName);
            _mapper = mapper;
        }

        public List<AnnouncementDto> GetAnnouncements()
        {
            var announcements = _mapper.Map<List<AnnouncementDto>>(_announcement.Find(announcement => true).ToList());
            
            foreach (var announcement in announcements)
            {
                var deadline = _deadline.Find(d => d.Id == announcement.DeadlineId).FirstOrDefault();
                announcement.Deadline = deadline;
            }

            return announcements;
        }

        public AnnouncementDto GetAnnouncement(string id)
        {
            var announcement = _mapper.Map<AnnouncementDto>(_announcement.Find(announcement => announcement.Id == id).FirstOrDefault());

            var deadline = _deadline.Find(d => d.Id == announcement.DeadlineId).FirstOrDefault();
            announcement.Deadline = deadline;

            return announcement;
        }

        public AnnouncementDto CreateAnnouncement(AnnouncementDto announcementDto)
        {
            var mappedAnnouncement = _mapper.Map<Announcement>(announcementDto);

            _announcement.InsertOne(mappedAnnouncement);
            return announcementDto;
        }

        public void UpdateAnnouncement(string id, UpdateAnnouncementDto updateAnnouncementDto)
        {
            var filter = Builders<Announcement>.Filter.Eq(a => a.Id, id);

            var existingAnnouncement = _announcement.Find(filter).FirstOrDefault();

            var update = Builders<Announcement>.Update
                .Set(a => a.Title, updateAnnouncementDto.Title ?? existingAnnouncement.Title)
                .Set(a => a.Description, updateAnnouncementDto.Description ?? existingAnnouncement.Description)
                .Set(a => a.DeadlineId, updateAnnouncementDto.DeadlineId ?? existingAnnouncement.DeadlineId );

            _announcement.UpdateOne(filter, update);
        }

        public void RemoveAnnouncement(string id)
        {
            _announcement.DeleteOne(announcement => announcement.Id == id);
        }
    }
}