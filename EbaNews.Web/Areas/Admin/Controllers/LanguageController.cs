using EbaNews.Core.Interfaces.Services;
using System.Web.Mvc;

namespace EbaNews.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class LanguageController : BaseController
    {
        private readonly ILanguageService languageService;

        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }

        [HttpGet]
        public JsonResult GetLanguages()
        {
            var languages = languageService.GetLanguages();

            return Json(languages, JsonRequestBehavior.AllowGet);
        }
    }
}