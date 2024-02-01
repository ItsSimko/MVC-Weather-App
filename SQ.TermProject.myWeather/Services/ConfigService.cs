namespace SQ.TermProject.myWeather.Services
{
    public class ConfigService
    {
        public static string ConfigPath = ".\\appsettings.Development.json";
        public static IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile(ConfigPath, optional: false, reloadOnChange: true)
                .Build();

        
    }
}
