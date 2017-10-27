using System.Web.Mvc;

namespace EbaNews.Web.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}