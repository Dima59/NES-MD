using System.Web.Optimization;

namespace NES
{
    public static class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Login/css").Include(
                        //"~/Content/bootstrap.css",
                        "~/Content/bootstrap-materia.css",
                        "~/Content/floating-labels.css",
                        "~/Content/materialdesignicons.css",
                        "~/Content/Login.css"
                        ));

            bundles.Add(new ScriptBundle("~/Login/js").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.easing.js",
                        "~/Scripts/umd/popper.js",
                        "~/Scripts/bootstrap.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        //"~/Content/bootstrap.css",
                        "~/Content/sb-admin-2-without-bootstrap.css",
                        "~/Content/bootstrap-materia.css",
                        "~/Content/floating-labels.css",
                        "~/Content/datatables.css",
                        "~/Content/bootstrap-datepicker.css",
                        "~/Content/alertify.css",
                        "~/Content/alertifyjs/themes/bootstrap.css",
                        "~/Content/materialdesignicons.css",
                        "~/Content/tooltipster.bundle.css",
                        "~/Content/tooltipster-sideTip-borderless.css",
                        "~/Content/tooltipster-sideTip-borderless-warning.css",
                        "~/Content/tooltipster-sideTip-shadow.min.css",
                        "~/Content/nprogress.css",
                        "~/Content/css/select2.css",
                        "~/Content/css/select2-bootstrap4-materia.css",
                        "~/Content/Site.css"
                        ));

            bundles.Add(new ScriptBundle("~/Content/js").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.easing.js",
                        "~/Scripts/umd/popper.js",
                        "~/Scripts/moment-with-locales.js",
                        "~/Scripts/datetime-moment.js",
                        "~/Scripts/sb-admin-2.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/datatables.js",
                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/tooltipster.bundle.js",
                        "~/Scripts/nprogress.js",
                        "~/Scripts/select2.js",
                        "~/Scripts/alertify.js"
                        ));
        }
    }
}