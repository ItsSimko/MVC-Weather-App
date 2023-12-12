using Newtonsoft.Json;

namespace SQ.TermProject.myWeather.Models.WeatherData
{
    /// <summary>
    /// Represents geographic coordinates (longitude and latitude).
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Gets or sets the longitude coordinate.
        /// </summary>
        [JsonProperty("lon")]
        public double Lon { get; set; }

        /// <summary>
        /// Gets or sets the latitude coordinate.
        /// </summary>
        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}
