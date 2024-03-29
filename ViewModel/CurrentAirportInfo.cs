using ForeflightExercise.Models;

namespace ForeflightExercise.ViewModel
{
    public class CurrentAirportInfo
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public List<Runway> Runways { get; set; }
        public string BestRunway { get; set; }
        public string Latitude {  get; set; }
        public string Longitude { get; set; }
        public WeatherReport WeatherReport { get; set; }

        public CurrentAirportInfo MapAirportInfoToCurrentAirportInfo(WeatherReport weatherReport, AirportData airportData)
        {
            return new CurrentAirportInfo
            {
                Identifier = airportData.Icao,
                Latitude = Math.Round(airportData.Latitude, 2).ToString(),
                Longitude = Math.Round(airportData.Longitude, 2).ToString(),
                Name = airportData.Name,
                Runways = airportData.Runways,
                BestRunway = airportData.BestRunway,
                WeatherReport = weatherReport
            };
        }
    }
}
