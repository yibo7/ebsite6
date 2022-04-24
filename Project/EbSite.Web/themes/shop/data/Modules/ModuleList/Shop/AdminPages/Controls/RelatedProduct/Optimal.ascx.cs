using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.RelatedProduct
{
    public partial class Optimal : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "最佳组合";
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
                return "29";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "30";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "31";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "32";
            }
        }

        public override int OrderID
        {
            get
            {
                return 3;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("6bd8c270-034e-4aeb-9455-950acd87fc4d");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=1";
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
            return ModuleCore.BLL.P_BestGroup.Instance.GetListPages(pcPage.PageIndex, iPageSize, " a.typeid=1 ", "", out iCount);
        }

        override protected object SearchList(out int iCount)
        {
            string key = ucToolBar.GetItemVal(ProductName);
            if (!string.IsNullOrEmpty(key))
            {
                return ModuleCore.BLL.P_BestGroup.Instance.GetListPages(pcPage.PageIndex, iPageSize,
                                                                        " a.typeid=1 and b.NewsTitle like '%" +
                                                                        key + "%' ", "", out iCount);
            }
            else
            {
                iCount = 0;
                return null;
            }
        }

        override protected void Delete(object iID)
        {
            List<ModuleCore.Entity.P_BestGroup> lss =
                   ModuleCore.BLL.P_BestGroup.Instance.GetListArray("TypeID=1 and  ProductID=" + iID);
            foreach (var pBestGroup in lss)
            {
                ModuleCore.BLL.P_BestGroup.Instance.Delete(pBestGroup.id);
            }
        }
        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox ProductName = new TextBox();
        override protected void BindToolBar()
        {
            base.BindToolBar();
            ucToolBar.AddLine();
            LbName.ID = "LbName";
            LbName.Text = "商品名称";
            ucToolBar.AddCtr(LbName);
            ProductName.ID = "ProductName";
            ProductName.Attributes.Add("style", "width:90px");
            ucToolBar.AddCtr(ProductName);
            base.ShowCustomSearch("查询");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}