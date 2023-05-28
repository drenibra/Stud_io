using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.DTOs;
using Stud_io.Application.Models;

namespace Stud_io.Application.Services.Interfaces
{
    public interface IProfileMatchService
    {
        
        public Task<ActionResult<int>> CalculateAverageGradePoints(double averageGrade);
        public Task<ActionResult<int>> CalculateExtraPoints(string category);
        public Task<ActionResult<List<ProfileMatch>>> GetLastProfileMatches();
    }
}
