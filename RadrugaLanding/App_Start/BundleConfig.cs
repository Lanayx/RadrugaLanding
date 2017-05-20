using System.Web;
using System.Web.Optimization;

namespace RadrugaLanding
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Content/js").Include(
                       "~/Scripts/jquery-2.2.3.min.js",
                       "~/Scripts/jquery.fullPage.min.js",
                       "~/Scripts/jquery.bpopup.min.js",
                       "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/jquery.fullPage.css",
                      "~/Content/fonts.css",
                      "~/Content/site.css"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
