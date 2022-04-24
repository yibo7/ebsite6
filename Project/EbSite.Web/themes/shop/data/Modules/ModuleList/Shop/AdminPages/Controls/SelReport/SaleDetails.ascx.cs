using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.SelReport
{
    public partial class SaleDetails : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "销售明细";
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
                return new Guid("cf34edc7-f7d7-4dda-ae38-125bc61111dc");
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
            pcPage.PageSize = 15;
            return ModuleCore.BLL.Buy_OrderItem.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, "", "id desc", out iCount);
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

        }

        protected void btnSeach_Click(object sender, EventArgs e)
        {
            string strBegin = this.txtBeginDate.Text;
            string strEnd = this.txtEndDate.Text;
            string strWhere = "1=1 ";
            if (!string.IsNullOrEmpty(strBegin))
            {
                strWhere +=string.Format("and adddatetime>='{0}' ",strBegin);
            }
            if (!string.IsNullOrEmpty(strEnd))
            {
                strWhere += string.Format("and adddatetime<='{0}'", strEnd);
            }
            pcPage.PageSize = 15;
            int iCount = 0;
            List<ModuleCore.Entity.Buy_OrderItem> ls = ModuleCore.BLL.Buy_OrderItem.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, strWhere, "id desc", out iCount);
            if (ls != null && ls.Count > 0)
            {
                this.pcPage.AllCount = iCount;
                this.rpList.DataSource = ls;
                this.rpList.DataBind();
            }
            else
            {
                this.rpList.DataSource =null;
                this.rpList.DataBind();
            }
        }
    }
}