using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using Amib.Threading;
using EbSite.Base;
using EbSite.BLL.Count;
using EbSite.BLL.User;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for count
    /// </summary>
    public class count : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!string.IsNullOrEmpty(context.Request["ebid"]) && !string.IsNullOrEmpty(context.Request["ebcid"]))
            {
                int iID = int.Parse(context.Request["ebid"]);
                int iClassID = int.Parse(context.Request["ebcid"]);
                ContentBase ch = ContentHits.Instance(iClassID);
                ch.iID = iID;
                ch.AddNum(); //点击率

                GoodsVisite.Instance.iID = iID;
                GoodsVisite.Instance.ClassID = iClassID;
                GoodsVisite.Instance.AddNum(); //内容访问记录
            }
            else if (!string.IsNullOrEmpty(context.Request["ebclassid"]))
            {
                ClassHits.Instance.iID = int.Parse(context.Request["ebclassid"]);

                ClassHits.Instance.AddNum();
            }
            //更新用户访问信息，如在线信息  UserOnlineUpdate

             

            BLL.User.UserOnlineUpdate uou = new UserOnlineUpdate(HttpContext.Current,Host.Instance.OnlineID, Host.Instance.UserID, Host.Instance.UserName, Host.Instance.UserNiName, "",0, Core.Utils.GetClientIP());
            uou.SetUserOnline(null);
           // IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(uou.SetUserOnline)); //无法使用session cookie
            
            //context.Response.StatusCode = 200;
            context.Response.Write("{}");
            //context.Response.End();
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
