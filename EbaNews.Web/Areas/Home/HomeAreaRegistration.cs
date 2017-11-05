using System.Web.Mvc;

namespace EbaNews.Web.Areas.Home
{
    public class HomeAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Home";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "",
                "404",
                new { area = AreaName, controller = "Error", action = "Page404" }
            );

            context.MapRoute(
                "",
                "error",
                new { area = AreaName, controller = "Error", action = "DefaultError" }
            );

            context.MapRoute(
                "",
                "",
                new { area = AreaName, controller = "Home", action = "Index" }
            );

            context.MapRoute(
                "",
                "news/{id}",
                new { area = AreaName, controller = "Home", action = "News" }
            );

            context.MapRoute(
                "",
                "language/change",
                new { area = AreaName, controller = "Home", action = "ChangeLanguage" }
            );
        }
    }
}