

namespace SQ.TermProject.myWeather.Models.WeatherData
{
    public class WeatherForecast
    {
        public Coordinate coord { get; set; }
        public List<WeatherDescription> weather { get; set; }
        public string @base { get; set; }
        public MainWeatherData main { get; set; }
        public int visibility { get; set; }
        public WindData wind { get; set; }
        public Snow snow { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}