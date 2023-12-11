using Microsoft.AspNetCore.Mvc;
using SQ.TermProject.myWeather.Models;
using SQ.TermProject.myWeather.Services;

namespace SQ.TermProject.myWeather.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly OpenWeatherService _weatherService;
        //private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController()
        {
            _weatherService = new OpenWeatherService();
            //_logger = logger;
        }

        [HttpPost("GetWeather")]
        public async Task<IActionResult> GetWeatherByCity(string cityName)
        {
            try
            {
                var weatherData = await _weatherService.GetWeatherDataAsync(cityName);
                return Ok(weatherData);
            }
            catch (Exception e)
            {
                //_logger.LogError(e, "Error fetching weather data");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}