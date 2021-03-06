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
    public partial class NewCoupons : UserControlListBase
    {
        public override string PageName
        {
            get
            {
                return "新创建优惠券";
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
                return 1;
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
            return BLL.Coupons.Instance.GetListPages(pcPage.PageIndex, iPageSize, "SentCount=0", "", out iCount);
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


               

                spModel.ColumnName = "CouponName";
                spModel.ColumnValue = ucToolBar.GetItemVal(ProductName);
                spModel.IsString = true;
                spModel.SearchWhere = EmSearchWhere.模糊匹配;
                spModel.SearchLink = EmSearchLink.与连and;
                lstSp.Add(spModel);

                SearchParameter spModel2 = new SearchParameter();
                spModel2.ColumnName = "SentCount";
                spModel2.ColumnValue = "0";
                spModel2.IsString = false;
                spModel2.SearchWhere = EmSearchWhere.相等匹配;
                lstSp.Add(spModel2);

                return lstSp.ToArray();
            }
        }
        override protected object SearchList(out int iCount)
        {
           
            return BLL.Coupons.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "", out iCount);
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
            base.BindToolBar();
            ucToolBar.AddLine();
            LbName.ID = "LbName";
            LbName.Text = "名称";
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