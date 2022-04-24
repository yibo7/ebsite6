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

namespace EbSite.Modules.Shop.UserPages.Controls.OrderRepair
{
    public partial class repairlist : MPUCBaseListForUserRp
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("13fd55f1-e4d6-41f6-934d-0b436c926d5d");
            }
        }
        
        public override string PageName
        {
            get
            {
                
                return "申请列表";
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
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "6";
            }
        }
        public override int OrderID
        {
            get
            {
                return 0;
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
            return ModuleCore.BLL.Buy_Orders.Instance.GetListPages(this.pcPage.PageIndex, this.pcPage.PageSize,"UserId="+base.UserID+" and (orderstatus="+ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.确认收货)+" or orderstatus="+ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.交易完成)+")", "",out iCount);
        }

        override protected object SearchList(out int iCount)
        {

            string typeid ="";
            string orderid = ucToolBar.GetItemVal(tbOrderID);
            string dtb ="";
            string dte ="";

            SqlWhere = ModuleCore.BLL.Buy_Orders.Instance.GetSqlWhere(orderid, typeid, dtb, dte);
            return ModuleCore.BLL.Buy_Orders.Instance.GetListPages(this.pcPage.PageIndex, this.pcPage.PageSize, base.GetWhere(true), "", out iCount);
        }

        public string SqlWhere = "";
        protected override string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            return SqlWhere;
        }
        override protected void Delete(object iID)
        {
           
        }

        public string GetLinkURL(object id,object status)
        {
            int tid = Core.Utils.ObjectToInt(id, 0);
            int stas = Core.Utils.ObjectToInt(status,0);
            if (tid > 0 &&stas==0)
            {
                return string.Format("<a href='?mukey=999ebbca-0202-4a18-9141-3fd7a8808957&id={0}' class='{1}'>申请</a>",id, "btnappliy");
            }
            else
            {
                return string.Format("<a href='{0}' class='{1}'>申请</a>", "javascript:void(0)", "btnnoappliy");
            }
        }

        #region

        protected void gdList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ModuleCore.Entity.Buy_Orders order = (ModuleCore.Entity.Buy_Orders)e.Item.DataItem;
                if (order != null)
                {
                    List<ModuleCore.Entity.Buy_OrderItem> ls = ModuleCore.BLL.Buy_OrderItem.Instance.GetListArray("orderid="+order.OrderId);
                    System.Web.UI.WebControls.Repeater rpItem=(System.Web.UI.WebControls.Repeater)e.Item.FindControl("rpItemList");
                    rpItem.DataSource = ls;
                    rpItem.DataBind();
                }
            }
        }

        #endregion

        #region 工具栏的初始化

        protected Label Lb = new Label();
        protected Label LbOrderID = new Label();
        protected System.Web.UI.WebControls.TextBox tbOrderID = new System.Web.UI.WebControls.TextBox();
        override protected void BindToolBar()
        {

            base.BindToolBar(true, true);
            //ucToolBar.AddLine();
            LbOrderID.ID = "LbOrderID";
            LbOrderID.Text = "订单号";
            ucToolBar.AddCtr(LbOrderID);
            tbOrderID.ID = "tbOrderID";
            tbOrderID.Width =200;
            
            ucToolBar.AddCtr(tbOrderID);

            
            ucToolBar.AddBnt("快速查询", IISPath + "images/menus/Search.gif", "search");
        }
        #endregion

    }
}