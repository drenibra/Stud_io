using Microsoft.AspNetCore.Mvc;
using Stud_io_Notifications.DTOs;
using Stud_io_Notifications.Models;

namespace Stud_io_Notifications.Services.Interfaces
{
    public interface IInformationService
    {
        public Task<ActionResult<List<InformationDTO>>> GetAllInformations(string? searchString);
        public Task<ActionResult<InformationDTO>> GetInformationById(int id);
        public Task<ActionResult> AddInformation(InformationDTO informationDTO);
        public Task<ActionResult> UpdateInformation(int id, UpdateInformationDTO updateInformation);
        public Task<ActionResult> DeleteInformation(int id);
    }
}
