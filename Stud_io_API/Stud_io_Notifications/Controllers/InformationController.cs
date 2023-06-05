using Microsoft.AspNetCore.Mvc;
using Notifications.Models;
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
        public ActionResult<List<Information>> GetInformations() => _informationService.GetInformations();

        [HttpGet("get-information-by-id /{id}")]
        public ActionResult<Information> GetInformation(string id)
        {
            var information = _informationService.GetInformation(id);

            if (information == null)
                return NotFound($"Information with Id = {id} not found");

            return information;
        }

    }
}
