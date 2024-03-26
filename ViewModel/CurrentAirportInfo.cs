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

        public List<CurrentAirportInfo> MapAirportInfoToCurrentAirportInfo(List<WeatherReport> allWeatherReports, List<AirportData> allAirportData)
        {
            var allCurrentAirportInfo = new List<CurrentAirportInfo>();
            
            // I probably should have created an object that held the weather and airport details
            // then I could have used foreach here and not indexes
            for(int i=0;i<allAirportData.Count;i++)
            {
                allCurrentAirportInfo.Add(new CurrentAirportInfo {
                    Identifier = allAirportData[i].Icao,
                    Latitude = Math.Round(allAirportData[i].Latitude, 2).ToString(),
                    Longitude = Math.Round(allAirportData[i].Longitude, 2).ToString(),
                    Name = allAirportData[i].Name,
                    Runways = allAirportData[i].Runways,
                    BestRunway = allAirportData[i].BestRunway,
                    WeatherReport = allWeatherReports[i]
                });
            }

            return allCurrentAirportInfo;
        }
    }
}
