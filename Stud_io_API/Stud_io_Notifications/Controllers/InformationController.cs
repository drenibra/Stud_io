/*using Microsoft.AspNetCore.Mvc;
using Stud_io_Notifications.DTOs;
using Stud_io_Notifications.Models;
using Stud_io_Notifications.Services.Interfaces;

namespace Stud_io_Notifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly IInformationService _informationService;

        public InformationController(IInformationService informationService)
        {
            _informationService = informationService;
        }

        [HttpPost("add-information")]
        public async Task<ActionResult> AddDeadline(InformationDTO information)
        {
           return await _informationService.AddInformation(information);
        }

        [HttpGet("get-all-informations")]
        public async Task<ActionResult<List<InformationDTO>>> GetAll(string? searchString)
        {
            return await _informationService.GetAllInformations(searchString);

        }

        [HttpGet("get-information-by-id /{id}")]
        public async Task<ActionResult<InformationDTO>> GetInformationById(int id)
        {
            return await _informationService.GetInformationById(id);

        }

        [HttpPut("update-information-by-id/{id}")]
        public async Task<ActionResult> UpdateInformation(int id, UpdateInformationDTO information)
        {
            return await _informationService.UpdateInformation(id, information);

        }

        [HttpDelete("delete-information/{id}")]
        public async Task<ActionResult> DeleteInformation(int id)
        {
            return await _informationService.DeleteInformation(id);
        }
    }
}
*/