using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.StockAlarm
{
    public partial class AlarmList : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "报警商品";
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
                return "91";
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
                return new Guid("2999c5c8-ab9d-47dd-975f-5345ef6c10c3");
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
                return "t=0";
            }
        }
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.NormRelationProduct.Instance.UnionGetListPages(pcPage.PageIndex, iPageSize, out iCount, "");

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
                spModel.ColumnName = "b.newstitle";
                spModel.ColumnValue = ucToolBar.GetItemVal(ProductName);
                spModel.IsString = true;
                spModel.SearchWhere = EmSearchWhere.模糊匹配;
                lstSp.Add(spModel);
                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.NormRelationProduct.Instance.UnionGetListPages(pcPage.PageIndex, iPageSize, out iCount, base.GetWhere(true));
        }
        override protected void Delete(object iID)
        {
           
        }
        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox ProductName = new TextBox();
        override protected void BindToolBar()
        {
            base.BindToolBar(true, true, true, true, true);

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