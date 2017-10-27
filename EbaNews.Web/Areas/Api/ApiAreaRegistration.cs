using System.Web.Mvc;

namespace EbaNews.Web.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Api";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "",
                "api/news/get",
                new { area = "Api", controller = "News", action = "GetNews" }
            );

            context.MapRoute(
                "",
                "api/news/suggest",
                new { area = "Api", controller = "News", action = "SuggestNews" }
            );
        }
    }
}