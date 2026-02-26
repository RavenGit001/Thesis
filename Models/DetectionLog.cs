using System.Text.Json;

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
        public int Id { get; set; }
        public string BreadResultsJson { get; set; } = "{}"; // Store as JSON string
        public string? ImageUrl { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public List<BreadDetection> GetBreadResults()
        {
            return JsonSerializer.Deserialize<List<BreadDetection>>(BreadResultsJson) ?? new List<BreadDetection>();
        }

        public void SetBreadResults(List<BreadDetection> results)
        {
            BreadResultsJson = JsonSerializer.Serialize(results);
        }
    }
}