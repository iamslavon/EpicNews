﻿using EbaNews.Ioc;
using EbaNews.Web.Helpers;
using EbaNews.Web.Mapping;
using NLog;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EbaNews.Web
{
    public class MvcApplication : HttpApplication
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IocContainer.Initialize();
            AutoMapperConfig.Register();
            Settings.Init();
        }

        protected void Application_BeginRequest()
        {
            var culture = Request.Cookies[Settings.CultureCookieName]?.Value;

            if (culture == null)
            {
                var browserLanguages = Request.UserLanguages;

                if (browserLanguages != null && browserLanguages.Length > 0)
                {
                    culture = browserLanguages[0].Substring(0, 2);
                }
                else
                {
                    culture = Settings.DefaultCulture;
                }

                Response.SetCookie(new HttpCookie(Settings.CultureCookieName, culture));
            }

            CultureHelper.SetCulture(culture);
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            logger.Error(exception);
        }
    }
}
