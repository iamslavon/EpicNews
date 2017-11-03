using System.Globalization;
using System.Threading;

namespace EbaNews.Web.Helpers
{
    public static class CultureHelper
    {
        public static void SetCulture(string culture)
        {
            var cultureInfo = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        public static string GetUiCulture()
        {
            return Thread.CurrentThread.CurrentUICulture.Name;
        }
    }
}