using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EbSite.Base;

namespace EbSite.Mvc
{
    static public class HtmlExtensions
    {
        
        static public EbSite.Entity.Sites CurrentSite(this HtmlHelper htmlHelper)
        {

            return EbSite.BLL.Sites.Instance.GetEntity(GetSiteID(htmlHelper));

             
        }
        public static Host HostApi(this HtmlHelper htmlHelper)
        {
            return Host.Instance;

        }

        public static string ThemePage(this HtmlHelper htmlHelper)
        {
            return string.Concat(CurrentSite(htmlHelper).ThemesPath("pages"), "/");
        }

        public static string MThemePage(this HtmlHelper htmlHelper)
        {

            return CurrentSite(htmlHelper).MGetCurrentPageUrl("");
            
        }
        public static string ThemeCss(this HtmlHelper htmlHelper)
        {

            return string.Concat(CurrentSite(htmlHelper).ThemesPath("css"), "/");

        }
        public static string MThemeCss(this HtmlHelper htmlHelper)
        {

            return string.Concat(CurrentSite(htmlHelper).MThemesPath("css"), "/");

        }
        static public int GetSiteID(this HtmlHelper htmlHelper)
        {
            var siteid = htmlHelper.ViewContext.RouteData.Values["SiteId"];
          return Core.Utils.ObjectToInt(siteid, 1);
             
        }
        static public string SiteName(this HtmlHelper htmlHelper)
        {

            return CurrentSite(htmlHelper).SiteName;

        }
    
       
                /// <summary>
                /// 站点域名
                /// </summary>
        static public string DomainName(this HtmlHelper htmlHelper)
                {
                     
                        return AppStartInit.DomainName;
                     
                }

        static public int UserID(this HtmlHelper htmlHelper)
        {

            return AppStartInit.UserID;

        }
        static public string UserNiName(this HtmlHelper htmlHelper)
        {

            return AppStartInit.UserNiName;

        }
        static public string UserName(this HtmlHelper htmlHelper)
        {

            return AppStartInit.UserName;

        }
        static public string IISPath(this HtmlHelper htmlHelper)
        {

            return EbSite.Base.AppStartInit.IISPath;

        }
        static public string GetNavClass(this HtmlHelper htmlHelper,int ClassID,string Nav, bool IsAddCurrent, int FilterClassID)
        {
            return BLL.NewsClass.GetNav(Nav, ClassID, IsAddCurrent, GetSiteID(htmlHelper), FilterClassID);
        }
        static public string GetNavClass(this HtmlHelper htmlHelper, int ClassID)
        {
            return BLL.NewsClass.GetNav(">", ClassID, false, GetSiteID(htmlHelper), 0);
        }
        static public string GetNav(this HtmlHelper htmlHelper)
        {
           string ClassId = HttpContext.Current.Request["cid"];
            string ContentId = HttpContext.Current.Request["id"];

            if (!string.IsNullOrEmpty(ClassId) && !string.IsNullOrEmpty(ContentId))
            {
                
            }
            else if (!string.IsNullOrEmpty(ClassId) && string.IsNullOrEmpty(ContentId))
            {
                return BLL.NewsClass.GetNav(">", int.Parse(ClassId), false, GetSiteID(htmlHelper), 0);
            }

            return "";
        }
        


    }
}
