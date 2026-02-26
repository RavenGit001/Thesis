using Microsoft.EntityFrameworkCore;
using Thesis.Models;

namespace Thesis.Data
{
    public class BreadDbContext : DbContext
    {
        public BreadDbContext(DbContextOptions<BreadDbContext> options)
            : base(options)
        {
        }

        public DbSet<SensorReading> SensorReadings { get; set; }
        public DbSet<DetectionLog> DetectionLogs { get; set; }
    }
}