using Microsoft.AspNetCore.Mvc;
using Stud_io.StudyGroups.DTOs;

namespace Stud_io.StudyGroups.Services.Interfaces
{
    public interface IResourceService
    {
        Task<ActionResult<ResourceDto>> GetResourceById(int id);
        Task<ActionResult<List<ResourceDto>>> GetResources(FilterResourceDto filter);
        Task<ActionResult> CreateResource(CreateResourceDto dto);
        Task<ActionResult> DeleteResource(int id);
    }
}
