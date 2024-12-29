using Microsoft.Extensions.Configuration;
using System.IO;

namespace AnimeDL
{
    public class SettingsManager
    {
        private IConfigurationRoot configuration;

        public SettingsManager()
        {
            configuration = LoadSettings();
        }

        public IConfigurationRoot Configuration => configuration;

        private static IConfigurationRoot LoadSettings()
        {
            var settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "settings.json");

            if (!File.Exists(settingsFilePath))
            {
                // Create default settings
                var defaultSettings = new
                {
                    AniwatchSettings = new
                    {
                        Protocol = "http://",
                        Address = "localhost",
                        Port = "4000"
                    },
                    FFmpeg = new
                    {
                        Path = "C:\\ffmpeg\\bin\\ffmpeg.exe"
                    },
                    General = new
                    {
                        DefaultLanguage = "Dub"
                    }
                };

                var defaultJson = System.Text.Json.JsonSerializer.Serialize(defaultSettings, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(settingsFilePath, defaultJson);
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        public static void SaveSettings(string protocol, string address, string port, string ffmpegPath, string defaultLanguage)
        {
            var aniwatchSettings = new
            {
                Protocol = protocol,
                Address = address,
                Port = port
            };

            var ffmpegSettings = new
            {
                Path = ffmpegPath
            };

            var generalSettings = new
            {
                DefaultLanguage = defaultLanguage
            };

            var settings = new
            {
                AniwatchSettings = aniwatchSettings,
                FFmpeg = ffmpegSettings,
                General = generalSettings
            };

            var json = System.Text.Json.JsonSerializer.Serialize(settings, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("settings.json", json);
        }
    }
}
