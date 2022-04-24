using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.FloorSet
{
    public partial class ChildClassList : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "楼层子分类列表";
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
                return new Guid("1566ce26-50d8-4cfc-8382-96352af896df");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=4&fid="+Request.Params["fid"];
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=1";
            }
        }
        protected int fid
        {
            get
            {
                return Core.Utils.StrToInt(Request.Params["fid"], 0);
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            List<ModuleCore.Entity.FloorSmallClass> ls = ModuleCore.BLL.FloorSmallClassInfo.Instance.FillList();
            List<ModuleCore.Entity.FloorSmallClass> nls = (from i in ls where i.FloorSetId == fid select i).ToList();
            return nls;
        }
       
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.FloorSmallClassInfo.Instance.Delete(int.Parse(iID.ToString()));
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