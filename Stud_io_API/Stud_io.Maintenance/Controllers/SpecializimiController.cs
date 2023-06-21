using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Maintenance.Configurations;
using Stud_io.Maintenance.Models;

namespace Stud_io.Maintenance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializimiController : ControllerBase
    {
        private readonly MaintenanceDbContext _context;

        public SpecializimiController(MaintenanceDbContext context)
        {
            _context = context;
        }

        [HttpGet("get-specializimet")]
        public async Task<ActionResult<List<Specializimi>>> GetSpecializimet()
        {
            return await _context.Specializimet.ToListAsync();
        }

        [HttpPost("add-specializim")]
        public async Task<ActionResult> PostSpecializim(Specializimi a)
        {
            if (a == null)
                return BadRequest("Artikulli eshte null!!");

            await _context.Specializimet.AddAsync(a);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Specializimi u shtua!");
        }

        [HttpDelete("delete-specializim")]
        public async Task<ActionResult> DeleteSpecializim(int id)
        {
            var a = await _context.Specializimet.FindAsync(id);
            if (a == null)
                return NotFound();
            _context.Specializimet.Remove(a);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Specializimi u fshi!");
        }

        [HttpPut("update-specializimin")]
        public async Task<ActionResult> UpdateSpecializimin(Specializimi a)
        {
            if (a == null)
                return BadRequest();

            var art = await _context.Specializimet.FindAsync(a.Id);

            if (art == null)
                return BadRequest();

            art.Name = a.Name ?? art.Name;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Specializimi u be update!");
        }
    }
}
