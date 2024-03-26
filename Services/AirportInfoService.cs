using ForeflightExercise.Models;
using ForeflightExercise.ViewModel;

namespace ForeflightExercise.Services
{
    public class AirportInfoService : IAirportInfoService
    {
        private readonly IDataAccess _dataAccess;
        private readonly IWeatherService _weatherService;
        private readonly IAirportDataService _airportDataService;

        public AirportInfoService(IDataAccess dataAccess, IWeatherService weatherService, IAirportDataService airportDataService) 
        {
            _dataAccess = dataAccess;
            _weatherService = weatherService;
            _airportDataService = airportDataService;
        }

        public async Task<List<CurrentAirportInfo>> GetAirportInfoByAirportCodesAsync(string airportCodes)
        {
            var weatherReportUrl = _dataAccess.GetWeatherReportUrl();
            var airportDataUrl = _dataAccess.GetAirportDataUrl();

            var allWeatherReports = new List<WeatherReport>();
            var allAirportData = new List<AirportData>();

            foreach (var airportCode in airportCodes.Split(','))
            {
                var weatherReport = await _weatherService.GetWeatherReportByAirportCodeAsync(airportCode, weatherReportUrl);
                var airportData = await _airportDataService.GetAirportDataByCodeAsync(airportCode, airportDataUrl);
                airportData.BestRunway = DetermineBestRunway(weatherReport.Report.Conditions.Wind.Direction, airportData.Runways);
                allWeatherReports.Add(weatherReport);
                allAirportData.Add(airportData);
            }
            
            return new CurrentAirportInfo().MapAirportInfoToCurrentAirportInfo(allWeatherReports, allAirportData); 
        }

        private string DetermineBestRunway(int windDirection, List<Runway> runways)
        {
            var runwayWindMap = new Dictionary<string, int>();

            foreach (var runway in runways)
            {
                var runwayDegrees = int.Parse(runway.Name) * 10;
                var recipRunwayDegrees = int.Parse(runway.RecipName) * 10;
                runwayWindMap.Add(runway.Name, runwayDegrees > windDirection ? runwayDegrees - windDirection : windDirection - runwayDegrees);
                runwayWindMap.Add(runway.RecipName, recipRunwayDegrees > windDirection ? recipRunwayDegrees - windDirection : windDirection - recipRunwayDegrees);
            }

            return runwayWindMap.OrderBy(x => x.Value).ToList().FirstOrDefault().Key;
        }
    }
}
