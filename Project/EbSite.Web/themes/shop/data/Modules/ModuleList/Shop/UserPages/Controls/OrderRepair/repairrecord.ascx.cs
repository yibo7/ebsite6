using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Modules;
using EbSite.Control;
using DropDownList = System.Web.UI.WebControls.DropDownList;
using System.Data;

namespace EbSite.Modules.Shop.UserPages.Controls.OrderRepair
{
    public partial class repairrecord : MPUCBaseListForUserRp
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("bca929f1-3284-4b0a-b47e-e0c573eba7ad");
            }
        }
        
        public override string PageName
        {
            get
            {
                
                return "退换货记录";
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
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "6";
            }
        }

        override protected string AddUrlType
        {
            get
            {
                return "0";
            }

        }
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.Buy_OrderItem.Instance.GetTHOrderItem_GetListPages(base.UserID,pcPage.PageIndex, pcPage.PageSize,
                                                                                     out iCount);
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }

        public string SqlWhere = "";
        protected override string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            return SqlWhere;
        }
        override protected void Delete(object iID)
        {
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable dt = ModuleCore.BLL.Buy_OrderItem.Instance.GetTHOrderItemList(base.UserID);
                //this.gdList.DataSource = dt;
                //this.gdList.DataBind();
            }
        }

        protected string GetItemStatus(object state)
        {
            int istate = Core.Utils.ObjectToInt(state, 0);
            if (istate > 0)
            {
                return ((ModuleCore.SystemEnum.OrderItemStatus)istate).ToString();
            }
            else
            {
                return "申请失败";
            }
        }
    }
}