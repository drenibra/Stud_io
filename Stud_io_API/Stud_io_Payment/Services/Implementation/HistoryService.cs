using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io_Payment.Configurations;
using Stud_io_Payment.DTOs;
using Stud_io_Payment.Models;
using Stud_io_Payment.Services.Interfaces;

namespace Stud_io_Payment.Services.Implementation
{
    public class HistoryService : IHistoryService
    {
        private readonly PaymentDbContext _context;
        private readonly IMapper _mapper;

        public HistoryService(PaymentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<HistoryDto>>> GetHistories() =>
            _mapper.Map<List<HistoryDto>>(await _context.Histories.ToListAsync());

        public async Task<ActionResult<HistoryDto>> GetHistoryById(int id)
        {
            var mappedHistory = _mapper.Map<HistoryDto>(await _context.Histories.FindAsync(id));
            return mappedHistory == null
                ? new NotFoundObjectResult("History doesn't exist!!")
                : new OkObjectResult(mappedHistory);
        }

        public async Task<ActionResult> AddHistory(HistoryDto historyDTO)
        {
            if (historyDTO == null)
                return new BadRequestObjectResult("History can not be null!!");
            var mappedHistory = _mapper.Map<History>(historyDTO);
            await _context.Histories.AddAsync(mappedHistory);
            await _context.SaveChangesAsync();
            return new OkObjectResult("History added successfully!");
        }

        public async Task<ActionResult> UpdateHistory(int id, UpdateHistoryDto updateHistoryDTO)
        {
            if (updateHistoryDTO == null)
                return new BadRequestObjectResult("History can not be null!!");

            var dbHistory = await _context.Histories.FindAsync(id);
            if (dbHistory == null)
                return new NotFoundObjectResult("History doesn't exist!!");

            dbHistory.Payment = updateHistoryDTO.Payment ?? dbHistory.Payment;
            dbHistory.StdPersonalNo = updateHistoryDTO.StdPersonalNo ?? dbHistory.StdPersonalNo;
            await _context.SaveChangesAsync();

            return new OkObjectResult("History updated successfully!");
        }

        public async Task<ActionResult> DeleteHistory(int id)
        {
            var dbHistory = await _context.Histories.FindAsync(id);
            if (dbHistory == null)
                return new NotFoundObjectResult("History doesn't exist!!");

            _context.Histories.Remove(dbHistory);
            await _context.SaveChangesAsync();
            return new OkObjectResult("History deleted successfully!");
        }
    }
}