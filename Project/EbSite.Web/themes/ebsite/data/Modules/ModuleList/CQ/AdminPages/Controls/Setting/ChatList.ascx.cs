using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.AdminPages.Controls.Setting
{
    public partial class ChatList : UserControlBase
    {
        public string SUid
        {
            get
            {
                return Request.QueryString["suid"];
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("762f60d6-6fac-4035-ba81-c3ef892e6ab0");
            }
        }
        public override string PageName
        {
            get
            {
                return "聊天窗口";
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
                return 1;
            }
        }
        public override string Permission
        {
            get
            {
                return "";
            }
        }
       

        protected ServiceInfo mdServer;
        protected void Page_Load(object sender, EventArgs e)
        {
            mdServer = ModuleCore.BLL.Service.Instance.GetServerByUserID(UserID);
            if (!Equals(mdServer, null))
            {
                mdServer.IsOnline = true;
                //更新在线状态
                ModuleCore.BLL.Service.Instance.Update(mdServer);
                
                //List<ModuleCore.Entity.CustomWord> ls = ModuleCore.BLL.CustomWord.Instance.FillList();
                //this.rpCustomList.DataSource = (from i in ls where i.UserId == base.UserID select i).ToList();
                //this.rpCustomList.DataBind();
            }
            else
            {
                Tips("出错了", "您还不是客服，请找管理员为您的帐号设置关联一个客服才可以访问此页面！", "");
            }
        }

        protected void rblOnline_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ServiceInfo mdS = ModuleCore.BLL.Service.Instance.GetServerByUserID(UserID);
            if(rblOnline.SelectedValue=="1")
            {
                mdServer.IsOnline = true;
            }
            else
            {
                mdServer.IsOnline = false;
            }
            //更新在线状态
            ModuleCore.BLL.Service.Instance.Update(mdServer);
        }
       

    }
}