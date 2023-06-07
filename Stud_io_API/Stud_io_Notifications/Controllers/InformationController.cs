using Microsoft.AspNetCore.Mvc;
using Notifications.Models;
using Stud_io_Notifications.DTOs;
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

        [HttpGet("get-all-informations")]
        public ActionResult<List<InformationDto>> GetInformations() => _informationService.GetInformations();

        [HttpGet("get-information-by-id /{id}")]
        public ActionResult<InformationDto> GetInformation(string id)
        {
            var information = _informationService.GetInformation(id);

            if (information == null)
                return NotFound($"Information with Id = {id} not found");

            return information;
        }

        [HttpPost("add-information")]
        public ActionResult<InformationDto> PostInformation([FromBody] InformationDto information)
        {
            if (information == null)
                return BadRequest("Information can't be null!");

            _informationService.CreateInformation(information);

            return information;
        }

        [HttpPut("update-information-by-id/{id}")]
        public ActionResult PutInformation(string id, [FromBody] UpdateInformationDto information)
        {
            var existingInformation = _informationService.GetInformation(id);

            if (existingInformation == null)
                return NotFound($"Information with Id = {id} not found");

            _informationService.UpdateInformation(id, information);

            return NoContent();
        }

        [HttpDelete("delete-information/{id}")]
        public ActionResult DeleteInformation(string id)
        {
            var existingInformation = _informationService.GetInformation(id);

            if (existingInformation == null)
                return NotFound($"Information with Id = {id} not found");

            _informationService.RemoveInformation(id);

            return Ok($"Information with Id = {id} deleted");
        }

    }
}
