namespace ForeflightExercise.Models
{
    public class AirportData
    {
        public string Icao { get; set; }
        public string Name { get; set; }
        public List<Runway> Runways { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string BestRunway { get; set; }
    }
}
