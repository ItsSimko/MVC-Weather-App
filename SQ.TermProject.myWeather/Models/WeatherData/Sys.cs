namespace SQ.TermProject.myWeather.Models.WeatherData
{
    /// <summary>
    /// Represents system-related weather data, including country and sunrise/sunset times.
    /// </summary>
    public class Sys
    {
        /// <summary>
        /// Gets or sets the type of weather data.
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the weather data.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the country code for the location.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the sunrise time.
        /// </summary>
        public int Sunrise { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the sunset time.
        /// </summary>
        public int Sunset { get; set; }
    }
}
