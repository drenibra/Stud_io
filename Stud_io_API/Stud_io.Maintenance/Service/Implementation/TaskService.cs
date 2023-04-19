using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Maintenance.Configurations;
using Stud_io.Maintenance.DTOs;
using Stud_io.Maintenance.Service.Interfaces;

namespace Stud_io.Maintenance.Service.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly MaintenanceDbContext _context;
        private readonly IMapper _mapper;

        public TaskService(MaintenanceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult<DTaskDto>> GetTaskById(int id)
        {
            var task = _mapper.Map<DTaskDto>(await _context.Tasks.FindAsync(id));
            return new OkObjectResult(task);
        }

        public async Task<ActionResult<List<DTaskDto>>> GetTasks()
        {
            var tasks = _mapper.Map<List<DTaskDto>>(await _context.Tasks.ToListAsync());
            return new OkObjectResult(tasks);
        }

        public Task<ActionResult> AddTask(DTaskDto historyDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> DeleteTask(int id)
        {
            throw new NotImplementedException();
        }


        public Task<ActionResult> UpdateTask(int id, DTaskDto updateHistoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
