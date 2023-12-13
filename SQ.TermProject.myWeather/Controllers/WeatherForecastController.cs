using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Import for ILogger
using SQ.TermProject.myWeather.Models;
using SQ.TermProject.myWeather.Services;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace SQ.TermProject.myWeather.Controllers
{
    /// <summary>
    /// Controller for retrieving weather forecast information.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly OpenWeatherService _weatherService;
        private StatisticService stats;
        private readonly ILogger<WeatherForecastController> _logger; // Add ILogger

        /// <summary>
        /// Initializes a new instance of the WeatherForecastController class.
        /// </summary>
        /// <param name="logger">The logger to use for logging.</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            stats = new StatisticService();
            _weatherService = new OpenWeatherService();
            _logger = logger; // Intialize the logger
        }

        /// <summary>
        /// Retrieves weather data based on the provided city and country or coordinates.
        /// </summary>
        /// <param name="cityName">The name of the city.</param>
        /// <param name="country">The country code.</param>
        /// <param name="lon">Longitude coordinate.</param>
        /// <param name="lat">Latitude coordinate.</param>
        /// <returns>The IActionResult containing weather data if successful; otherwise, an error response.</returns>
        [HttpPost("GetWeather")]
        public async Task<IActionResult> GetWeatherByCity(string cityName, string country, double lon, double lat)
        {
            try
            {
                var weatherData = await _weatherService.GetWeatherDataAsync(cityName, country, lon, lat);
                stats.UpdateStat($"{cityName}, {country}");

                // Log Informatyion anout the successful operation
                _logger.LogInformation($"Weather data retrieved successfully for {cityName}, {country}");

                return Ok(weatherData);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error fetching weather data");
                _logger.LogError(e, $"Error fetching weather data for {cityName}, {country}");

                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}