using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io_Dormitory.Configurations;
using Stud_io_Dormitory.DTOs;
using Stud_io_Dormitory.Models;
using Stud_io_Dormitory.Services.Interfaces;

namespace Stud_io_Dormitory.Services.Implementations
{
    public class DormitoryService : IDormitoryService
    {
        private readonly DormitoryDbContext _context;
        private readonly IMapper _mapper;

        public DormitoryService(DormitoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<DormitoryDto>>> GetDormitories() =>
            _mapper.Map<List<DormitoryDto>>(await _context.Dormitories.ToListAsync());

        public async Task<ActionResult<DormitoryDto>> GetDormitoryById(int id)
        {
            var mappedDormitory = _mapper.Map<DormitoryDto>(await _context.Dormitories.FindAsync(id));
            return mappedDormitory == null
                ? new NotFoundObjectResult("Dormitory doesn't exist!!")
                : new OkObjectResult(mappedDormitory);
        }

        public async Task<ActionResult> AddDormitory(DormitoryDto dormitoryDTO)
        {
            if (dormitoryDTO == null)
                return new BadRequestObjectResult("Dormitory can not be null!!");
            var mappedDormitory = _mapper.Map<Dormitory>(dormitoryDTO);
            await _context.Dormitories.AddAsync(mappedDormitory);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Dormitory added successfully!");
        }

        public async Task<ActionResult> UpdateDormitory(int id, UpdateDormitoryDto updateDormitoryDTO)
        {
            if (updateDormitoryDTO == null)
                return new BadRequestObjectResult("Dormitory can not be null!!");

            var dbDormitory = await _context.Dormitories.FindAsync(id);
            if (dbDormitory == null)
                return new NotFoundObjectResult("Dormitory doesn't exist!!");

            dbDormitory.DormNo = updateDormitoryDTO.DormNo ?? dbDormitory.DormNo;
            dbDormitory.Gender = updateDormitoryDTO.Gender ?? dbDormitory.Gender;
            dbDormitory.NoOfRooms = updateDormitoryDTO.NoOfRooms ?? dbDormitory.NoOfRooms;
            dbDormitory.Capacity = updateDormitoryDTO.Capacity ?? dbDormitory.Capacity;
            dbDormitory.isFull = updateDormitoryDTO.isFull ?? dbDormitory.isFull;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Dormitory updated successfully!");
        }

        public async Task<ActionResult> DeleteDormitory(int id)
        {
            var dbDormitory = await _context.Dormitories.FindAsync(id);
            if (dbDormitory == null)
                return new NotFoundObjectResult("Dormitory doesn't exist!!");

            _context.Dormitories.Remove(dbDormitory);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Dormitory deleted successfully!");
        }

    }
}
