using AutoMapper;
using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces.Services;
using EbaNews.Core.Responses;
using EbaNews.Web.Areas.Api.Models;
using EbaNews.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Strings = EbaNews.Resources.Web.Areas.Api.Controllers.NewsControllerStrings;

namespace EbaNews.Web.Areas.Api.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService newsService;
        private readonly ISuggestedNewsService suggestedNewsService;
        private readonly ITelegramService telegramService;

        public NewsController(INewsService newsService, ISuggestedNewsService suggestedNewsService, ITelegramService telegramService)
        {
            this.newsService = newsService;
            this.suggestedNewsService = suggestedNewsService;
            this.telegramService = telegramService;
        }

        [HttpGet]
        public ActionResult GetNews(int id)
        {
            try
            {
                var news = newsService.GetNews(id);
                var newsModel = Mapper.Map<ExtendedNewsModel>(news);
                return Json(newsModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetNewsList(int start, int count, string culture)
        {
            if (count > Settings.AllowedNewsCount)
                return new HttpStatusCodeResult(422, string.Format(Strings.CanNotGetManyNews, Settings.AllowedNewsCount));

            if (culture == null)
                culture = CultureHelper.GetUiCulture();

            if (!Settings.AvailableCultures.Contains(culture))
                culture = Settings.DefaultCulture;

            try
            {
                var serviceResponse = newsService.GetNewsList(start, count, culture);

                var response = new PagedResponse<NewsModel>
                {
                    Total = serviceResponse.Total,
                    Data = Mapper.Map<List<NewsModel>>(serviceResponse.Data)
                };

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
            if (news.LinkToArticle == null)
            {
                return new HttpStatusCodeResult(422, Strings.ParameterMissed);
            }

            try
            {
                news.Ip = GetIpAddress();
                news.Title = suggestedNewsService.TryGetTitleFromUrl(news.LinkToArticle);
                suggestedNewsService.AddSuggestedNews(news);
                SuggestionNotify(news);

                return new HttpStatusCodeResult(200);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult IncrementShareCount(int id)
        {
            newsService.IncrementShareCount(id);
            return new HttpStatusCodeResult(200);
        }

        private void SuggestionNotify(SuggestedNews news)
        {
            telegramService.SendAsync(Settings.TelegramSuggestionChannelId, news.LinkToArticle);
        }

        private string GetIpAddress()
        {
            var context = System.Web.HttpContext.Current;
            var ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            return string.IsNullOrEmpty(ipAddress)
                ? context.Request.ServerVariables["REMOTE_ADDR"]
                : ipAddress.Split(',')[0];
        }
    }
}