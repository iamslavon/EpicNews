using System.Web.Mvc;

namespace EbaNews.Web.Areas.Home.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ActionResult DefaultError()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}