using Microsoft.AspNetCore.Mvc;
using Stud_io.StudyGroups.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stud_io.StudyGroups.Services.Interfaces
{
    public interface IMajorService
    {
        Task<ActionResult<List<MajorDto>>> GetAllMajors();
        Task<ActionResult<MajorDto>> GetMajorById(int id);
        Task<ActionResult<MajorDto>> CreateMajor(CreateMajorDto createDto);
        Task<ActionResult<MajorDto>> UpdateMajor(int id, UpdateMajorDto updateDto);
        Task<ActionResult<bool>> DeleteMajor(int id);
    }
}
