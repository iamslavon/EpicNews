using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces.Services;
using System;
using System.Web.Mvc;
using Strings = EbaNews.Resources.Web.Areas.Api.Controllers.NewsControllerStrings;

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
        public ActionResult GetNews(int start, int count)
        {
            if (count > Settings.AllowedNewsCount)
            {
                return new HttpStatusCodeResult(422, string.Format(Strings.CanNotGetManyNews, Settings.AllowedNewsCount));
            }

            try
            {
                var response = newsService.GetNews(start, count);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult SuggestNews(SuggestedNews news)
        {
            if (news.Title == null || news.LinkToArticle == null)
            {
                return new HttpStatusCodeResult(422, Strings.ParameterMissed);
            }

            try
            {
                suggestedNewsService.AddSuggestedNews(news);
                return new HttpStatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }
    }
}