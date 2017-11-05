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
                "api/newslist/get",
                new { area = AreaName, controller = "News", action = "GetNewsList" }
            );

            context.MapRoute(
                "",
                "api/news/get",
                new { area = AreaName, controller = "News", action = "GetNews" }
            );

            context.MapRoute(
                "",
                "api/news/suggest",
                new { area = AreaName, controller = "News", action = "SuggestNews" }
            );
        }
    }
}