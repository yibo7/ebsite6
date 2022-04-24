using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.FloorSet
{
    public partial class List : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "PC版楼层设置";
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

        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("281ad765-fe9a-4ae2-8f90-50a9193b3508");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            List<ModuleCore.Entity.FloorSet> ls= ModuleCore.BLL.FloorSetInfo.Instance.FillList();
            List<ModuleCore.Entity.FloorSet> nls = (from i in ls orderby i.FloorId ascending select i).ToList();
            return nls;
        }
       
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.FloorSetInfo.Instance.Delete(int.Parse(iID.ToString()));
        }
        #region  工具栏的初始化
      
        override protected void BindToolBar()
        {
            base.BindToolBar();
           
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
    }
}