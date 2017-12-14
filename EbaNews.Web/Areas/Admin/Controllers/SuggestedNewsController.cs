using AutoMapper;
using EbaNews.Core.Interfaces.Services;
using EbaNews.Core.Responses;
using EbaNews.Web.Areas.Admin.Models.SuggestedNews;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EbaNews.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class SuggestedNewsController : BaseController
    {
        private readonly ISuggestedNewsService suggestedNewsService;

        public SuggestedNewsController(ISuggestedNewsService suggestedNewsService)
        {
            this.suggestedNewsService = suggestedNewsService;
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
                var serviceResponse = suggestedNewsService.GetSuggestedNews(page, pageSize);

                var response = new PagedResponse<SuggestedNewsViewModel>
                {
                    Data = Mapper.Map<IEnumerable<SuggestedNewsViewModel>>(serviceResponse.Data),
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
        public ActionResult DeclineNews(int id)
        {
            try
            {
                suggestedNewsService.DeclineSuggestedNews(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalError(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult ApproveNews(int newsId, int languageId, string title)
        {
            try
            {
                suggestedNewsService.ApproveSuggestedNews(newsId, languageId, title);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalError(ex.Message);
            }
        }
    }
}