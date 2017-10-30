using AutoMapper;
using EbaNews.Core;
using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces.Services;
using EbaNews.Core.Responses;
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
        public ActionResult GetNews(int page, int pageSize)
        {
            try
            {
                var serviceResponse = newsService.GetAllNews(page, pageSize);

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
            try
            {
                newsService.SwitchOnlineStatus(newsId, online);
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