using AutoMapper;
using MongoDB.Driver;
using Notifications.Models;
using Stud_io_Notifications.Configurations;
using Stud_io_Notifications.DTOs;
using Stud_io_Notifications.Services.Interfaces;

namespace Stud_io_Notifications.Services.Implementations
{
    public class InformationService : IInformationService
    {
        private readonly IMongoCollection<Information>_information;
        private readonly IMapper _mapper;
        public InformationService(INotificationsDatabaseSettings settings, IMongoClient mongoClient, IMapper mapper)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _information = database.GetCollection<Information>(settings.InformationsCollectionName);
            _mapper = mapper;
        }
        public List<InformationDto> GetInformations()
        {
            return _mapper.Map<List<InformationDto>>(_information.Find(information => true).ToList());
        }

        public InformationDto GetInformation(string id)
        {
            return _mapper.Map<InformationDto>(_information.Find(information => information.Id == id).FirstOrDefault());
        }

        public Information CreateInformation(InformationDto information)
        {
            var mappedInformation = _mapper.Map<Information>(information);

            _information.InsertOne(mappedInformation);
            return mappedInformation;
        }

        public void UpdateInformation(string id, UpdateInformationDto updateInformationDto)
        {
            var filter = Builders<Information>.Filter.Eq(d => d.Id, id);

            var existingInformation = _information.Find(filter).FirstOrDefault();

            var update = Builders<Information>.Update
                .Set(i => i.Name, updateInformationDto.Name ?? existingInformation.Name)
                .Set(i => i.Link, updateInformationDto.Link ?? existingInformation.Link);
                
            _information.UpdateOne(filter, update);
        }

        public void RemoveInformation(string id)
        {
            _information.DeleteOne(information => information.Id == id);
        }

    }


}