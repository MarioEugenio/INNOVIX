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
                        "~/Web/js/Externals/jquery/jquery*"));

            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                        "~/Web/js/core.js",
                        "~/Web/js/bootstrap.js",
                        "~/Web/js/directives.js",
                        "~/Web/js/loading.js",
                        "~/Web/js/utils.js",
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
                        "~/Web/js/Externals/angular/angular-select.js",
                        "~/Web/js/Externals/angular/strap/dist/angular-strap.js",
                        "~/Web/js/Externals/angular/ui/ui-bootstrap.js",
                        "~/Web/js/Externals/angular/angular-router.js"/*,
                        "~/Web/js/Externals/htmltable_export/jsPDF0.9/jspdf.js",
                        "~/Web/js/Externals/htmltable_export/jsPDF0.9/jspdf.plugin.standard_fonts_metrics.js",
                        "~/Web/js/Externals/htmltable_export/jsPDF0.9/jspdf.plugin.split_text_to_size.js",
                        "~/Web/js/Externals/htmltable_export/jsPDF0.9/jspdf.plugin.from_html.js",
                        "~/Web/js/Externals/htmltable_export/jsPDF0.9/libs/Deflate/adler32cs.js",
                        "~/Web/js/Externals/htmltable_export/jsPDF0.9/libs/FileSaver.js/FileSaver.js",
                        "~/Web/js/Externals/htmltable_export/jsPDF0.9/libs/Blob.js/BlobBuilder.js",
                        "~/Web/js/Externals/htmltable_export/jsPDF0.9/jspdf.plugin.addimage.js",
                        "~/Web/js/Externals/htmltable_export/jsPDF0.9/jspdf.plugin.table.js",
                        "~/Web/js/Externals/htmltable_export/jsPDF0.9/jspdf.plugin.cell.js",
                        "~/Web/js/Externals/htmltable_export/jsPDF0.9/jspdf.debug.js",
                        "~/Web/js/Externals/htmltable_export/excellentexport.js"*/));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Web/css/bootstrap.css",
                "~/Web/css/bootstrap-theme.css",
                "~/Web/css/navbar.css",
                "~/Web/css/select.css",
                "~/Web/css/main.css"));
        }
    }
}