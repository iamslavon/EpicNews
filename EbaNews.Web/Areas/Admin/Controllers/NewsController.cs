using AutoMapper;
using EbaNews.Core;
using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces.Services;
using EbaNews.Core.Responses;
using EbaNews.Web.Areas.Admin.Models.News;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EbaNews.Core.Filters;

namespace EbaNews.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class NewsController : BaseController
    {
        private readonly INewsService newsService;
        private readonly ITelegramService telegramService;

        public NewsController(INewsService newsService, ITelegramService telegramService)
        {
            this.newsService = newsService;
            this.telegramService = telegramService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNews(GetNewsFilter filter)
        {
            try
            {
                var serviceResponse = newsService.GetAllNews(filter);

                var response = new PagedResponse<NewsViewModel>
                {
                    Data = Mapper.Map<IEnumerable<NewsViewModel>>(serviceResponse.Data),
                    Total = serviceResponse.Total,
                };

                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return InternalError(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult SwitchOnlineStatus(int newsId, bool online)
        {
            var news = newsService.GetNews(newsId);

            if (news == null) return InternalError("News not found");

            try
            {
                if (online && !news.SocialNetworksPublished)
                {
                    telegramService.PublishAsync(news);
                    news.SocialNetworksPublished = true;
                }

                news.Online = online;
                newsService.EditNews(news);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalError(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AddNews(NewsViewModel model)
        {
            var news = Mapper.Map<News>(model);
            news.PublicationDate = DateTime.Now;

            try
            {
                newsService.AddNews(news);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalError(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult EditNews(NewsViewModel model)
        {
            var news = Mapper.Map<News>(model);

            try
            {
                newsService.EditNews(news);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalError(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = Roles.Owner)]
        public ActionResult DeleteNews(int id)
        {
            try
            {
                newsService.RemoveNews(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalError(ex.Message);
            }
        }
    }
}