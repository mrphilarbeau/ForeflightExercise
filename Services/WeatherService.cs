using ForeflightExercise.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ForeflightExercise.Services
{
    public class WeatherService : IWeatherService
    {
        /// <summary>
        /// Gets weather report for a specific airport
        /// </summary>
        /// <param name="airportCode">airport code</param>
        /// <param name="weatherReportUrl">URL at foreflight to pull data from</param>
        /// <returns>Airport Weather Report</returns>
        public virtual async Task<WeatherReport> GetWeatherReportByAirportCodeAsync(string airportCode, string weatherReportUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(weatherReportUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("ff-coding-exercise", "1");

                HttpResponseMessage responseMessage = await client.GetAsync(airportCode);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string jsonData = await responseMessage.Content.ReadAsStringAsync();

                    WeatherReport weatherReport = JsonSerializer.Deserialize<WeatherReport>(jsonData, new JsonSerializerOptions(JsonSerializerDefaults.Web));

                    return weatherReport;
                }

                // TODO: Unsuccessful error handling
                return null;
            }
        }
    }
}
