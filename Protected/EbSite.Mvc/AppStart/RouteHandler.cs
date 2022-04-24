using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using EbSite.Base.EBSiteEventArgs;

namespace EbSite.Mvc.AppStart
{
    public class RouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            
            var action = requestContext.RouteData.Values["action"].ToString().ToLower();
            switch (action)
            {
                case "validatecode":
                    return new EbSite.BLL.HttpHandlers.ValidateCode();
                case "jscss":
                    return new EbSite.BLL.HttpHandlers.jscss();
                case "count":
                    return new EbSite.BLL.HttpHandlers.count();
                case "upsinglefile":
                    return new EbSite.BLL.HttpHandlers.UpSingleFile();
                case "gotopay":
                    return new EbSite.BLL.HttpHandlers.gotopay();
                case "loginapi":
                    return new EbSite.BLL.HttpHandlers.loginapi();
                case "avatar":
                    return new EbSite.BLL.HttpHandlers.avatar();
                case "barcode":
                    return new EbSite.BLL.HttpHandlers.barcode();
                case "chatevent":
                    return new EbSite.BLL.HttpHandlers.chatevent();
                case "currentuser":
                    return new EbSite.BLL.HttpHandlers.CurrentUser();
                case "email":
                    return new EbSite.BLL.HttpHandlers.email();
                //case "executepost":
                //    return new EbSite.BLL.HttpHandlers.ExecutePost();
                case "getcount":
                    return new EbSite.BLL.HttpHandlers.GetCount();
                case "isnewsmsg":
                    return new EbSite.BLL.HttpHandlers.IsNewsMsg();
                case "log":
                    return new EbSite.BLL.HttpHandlers.log();
                case "mobile":
                    return new EbSite.BLL.HttpHandlers.mobile();
                case "msgevent":
                    return new EbSite.BLL.HttpHandlers.msgevent();
                case "saveremoteimg":
                    return new EbSite.BLL.HttpHandlers.UploadImgByUrls();
                case "uico":
                    return new EbSite.BLL.HttpHandlers.uico();
                case "uploadcheck":
                    return new EbSite.BLL.HttpHandlers.uploadcheck();
                case "username":
                    return new EbSite.BLL.HttpHandlers.username();
                case "yzm":
                    return new EbSite.BLL.HttpHandlers.yzm();
                case "appstart":
                    return new EbSite.BLL.HttpHandlers.appstart();
                case "rss":
                    return new EbSite.BLL.HttpHandlers.rss(); 
            }

            MvcRouteHandlerEventArgs Args = new MvcRouteHandlerEventArgs(action);
            Base.EBSiteEvents.OnEbMvcRouteHandler(requestContext, Args);

            if (Equals(Args.CustomHandler, null))
            {
                return new EbSite.BLL.HttpHandlers.web404();
            }
            else
            {
                return Args.CustomHandler;
            }
           
            //return null;
        }
    }
}
