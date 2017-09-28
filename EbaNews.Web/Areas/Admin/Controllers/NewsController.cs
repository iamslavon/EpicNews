using AutoMapper;
using EbaNews.Core;
using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces.Services;
using EbaNews.Web.Areas.Admin.Models.News;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EbaNews.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class NewsController : BaseController
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetNews(int page, int pageSize)
        {
            var serviceResponse = newsService.GetNews(page, pageSize);

            var response = new PagedResponse<NewsViewModel>
            {
                Data = Mapper.Map<IEnumerable<NewsViewModel>>(serviceResponse.Data),
                Total = serviceResponse.Total,
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SwitchOnlineStatus(int newsId, bool online)
        {
            newsService.SwitchOnlineStatus(newsId, online);
        }

        [HttpPost]
        public JsonResult AddNews(NewsViewModel model)
        {
            var news = Mapper.Map<News>(model);
            news.PublicationDate = DateTime.Now;
            var id = newsService.AddNews(news);

            return Json(id);
        }

        [HttpPost]
        public void EditNews(NewsViewModel model)
        {
            var news = Mapper.Map<News>(model);
            newsService.EditNews(news);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Owner)]
        public void DeleteNews(int id)
        {
            newsService.RemoveNews(id);
        }
    }
}