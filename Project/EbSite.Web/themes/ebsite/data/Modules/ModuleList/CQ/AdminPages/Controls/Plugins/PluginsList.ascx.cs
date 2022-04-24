using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages.Controls.Plugins
{
    public partial class PluginsList : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("28bfb1c1-7e31-4e8d-b556-666535083c9a");
            }
        }
        public override string PageName
        {
            get
            {
                return "聊天插件";
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
                return 12;
            }
        }
        public override string Permission
        {
            get
            {
                return "13";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "14";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "14";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "14";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=4";
            }
        }


        override protected object LoadList(out int iCount)
        {
            iCount = 0;

            return ModuleCore.BLL.ChatPlugin.Instance.FillList();
          
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.ChatPlugin.Instance.Delete(int.Parse(iID.ToString()));
        }
        override protected void CopyData(object iID)
        {
            ModuleCore.BLL.ChatPlugin.Instance.CopyData(int.Parse(iID.ToString()));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}