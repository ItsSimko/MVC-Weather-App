using Newtonsoft.Json;

namespace SQ.TermProject.myWeather.Models.WeatherData
{
    /// <summary>
    /// Represents weather description details.
    /// </summary>
    public class WeatherDescription
    {
        /// <summary>
        /// Gets or sets the weather condition ID.
        /// </summary>
        [JsonProperty]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the main weather description.
        /// </summary>
        public string Main { get; set; }

        /// <summary>
        /// Gets or sets the detailed weather description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the icon ID for the weather condition.
        /// </summary>
        public string Icon { get; set; }
    }
}
