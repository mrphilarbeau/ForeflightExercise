namespace ForeflightExercise.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _configuration;

        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataAccess() { }

        public virtual string GetWeatherReportUrl()
        {
            var weatherReportUrl = _configuration.GetValue<string>("AppSettings:WeatherReportUrl");

            return weatherReportUrl;
        }

        public virtual string GetAirportDataUrl()
        {
            var airportDataUrl = _configuration.GetValue<string>("AppSettings:AirportDataUrl");

            return airportDataUrl;
        }
    }
}
