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
    public partial class AllList : BaseOrderList
    {

        public override string PageName
        {
            get { return "所有订单"; }
        }


        public override int OrderID
        {
            get { return 1; }
        }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get { return new Guid("05c7107c-75f7-483e-ba72-e794c9c59c7d"); }
        }

        protected override string AddUrl
        {
            get { return ""; }
        }

        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get { return true; }
        }

        protected override void Delete(object iID)
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

        protected override object LoadList(out int iCount)
        {
            List<ModuleCore.Entity.Buy_Orders> ls = ModuleCore.BLL.Buy_Orders.Instance.GetListPages(pcPage.PageIndex,
                                                                                                    pcPage.PageSize, "",
                                                                                                    "id desc",
                                                                                                    out iCount);
            return ls;
        }

        protected override object SearchList(out int iCount)
        {
            List<ModuleCore.Entity.Buy_Orders> ls = ModuleCore.BLL.Buy_Orders.Instance.GetListPages(pcPage.PageIndex,
                                                                                                    pcPage.PageSize,
                                                                                                    base.GetWhere(true),
                                                                                                    "id desc",
                                                                                                    out iCount);
            return ls;
        }

        /// <summary>
        /// 普通查询
        /// </summary>
        /// <param name="IsValueEmpytNoSearch"></param>
        /// <returns></returns>
        protected override string BulderSearchWhere(bool IsValueEmpytNoSearch)
        {
            string s_ordernum = ucToolBar.GetItemVal(txtOrderNum); //订单编号
            string s_printstate = ucToolBar.GetItemVal(printState); //打印状态
            string s_sendtype = ucToolBar.GetItemVal(sendType); //配送方式

            string s_ordericome = ucToolBar.GetItemVal(ddlOrderiCome);//订单来源
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
            string OrderState = ucToolBar.GetItemVal(ddlOrderState);
            if (!string.IsNullOrEmpty(OrderState))
            {
                sqlWhere.AppendFormat("and orderstatus={0}", OrderState);
            }

            if (!string.IsNullOrEmpty(s_ordericome))
            {
                sqlWhere.AppendFormat("and icome={0}", s_ordericome);
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
            string memberName = this.txtMemberAdv.Text; //会员名称
            string orderNum = this.txtOrderNumAdv.Text; //订单编号
            string goodsName = this.txtGoodsNameAdv.Text; //商品名称
            string toUserName = this.txtRecNameAdv.Text; //收货人姓名
            string printState = this.ddlPrintStateAdv.SelectedValue; //打印状态
            string sendName = this.ddlSendTypeAdv.SelectedValue; //配送方式

            string OrderState = ucToolBar.GetItemVal(ddlOrderState);
            if (!string.IsNullOrEmpty(OrderState))
            {
                sqlWhere.AppendFormat(" and orderstatus={0}", OrderState);
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
            if (!string.IsNullOrEmpty(this.dateStartAdv.Text) && !string.IsNullOrEmpty(this.dateEndAdv.Text))
            {
                int staDate = Core.SqlDateTimeInt.GetSecond(DateTime.Parse(this.dateStartAdv.Text + " 00:00:01"));
                int endDate = Core.SqlDateTimeInt.GetSecond(DateTime.Parse(this.dateEndAdv.Text + " 23:59:59"));
                if (endDate > staDate)
                {
                    sqlWhere.AppendFormat(" and (timenumber between {0} and {1})", staDate, endDate);
                }
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
        protected System.Web.UI.WebControls.Label laborderstate = new Label();
        protected System.Web.UI.WebControls.DropDownList ddlOrderState = new DropDownList();


        protected System.Web.UI.WebControls.Label labordericome = new Label();
        protected System.Web.UI.WebControls.DropDownList ddlOrderiCome = new DropDownList();

        protected override void BindToolBar()
        {
            base.BindToolBar(true, true, true, false, true);
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

            laborderstate.ID = "laborderstate";
            laborderstate.Text = "订单状态";
            ddlOrderState.ID = "ddlOrderState";
            ddlOrderState.Width = 100;
            base.BindDDLOrderStateList(ddlOrderState);

            ucToolBar.AddCtr(laborderstate);
            ucToolBar.AddCtr(ddlOrderState);

            LbPS.ID = "labPrint";
            LbPS.Text = "打印状态";
            printState.ID = "ddlPrintState";
            printState.Width = 80;
            base.BindDDLPrintTypeList(printState);
            
            ucToolBar.AddCtr(LbPS);
            ucToolBar.AddCtr(printState);

            LbST.ID = "labSend";
            LbST.Text = "配送方式";
            sendType.ID = "ddlSendType";
            sendType.Width = 80;
            base.BindDDLSendTypeList(sendType);

            ucToolBar.AddCtr(LbST);
            ucToolBar.AddCtr(sendType);



            labordericome.ID = "labordericome";
            labordericome.Text = "订单来源";
            ddlOrderiCome.ID = "ddlOrderiCome";
            ddlOrderiCome.Width = 100;
            base.BindDDLiComeList(ddlOrderiCome);

            ucToolBar.AddCtr(labordericome);
            ucToolBar.AddCtr(ddlOrderiCome);

            base.ShowCustomSearch("查询");
            ucToolBar.AddLine();
            base.ShowAdvSearch("高级");
        }

        #endregion 绑定工具条

    }
}