namespace SQ.TermProject.myWeather.Models
{
    /// <summary>
    /// Represents the current weather data.
    /// </summary>
    public class Current
    {
        /// <summary>
        /// Time of data calculation, Unix, UTC.
        /// </summary>
        public int dt { get; set; }

        /// <summary>
        /// Sunrise time, Unix, UTC.
        /// </summary>
        public int sunrise { get; set; }

        /// <summary>
        /// Sunset time, Unix, UTC.
        /// </summary>
        public int sunset { get; set; }

        /// <summary>
        /// Temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        public double temp { get; set; }

        /// <summary>
        /// This temperature parameter accounts for the human perception of weather.
        /// Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        public double feels_like { get; set; }

        /// <summary>
        /// Atmospheric pressure on the sea level, hPa.
        /// </summary>
        public int pressure { get; set; }

        /// <summary>
        /// Humidity, %.
        /// </summary>
        public int humidity { get; set; }

        /// <summary>
        /// Atmospheric temperature below which water droplets begin to condense and dew can form.
        /// Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        public double dew_point { get; set; }

        /// <summary>
        /// The UV index.
        /// </summary>
        public double uvi { get; set; }

        /// <summary>
        /// Cloudiness, %.
        /// </summary>
        public int clouds { get; set; }

        /// <summary>
        /// Visibility, meters.
        /// </summary>
        public int visibility { get; set; }

        /// <summary>
        /// Wind speed. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        /// </summary>
        public double wind_speed { get; set; }

        /// <summary>
        /// Wind direction, degrees (meteorological).
        /// </summary>
        public int wind_deg { get; set; }

        /// <summary>
        /// Wind gust. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        /// </summary>
        public double wind_gust { get; set; }

        /// <summary>
        /// Weather conditions.
        /// </summary>
        public List<Weather> weather { get; set; }
    }

    /// <summary>
    /// Represents the minutely weather forecast.
    /// </summary>
    public class Minutely
    {
        /// <summary>
        /// Time of the forecasted data, Unix, UTC.
        /// </summary>
        public int dt { get; set; }

        /// <summary>
        /// Precipitation volume, mm.
        /// </summary>
        public int precipitation { get; set; }
    }

    /// <summary>
    /// Represents the weather forecast data.
    /// </summary>
    public class Forecast
    {
        /// <summary>
        /// Geographic coordinates of the location (latitude).
        /// </summary>
        public double lat { get; set; }

        /// <summary>
        /// Geographic coordinates of the location (longitude).
        /// </summary>
        public double lon { get; set; }

        /// <summary>
        /// Timezone name for the requested location.
        /// </summary>
        public string timezone { get; set; }

        /// <summary>
        /// Shift in seconds from UTC.
        /// </summary>
        public int timezone_offset { get; set; }

        /// <summary>
        /// Current weather data.
        /// </summary>
        public Current current { get; set; }

        /// <summary>
        /// Minutely forecast data.
        /// </summary>
        public List<Minutely> minutely { get; set; }
    }

    /// <summary>
    /// Represents weather information.
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Weather condition ID.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Group of weather parameters (Rain, Snow, Extreme etc.).
        /// </summary>
        public string main { get; set; }

        /// <summary>
        /// Weather condition within the group.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Weather icon ID.
        /// </summary>
        public string icon { get; set; }
    }
}