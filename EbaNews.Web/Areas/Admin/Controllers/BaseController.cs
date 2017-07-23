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
    }
}