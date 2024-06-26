﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Stud_io.Maintenance.Configurations;
using Stud_io.Maintenance.DTOs;
using Stud_io.Maintenance.Models;
using Stud_io.Maintenance.Paging;
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

        public async Task<ActionResult<GetTaskDto>> GetTaskById(int id)
        {
            var task = _mapper.Map<GetTaskDto>(await _context.Tasks.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync());

            if (task is null)
                return new NotFoundObjectResult("Task not found or has been deleted.");
            
            return new OkObjectResult(task);
        }

        public async Task<ActionResult<List<GetTaskDto>>> GetDormTasks(FilterTaskDto filter, int? pageNumber)
        {
            var tasks = _context.Tasks
                                .Where(x => !x.IsDeleted 
                                    && x.DormNo == (filter.DormNo ?? x.DormNo)
                                    && x.MaintenantId == (filter.MaintenantId ?? x.MaintenantId)
                                    && x.IsCompleted == (filter.IsCompleted ?? x.IsCompleted))
                                .AsQueryable();

            var dtoTasks = _mapper.Map<List<GetTaskDto>>(await PaginatedList<DTask>.Create(tasks, pageNumber ?? 1, 10));

            return new OkObjectResult(dtoTasks);
        }

        public async Task<ActionResult> CreateTask(CreateTaskDto taskDto)
        {
            var task = new DTask()
            {
                DormNo = taskDto.DormNo,
                MaintenantId = taskDto.MaintenantId,
                Title = taskDto.Title,
                Description = taskDto.Description,
                Type = taskDto.Type,
                FloorNo = taskDto.FloorNo,
                DateCreated = taskDto.DateCreated,
                DueDate = taskDto.DueDate
            };

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Task added succesfully.");
        }
        public async Task<ActionResult> UpdateTask(int id, UpdateTaskDto dto)
        {
            var dbTask = await _context.Tasks.FindAsync(id);

            if (dbTask == null)
                return new BadRequestObjectResult("Task with this id doesn't exist.");

            dbTask.DormNo = dto.DormNo;
            dbTask.MaintenantId = dto.MaintenantId;
            dbTask.Title = dto.Title;
            dbTask.Description = dto.Description;
            dbTask.Type = dto.Type;
            dbTask.FloorNo = dto.FloorNo;
            dbTask.DueDate = dto.DueDate;
            dbTask.IsCompleted = dto.IsCompleted;

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return new OkObjectResult("Task updated succesfully.");
            else
                return new BadRequestObjectResult("Something went wrong.");
        }
        
        //soft delete method
        public async Task<ActionResult> DeleteTask(int id)
        {
            var dbTask = await _context.Tasks.FindAsync(id);

            if (dbTask == null)
                return new BadRequestObjectResult("Task with this id doesn't exist.");

            dbTask.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Task deleted succesfully.");
        }

        public async Task<ActionResult> ChangeTaskStatus(int id, bool status)
        {
            var dbTask = await _context.Tasks.FindAsync(id);

            if (dbTask == null)
                return new BadRequestObjectResult("Task with this id doesn't exist.");

            dbTask.IsCompleted = status;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Task's status updated succesfully.");
        }
    
        
    }
}
