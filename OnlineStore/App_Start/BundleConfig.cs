using System.Web;
using System.Web.Optimization;

namespace OnlineStore
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Backstage/js").Include(
                        "~/Scripts/modernizr.min.js",
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/moment.min.js",
                        //"~/Scripts/popper.min.js",
                        //"~/Scripts/bootstrap.min.js",
                        //"~/Scripts/detect.js",
                        //"~/Scripts/astclick.js",
                        //"~/Scripts/jquery.blockUI.js",
                        //"~/Scripts/jquery.nicescroll.js",
                        "~/Scripts/pikeadmin.js"
                        //"~/Scripts/jquery.waypoints.min.js",
                        //"~/Scripts/jquery.counterup.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.validate*"));
            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/respond.js",
                      "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/main.css",
                      "~/Content/product.css"
                      ));
            bundles.Add(new StyleBundle("~/BackStage/css").Include(
                "~/Content/sb-main.css"
                ));
            bundles.Add(new StyleBundle("~/Backstage/css").Include(
                     //"~/Content/backstageCSS/bootstrap-checkbox.css",
                     //"~/Content/backstageCSS/bootstrap-grid.css",
                     //"~/Content/backstageCSS/bootstrap-grid.min.css",
                     //"~/Content/backstageCSS/bootstrap-reboot.css",
                     //"~/Content/backstageCSS/bootstrap-reboot.min.css",
                     //"~/Content/backstageCSS/bootstrap.css",
                     "~/Content/backstageCSS/bootstrap.min.css",
                     //"~/Content/backstageCSS/coming-soon.css",
                     //"~/Content/backstageCSS/pricing-tables.css",
                     "~/Content/backstageCSS/style.css",
                     "~/Content/font-awesome.min.css"
                ));
        }
    }
}
