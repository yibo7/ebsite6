using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Control;
using EbSite.Modules.Wenda.ModuleCore.BLL;
using DropDownList = EbSite.Control.DropDownList;
using LinkButton = System.Web.UI.WebControls.LinkButton;
using TextBox = System.Web.UI.WebControls.TextBox;
namespace EbSite.Modules.Wenda.AdminPages.Controls.Experts
{
    public partial class ExpertsList : MPUCBaseList
    {
        #region 权限
        public override string PageName
        {
            get
            {
                return "专家列表";
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
                return "26";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "27";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "28";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "29";
            }
        }
        #endregion

        protected override Guid MenuAddID
        {
            get
            {
                return new Guid("4491705b-75a4-4512-9195-674c72864d7c");
            }
        }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("401a2b61-e4bc-40af-8039-fcd55f93b0a0");
            }
        }
        //override protected string AddUrl
        //{
        //    get
        //    {
        //        return "t=12";
        //    }
        //}
        override protected string ShowUrl
        {
            get
            {
                return "t=3";
            }
        }
        public override int OrderID
        {
            get
            {
                return 6;
            }
        }
       
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return ModuleCore.BLL.ExpertsControl.Instance.FillList();
        }

        override protected object SearchList(out int iCount)
        {

            iCount = 0;
            return null;

        }
        
        override protected void Delete(object iID)
        {
           ModuleCore.BLL.ExpertsControl.Instance.Delete(int.Parse(iID.ToString()));
        }
       
        #region  工具栏的初始化
        
        override protected void BindToolBar()
        {
            base.BindToolBar(false, false, true, true, true);
            //base.ShowCustomSearch("查询");
        }
        #endregion
    }
}