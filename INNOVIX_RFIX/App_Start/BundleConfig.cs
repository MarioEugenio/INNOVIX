using System.Web;
using System.Web.Optimization;

namespace INNOVIX_RFIX
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Web/js/Externals/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                        "~/Web/js/core.js",
                        "~/Web/js/bootstrap.js",
                        "~/Web/js/modal.js"));

            bundles.Add(new ScriptBundle("~/bundles/routers").Include(
                        "~/Web/js/Routers/*-router.js"));

            bundles.Add(new ScriptBundle("~/bundles/login/routers").Include(
                        "~/Web/js/Routers/login.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                        "~/Web/js/Src/*-ctrl.js"));

            bundles.Add(new ScriptBundle("~/bundles/login/controllers").Include(
                        "~/Web/js/Src/login-init.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Web/js/Externals/jquery/jquery-ui-{version}.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Web/js/Externals/angular/angular.js",
                        "~/Web/js/Externals/angular/strap/dist/angular-strap.js",
                        "~/Web/js/Externals/angular/ui/ui-bootstrap.js",
                        "~/Web/js/Externals/angular/angular-router.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Web/css/bootstrap.css",
                "~/Web/css/bootstrap-theme.css",
                "~/Web/css/navbar.css"));
        }
    }
}