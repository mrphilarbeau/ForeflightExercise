using ForeflightExercise.Models;

namespace ForeflightExercise.Services
{
    public interface IWeatherService
    {
        Task<WeatherReport> GetWeatherReportByAirportCodeAsync(string airportCode, string weatherReportUrl);
    }
}
