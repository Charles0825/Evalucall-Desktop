using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Evalucall_Desktop
{
    public class AppSettings
    {
        private readonly IConfigurationRoot _config;
        private static readonly HttpClient _httpClient = new HttpClient();

        private AppSettings(IConfigurationRoot config)
        {
            _config = config;
        }

        public static async Task<AppSettings> CreateAsync()
        {
            try
            {
                // Fetch the JSON data from the direct URL
                string jsonData = await FetchJsonFromGitHubAsync();

                // Parse JSON data into IConfigurationRoot
                var builder = new ConfigurationBuilder()
                    .AddJsonStream(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonData)));
                var config = builder.Build();

                return new AppSettings(config);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while initializing AppSettings: " + ex.Message);
                throw;
            }
        }

        private static async Task<string> FetchJsonFromGitHubAsync()
        {
            // Direct URL to the JSON configuration file
            string directUrl = "https://raw.githubusercontent.com/Charles0825/evalucall-data/main/appsettings.json";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(directUrl);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching JSON from GitHub: {ex.Message}");
                throw;
            }
        }

        public string GetConnectionString() => _config["DatabaseConnection"] ?? "Default Connection String Not Found";
        public string ProcessAudioURL() => _config["ProcessAudioURL"] ?? "Process Audio URL Not Found";
        public string ApiStatusURL() => _config["ApiStatus"] ?? "Api Status URL Not Found";
        public string GetEmailCred() => _config["EmailCred"] ?? "Cred not found";
        public string GetPasswordCred() => _config["PasswordCred"] ?? "Cred not found";
        public string ResetWebsiteURL() => _config["ResetWebsiteURL"] ?? "Reset website not found";
    }
}
