using EbaNews.Resources.Web.Areas.Home;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace EbaNews.Web.Areas.Home.Controllers
{
    public class FrontLocalizeController : Controller
    {
        [HttpGet]
        public ActionResult GetLocalizedStrings()
        {
            var strings = FrontStrings
                .ResourceManager
                .GetResourceSet(Thread.CurrentThread.CurrentUICulture, true, true)
                .Cast<DictionaryEntry>()
                .ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());

            return Json(strings, JsonRequestBehavior.AllowGet);
        }
    }
}