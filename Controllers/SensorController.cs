using Microsoft.AspNetCore.Mvc;
using Thesis.Data;
using Thesis.Models;
using Microsoft.EntityFrameworkCore;

namespace Thesis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly BreadDbContext _context;

        public SensorController(BreadDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostReading([FromBody] SensorReading reading)
        {
            _context.SensorReadings.Add(reading);
            await _context.SaveChangesAsync();
            return Ok(reading);
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestReading()
        {
            var latest = await _context.SensorReadings
                .OrderByDescending(r => r.Timestamp)
                .FirstOrDefaultAsync();

            if (latest == null)
                return Ok(null);

            return Ok(latest);
        }
    }
}