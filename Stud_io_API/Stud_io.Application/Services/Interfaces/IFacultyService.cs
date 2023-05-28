using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.DTOs;

namespace Stud_io.Application.Services.Interfaces
{
    public interface IFacultyService
    {
        public Task<ActionResult<List<FacultyDto>>> GetFaculties();
        public Task<ActionResult<FacultyDto>> GetFacultyById(int id);
        public Task<ActionResult> AddFaculty(FacultyDto facultyDto);
        public Task<ActionResult> UpdateFaculty(int id, UpdateFacultyDto updateFacultyDto);
        public Task<ActionResult> DeleteFaculty(int id);
    }
}
