using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces.Services;
using System.Web.Mvc;
using EbaNews.Core.Enums;

namespace EbaNews.Web.Areas.Api.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService newsService;
        private readonly ISuggestedNewsService suggestedNewsService;

        public NewsController(INewsService newsService, ISuggestedNewsService suggestedNewsService)
        {
            this.newsService = newsService;
            this.suggestedNewsService = suggestedNewsService;
        }

        [HttpGet]
        public JsonResult GetNews(int start, int count)
        {
            var response = newsService.GetNews(start, count);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SuggestNews(SuggestedNews news)
        {
            suggestedNewsService.AddSuggestedNews(news);
        }
    }
}