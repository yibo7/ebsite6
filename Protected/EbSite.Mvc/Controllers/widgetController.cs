using System;
using System.Collections.Generic; 
using System.Web.Mvc; 
using EbSite.Base;
using EbSite.Base.Static; 

namespace EbSite.Mvc.Controllers
{
    [System.Web.Mvc.RoutePrefix("widget")]
    public class widgetController : CtlBase
    {
        
        [System.Web.Mvc.Route("txt/{key}")]
        [System.Web.Http.HttpGet]
        public ActionResult ShowInfo(string key)
        {
            if (Core.Utils.IsGuid(key))
            {
                string rz = GetWidgetStr(key);
                return Content(rz);
            }
            return HttpNotFound("找不到相应的key");
        }
        [System.Web.Mvc.Route("js/{key}")]
        [System.Web.Http.HttpGet]
        public ActionResult ShowJs(string key)
        {
            if (Core.Utils.IsGuid(key))
            {
                string rz = GetWidgetStr(key);
                //string js = "var sb=\"" +rz.Trim().Replace("\"", "\\\"").Replace("\r\n", "\n").Replace("\n", "\";\r\n sb=sb+\"")+ "\";";
                string js = "document.writeln(\"" + rz.Trim().Replace("\"", "\\\"").Replace("\r\n", "\n").Replace("\n", "\");\r\n document.writeln(\"") + "\");";
                //document.writeln
                return Content(js, "application/x-javascript");
            }

            return HttpNotFound("找不到相应的key");

        }

        [NonAction]
        private string GetWidgetStr(string key)
        {
            
            if (Core.Utils.IsGuid(key))
            {
                string CacheKey = string.Concat("GetWidgetStr-", key);
                string rz  = Host.CacheApp.GetCacheItem<string>(CacheKey, "WidgetData");
                if (string.IsNullOrEmpty(rz))
                {
                    rz = Core.WebUtility.LoadURLStringUTF8(string.Concat(HostApi.Domain, IISPath, "custompages/getctrhtml.aspx?widgetid=", key));
                    rz = Core.Strings.GetString.CutMiddleStr(rz, "<!--开始-->", "<!--结束-->");

                    Host.CacheApp.AddCacheItem(CacheKey, rz,1, ETimeSpanModel.T, "WidgetData");
                }
                return rz;
            }
            return string.Empty;
        }

    }
}
