using System;
using System.Configuration;

namespace EbaNews.Web
{
    public static class Settings
    {
        public static string ContactEmail { get; private set; }

        public static int AllowedNewsCount { get; private set; }

        public static string[] AvailableCultures { get; private set; }

        public static string DefaultCulture { get; private set; }

        public static string CookieName { get; private set; }

        public static string CultureCookieName => $"{CookieName}_culture";

        public static string TelegramApiToken { get; private set; }

        public static string TelegramPublicChannelId { get; private set; }

        public static string TelegramSuggestionChannelId { get; private set; }

        public static void Init()
        {
            ContactEmail = ConfigurationManager.AppSettings["ContactEmail"];
            AllowedNewsCount = Convert.ToInt32(ConfigurationManager.AppSettings["AllowedNewsCount"]);
            AvailableCultures = ConfigurationManager.AppSettings["AvailableCultures"].Split(',');
            DefaultCulture = ConfigurationManager.AppSettings["DefaultCulture"];
            CookieName = ConfigurationManager.AppSettings["CookieName"];
            TelegramApiToken = ConfigurationManager.AppSettings["TelegramApiToken"];
            TelegramPublicChannelId = ConfigurationManager.AppSettings["TelegramPublicChannelId"];
            TelegramSuggestionChannelId = ConfigurationManager.AppSettings["TelegramSuggestionChannelId"];
        }
    }
}