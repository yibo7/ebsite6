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
    public partial class OrderStatistics : MPUCBaseList
    {
        public override string PageName
        {
            get
            {
                return "订单统计";
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
                return new Guid("b7bcdc45-284a-439e-8c0a-64f87af718cd");
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
            List<ModuleCore.Entity.Buy_Orders> ls = ModuleCore.BLL.Buy_Orders.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, "", "id desc", out iCount);
            if (ls != null && ls.Count > 0)
            {
                this.litCureenCount.Text = ls.Count.ToString();
                this.litTotalCount.Text =iCount.ToString();
                BindCountMoney(ls);

                string totalProfit = "0.00";
                string totalPrice = ModuleCore.BLL.Buy_Orders.Instance.GetTotalOrderPrice("", out totalProfit);
                this.litTotalMoney.Text = totalPrice;
                this.litTotalProfit.Text = totalProfit;

                return ls;
            }
            else
            {
                return null;
            }
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
                
            }
        }

        override protected void rpList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ModuleCore.Entity.Buy_Orders md =(ModuleCore.Entity.Buy_Orders)e.Item.DataItem;
                if (md != null)
                {
                    List<ModuleCore.Entity.Buy_OrderItem> ls = ModuleCore.BLL.Buy_OrderItem.Instance.GetListArray(string.Concat("orderid=",md.OrderId));
                    if (ls != null && ls.Count > 0)
                    {
                        Repeater rpItemList = (Repeater)e.Item.FindControl("repItemList");
                        rpItemList.DataSource = ls;
                        rpItemList.DataBind();
                    }
                }
            }
        }

        protected void btnSeach_Click(object sender, EventArgs e)
        {
            pcPage.PageSize = 15;
            int iCount = 0;

            string strMemberName = this.txtMeberName.Text;
            string strReUserName = this.txtReUserName.Text;
            string strOrderNum = this.txtOrderNum.Text;
            string strBeginDate = this.txtBeginDate.Value;
            string strEndDate = this.txtEndDate.Value;
            string strWhere = "1=1 ";
            if (!string.IsNullOrEmpty(strMemberName))
            {
                strWhere +=string.Format("and username='{0}' ",strMemberName);
            }
            if (!string.IsNullOrEmpty(strReUserName))
            {
                strWhere += string.Format("and sendtousername='{0}' ", strReUserName);
            }
            if (!string.IsNullOrEmpty(strOrderNum))
            {
                strWhere += string.Format("and orderid={0} ", strOrderNum);
            }
            if (!string.IsNullOrEmpty(strBeginDate))
            {
                strWhere += string.Format("and orderadddate>'{0}' ", strBeginDate);
            }
            if (!string.IsNullOrEmpty(strEndDate))
            {
                strWhere += string.Format("and orderadddate<'{0}' ", strEndDate);
            }

            List<ModuleCore.Entity.Buy_Orders> ls = ModuleCore.BLL.Buy_Orders.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, strWhere, "id desc", out iCount);
            if (ls != null && ls.Count > 0)
            {
                this.litCureenCount.Text = ls.Count.ToString();
                this.litTotalCount.Text = iCount.ToString();

                BindCountMoney(ls);

                this.pcPage.AllCount= iCount;
                this.rpList.DataSource = ls;
                this.rpList.DataBind();
            }
            else
            {
                this.pcPage.AllCount = 0;
                this.rpList.DataSource = null;
                this.rpList.DataBind();
            }
        }

        private void BindCountMoney(List<ModuleCore.Entity.Buy_Orders> ls)
        {
            decimal d = 0,dr=0;
            foreach (ModuleCore.Entity.Buy_Orders md in ls)
            {
                if (md != null && md.OrderTotal > 0)
                {
                    d += md.OrderTotal;
                    dr +=decimal.Parse(md.OrderProfit.ToString());
                }
            }
            this.litCureenProfit.Text = dr.ToString();
            this.litCureenTotalMoney.Text = d.ToString();
        }
    }
}