using System;
using System.Configuration;

namespace EbaNews.Web
{
    public static class Settings
    {
        public static int AllowedNewsCount { get; private set; }

        public static string[] AvailableCultures { get; private set; }

        public static string DefaultCulture { get; private set; }

        public static string CookieName { get; private set; }

        public static string CultureCookieName => $"{CookieName}_culture";

        public static void Init()
        {
            AllowedNewsCount = Convert.ToInt32(ConfigurationManager.AppSettings["AllowedNewsCount"]);
            AvailableCultures = ConfigurationManager.AppSettings["AvailableCultures"].Split(',');
            DefaultCulture = ConfigurationManager.AppSettings["DefaultCulture"];
            CookieName = ConfigurationManager.AppSettings["CookieName"];
        }
    }
}