using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class IsNewsMsg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //string sCurrentUserName = string.IsNullOrEmpty(EbSite.Base.AppStartInit.UserName) ? EbSite.Base.Host.Instance.GetGuestName(EbSite.Base.Host.Instance.OnlineID) : EbSite.Base.AppStartInit.UserName;

            if (EbSite.Base.Host.Instance.OnlineID > 0)//if(!string.IsNullOrEmpty(sCurrentUserName))
            {

                Chat mdChat = BLL.Chat.HaveNewChat(EbSite.Base.Host.Instance.OnlineID);

                if (!Equals(mdChat, null)) //聊天优先
                {
                    context.Response.Write(string.Format("1#\n#{0}", EbSite.Base.Host.Instance.GetChatOnline(mdChat)));
                }
                else //短信在后
                {
                    int uid = Base.AppStartInit.UserID;
                    if (uid > 0)
                    {
                        int count = BLL.Msg.Msg_Count(uid, true);
                        if (count > 0)
                        {
                            context.Response.Write(string.Format("2#\n#{0}", Base.Host.Instance.GetNewMsg(uid)));
                        }
                        else
                        {
                            context.Response.Write("");
                        }

                    }
                    else
                    {
                        context.Response.Write("");
                    }


                }


            }
            else
            {
                context.Response.Write("");
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
