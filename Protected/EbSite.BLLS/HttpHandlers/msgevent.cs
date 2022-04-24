using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using EbSite.Base;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class msgevent : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string sRequestType = context.Request["t"];
            string sRecipient = context.Request["u"];
            string sPram = context.Request["p"];
            if (!string.IsNullOrEmpty(sRequestType) && !string.IsNullOrEmpty(sRecipient))
            {
                BLL.Msg md = new Msg();

                md.Sender = AppStartInit.UserName;
                md.SenderUserID = AppStartInit.UserID;
                md.SenderNiName = AppStartInit.UserNiName;
                md.Recipient = sRecipient;
                md.MsgType = int.Parse(sRequestType);
                md.IsNewMsg = true;
                md.SendDate = DateTime.Now;
                md.Title = "不用标题";
                if (!string.IsNullOrEmpty(sPram))
                    md.EventPram = sPram;

                md.Save();

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
