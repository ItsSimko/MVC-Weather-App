using System;
using System.IO;

namespace SQ.TermProject.myWeather.Services
{
    public static class LoggerService
    {
        private static string logFilePath = "./log.txt";

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    string logMessage = $"{DateTime.Now} - {message}";
                    writer.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}

