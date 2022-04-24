using System;
using System.Collections.Generic;
using System.Web;

namespace EbSite.Web.home.ajaxget
{
    /// <summary>
    /// Summary description for DeleteTabWidget
    /// </summary>
    public class DeleteTabWidget : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request.QueryString["wdid"]) && !string.IsNullOrEmpty(context.Request.QueryString["tid"]))
            {
                int TabID = Core.Utils.StrToInt(context.Request.QueryString["tid"], 0);

                int GetSubTabID = 0;
                if (!string.IsNullOrEmpty(context.Request.QueryString["t"]))
                {
                    GetSubTabID =  EbSite.BLL.SpaceTabs.Instance.GetTabIDFormMark(TabID, context.Request.QueryString["t"]);
                }
                else
                {
                    GetSubTabID =  0;
                }
                if (GetSubTabID > 0)
                    TabID = GetSubTabID;
                BLL.SpaceTabWidget.Instance.Delete(EbSite.Base.AppStartInit.UserID, TabID, context.Request.QueryString["wdid"]);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}