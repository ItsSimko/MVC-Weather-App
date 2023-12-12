namespace SQ.TermProject.myWeather.Services
{
    public class ConfigService
    {
        public static string ConfigPath = "C:\\Users\\alexs\\source\\repos\\SQ.TermProject.myWeather\\SQ.TermProject.myWeather\\appsettings.Development.json";
        public static IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile(ConfigPath, optional: false, reloadOnChange: true)
                .Build();

        
    }
}
