using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Entity;
using System.Collections;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.MyMsg
{
    public partial class SendMsg : MPUCBaseSaveForUser
    {

        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("156571d6-8705-419d-a7a8-cdd68a87459b");
            }
        }
        public override string PageName
        {
            get
            {
                return "发送消息";
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
                return 4;
            }
        }
        private int GetFriendUserID
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetFriendUserID > 0)
            {
                if (UserID > 0)
                {
                    if (UserID == GetFriendUserID)
                    {
                        Tips("不能自己加自己发消息哦！");
                    }
                    txtMsg.Text = "请输入留言内容";
                }
            }
            else
            {
                Tips("出错了", "传入的参数有误！");
            }
         
           

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
            string msg = txtMsg.Text.Trim();
            if (string.IsNullOrEmpty(msg) || msg.Equals("请输入留言内容"))
            {
                Tips("出错了","请输入消息内容！");
                return;
            }

             if (msg.Length > 300)
            {
                Tips("出错了", "消息内容要控制在300字以内！");
                return;
            }

            HostApi.SendSysMsg(msg, GetFriendUserID,false);

            Tips("短信已经发送成功！");
           
        }
       
    }
}