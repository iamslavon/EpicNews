using AutoMapper;
using EbaNews.Core.Interfaces.Services;
using EbaNews.Core.Responses;
using EbaNews.Web.Areas.Admin.Models.SuggestedNews;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EbaNews.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class SuggestedNewsController : Controller
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
        public JsonResult GetNews(int page, int pageSize)
        {
            var serviceResponse = suggestedNewsService.GetSuggestedNews(page, pageSize);

            var response = new PagedResponse<SuggestedNewsViewModel>
            {
                Data = Mapper.Map<IEnumerable<SuggestedNewsViewModel>>(serviceResponse.Data),
                Total = serviceResponse.Total,
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void DeclineNews(int id)
        {
            suggestedNewsService.DeclineSuggestedNews(id);
        }

        [HttpPost]
        public void ApproveNews(int newsId, int languageId)
        {
            suggestedNewsService.ApproveSuggestedNews(newsId, languageId);
        }
    }
}