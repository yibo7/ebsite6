using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.SalesActivities
{
    public partial class GroupBuy : MPUCBaseList
    {

        public override string PageName
        {
            get
            {
                return "团购活动";
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
                return "17";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "18";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "19";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "20";
            }
        }

        public override int OrderID
        {
            get
            {
                return 2;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("98e5efec-e869-4acc-899a-e11ed41f05f5");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=18";
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
            ModuleCore.BLL.GroupBuy.Instance.AutoSetGroupStaus();
          
            return ModuleCore.BLL.GroupBuy.Instance.GetListPages(this.pcPage.PageIndex,this.pcPage.PageSize,out iCount);
        }
        /// <summary>
        /// 重写简单查询条件
        /// </summary>
        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
                SearchParameter spModel = new SearchParameter();


                spModel.ColumnName = "title";
                spModel.ColumnValue = ucToolBar.GetItemVal(ProductName);
                spModel.IsString = true;
                spModel.SearchWhere = EmSearchWhere.相等匹配;
                lstSp.Add(spModel);


                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.GroupBuy.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.GroupBuy.Instance.Delete(int.Parse(iID.ToString()));
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