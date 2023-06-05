using Notifications.Models;

namespace Stud_io_Notifications.Services.Interfaces
{
    public interface IInformationService
    {
        public List<Information> GetInformations();
        public Information GetInformation(string id);

    }
}
