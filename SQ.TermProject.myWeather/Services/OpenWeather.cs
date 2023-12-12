using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQ.TermProject.myWeather.Models;
using SQ.TermProject.myWeather.Models.WeatherData;

namespace SQ.TermProject.myWeather.Services
{
    /// <summary>
    /// Service to interact with OpenWeather API for weather data retrieval.
    /// </summary>
    public class OpenWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "d381eff9c0d0b6a2cc5418ab4a09e2e6";

        /// <summary>
        /// Initializes a new instance of the OpenWeatherService class with an HttpClient.
        /// </summary>
        public OpenWeatherService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Retrieves weather data asynchronously for a specified city.
        /// </summary>
        /// <param name="cityName">The name of the city for which weather data is requested.</param>
        /// <returns>A task representing the asynchronous operation that yields weather forecast data.</returns>
        public async Task<WeatherForecast> GetWeatherDataAsync(string cityName)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q="+cityName+"&appid="+_apiKey+"&units=metric";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<WeatherForecast>();
            return content;
        }
    }

}
