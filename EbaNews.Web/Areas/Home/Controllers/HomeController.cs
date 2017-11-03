using EbaNews.Web.Helpers;
using System.Web;
using System.Web.Mvc;

namespace EbaNews.Web.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangeLanguage(string language, string returnUrl)
        {
            CultureHelper.SetCulture(language);
            Response.SetCookie(new HttpCookie(Settings.CultureCookieName, language));

            return Redirect(returnUrl);
        }
    }
}