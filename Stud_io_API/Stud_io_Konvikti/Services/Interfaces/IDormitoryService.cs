using Microsoft.AspNetCore.Mvc;
using Stud_io_Dormitory.DTOs;

namespace Stud_io_Dormitory.Services.Interfaces
{
    public interface IDormitoryService
    {
        public Task<ActionResult<List<DormitoryDto>>> GetDormitories();
        public Task<ActionResult<DormitoryDto>> GetDormitoryById(int id);
        public Task<ActionResult> AddDormitory(DormitoryDto dormitoryDTO);
        public Task<ActionResult> UpdateDormitory(int id, UpdateDormitoryDto updateDormitoryDTO);
        public Task<ActionResult> DeleteDormitory(int id);
        public Task AssignStudentsToDormitories(string token);
    }
}

