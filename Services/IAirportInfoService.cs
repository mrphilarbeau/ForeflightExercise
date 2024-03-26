using ForeflightExercise.ViewModel;

namespace ForeflightExercise.Services
{
    public interface IAirportInfoService
    {
        Task<List<CurrentAirportInfo>> GetAirportInfoByAirportCodesAsync(string airportCodes);
    }
}
