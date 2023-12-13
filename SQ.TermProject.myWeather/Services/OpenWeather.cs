using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Xsl;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SQ.TermProject.myWeather.Models;

namespace SQ.TermProject.myWeather.Services
{
    /// <summary>
    /// Service to interact with OpenWeather API for weather data retrieval.
    /// </summary>
    public class OpenWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        private static Dictionary<string, Tuple<Forecast, DateTime>> cache = new Dictionary<string, Tuple<Forecast, DateTime>>();
        private TimeSpan expirationTime = TimeSpan.FromSeconds(600); // Expiration time (e.g., 60 seconds)

        /// <summary>
        /// Initializes a new instance of the OpenWeatherService class with an HttpClient.
        /// </summary>
        public OpenWeatherService()
        {
            _apiKey = ConfigService.Configuration["OpenWeatherApiKey"];
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Retrieves weather data asynchronously for a specified city.
        /// </summary>
        /// <param name="cityName">The name of the city for which weather data is requested.</param>
        /// <returns>A task representing the asynchronous operation that yields weather forecast data.</returns>
        public async Task<Forecast> GetWeatherDataAsync(string cityName, string country, double lon, double lat)
        {
            try
            {
                if (cache.ContainsKey(cityName))
                {
                    var (cachedData, timestamp) = cache[cityName];
                    if (DateTime.Now - timestamp < expirationTime)
                    {
                        return cachedData;
                    }
                    else
                    {
                        cache.Remove(cityName); // Remove expired cache entry
                    }
                }

                string url = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=hourly,daily,minutely&appid={_apiKey}&units=metric";
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadFromJsonAsync<Forecast>();

                // Update the cache with the new data
                cache[cityName] = Tuple.Create(content, DateTime.Now);

                return content;
            }
            catch(Exception ex)
            {
                LoggerService.Log("Api Exception Thrown: " + ex.Message);
                return null;
            }

        }
    }

}
