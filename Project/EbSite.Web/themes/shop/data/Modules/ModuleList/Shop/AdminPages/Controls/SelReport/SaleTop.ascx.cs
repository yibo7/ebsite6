using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using System.Data;

namespace EbSite.Modules.Shop.AdminPages.Controls.SelReport
{
    public partial class SaleTop : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "销售排行";
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
                return "61";
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
                return new Guid("0cfc7881-a542-4606-bc71-a5b8eba12298");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }
       
      
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return null;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTopProductList();
            }
        }

        protected void btnSeach_Click(object sender, EventArgs e)
        {
            GetTopProductList();
        }

        private void GetTopProductList()
        {
            string strBegin = this.txtBeginDate.Text;
            string strEnd = this.txtEndDate.Text;
            string strWhere = "1=1 ";
            if (!string.IsNullOrEmpty(strBegin))
            {
                strWhere += string.Format("and adddatetime>='{0}' ", strBegin);
            }
            if (!string.IsNullOrEmpty(strEnd))
            {
                strWhere += string.Format("and adddatetime<='{0}'", strEnd);
            }
            DataTable dt = ModuleCore.BLL.Buy_OrderItem.Instance.GetSaleTop(strWhere, 0);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.rpList.DataSource = dt;
                this.rpList.DataBind();
            }
            else
            {
                this.rpList.DataSource = null;
                this.rpList.DataBind();
            }
        }
    }
}