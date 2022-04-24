using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.DataProfile;

namespace EbSite.Mvc.Controllers
{
    public class CtlBase : Controller
    {
        protected int SiteId = 1;
        public CtlBase()
        {
            //            #if DEBUG
            //                        Base.DataProfile.DbHelperBase.QueryCount = 0;
            //                        Base.DataProfile.DbHelperBase.QueryDetail = "";
            //#endif
#if DEBUG
            if (ConfigsControl.Instance.IsOpenSql)
            {
                Base.DataProfile.DbHelperBase.QueryCount = 0;
                Base.DataProfile.DbHelperBase.QueryDetail = "";
            }
#endif
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            ViewBag.UserId = UserID;
            ViewBag.SiteId = SiteId;
            ViewBag.SiteName = SiteName;
            ViewBag.UserNiName = UserNiName;
            ViewBag.IISPath = IISPath;
            ViewBag.DomainName = ViewBag.DomainName;


        }

        protected  string GetUploadCtr(string selfilebox, string ext, string folder, int size)
        {
            return Host.Instance.GetUploadStr(selfilebox, ext, folder, size);

        }



        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
           SiteId = Core.Utils.ObjectToInt(base.RouteData.Values["SiteId"],1) ;
            
           
        }
        public string GetPagesFileName(string fileName)
        {

            EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(SiteId);

            return mdSite.ThemesPath(string.Concat("mvc/", fileName));

        }

        
        public Host HostApi
        {
            get
            {
                return Host.Instance;
            }
        }
        protected string SiteName
        {
            get
            {
                return HostApi.CurrentSite.SiteName;
            }
        }
        /// <summary>
        /// 站点域名
        /// </summary>
        protected string DomainName
        {
            get
            {
                return AppStartInit.DomainName;
            }
        }
        /// <summary>
        /// 版权信息
        /// </summary>
        protected string Copyright
        {
            get
            {
                return AppStartInit.Copyright;
            }
        }

      
        protected int UserID = AppStartInit.UserID;
        protected string UserNiName = AppStartInit.UserNiName;
        protected string UserName = AppStartInit.UserName;

        /// <summary>
        /// 网站安装目录
        /// </summary>
        protected static string IISPath
        {
            get
            {
                return EbSite.Base.AppStartInit.IISPath;
            }
        }
        //protected int GetSiteID
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Request.QueryString["site"]))
        //        {
        //            return int.Parse(Request.QueryString["site"]);
        //        }
        //        return 1;
        //    }
        //}
    }
}
