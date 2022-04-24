using System;
using System.Collections;
using System.Data;

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using EbSite.Base.Static.BatchCreatManager;

//using EbSite.Core.Static.BatchCreatManager;

namespace EbSite.Web.AdminHt.ajaxget
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class HtmlProgressInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";



            if (!string.IsNullOrEmpty(context.Request["t"]) && !string.IsNullOrEmpty(context.Request["mid"]))
            {
                int GetMakeType = int.Parse(context.Request["t"]);
                Guid ModleID = new Guid(context.Request["mid"]);
                ProgressBase CurrentPg = MakeUtils.GetProgressObj(GetMakeType, Base.Host.Instance.GetSiteID, ModleID);
                if (CurrentPg!=null)
                {
                    context.Response.Write(CurrentPg.pgInfo.GetProgressInfo);
                }
                else
                {
                    context.Response.Write("");//
                }
                
                
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
