using Newtonsoft.Json;

namespace SQ.TermProject.myWeather.Models.WeatherData
{
    public class Snow
    {
        [JsonProperty("1h")]
        public double _1h { get; set; }
    }
}
