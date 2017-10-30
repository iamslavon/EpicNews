using System.Collections.Generic;
using System.Web.Mvc;

namespace EbaNews.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected void AddModelErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected void AddModelError(string error)
        {
            ModelState.AddModelError("", error);
        }

        protected HttpStatusCodeResult Ok()
        {
            return new HttpStatusCodeResult(200);
        }

        protected HttpStatusCodeResult InternalError(string message)
        {
            return new HttpStatusCodeResult(500, message);
        }
    }
}