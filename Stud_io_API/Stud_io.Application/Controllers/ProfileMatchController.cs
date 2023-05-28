using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.Configurations;
using Stud_io.Application.Models;
using Stud_io.Application.Services.Interfaces;
using System;

namespace Stud_io.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileMatchController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IProfileMatchService _profileMatchService;

        public ProfileMatchController(ApplicationDbContext context, IProfileMatchService profileMatchService)
        {
            _context = context;
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

        [HttpGet("profilematches")]
        public async Task<ActionResult<IEnumerable<ProfileMatch>>> GetProfileMatches()
        {
           return await _profileMatchService.CalculateTotalPointsForAllStudents();

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
