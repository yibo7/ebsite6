using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using System.Text;

namespace EbSite.Modules.Shop.AdminPages.Controls.Orders
{
    public partial class ListForAudit : BaseOrderList
    {
        public override string PageName
        {
            get
            {
                return "已审核(待支付)";
            }
        }
       

        public override int OrderID
        {
            get
            {
                return 3;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("c533d7cb-fa6b-4045-8cc7-bd421e5fb234");
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

        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 订单的状态
        /// </summary>
        public string OrderState
        {
            get
            {
                return "OrderStatus=" + base.GetOrderState(ModuleCore.SystemEnum.OrderStatus.审核订单);
            }
        }

        override protected void Delete(object iID)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //填充打印状态数据
                base.BindDDLPrintTypeList(this.ddlPrintStateAdv);
                base.BindDDLSendTypeList(this.ddlSendTypeAdv);
            }
        }

        override protected object LoadList(out int iCount)
        {
            List<ModuleCore.Entity.Buy_Orders> ls = ModuleCore.BLL.Buy_Orders.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, OrderState, "OrderAddDate desc", out iCount);
            return ls;
        }

        override protected object SearchList(out int iCount)
        {
            List<ModuleCore.Entity.Buy_Orders> ls = ModuleCore.BLL.Buy_Orders.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), "OrderAddDate desc", out iCount);
            return ls;
        }
        /// <summary>
        /// 普通查询
        /// </summary>
        /// <param name="IsValueEmpytNoSearch"></param>
        /// <returns></returns>
        override protected string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            string s_ordernum = ucToolBar.GetItemVal(txtOrderNum);//订单编号
            string s_printstate = ucToolBar.GetItemVal(printState);//打印状态
            string s_sendtype = ucToolBar.GetItemVal(sendType);//配送方式
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append("1=1 ");
            if (!string.IsNullOrEmpty(s_ordernum))
            {
                sqlWhere.AppendFormat("and orderid=\"{0}\" ", s_ordernum);
            }
            if (!string.IsNullOrEmpty(s_printstate) && !s_printstate.Equals("-1"))
            {
                if (s_printstate.Equals("1"))
                {
                    sqlWhere.Append("and IsPrinted>111 ");
                }
                else
                {
                    sqlWhere.Append("and IsPrinted<=111 ");
                }
            }
            if (!string.IsNullOrEmpty(s_sendtype) && !s_sendtype.Equals("-1"))
            {
                sqlWhere.AppendFormat("and shippingmodeid={0} ", s_sendtype);
            }
            if (!string.IsNullOrEmpty(OrderState))
            {
                sqlWhere.AppendFormat("and {0}", OrderState);
            }
            return sqlWhere.ToString();
        }
        /// <summary>
        /// 高级查询
        /// </summary>
        /// <param name="IsValueEmpytNoSearch"></param>
        /// <returns></returns>
        protected override string BulderSearchWhereAdv(bool IsValueEmpytNoSearch)
        {
            StringBuilder sqlWhere = new StringBuilder();
            sqlWhere.Append("1=1");
            string memberName = this.txtMemberAdv.Text;//会员名称
            string orderNum = this.txtOrderNumAdv.Text;//订单编号
            string goodsName = this.txtGoodsNameAdv.Text;//商品名称
            string toUserName = this.txtRecNameAdv.Text;//收货人姓名
            string printState = this.ddlPrintStateAdv.SelectedValue;//打印状态
            string sendName = this.ddlSendTypeAdv.SelectedValue;//配送方式
            if (!string.IsNullOrEmpty(OrderState))
            {
                sqlWhere.AppendFormat(" and {0}", OrderState);
            }
            if (!string.IsNullOrEmpty(memberName))
            {
                sqlWhere.AppendFormat(" and username=\"{0}\"", memberName);
            }
            if (!string.IsNullOrEmpty(orderNum))
            {
                sqlWhere.AppendFormat(" and orderid=\"{0}\"", orderNum);
            }
            if (!string.IsNullOrEmpty(toUserName))
            {
                sqlWhere.AppendFormat(" and SendToUserName=\"{0}\"", toUserName);
            }
            if (!printState.Equals("-1"))
            {
                sqlWhere.AppendFormat(" and IsPrinted={0}", printState);
            }
            if (!sendName.Equals("-1"))
            {
                sqlWhere.AppendFormat(" and shippingmodeid={0}", sendName);
            }
            return sqlWhere.ToString();
        }

        #region 绑定工具条

        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox txtOrderNum = new TextBox();
        protected System.Web.UI.WebControls.Label LbPS = new Label();
        protected System.Web.UI.WebControls.DropDownList printState = new DropDownList();
        protected System.Web.UI.WebControls.Label LbST = new Label();
        protected System.Web.UI.WebControls.DropDownList sendType = new DropDownList();
        override protected void BindToolBar()
        {
            base.BindToolBar(true, true, true, true, true);
            //ucToolBar.AddLine();
            //ucToolBar.AddBnt("全选", "/images/menus/Ok.gif", "", false, "SelectAll(1)", "");
            //ucToolBar.AddBnt("反选", "/images/menus/Error.gif", "", false, "SelectAll(0)", "");
            ucToolBar.AddBnt("删除", "/images/menus/Delete.gif", "", false, "DeleteItem()", "");
            //ucToolBar.AddBnt("批量打印快递单", "/images/menus/Printer.gif", "", false, "PrintOrders()", "");
            //ucToolBar.AddBnt("批量发货", "/images/menus/Compile-Run.gif", "", false, "SendProducts()", "");
            ucToolBar.AddLine();

            LbName.ID = "LbName";
            LbName.Text = "订单编号";
            ucToolBar.AddCtr(LbName);
            txtOrderNum.ID = "b_ordernum";
            txtOrderNum.Attributes.Add("style", "width:150px");
            ucToolBar.AddCtr(txtOrderNum);

            LbPS.ID = "labPrint";
            LbPS.Text = "打印状态";
            printState.ID = "ddlPrintState";
            printState.Width = 80;
            BindDDLPrintTypeList(printState);
            ucToolBar.AddCtr(LbPS);
            ucToolBar.AddCtr(printState);

            LbST.ID = "labSend";
            LbST.Text = "配送方式";
            sendType.ID = "ddlSendType";
            sendType.Width = 80;
            base.BindDDLSendTypeList(sendType);

            ucToolBar.AddCtr(LbST);
            ucToolBar.AddCtr(sendType);

            base.ShowCustomSearch("查询");
            ucToolBar.AddLine();
            base.ShowAdvSearch("高级");
        }

        #endregion 绑定工具条

    }
}