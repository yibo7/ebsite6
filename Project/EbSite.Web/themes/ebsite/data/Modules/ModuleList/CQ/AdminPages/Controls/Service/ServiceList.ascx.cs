using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.CQ.ModuleCore.BLL;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.AdminPages.Controls.Service
{
    public partial class ServiceList : MPUCBaseList
    {
        protected override Guid MenuAddID
        {
            get
            {
                return new Guid("a85f9d78-adba-49e9-9765-659e33674993");
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("c5665027-d278-46ba-af6a-47fbe369bc56");
            }
        }
        public override string PageName
        {
            get
            {
                return "客服管理";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
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
                return "17";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "18";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "18";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "18";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }

       
        override protected object LoadList(out int iCount)
        {
            iCount = 0;

            return ModuleCore.BLL.Service.Instance.FillList();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        protected string GetUrlMsg
        {
            get
            {
                return string.Format("{0}?muid={1}&mid={2}", this.GetPageName, "9256aed5-4799-4a6c-be71-96a2647bfcd4", this.ModuleID);
            }
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.Service.Instance.Delete(int.Parse(iID.ToString()));
        }
        override protected void CopyData(object iID)
        {
            
            ModuleCore.BLL.Service.Instance.CopyData(int.Parse(iID.ToString()));
        }

        public string IsOnline(object isonline,object sid)
        {
            bool ison = bool.Parse(isonline.ToString());
            string sInfo = "离线";
            if (ison)
            {
               int iCount =  ChatBll.Instance.CustomersOnline(int.Parse(sid.ToString())).Count;
               sInfo = string.Format("<font color=#ff0000>在线(正在接待{0}位客户)</font>", iCount);
            }
            return sInfo;
        }

        #region 工具栏的初始化
        override protected void BindToolBar()
        {

            base.BindToolBar();
            ucToolBar.AddLine();

            ucToolBar.AddBnt("重新生成客服JS数据", string.Concat(IISPath, "images/Menus/ie.png"), "makejs");
            string sjsSearch = "return confirm('确认要将所有客服置为离线吗？');";
            ucToolBar.AddBnt("将所有客服重置为离线", string.Concat(IISPath, "images/Menus/User-Block.gif"), "offline", true, sjsSearch, "此操作会将所有客服在线状态改变为离线");



        }
        #endregion

        #region 工具栏事件扩展

        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "makejs":
                    ModuleCore.BLL.Service.Instance.UpdateFloatJsData();
                    break;
                case "offline":
                    ModuleCore.BLL.Service.Instance.AllOfLine();
                    break;
            }
        }

        #endregion
        override protected void rpList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            base.rpList_ItemCommand(sender, e);
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                if (e.CommandName == "OffLine")
                {

                    ServiceInfo mdServer = ModuleCore.BLL.Service.Instance.GetEntity(int.Parse(e.CommandArgument.ToString()));
                    mdServer.IsOnline = false;
                    //更新在线状态
                    ModuleCore.BLL.Service.Instance.Update(mdServer);

                    gdList_Bind();
                }
            }
        }
    }
}