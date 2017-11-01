using System;

namespace EbaNews.Web
{
    public static class Settings
    {
        public static void Init()
        {
            AllowedNewsCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["AllowedNewsCount"]);
            DefaultCulture = System.Configuration.ConfigurationManager.AppSettings["DefaultCulture"];
            CookieName = System.Configuration.ConfigurationManager.AppSettings["CookieName"];
        }

        public static int AllowedNewsCount { get; set; }

        public static string DefaultCulture { get; set; }

        public static string CookieName { get; set; }
    }
}