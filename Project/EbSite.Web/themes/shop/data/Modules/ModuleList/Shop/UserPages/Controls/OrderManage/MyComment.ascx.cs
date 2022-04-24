using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.UserPages.Controls.OrderManage
{
    public partial class MyComment : MPUCBaseShow<ModuleCore.Entity.Buy_Orders>
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("34394338-7ff6-480e-a478-e6809d8d7546");
            }
        }

        public override string PageName
        {
            get
            {

                return "商品评价";
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
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "5";
            }
        }

        protected override ModuleCore.Entity.Buy_Orders LoadModel()
        {
            if (!string.IsNullOrEmpty(GetKeyID))
            {
                return ModuleCore.BLL.Buy_Orders.Instance.GetEntity(int.Parse(GetKeyID));
            }
            else
            {
                Tips("出错了", "找不到要查看的记录!");
                return null;
            }
        }

       
      
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ModuleCore.Entity.Buy_OrderItem> ls = ModuleCore.BLL.Buy_OrderItem.Instance.GetListArray(0, "orderid="+Model.OrderId, "");
                gdList.DataSource = ls;
                gdList.DataBind();
            }
        }
    }
}