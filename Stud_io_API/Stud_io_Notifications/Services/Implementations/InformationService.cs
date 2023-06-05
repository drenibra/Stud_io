using MongoDB.Driver;
using Notifications.Models;
using Stud_io_Notifications.Configurations;
using Stud_io_Notifications.Services.Interfaces;

namespace Stud_io_Notifications.Services.Implementations
{
    public class InformationService : IInformationService
    {
        private readonly IMongoCollection<Information>_information;
        public InformationService(INotificationsDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _information = database.GetCollection<Information>(settings.DeadlinesCollectionName);
        }

        public List<Information> GetInformations()
        {
            return _information.Find(information => true).ToList();
        }

        public Information GetInformation(string id)
        {
            return _information.Find(information => information.Id == id).FirstOrDefault();
        }


    }


}