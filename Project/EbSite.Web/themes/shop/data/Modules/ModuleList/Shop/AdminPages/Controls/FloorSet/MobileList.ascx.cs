using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.FloorSet
{
    public partial class MobileList : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "Mobile版楼层设置";
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("eff717bb-3ad6-4386-9849-a6c435d1a93f");
            }
        }
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "95";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "96";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "97";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "98";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=14";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=1";
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
                return 2;
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            List<ModuleCore.Entity.MFloorSet> ls = ModuleCore.BLL.MFloorSetInfo.Instance.FillList();
            List<ModuleCore.Entity.MFloorSet> nls = (from i in ls orderby i.FloorId ascending select i).ToList();
            return nls;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.MFloorSetInfo.Instance.Delete(int.Parse(iID.ToString()));
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}