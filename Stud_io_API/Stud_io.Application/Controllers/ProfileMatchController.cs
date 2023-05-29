using Microsoft.AspNetCore.Mvc;
using Stud_io.Application.Configurations;
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

        public async Task<int> CalculateAGPoints(float grade)
        {
            return await _profileMatchService.CalculateAverageGradePoints(grade);
            
        }

        [HttpGet("getExtraPoints/{category}")]

        public async Task<int> CalculateExtraPoints(string category)
        {
            return await _profileMatchService.CalculateExtraPoints(category);   
        }


       



    }
}
