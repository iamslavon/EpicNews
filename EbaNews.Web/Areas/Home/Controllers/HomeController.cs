using EbaNews.Core.Interfaces.Services;
using EbaNews.Web.Helpers;
using System;
using System.Web;
using System.Web.Mvc;

namespace EbaNews.Web.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService newsService;

        public HomeController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult News(int id)
        {
            try
            {
                var news = newsService.GetNews(id);
                return View(news);
            }
            catch (Exception)
            {
                return RedirectToActionPermanent("Index");
            }
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