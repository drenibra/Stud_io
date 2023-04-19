using Microsoft.AspNetCore.Mvc;
using Stud_io_Payment.DTOs;

namespace Stud_io_Payment.Services.Interfaces
{
    public interface IHistoryService
    {
        public Task<ActionResult<List<HistoryDto>>> GetHistories();
        public Task<ActionResult<HistoryDto>> GetHistoryById(int id);
        public Task<ActionResult> AddHistory(HistoryDto historyDTO);
        public Task<ActionResult> UpdateHistory(int id, UpdateHistoryDto updateHistoryDTO);
        public Task<ActionResult> DeleteHistory(int id);
    }
}
