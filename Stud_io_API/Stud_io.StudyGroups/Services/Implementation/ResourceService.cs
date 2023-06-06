using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Configuration;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.Models;
using Stud_io.StudyGroups.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stud_io.StudyGroups.Services.Implementation
{
    public class ResourceService : IResourceService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICloudinaryService _cloudinaryService;

        public ResourceService(ApplicationDbContext context, ICloudinaryService cloudinaryService)
        {
            _context = context;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<ActionResult<ResourceDto>> GetResourceById(int id)
        {
            var resource = await _context.Resources.FindAsync(id);

            if (resource == null)
                return new NotFoundResult();

            var resourceDto = new ResourceDto
            {
                Id = resource.Id,
                FileName = resource.FileName,
                FileType = resource.FileType,
                FileUrl = resource.FileUrl,
                StudentId = resource.StudentId,
                StudyGroupId = resource.StudyGroupId
            };

            return resourceDto;
        }

        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetAllResources()
        {
            var resources = await _context.Resources.ToListAsync();

            var resourceDtos = resources.Select(resource => new ResourceDto
            {
                Id = resource.Id,
                FileName = resource.FileName,
                FileType = resource.FileType,
                FileUrl = resource.FileUrl,
                StudentId = resource.StudentId,
                StudyGroupId = resource.StudyGroupId
            }).ToList();

            return resourceDtos;
        }

        public async Task<ActionResult> CreateResource(CreateResourceDto dto)
        {
            if (dto == null || dto.File == null)
                return new BadRequestObjectResult("You must provide a valid resource file.");

            var resource = new Resource
            {
                FileName = dto.FileName,
                FileType = dto.FileType,
                StudentId = dto.StudentId,
                StudyGroupId = dto.StudyGroupId
            };

            // Upload the file and set the FileUrl property of the resource
            resource.FileUrl = await _cloudinaryService.UploadFile(dto.File);

            await _context.Resources.AddAsync(resource);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Resource created successfully!");
        }

        public async Task<ActionResult> DeleteResource(int id)
        {
            var resource = await _context.Resources.FindAsync(id);

            if (resource == null)
                return new NotFoundResult();

            _context.Resources.Remove(resource);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Resource deleted successfully!");
        }


    }
}
