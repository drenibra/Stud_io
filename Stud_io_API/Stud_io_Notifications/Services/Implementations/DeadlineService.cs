using AutoMapper;
using MongoDB.Driver;
using Notifications.Models;
using Stud_io_Notifications.Configurations;
using Stud_io_Notifications.DTOs;
using Stud_io_Notifications.Services.Interfaces;

namespace Stud_io_Notifications.Services.Implementations
{
    public class DeadlineService : IDeadlineService
    {
        private readonly IMongoCollection<Deadline> _deadline;
        private readonly IMapper _mapper;

        public DeadlineService(INotificationsDatabaseSettings settings, IMongoClient mongoClient, IMapper mapper)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _deadline = database.GetCollection<Deadline>(settings.DeadlinesCollectionName);
            _mapper = mapper;
        }

        public List<DeadlineDto> GetDeadlines()
        {
            return _mapper.Map<List<DeadlineDto>>(_deadline.Find(deadline => true).ToList()); 
        }

        public DeadlineDto GetDeadline(string id)
        {
            return _mapper.Map<DeadlineDto>(_deadline.Find(deadline => deadline.Id == id).FirstOrDefault());
        }

        public DeadlineDto CreateDeadline(DeadlineDto deadline)
        {
            var mappedDeadline = _mapper.Map<Deadline>(deadline);

            _deadline.InsertOne(mappedDeadline);
            return deadline;
        }

        public void UpdateDeadline(string id, UpdateDeadlineDto updateDeadlineDto)
        {
            var filter = Builders<Deadline>.Filter.Eq(d => d.Id, id);

            var existingDeadline = _deadline.Find(filter).FirstOrDefault();

            var update = Builders<Deadline>.Update
                .Set(d => d.Name, updateDeadlineDto.Name ?? existingDeadline.Name)
                .Set(d => d.OpenDate, updateDeadlineDto.OpenDate ?? existingDeadline.OpenDate)
                .Set(d => d.ClosedDate, updateDeadlineDto.ClosedDate ?? existingDeadline.ClosedDate);

            _deadline.UpdateOne(filter, update);
        }

        public void RemoveDeadline(string id)
        {
            _deadline.DeleteOne(deadline => deadline.Id == id);
        }
    }
}