using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Web.AdminHt.Controls.Admin_Coupons
{
    public partial class DisableCoupons : UserControlListBase
    {
        public override string PageName
        {
            get
            {
                return "优惠券管理";
            }
        }
        #region 权限

        public override string Permission
        {
            get
            {
                return "160";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "159";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "230";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "229";
            }
        }

        #endregion

        public override int OrderID
        {
            get
            {
                return 3;
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
                return "t=2";
            }
        }
        override protected object LoadList(out int iCount)
        {
            //EndDateTime<now()  在数据层 用 2代替
            return BLL.Coupons.Instance.GetListPages(pcPage.PageIndex, iPageSize, "2", "", out iCount);
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


                spModel.ColumnName = "ProductName";
                spModel.ColumnValue = ucToolBar.GetItemVal(ProductName);
                spModel.IsString = true;
                spModel.SearchWhere = EmSearchWhere.相等匹配;
                lstSp.Add(spModel);


                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
            //return ModuleCore.BLL.Coupons.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }
        override protected void Delete(object iID)
        {
            BLL.Coupons.Instance.Delete(int.Parse(iID.ToString()));
        }
        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox ProductName = new TextBox();
      
        override protected void BindToolBar()
        {
            base.BindToolBar(true,false,false,false,false);
            //ucToolBar.AddLine();
            //LbName.ID = "LbName";
            //LbName.Text = "名称";
            //ucToolBar.AddCtr(LbName);
            //ProductName.ID = "ProductName";
            //ProductName.Attributes.Add("style", "width:90px");
            //ucToolBar.AddCtr(ProductName);

           
            //base.ShowCustomSearch("查询");
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}