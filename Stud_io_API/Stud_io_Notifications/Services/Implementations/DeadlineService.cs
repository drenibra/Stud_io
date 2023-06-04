using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public DeadlineService(INotificationsDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _deadline = database.GetCollection<Deadline>(settings.DeadlinesCollectionName);
        }

        public List<Deadline> GetDeadlines()
        {
            return _deadline.Find(deadline => true).ToList();
        }

        public Deadline GetDeadline(string id)
        {
            return _deadline.Find(deadline => deadline.Id == id).FirstOrDefault();
        }

        public Deadline CreateDeadline(Deadline deadline)
        {
            _deadline.InsertOne(deadline);
            return deadline;
        }

        public void UpdateDeadline(string id, Deadline deadline)
        {
            _deadline.ReplaceOne(deadline => deadline.Id == id, deadline);
        }

        public void RemoveDeadline(string id)
        {
            _deadline.DeleteOne(deadline => deadline.Id == id);
        }
    }
}