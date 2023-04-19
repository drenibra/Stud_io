using Microsoft.AspNetCore.Mvc;
using Stud_io.Maintenance.DTOs;

namespace Stud_io.Maintenance.Service.Interfaces
{
    public interface ITaskService
    {
        Task<ActionResult<List<DTaskDto>>> GetTasks();
        Task<ActionResult<DTaskDto>> GetTaskById(int id);
        Task<ActionResult> AddTask(DTaskDto historyDTO);
        Task<ActionResult> UpdateTask(int id, DTaskDto updateHistoryDTO);
        Task<ActionResult> DeleteTask(int id);
    }
}
