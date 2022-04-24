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
    public partial class Transformation : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "购买转化率";
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
                return new Guid("4ac8e669-0596-4c87-8552-fbdf716f0ced");
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
                DataTable dt = ModuleCore.BLL.Buy_Orders.Instance.GetOrderViewRate(20);
                this.rpList.DataSource = dt;
                this.rpList.DataBind();
            }
        }
    }
}