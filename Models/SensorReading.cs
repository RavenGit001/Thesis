using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thesis.Models
{
    public class SensorReading
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "double precision")] // PostgreSQL double precision
        public double Temperature { get; set; }

        [Column(TypeName = "double precision")]
        public double Humidity { get; set; }

        [Column(TypeName = "timestamp with time zone")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}