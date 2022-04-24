using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.EntityAPI;
using EbSite.Base.Modules;
using EbSite.Entity;
using System.Collections;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.Chat
{
    public partial class ChatOnline : MPUCBaseSaveForUser
    {

        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("f546355f-b540-4082-8ce0-674be18a117b");
            }
        }
        public override string PageName
        {
            get
            {
                return "即时聊天窗口";
            }
        }

        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return false;
            }
        }
        public override int OrderID
        {
            get
            {
                return 5;
            }
        }
        protected int GetFriendUserID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["uid"]))
                {
                    return int.Parse(Request["uid"]);
                }
                return 0;
            }
        } 
        
        protected int GetFriendOlid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["olid"]))
                {
                    return int.Parse(Request["olid"]);
                }
                return 0;
            }
        }

        

        protected int GetFriendOnlineId = 0;

        protected EbSite.Base.EntityAPI.MembershipUserEb FriendModel;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetFriendUserID > 0)
            {
                    if (UserID == GetFriendUserID)
                    {
                        Tips("自己和自己聊天有什么意思！");
                    }
                    GetFriendOnlineId = BLL.User.UserOnline.ExistsUserID(GetFriendUserID);
                    if (GetFriendOnlineId > 0)
                    {
                        llOnlineInfo.Text = "<b>对方在线，您可以与他即时聊天</b>";
                    }
                    else
                    {
                        llOnlineInfo.Text = "<b>对方离线，发送消息将会给他留言!</b>";
                    }
                    FriendModel = HostApi.GetUser(GetFriendUserID);



                llOnlineInfo.Text +=
                    string.Format(
                        "<dt><a target=\"_blank\" href=\"{0}\">TA的空间</a>&nbsp;|&nbsp;<a target=\"_blank\" href=\"{1}\">加为好友</a></dt>", HostApi.GetUserSiteUrl(FriendModel.id), HostApi.GetAddFriend(FriendModel.id));

                imgUserIco.ImageUrl = FriendModel.AvatarSmall;
            }
            else if (GetFriendOlid>0)
            {
                GetFriendOnlineId = GetFriendOlid;
               bool isok =  BLL.User.UserOnline.ExistsUser(GetFriendOnlineId);
               if (isok)
                   llOnlineInfo.Text = "对方在线，您可以与他即时聊天";
               else
               {
                   BLL.Chat.DeleteMsg(GetFriendOnlineId);//不在线了，清空他所有发送过的消息
                   Tips("出错了", "对方已经离开网站，无法发起对话！");
               }
                   

                FriendModel = new MembershipUserEb();
                imgUserIco.ImageUrl = string.Concat(IISPath, "images/nopic.gif");
                
            }
            else
            {
                Tips("出错了", "传入的参数有误！");
            }

            //llOnlineInfo.Text += "对方在线ID" + GetFriendOnlineId + ";我的在线ID:" + HostApi.OnlineID;

        }
    
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
             
        }

        override protected void SaveModel()
        {
             
           
        }
       
    }
}