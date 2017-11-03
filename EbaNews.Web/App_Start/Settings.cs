using System;
using System.Configuration;

namespace EbaNews.Web
{
    public static class Settings
    {
        public static void Init()
        {
            AllowedNewsCount = Convert.ToInt32(ConfigurationManager.AppSettings["AllowedNewsCount"]);
            AvailableLanguages = ConfigurationManager.AppSettings["AvailableLanguages"].Split(',');
            DefaultLanguage = ConfigurationManager.AppSettings["DefaultLanguage"];
            CookieName = ConfigurationManager.AppSettings["CookieName"];
        }

        public static int AllowedNewsCount { get; private set; }

        public static string[] AvailableLanguages { get; private set; }

        public static string DefaultLanguage { get; private set; }

        public static string CookieName { get; private set; }

        public static string CultureCookieName => $"{CookieName}_culture";
    }
}