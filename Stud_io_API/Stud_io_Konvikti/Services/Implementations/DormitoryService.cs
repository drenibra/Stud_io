using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Dormitory.Models;
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

        public async Task AssignStudentsToDormitories()
        {
            var acceptedStudents = await _context.Students.Where(s => s.isAccepted).ToListAsync();
            var femaleStudents = acceptedStudents.Where(s => s.Gender == 'F').ToList();
            var maleStudents = acceptedStudents.Where(s => s.Gender == 'M').ToList();
            var dormitories = await _context.Dormitories.ToListAsync();

      
            var femaleDormitories = dormitories.Where(d => d.Gender == 'F').ToList();
            await AssignStudentsToDormitory(femaleStudents, femaleDormitories);

            var maleDormitories = dormitories.Where(d => d.Gender == 'M').ToList();
            await AssignStudentsToDormitory(maleStudents, maleDormitories);

            await _context.SaveChangesAsync();
        }

        private async Task AssignStudentsToDormitory(List<Student> students, List<Dormitory> dormitories)
        {
            foreach (var student in students)
            {
                var dormitory = dormitories.FirstOrDefault(d => d.CurrentStudents < d.Capacity);

                if (dormitory != null)
                {
                    student.DormNumber = dormitory.DormNo;

                    dormitory.CurrentStudents++;
                }
            }
        }



    }
}
