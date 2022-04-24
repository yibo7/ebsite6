using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for yzm
    /// </summary>
    public class rss : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
             
             HttpRequest request = context.Request;
            HttpResponse response = context.Response;
             

            int itop =  Core.Utils.StrToInt(request.QueryString["top"],10) ;
             int itype = Core.Utils.StrToInt(request.QueryString["it"],0) ;//0为排行，1为推荐,2为最新
             int iclassid = Core.Utils.StrToInt(request.QueryString["cid"],0);
            int siteid = Core.Utils.StrToInt(request.QueryString["site"],1);

            string s = EbSite.Base.AppStartInit.GetNewsContentInst(iclassid).GetRss(itop, itype, iclassid, siteid);

            response.Write(s);
            response.End();

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
