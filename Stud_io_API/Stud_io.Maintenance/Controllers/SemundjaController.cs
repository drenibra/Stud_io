using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stud_io.Maintenance.Configurations;
using Stud_io.Maintenance.Models;

namespace Stud_io.Maintenance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemundjaController : ControllerBase
    {
        private readonly MaintenanceDbContext _context;

        public SemundjaController(MaintenanceDbContext context)
        {
            _context = context;
        }

        [HttpGet("get-semundjet")]
        public async Task<ActionResult<List<Semundja>>> GetKomentet()
        {
            return await _context.Semundjet.ToListAsync();
        }

        public record AddSemundjen()
        {
            public string Name { get; set; }
            public int SpecializimiId { get; set; }
        }

        [HttpPost("add-semundjen")]
        public async Task<ActionResult> AddSemundje(AddSemundjen k)
        {
            if (k == null)
                return BadRequest("Semundja eshte null!!");

            var semundja = new Semundja()
            {
                Name = k.Name,
                SpecializimiId = k.SpecializimiId,
                Specializimi = await _context.Specializimet.FindAsync(k.SpecializimiId),
            };
            await _context.Semundjet.AddAsync(semundja);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Semundja u shtua!");
        }

        [HttpPut("update-semundjen")]
        public async Task<ActionResult> UpdateSemundjen(int id, AddSemundjen k)
        {
            if (k == null)
                return BadRequest();

            var c = await _context.Semundjet.FindAsync(id);

            if (c == null)
                return BadRequest();

            c.Name = k.Name ?? c.Name;
            if (c.SpecializimiId != k.SpecializimiId)
                c.SpecializimiId = k.SpecializimiId;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Specializimi u be update!");
        }

        [HttpDelete("delete-semundjen")]
        public async Task<ActionResult> DeleteSemundjen(int id)
        {
            var k = await _context.Semundjet.FindAsync(id);
            if (k == null)
                return NotFound();
            _context.Semundjet.Remove(k);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Semundja u fshi!");
        }
    }
}
