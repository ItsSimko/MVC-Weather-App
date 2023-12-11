using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQ.TermProject.myWeather.Models;

namespace SQ.TermProject.myWeather.Services
{
    public class OpenWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "d381eff9c0d0b6a2cc5418ab4a09e2e6";

        public OpenWeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<dynamic> GetWeatherDataAsync(string cityName)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q="+cityName+"&appid=d381eff9c0d0b6a2cc5418ab4a09e2e6&units=metric";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }

}
