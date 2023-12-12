using Newtonsoft.Json;

namespace SQ.TermProject.myWeather.Models.WeatherData
{
    /// <summary>
    /// Represents cloudiness data in weather information.
    /// </summary>
    public class Clouds
    {
        /// <summary>
        /// Gets or sets the percentage of cloudiness.
        /// </summary>
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
