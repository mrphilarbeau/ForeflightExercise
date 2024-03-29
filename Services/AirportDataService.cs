using ForeflightExercise.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ForeflightExercise.Services
{
    public class AirportDataService : IAirportDataService
    {
        /// <summary>
        /// Get airport data based on airport code
        /// </summary>
        /// <param name="airportCode">airport code</param>
        /// <param name="airportDataUrl">URL at forflight to retrieve data from</param>
        /// <returns>Airport data</returns>
        public virtual async Task<AirportData> GetAirportDataByCodeAsync(string airportCode, string airportDataUrl)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(airportDataUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"ff-interview:@-*KzU.*dtP9dkoE7PryL2ojY!uDV.6JJGC9")));
                client.DefaultRequestHeaders.Add("ff-coding-exercise", "1");

                HttpResponseMessage responseMessage = await client.GetAsync(airportCode);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string jsonData = await responseMessage.Content.ReadAsStringAsync();

                    AirportData airportData = JsonSerializer.Deserialize<AirportData>(jsonData, new JsonSerializerOptions(JsonSerializerDefaults.Web));

                    return airportData;
                }

                // TODO: Unsuccessful error handling
                return null;
            }
        }
    }
}
