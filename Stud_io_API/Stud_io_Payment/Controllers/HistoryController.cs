using Microsoft.AspNetCore.Mvc;
using Stud_io_Payment.DTOs;
using Stud_io_Payment.Services.Interfaces;

namespace Stud_io_Payment.Controllers
{
    [Route("")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet("Histories")]
        public async Task<ActionResult<List<HistoryDto>>> GetHistories()
        {
            return await _historyService.GetHistories();
        }

        [HttpGet("History/{id}")]
        public async Task<ActionResult<HistoryDto>> GetHistoryById(int id)
        {
            return await _historyService.GetHistoryById(id);
        }

        [HttpPost("History")]
        public async Task<ActionResult> AddHistory(HistoryDto historyDto)
        {
            return await _historyService.AddHistory(historyDto);
        }

        [HttpPut("History")]
        public async Task<ActionResult> UpdateHistory(int id, UpdateHistoryDto historyDto)
        {
            return await _historyService.UpdateHistory(id, historyDto);
        }

        [HttpDelete("History/{id}")]
        public async Task<ActionResult> DeleteHistory(int id)
        {
            return await _historyService.DeleteHistory(id);
        }
    }
}
