using ForeflightExercise.Services;
using ForeflightExercise.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ForeflightExercise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportInfoController : ControllerBase
    {
        private readonly IAirportInfoService _airportInfoService;

        public AirportInfoController(IAirportInfoService airportInfoService)
        {
            _airportInfoService = airportInfoService;
        }

        /// <summary>
        /// Takes a comma delimited list of airport codes and gathers the data for each airport and weather at
        /// each location and returns it to the client
        /// </summary>
        /// <param name="airportList">Comma delimted list of airport codes</param>
        /// <returns>Current airport data with weather report</returns>
        [HttpGet]
        public async Task<List<CurrentAirportInfo>> Get(string airportList)
        {
            if (string.IsNullOrWhiteSpace(airportList))
            {
                return null;
            }

            var currentAirportInfo = await _airportInfoService.GetAirportInfoByAirportCodesAsync(airportList);
            return currentAirportInfo;
        }
    }
}
