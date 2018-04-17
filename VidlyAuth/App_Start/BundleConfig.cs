using System.Web;
using System.Web.Optimization;

namespace VidlyAuth
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-1.10.2.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/materializecss").Include(
                    "~/Content/materializecss/js/materialize.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery-datatables").Include(
                    "~/Scripts/datatables/jquery.datatables.js",
                    "~/Scripts/datatables/datatables.material.min.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootbox").Include(
                    "~/Scripts/bootbox.min.js"
                ));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                    //"~/Content/bootstrap.css",
                    //"~/Content/site.css"
                    "~/Content/materializecss/custom.css"
                ));

            bundles.Add(new StyleBundle("~/Content/materializecss").Include(
                    "~/Content/materializecss/css/materialize.min.css"
                ));

            bundles.Add(new StyleBundle("~/Content/jquery-datatables").Include(
                    "~/Content/datatables/css/datatables.material.min.css"
                ));
        }
    }
}
