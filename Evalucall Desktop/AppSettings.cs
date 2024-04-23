using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Evalucall_Desktop
{
    public class AppSettings
    {
        private IConfigurationRoot _config;

        public AppSettings()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                Console.WriteLine(Directory.GetCurrentDirectory());
                _config = builder.Build();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading appsettings.json: " + ex.Message);
                throw;
            }
        }

        public string GetConnectionString()
        {
            try
            {
                return _config["DatabaseConnection"] ?? "Default Connection String Not Found";
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the connection string: " + ex.Message);
                throw;
            }
        }

        public string ProcessAudioURL()
        {
            try
            {
                return _config["ProcessAudioURL"] ?? "Process Audio URL Not Found";
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the process audio URL: " + ex.Message);
                throw;
            }
        }

        public string ApiStatusURL()
        {
            try
            {
                return _config["ApiStatus"] ?? "Api Status URL Not Found";
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the API status URL: " + ex.Message);
                throw;
            }
        }

        public string GetEmailCred()
        {
            try
            {
                return _config["EmailCred"] ?? "Cred not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the email credential: " + ex.Message);
                throw;
            }
        }

        public string GetPasswordCred()
        {
            try
            {
                return _config["PasswordCred"] ?? "Cred not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the password credential: " + ex.Message);
                throw;
            }
        }

        public string ResetWebsiteURL()
        {
            try
            {
                return _config["ResetWebsiteURL"] ?? "Reset website not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the reset website URL: " + ex.Message);
                throw;
            }
        }
    }
}
