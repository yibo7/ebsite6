using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages
{
    /// <summary>
    /// 品牌管理
    /// </summary>
    public partial class Orders : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("5f770597-e2bd-4c19-b206-97eebadb573a");
            }
        }
        public override string PageName
        {
            get
            {
                return "订单管理";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {    
            if (PageType ==4)//修改订单价格
            {
                base.LoadAControl("HelpPage/EditOrderPrice.ascx");
            }
            else if (PageType == 5)//关闭订单
            {
                base.LoadAControl("HelpPage/CloseOrder.ascx");
            }
            else if (PageType ==6)//查看 订单退款
            {
                base.LoadAControl("HelpPage/RefundOrder.ascx");
            }
            else if (PageType ==7)//标注订单
            {
                base.LoadAControl("HelpPage/MarkedOrder.ascx");
            }
            else if (PageType ==8)//订单详情
            {
                base.LoadAControl("HelpPage/OrderDetail.ascx");
            }
            else if (PageType ==9)//修改地址
            {
                base.LoadAControl("HelpPage/EditAddress.ascx");
            }
            else if (PageType ==10)//修改配送方式
            {
                base.LoadAControl("HelpPage/EditSendType.ascx");
            }
            else if (PageType ==11)//修改支付方式
            {
                base.LoadAControl("HelpPage/EditPayType.ascx");
            }
            else if (PageType == 12)//打印快递单
            {
                base.LoadAControl("HelpPage/PrintKDD.ascx");
            }
            else if (PageType == 13)//打印购货单
            {
                base.LoadAControl("HelpPage/PrintGHD.ascx");
            }
            else if (PageType == 14)//打印配送单
            {
                base.LoadAControl("HelpPage/PrintPSD.ascx");
            }
            else if (PageType == 15)//打印配送单
            {
                base.LoadAControl("HelpPage/SendOrder.ascx");
            }
            else if (PageType == 16)//退款 订单 操作
            {
                base.LoadAControl("HelpPage/OrderRefund.ascx");
            }
            else if (PageType == 17)
            {
                base.LoadAControl("HelpPage/OrderLog.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}