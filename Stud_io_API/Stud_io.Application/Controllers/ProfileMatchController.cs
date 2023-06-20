using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.Models;
using Stud_io.Application.Services.Interfaces;

namespace Stud_io.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileMatchController : ControllerBase
    {
        private readonly IProfileMatchService _profileMatchService;

        public ProfileMatchController(IProfileMatchService profileMatchService)
        {
            _profileMatchService = profileMatchService;
        }

        [HttpGet("getAverageGradePoints/{grade}")]
        public IActionResult CalculateAGPoints(float grade)
        {
            var points = _profileMatchService.CalculateAverageGradePoints(grade);
            return Ok(points);

        }

        [HttpGet("getExtraPoints/{category}")]
        public IActionResult CalculateExtraPoints(string category)
        {
            var points = _profileMatchService.CalculateExtraPoints(category);
            return Ok(points);
        }

        [HttpGet("getCityPoints/{city}")]
        public IActionResult CalculateCityPoints(string city)
        {
            var points = _profileMatchService.CalculateCityPoints(city);
            return Ok(points);
        }

        [HttpGet("get-matches")]
        public async Task<ActionResult<IEnumerable<ProfileMatch>>> GetMatches()
        {
            return await _profileMatchService.GetMatches();
        }

        [HttpGet("calculate-total-points-for-all-students/{token}")]
        public async Task<ActionResult<List<ProfileMatch>>> CalculateTotalPointsForAllStudents(string token)
        {
           return await _profileMatchService.CalculateTotalPointsForAllStudents(token);
        }

        [HttpGet("sortByTotalPoints")]
        public async Task<ActionResult<List<ProfileMatch>>> GetSortedProfileMatches()
        {
            return await _profileMatchService.SortByTotalPoints();
        }

        [HttpGet("topMatches")]
        public async Task<ActionResult<List<ProfileMatch>>> GetTopMatches()
        {
            return await _profileMatchService.GetTopProfileMatches();
        }

        [HttpGet("lastMatches")]
        public async Task<ActionResult<List<ProfileMatch>>> GetLastMatches()
        {
            return await _profileMatchService.GetLastProfileMatches();
        }
    }
}