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
                new { area = "Home", controller = "Error", action = "Page404" }
            );

            context.MapRoute(
                "",
                "error",
                new { area = "Home", controller = "Error", action = "DefaultError" }
            );

            context.MapRoute(
                "",
                "",
                new { area = "Home", controller = "Home", action = "Index" }
            );

            context.MapRoute(
                "",
                "language/change",
                new { area = "Home", controller = "Home", action = "ChangeLanguage" }
            );
        }
    }
}