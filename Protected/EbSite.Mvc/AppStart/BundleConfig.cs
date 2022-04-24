using System;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using EbSite.Base;

namespace EbSite.Mvc.AppStart
{
    public class BundleConfig
    {
        
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                "~/js/jquery.js",
                "~/js/init.js",
                "~/js/inc.js", "~/js/comm.js", "~/js/customctr.js", "~/js/json2.js"
                ));

            foreach (var site in AppStartInit.Sites)
            {
               
                try
                {
                    bundles.Add(new StyleBundle(string.Concat("~/themescss", site.Value.id)).Include("~/themes/base.css", string.Concat("~/themes/", site.Value.PageTheme, "/css/*.css")));
                    bundles.Add(new ScriptBundle("~/themesjs" + site.Value.id).Include(string.Concat("~/themes/", site.Value.PageTheme, "/js/*.js"))); 

                   
                    bundles.Add(new StyleBundle(string.Concat("~/themesmss", site.Value.id)).Include("~/themesm/base.css",  string.Concat("~/themesm/", site.Value.MobileTheme, "/css/*.css")));
                    bundles.Add(new ScriptBundle("~/themesmjs" + site.Value.id).Include(string.Concat("~/themesm/", site.Value.MobileTheme, "/js/*.js")));
 
                }
                catch (Exception e)
                {

                    EbSite.Log.Factory.GetInstance().ErrorLog("出错了:BundleConfig加载异常："+ e.Message);

                    //throw new Exception("出错了:" + e.Message + ";您要在此路径下创建目录：" + spathrule);
                }

            }

        }
    }
}
