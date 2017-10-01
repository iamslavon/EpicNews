using System.Web.Optimization;

namespace EbaNews.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
            bundles.Add(new ScriptBundle("~/libs/admin").Include(
                        "~/Scripts/Libs/jquery-3.1.1.min.js",
                        "~/Scripts/Libs/moment.min.js",
                        "~/Scripts/Libs/angular.min.js",
                        "~/Scripts/Libs/modernizr-*",
                        "~/Scripts/Libs/bootstrap.min.js",
                        "~/Scripts/Libs/respond.js"));

            bundles.Add(new ScriptBundle("~/app/admin").Include(
                        "~/Scripts/Areas/Admin/app.js"));

            bundles.Add(new StyleBundle("~/css/admin").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/Admin.css",
                      "~/Content/shared.css"));

            RegisterRouteBundles(bundles);
        }

        // Register scripts for pages here
        private static void RegisterRouteBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/admin/news").IncludeDirectory(
                "~/Scripts/Areas/Admin/News", "*.js", true));

            bundles.Add(new Bundle("~/admin/news/suggested").IncludeDirectory(
                "~/Scripts/Areas/Admin/SuggestedNews", "*.js", true));

            bundles.Add(new Bundle("~/admin/users").IncludeDirectory(
                "~/Scripts/Areas/Admin/Users", "*.js", true));
        }
    }
}
