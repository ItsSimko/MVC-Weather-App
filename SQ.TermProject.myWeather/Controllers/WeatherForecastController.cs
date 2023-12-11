using Microsoft.AspNetCore.Mvc;
using SQ.TermProject.myWeather.Models;

namespace Net6_Controller_And_VIte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly OpenWeatherService _weatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(OpenWeatherService weatherService, ILogger<WeatherForecastController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        [HttpGet("{cityName}")]
        public async Task<IActionResult> GetWeatherByCity(string cityName)
        {
            try
            {
                var weatherData = await _weatherService.GetWeatherDataAsync(cityName);
                return Ok(weatherData);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error fetching weather data");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}