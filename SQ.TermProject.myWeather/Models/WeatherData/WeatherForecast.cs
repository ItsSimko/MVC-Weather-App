

namespace SQ.TermProject.myWeather.Models.WeatherData
{
    /// <summary>
    /// Represents weather forecast data containing various weather-related information.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the coordinates of the location.
        /// </summary>
        public Coordinate Coord { get; set; }

        /// <summary>
        /// Gets or sets the weather description list.
        /// </summary>
        public List<WeatherDescription> Weather { get; set; }

        /// <summary>
        /// Gets or sets the base information.
        /// </summary>
        public string Base { get; set; }

        /// <summary>
        /// Gets or sets the main weather data.
        /// </summary>
        public MainWeatherData Main { get; set; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        public int Visibility { get; set; }

        /// <summary>
        /// Gets or sets the wind data.
        /// </summary>
        public WindData Wind { get; set; }

        /// <summary>
        /// Gets or sets the snow data.
        /// </summary>
        public Snow Snow { get; set; }

        /// <summary>
        /// Gets or sets the cloud data.
        /// </summary>
        public Clouds Clouds { get; set; }

        /// <summary>
        /// Gets or sets the date and time.
        /// </summary>
        public int Dt { get; set; }

        /// <summary>
        /// Gets or sets the system information.
        /// </summary>
        public Sys Sys { get; set; }

        /// <summary>
        /// Gets or sets the timezone.
        /// </summary>
        public int Timezone { get; set; }

        /// <summary>
        /// Gets or sets the city ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the city name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        public int Cod { get; set; }
    }
}