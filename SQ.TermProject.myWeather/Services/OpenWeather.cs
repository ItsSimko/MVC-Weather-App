using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class OpenWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "d381eff9c0d0b6a2cc5418ab4a09e2e6";

    public OpenWeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherData> GetWeatherDataAsync(string cityName)
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q=Toronto&appid=d381eff9c0d0b6a2cc5418ab4a09e2e6&units=metric";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<WeatherData>(content);
    }
}

public class WeatherData
{
    // Define properties based on the JSON structure you expect from OpenWeather
    public string Name { get; set; }
}
