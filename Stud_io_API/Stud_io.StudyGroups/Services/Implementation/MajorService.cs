using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.StudyGroups.DTOs;
using Stud_io.Configuration;
using Stud_io.StudyGroups.Models;
using Stud_io.StudyGroups.Services.Interfaces;

namespace Stud_io.StudyGroups.Services.Implementation
{
    public class MajorService : IMajorService
    {
        private readonly ApplicationDbContext _context;

        public MajorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<MajorDto>>> GetAllMajors()
        {
            var majors = await _context.Majors.Include(m => m.Faculty).ToListAsync();

            var majorDtos = majors.Select(m => new MajorDto
            {
                Id = m.Id,
                Title = m.Title,
                FacultyId = m.FacultyId,
                FacultyName = m.Faculty?.Name
            }).ToList();

            return new OkObjectResult(majorDtos);
        }

        public async Task<ActionResult<MajorDto>> GetMajorById(int id)
        {
            var major = await _context.Majors.Include(m => m.Faculty).FirstOrDefaultAsync(m => m.Id == id);

            if (major == null)
            {
                return new NotFoundResult();
            }

            var majorDto = new MajorDto
            {
                Id = major.Id,
                Title = major.Title,
                FacultyId = major.FacultyId,
                FacultyName = major.Faculty?.Name
            };

            return new OkObjectResult(majorDto);
        }

        public async Task<ActionResult<MajorDto>> CreateMajor(CreateMajorDto createDto)
        {
            var major = new Major
            {
                Title = createDto.Title,
                FacultyId = createDto.FacultyId
            };

            _context.Majors.Add(major);
            await _context.SaveChangesAsync();

            var majorDto = new MajorDto
            {
                Id = major.Id,
                Title = major.Title,
                FacultyId = major.FacultyId
            };

            return new OkObjectResult(majorDto);
        }

        public async Task<ActionResult<MajorDto>> UpdateMajor(int id, UpdateMajorDto updateDto)
        {
            var major = await _context.Majors.FindAsync(id);

            if (major == null)
            {
                return new NotFoundResult();
            }

            major.Title = updateDto.Title;
            major.FacultyId = updateDto.FacultyId;

            await _context.SaveChangesAsync();

            var majorDto = new MajorDto
            {
                Id = major.Id,
                Title = major.Title,
                FacultyId = major.FacultyId
            };

            return new OkObjectResult(majorDto);
        }

        public async Task<ActionResult<bool>> DeleteMajor(int id)
        {
            var major = await _context.Majors.FindAsync(id);

            if (major == null)
            {
                return new NotFoundResult();
            }

            _context.Majors.Remove(major);
            await _context.SaveChangesAsync();

            return new OkObjectResult(true);
        }
    }
}
