using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io_Notifications.Configurations;
using Stud_io_Notifications.DTOs;
using Stud_io_Notifications.Models;
using Stud_io_Notifications.Services.Interfaces;

namespace Stud_io_Notifications.Services.Implementations
{
    public class InformationService : IInformationService
    {
        private readonly NotificationDbContext _context;
        private readonly IMapper _mapper;

        public InformationService(NotificationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult> AddInformation(InformationDTO informationDTO)
        {
            if (informationDTO == null)
            {
                return new BadRequestObjectResult("Information can not be null");
            }
            var mappedInformation = _mapper.Map<Information>(informationDTO);
            await _context.Informations.AddAsync(mappedInformation);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Information added successfully");
        }

        public async Task<ActionResult> DeleteInformation(int id)
        {
            var information = await _context.Informations.FindAsync(id);
            if (information == null)
            {
                return new NotFoundObjectResult("Information doesn't exist");
            }
            _context.Informations.Remove(information);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Information deleted successfully");
        }

        public async Task<ActionResult<List<InformationDTO>>> GetAllInformations(string? searchString)
        {
            // sorting
            var allInformations = _mapper.Map<List<InformationDTO>>( _context.Informations.OrderBy(n => n.Name).ToList());

            if (!string.IsNullOrEmpty(searchString))
            {
                allInformations = allInformations.Where(n => n.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return allInformations;
        }


        public async Task<ActionResult<InformationDTO>> GetInformationById(int id)
        {
            var mappedInformation = _mapper.Map<InformationDTO>(await _context.Informations.FindAsync(id));
            return mappedInformation == null
                ? new NotFoundObjectResult("Information doesn't exist")
                : new OkObjectResult(mappedInformation);
        }

        public async Task<ActionResult> UpdateInformation(int id, UpdateInformationDTO updateInformation)
        {
            if (updateInformation == null)
                return new BadRequestObjectResult("Information can't be null");

            var information = await _context.Informations.FindAsync(id);
            if (information == null)
                return new NotFoundObjectResult("Information doesn't exist");

            information.Name = updateInformation.Name ?? information.Name;
            information.Link = updateInformation.Link ?? information.Link;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Information updated successfully");
        }
    }
}
