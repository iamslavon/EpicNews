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
                "Home_default",
                "Home/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}