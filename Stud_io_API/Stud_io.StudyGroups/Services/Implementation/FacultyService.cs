using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Configuration;
using Stud_io.StudyGroups.DTOs;
using Stud_io.StudyGroups.Models;
using Stud_io.StudyGroups.Services.Interfaces;

namespace Stud_io.StudyGroups.Services.Implementation
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
            await _context.Faculties.Select(x => new FacultyDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();

        public async Task<ActionResult<FacultyDto>> GetFacultyById(int id)
        {

            var mappedFaculty = await _context.Faculties.Where(x => x.Id == id).Select(x => new FacultyDto
            {
                Id = x.Id,
                Name = x.Name,
            }).FirstOrDefaultAsync();

            return mappedFaculty == null
                ? new NotFoundObjectResult("Faculty doesn't exist!!")
                : new OkObjectResult(mappedFaculty);
        }

        public async Task<ActionResult> AddFaculty(FacultyDto facultyDto)
        {
            if (facultyDto == null)
                return new BadRequestObjectResult("Faculty can not be null!!");

            var mappedFaculty = new Faculty
            {
                Name = facultyDto.Name,
            };
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
                return new NotFoundObjectResult("Faculty doesn't exist!!");

            dbFaculty.Name = updateFacultyDto.Name ?? dbFaculty.Name;

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
