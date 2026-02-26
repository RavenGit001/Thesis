using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thesis.Models
{
    public class BreadDetection
    {
        public string BreadType { get; set; } = string.Empty; // Spanish, Ensaymada, Pan de Coco
        public double Probability { get; set; } // 0-100%
        public bool IsMoldDetected { get; set; } // true if mold detected
    }

    public class DetectionLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "text")] // PostgreSQL text type
        public string BreadResultsJson { get; set; } = "{}"; // Store as JSON string

        [Column(TypeName = "text")] // PostgreSQL text type
        public string? ImageUrl { get; set; }

        [Column(TypeName = "timestamp with time zone")] // PostgreSQL timestamp with timezone
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Helper methods for JSON serialization/deserialization
        [NotMapped]
        public List<BreadDetection> BreadResults
        {
            get => JsonSerializer.Deserialize<List<BreadDetection>>(BreadResultsJson) ?? new List<BreadDetection>();
            set => BreadResultsJson = JsonSerializer.Serialize(value);
        }
    }
}