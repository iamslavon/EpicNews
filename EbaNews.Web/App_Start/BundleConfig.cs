using System.Web.Optimization;

namespace EbaNews.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
            bundles
                .RegisterHomeBundles()
                .RegisterAdminBundles()
                .RegisterAdminRouteBundles();
        }

        private static BundleCollection RegisterHomeBundles(this BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/libs/home").Include(
                "~/Scripts/Libs/jquery-3.1.1.min.js",
                "~/Scripts/Libs/moment.min.js",
                "~/Scripts/Libs/angular.min.js",
                "~/Scripts/Libs/bootstrap.min.js",
                "~/Scripts/Libs/respond.js",
                "~/Scripts/Libs/ng-notify.min.js",
                "~/Scripts/Libs/angular-clipboard.js",
                "~/Scripts/Libs/angular-socialshare.min.js"));

            bundles.Add(new Bundle("~/app/home")
                .IncludeDirectory("~/Scripts/Areas/Home", "*.js", true)
                .IncludeDirectory("~/Scripts/Services", "*.js", true));

            bundles.Add(new StyleBundle("~/css/home").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/Home.css",
                "~/Content/shared.css",
                "~/Content/ng-notify.min.css"));

            return bundles;
        }

        private static BundleCollection RegisterAdminBundles(this BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/libs/admin").Include(
                "~/Scripts/Libs/jquery-3.1.1.min.js",
                "~/Scripts/Libs/moment.min.js",
                "~/Scripts/Libs/angular.min.js",
                "~/Scripts/Libs/modernizr-*",
                "~/Scripts/Libs/bootstrap.min.js",
                "~/Scripts/Libs/respond.js",
                "~/Scripts/Libs/ng-notify.min.js"));

            bundles.Add(new ScriptBundle("~/app/admin").Include(
                "~/Scripts/Areas/Admin/app.js"));

            bundles.Add(new StyleBundle("~/css/admin").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/Admin.css",
                "~/Content/shared.css",
                "~/Content/ng-notify.min.css"));

            return bundles;
        }

        // Register scripts for pages here

        private static BundleCollection RegisterAdminRouteBundles(this BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/admin/news").IncludeDirectory(
                "~/Scripts/Areas/Admin/News", "*.js", true));

            bundles.Add(new Bundle("~/admin/news/suggested").IncludeDirectory(
                "~/Scripts/Areas/Admin/SuggestedNews", "*.js", true));

            bundles.Add(new Bundle("~/admin/users").IncludeDirectory(
                "~/Scripts/Areas/Admin/Users", "*.js", true));

            return bundles;
        }
    }
}
