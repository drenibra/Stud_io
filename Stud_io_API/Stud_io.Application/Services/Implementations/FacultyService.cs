using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Application.Configurations;
using Stud_io.Application.DTOs;
using Stud_io.Application.Models;
using Stud_io.Application.Services.Interfaces;

namespace Stud_io.Application.Services.Implementations
{
    public class FacultyService : IFacultyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FacultyService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<FacultyDto>>> GetFaculties() =>
            _mapper.Map<List<FacultyDto>>(await _context.Faculties.ToListAsync());

        public async Task<ActionResult<FacultyDto>> GetFacultyById(int id)
        {
            var mappedFaculty = _mapper.Map<FacultyDto>(await _context.Faculties.FindAsync(id));
            return mappedFaculty == null
                ? new NotFoundObjectResult("Faculty doesn't exist!!")
                : new OkObjectResult(mappedFaculty);
        }

        public async Task<ActionResult> AddFaculty(FacultyDto facultyDto)
        {
            if (facultyDto == null)
                return new BadRequestObjectResult("Faculty can not be null!!");
            var mappedFaculty = _mapper.Map<Faculty>(facultyDto);
            await _context.Faculties.AddAsync(mappedFaculty);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Faculty added successfully!");
        }

        public async Task<ActionResult> UpdateFaculty(int id, UpdateFacultyDto updateFacultyDto)
        {
            if (updateFacultyDto == null)
                return new BadRequestObjectResult("Faculty can not be null!!");

            var dbFaculty = await _context.Faculties.FindAsync(id);
            if (dbFaculty == null)
                return new NotFoundObjectResult("Student doesn't exist!!");

            dbFaculty.FacultyName = updateFacultyDto.FacultyName ?? dbFaculty.FacultyName;
            dbFaculty.Major = updateFacultyDto.Major ?? dbFaculty.Major;
          
            await _context.SaveChangesAsync();

            return new OkObjectResult("Faculty updated successfully!");
        }

        public async Task<ActionResult> DeleteFaculty(int id)
        {
            var dbFaculty = await _context.Faculties.FindAsync(id);
            if (dbFaculty == null)
                return new NotFoundObjectResult("Faculty doesn't exist!!");

            _context.Faculties.Remove(dbFaculty);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Faculty deleted successfully!");
        }
    }
}
