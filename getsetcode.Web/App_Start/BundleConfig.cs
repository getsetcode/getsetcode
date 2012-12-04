using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.IO;

namespace getsetcode.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bundle").Include(
                "~/Scripts/jquery-1.*",
                "~/Scripts/load-image.*",
                "~/Scripts/bootstrap.*",
                "~/Scripts/bootstrap-image-gallery.*",
                "~/Scripts/getsetcode.modal.js",
                "~/Scripts/getsetcode.form.js",
                "~/Scripts/getsetcode.global.js",
                "~/Scripts/getsetcode.loader.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css/bundle").Include(
                "~/Content/css/bootstrap.*",
                "~/Content/css/bootstrap-image-gallery.*",
                "~/Content/css/getsetcode.*"
            ));
        }
    }
}