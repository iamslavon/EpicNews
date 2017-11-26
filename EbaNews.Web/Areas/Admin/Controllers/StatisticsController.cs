using System;
using EbaNews.Core.Interfaces.Services;
using System.Web.Mvc;

namespace EbaNews.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class StatisticsController : BaseController
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        public ActionResult GetNewsCountByLanguages()
        {
            try
            {
                var statistics = statisticsService.GetNewsCountByLanguages();
                return Json(statistics, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return InternalError(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult GetSuggestedNewsCount()
        {
            try
            {
                var count = statisticsService.GetSuggestedNewsCount();
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return InternalError(ex.Message);
            }
        }
    }
}