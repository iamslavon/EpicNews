using System;

namespace EbaNews.Web
{
    public static class Settings
    {
        public static int AllowedNewsCount { get; set; }

        public static void Init()
        {
            AllowedNewsCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["AllowedNewsCount"]);
        }
    }
}