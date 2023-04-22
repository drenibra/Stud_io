using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Maintenance.DTOs;

namespace Stud_io.Maintenance.Service.Interfaces
{
    public interface ITaskService
    {
        Task<ActionResult<List<GetTaskDto>>> GetDormTasks(int dormNo, int? pageNumber);
        Task<ActionResult<GetTaskDto>> GetTaskById(int id);
        Task<ActionResult> CreateTask(CreateTaskDto taskDto);
        Task<ActionResult> UpdateTask(int id, UpdateTaskDto taskDto);
        Task<ActionResult> DeleteTask(int id);
        Task<ActionResult> ChangeTaskStatus(int id, bool status);

    }
}
