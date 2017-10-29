using System.Web;
using System.Web.Optimization;

namespace Trabalho20172
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

          //  bundles.Add(new ScriptBundle("~/bundles/js").
          //IncludeDirectory("~/Scripts/js/", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/js-rental-car").
          IncludeDirectory("~/Scripts/js-rental-car/", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.css",
                      "~/Content/datepicker.css",
                      "~/Content/styles.css",
                      "~/Content/rentalcar-template.css"));

            bundles.Add(new StyleBundle("~/Content/css/rental-car").
            IncludeDirectory("~/Content/css/rental-car-css/", "*.css", true));

            bundles.Add(new StyleBundle("~/Content/css/styles").
            IncludeDirectory("~/Content/css/", "*.css", true));

        }
    }
}
