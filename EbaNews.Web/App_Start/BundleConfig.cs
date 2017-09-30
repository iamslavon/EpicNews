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
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                        "~/Scripts/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/admin-css").Include(
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
