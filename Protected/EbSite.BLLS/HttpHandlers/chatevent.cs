using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using EbSite.Base;
using EbSite.BLL.User;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class chatevent : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string sRequestType = context.Request["t"];

            if (Equals(sRequestType, "1")) //写入条信息
            {
                int GetFriendOnlineId = int.Parse(context.Request["u"]);
                int GetFriendUserID = int.Parse(context.Request["uid"]);
                string sMsg = context.Request["m"];
                if (!string.IsNullOrEmpty(sMsg))
                {
                    if (BLL.User.UserOnline.ExistsUser(GetFriendOnlineId)) //对方在线
                    {
                        BLL.Chat mdChat = new Chat();

                        mdChat.Sender = string.IsNullOrEmpty(AppStartInit.UserName) ? EbSite.Base.Host.Instance.GetGuestName(Base.Host.Instance.OnlineID) : AppStartInit.UserName;
                        mdChat.SenderNiName = string.IsNullOrEmpty(AppStartInit.UserName) ? string.Concat("游客", Base.Host.Instance.OnlineID) : AppStartInit.UserNiName;
                        mdChat.SenderId = AppStartInit.UserID;
                        mdChat.SenderOnlineid = Base.Host.Instance.OnlineID;

                        UserOnline mdUserOnline = BLL.User.UserOnline.GetUser(GetFriendOnlineId);
                        mdChat.RecipientId = mdUserOnline.UserID;
                        mdChat.RecipientOnlineid = GetFriendOnlineId;
                        mdChat.RecipientNiName = mdUserOnline.UserNiname;

                        mdChat.MsgContent = sMsg;
                        mdChat.SendDate = DateTime.Now;
                        mdChat.Save();

                        context.Response.Write("1");//消息发送成功
                    }
                    else
                    {
                        if (GetFriendUserID > 0)
                        {
                            Host.Instance.SendSysMsg(sMsg, GetFriendUserID, false);
                            context.Response.Write("2");//对方离线，但发送对象是注册用户，可以以短信形式给他留言
                        }
                        else
                        {
                            context.Response.Write("3");//对方离线，并且是游客，中断聊天
                        }
                    }
                }
                else
                {
                    context.Response.Write("0");//消息不能为空
                }

            }
            else if (Equals(sRequestType, "2"))  //读取新信息
            {
                int iFriendId = int.Parse(context.Request["u"]);
                //int iMyUserId = AppStartInit.UserID;
                //if (iMyUserId < 1)
                //{
                //    iMyUserId = Base.Host.Instance.OnlineID; 

                //}
                List<BLL.Chat> mds = BLL.Chat.GetMsgs(iFriendId, Base.Host.Instance.OnlineID);

                context.Response.Write(BuilderMsg(mds));

            }



        }
        /// <summary>
        /// 格式 {#UserName#}{\n}{#NiName#}{\n}#DateTime#}{\n}{#Msg#}{*\n*}
        /// </summary>
        /// <param name="msgs"></param>
        /// <returns></returns>
        private string BuilderMsg(List<BLL.Chat> msgs)
        {
            StringBuilder sb = new StringBuilder("");

            foreach (Chat msg in msgs)
            {
                sb.Append(msg.Sender);
                sb.Append("{\n}");
                sb.Append(msg.SenderNiName);
                sb.Append("{\n}");
                sb.Append(msg.SendDate);
                sb.Append("{\n}");
                sb.Append(msg.MsgContent);
                sb.Append("{\n}");
                sb.Append("{*\n*}");
            }
            return sb.ToString();
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
