using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage
{
    public partial class RefundOrder : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "订单退款信息";
            }
        }
    
        public override string Permission
        {
            get
            {
                return "74";
            }
        }

        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }
        protected int OrderCodeID
        {
            get 
            {
                if (Request.Params["id"] != null)
                {
                    return Core.Utils.StrToInt(Request.Params["id"],0);
                }
                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (OrderCodeID > 0)
                {
                    ModuleCore.Entity.Buy_Orders m = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(OrderCodeID);
                    if (m != null)
                    {
                        this.litOrderNum.Text = m.OrderId.ToString();
                        this.litSuccesDate.Text = m.FinishDate.ToString();
                        this.litFactPrice.Text = m.OrderTotal.ToString();
                        this.litRefundDate.Text = m.FinishDate.ToString();
                        this.litRefundState.Text = m.RefundStatus>0?"退款成功":"未处理";
                        if (m.RefundStatus > 0)
                        {
                            litRefundStateEx.Text = "退款成功";
                        }
                        else
                        {
                            litRefundStateEx.Text = "未处理";
                        }
                        this.litRefundPrice.Text = m.RefundAmount.ToString();
                        this.litRefundMothd.Text = m.RefundStatus == 1 ? "线下退款" : "退款到买家的预付款账户";
                        this.litRefundMothdEx.Text = m.RefundStatus == 1 ? "我已经跟买家联系，使用线下操作完成退款" : "使用预付款功能退款到买家的预付款账户";
                        this.litRefundMark.Text = m.RefundRemark;
                    }
                }
            }
        }


        override protected void InitModifyCtr()
        {
           
        }
        override protected void SaveModel()
        {

        }
    }
}