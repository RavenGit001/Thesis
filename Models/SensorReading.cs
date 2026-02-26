namespace Thesis.Models
{
    public class SensorReading
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}