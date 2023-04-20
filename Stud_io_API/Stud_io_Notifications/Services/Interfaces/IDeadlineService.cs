using Microsoft.AspNetCore.Mvc;
using Stud_io_Notifications.DTOs;

namespace Stud_io_Notifications.Services.Interfaces
{
    public interface IDeadlineService
    {
        public Task<ActionResult<List<DeadlineDTO>>> GetAllDeadlines();
        public Task<ActionResult<DeadlineDTO>> GetDeadlineById(int id);
        public Task<ActionResult> AddDeadline(DeadlineDTO deadlineDto);
        public Task<ActionResult> UpdateDeadline(int id, UpdateDeadlineDTO updateDeadlineDto);
        public Task<ActionResult> DeleteDeadline(int id);
    }
}
