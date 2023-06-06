using Microsoft.AspNetCore.Mvc;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.Services.Interfaces;

namespace Stud_io.StudyGroups.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResourceDto>> GetResourceById(int id)
        {
            return await _resourceService.GetResourceById(id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetAllResources()
        {
            return await _resourceService.GetAllResources();
        }

        [HttpPost]
        public async Task<ActionResult> CreateResource(CreateResourceDto dto)
        {
            return await _resourceService.CreateResource(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteResource(int id)
        {
            return await _resourceService.DeleteResource(id);
        }
    }
}
