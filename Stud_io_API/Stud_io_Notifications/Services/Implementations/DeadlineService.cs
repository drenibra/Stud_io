using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io_Notifications.Configurations;
using Stud_io_Notifications.DTOs;
using Stud_io_Notifications.Models;
using Stud_io_Notifications.Services.Interfaces;

namespace Stud_io_Notifications.Services.Implementations
{
    public class DeadlineService : IDeadlineService
    {
        private readonly NotificationDbContext _context;
        private readonly IMapper _mapper;

        public DeadlineService(NotificationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult> AddDeadline(DeadlineDTO deadlineDto)
        {
            if (deadlineDto == null)
            {
                return new BadRequestObjectResult("Deadline can not be null");
            }
            var mappedDeadline = _mapper.Map<Deadline>(deadlineDto);
            await _context.Deadlines.AddAsync(mappedDeadline);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Deadline added successfully");
        }

        public async Task<ActionResult> DeleteDeadline(int id)
        {
            var deadline = await _context.Deadlines.FindAsync(id);
            if (deadline == null)
            {
                return new NotFoundObjectResult("Deadline doesn't exist");
            }
            _context.Deadlines.Remove(deadline);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Deadline deleted successfully");
        }

        public async Task<ActionResult<List<DeadlineDTO>>> GetAllDeadlines() =>
            _mapper.Map<List<DeadlineDTO>>(await _context.Deadlines.ToListAsync());

        public async Task<ActionResult<DeadlineDTO>> GetDeadlineById(int id)
        {
            var mappedDeadline = _mapper.Map<DeadlineDTO>(await _context.Deadlines.FindAsync(id));
            return mappedDeadline == null
                ? new NotFoundObjectResult("Deadline doesn't exist")
                : new OkObjectResult(mappedDeadline);
        }

        public async Task<ActionResult> UpdateDeadline(int id, UpdateDeadlineDTO updateDeadlineDto)
        {
            if (updateDeadlineDto == null)
                return new BadRequestObjectResult("Deadline can't be null");

            var deadline = await _context.Deadlines.FindAsync(id);
            if (deadline == null)
                return new NotFoundObjectResult("Deadline doesn't exist");

            deadline.Name = updateDeadlineDto.Name ?? deadline.Name;
            deadline.OpenDate = updateDeadlineDto.OpenDate ?? deadline.OpenDate;
            deadline.ClosedDate = updateDeadlineDto.ClosedDate ?? deadline.ClosedDate;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Deadline updated successfully");
        }
    }
}
