using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io_Notifications.Configurations;
using Stud_io_Notifications.DTOs;
using Stud_io_Notifications.Models;
using Stud_io_Notifications.Services.Interfaces;

namespace Stud_io_Notifications.Services.Implementations
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly NotificationDbContext _context;
        private readonly IMapper _mapper;

        public AnnouncementService(NotificationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult> AddAnnouncement(AnnouncementDTO announcementDto)
        {
            if(announcementDto == null)
            {
                return new BadRequestObjectResult("Announcement can not be null");
            }
            var mappedAnnouncement = _mapper.Map<Announcement>(announcementDto);
            await _context.Announcements.AddAsync(mappedAnnouncement);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Announcement added successfully");
        }

        public async Task<ActionResult> DeleteAnnouncement(int id)
        {
            var announcement = await _context.Announcements.FindAsync(id);
            if(announcement == null)
            {
                return new NotFoundObjectResult("Announcement doesn't exist");
            }
            _context.Announcements.Remove(announcement);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Announcement deleted successfully");
        }

        public async Task<ActionResult<List<AnnouncementDTO>>> GetAllAnnouncements() =>
            _mapper.Map<List<AnnouncementDTO>>(await _context.Announcements.ToListAsync());

        public async Task<ActionResult<AnnouncementDTO>> GetAnnouncementById(int id)
        {
            var mappedAnnouncement = _mapper.Map<AnnouncementDTO>(await _context.Announcements.FindAsync(id));
            return mappedAnnouncement == null
                ? new NotFoundObjectResult("Announcement doesn't exist")
                : new OkObjectResult(mappedAnnouncement);
        }

        public async Task<ActionResult> UpdateAnnouncement(int id, UpdateAnnouncementDTO updateAnnouncementDTO)
        {
            if (updateAnnouncementDTO == null)
                return new BadRequestObjectResult("Announcement can't be null");

            var announcement = await _context.Announcements.FindAsync(id);
            if (announcement == null)
                return new NotFoundObjectResult("Announcement doesn't exist");

            announcement.Title = updateAnnouncementDTO.Title ?? announcement.Title;
            announcement.Description = updateAnnouncementDTO.Description ?? announcement.Description;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Announcement updated successfully");
        }
    }
}
