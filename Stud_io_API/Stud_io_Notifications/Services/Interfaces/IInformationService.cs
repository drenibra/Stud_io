using Notifications.Models;
using Stud_io_Notifications.DTOs;

namespace Stud_io_Notifications.Services.Interfaces
{
    public interface IInformationService
    {
        public List<InformationDto> GetInformations();
        public InformationDto GetInformation(string id);
        public Information CreateInformation(InformationDto information);
        public void UpdateInformation(string id, UpdateInformationDto updateInformationDto);
        public void RemoveInformation(string id);

    }
}
