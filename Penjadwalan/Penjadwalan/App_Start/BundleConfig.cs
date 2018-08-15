using System.Web;
using System.Web.Optimization;

namespace Penjadwalan
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                   "~/bower_components/bootstrap/dist/js/bootstrap.min.js",
                       "~/build/js/custom.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/assets/js/app.js",
                "~/assets/js/routes.js",
                "~/assets/js/services.js",
                "~/assets/js/controllers.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
               "~/bower_components/font-awesome/css/font-awesome.min.css",
                "~/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      "~/build/css/custom.min.css"));
        }
    }
}
