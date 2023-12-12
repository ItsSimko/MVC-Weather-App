using Newtonsoft.Json;

namespace SQ.TermProject.myWeather.Models.WeatherData
{
    /// <summary>
    /// Represents snow-related information in the weather data.
    /// </summary>
    public class Snow
    {
        /// <summary>
        /// Gets or sets the snow volume for the last hour.
        /// </summary>
        [JsonProperty("1h")]
        public double LastHour { get; set; }
    }
}
