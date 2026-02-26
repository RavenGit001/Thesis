using Microsoft.AspNetCore.Mvc;
using Thesis.Data;
using Thesis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Thesis.Hubs;

namespace Thesis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetectionController : ControllerBase
    {
        private readonly BreadDbContext _context;
        private readonly IHubContext<AlertHub> _hub;

        public DetectionController(BreadDbContext context, IHubContext<AlertHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        [HttpPost]
        public async Task<IActionResult> PostMultiDetection([FromBody] DetectionLog log)
        {
            // log.BreadResultsJson must already be a JSON string with all three breads
            _context.DetectionLogs.Add(log);
            await _context.SaveChangesAsync();

            // Real-time alert: send entire log
            await _hub.Clients.All.SendAsync("ReceiveAlert", log);

            return Ok(log);
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestDetection()
        {
            var latest = await _context.DetectionLogs
                .OrderByDescending(d => d.Timestamp)
                .FirstOrDefaultAsync();

            if (latest == null)
                return NotFound();

            return Ok(latest);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetDetectionHistory()
        {
            var history = await _context.DetectionLogs
                .OrderByDescending(d => d.Timestamp)
                .ToListAsync();

            return Ok(history);
        }
    }
}