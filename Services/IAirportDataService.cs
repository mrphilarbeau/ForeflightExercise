using ForeflightExercise.Models;

namespace ForeflightExercise.Services
{
    public interface IAirportDataService
    {
        Task<AirportData> GetAirportDataByCodeAsync(string airportCode, string airportDataUrl);
    }
}
