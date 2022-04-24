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
    public partial class PrintGHD : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "打印购货单";
            }
        }
    
        public override string Permission
        {
            get
            {
                return "80";
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
                       #region 基本信息

                       this.litAddDate.Text = m.OrderAddDate.ToString();
                       this.litRecevUName.Text = m.SendToUserName;
                       this.litPayType.Text = m.PaymentType;
                       this.litOrderNum.Text = m.OrderId.ToString();
                       this.litZipCode.Text = m.ZipCode;
                       this.litSendType.Text = m.RealModeName;
                       this.litSendNum.Text = m.DeliveryOrderNumber;
                       this.litPhoneNum.Text = m.TelPhone;
                       this.litRecevAddress.Text =m.Address;
                       this.litMobilNum.Text = m.CellPhone;
                       this.litOrderState.Text = ModuleCore.BLL.Buy_Orders.Instance.ParseOrderState(m.OrderStatus.ToString());
                       this.litOrderRemark.Text = m.Remark;

                       #endregion 基本信息

                       #region 商品列表

                       List<ModuleCore.Entity.Buy_OrderItem> ls = ModuleCore.BLL.Buy_OrderItem.Instance.GetListArray(string.Format("OrderId=\"{0}\"",m.OrderId));
                       if (ls != null && ls.Count > 0)
                       {
                           this.rptDataList.DataSource = ls;
                           this.rptDataList.DataBind();
                       }

                       #endregion 商品列表

                       #region 费用计算

                       this.litGoodsPrice.Text = string.Format("&yen;{0}",m.OrderTotal>0?m.OrderTotal.ToString():"0.00");
                       this.litYFFree.Text = string.Format("&yen;{0}", m.AdjustedFreight > 0 ? m.AdjustedFreight.ToString() : m.Freight.ToString());
                       this.litPayFree.Text = string.Format("&yen;{0}",m.PayFree>0?m.PayFree.ToString():"0.00");
                       this.litYHQPrice.Text = string.Format("&yen;{0}",m.CouponValue>0?m.CouponValue.ToString():"0.00");
                       this.litMJZK.Text = string.Format("&yen;{0}","0.00");
                       this.litMEFree.Text = string.Format("&yen;{0}",m.DiscountAmount>0?m.DiscountAmount.ToString():"0.00");
                       this.litOrderOptionFree.Text = string.Format("&yen;{0}",m.OptionPrice>0?m.OptionPrice.ToString():"0.00");
                       this.litRealPrice.Text = string.Format("&yen;{0}",m.OrderTotal.ToString());

                       #endregion 费用计算

                       List<ModuleCore.Entity.creditproductorder> creditList = ModuleCore.BLL.creditproductorder.Instance.GetListArray(string.Format("a.orderid=\"{0}\"", m.OrderId));
                       if (creditList != null && creditList.Count > 0)
                       {
                          
                           this.rptCoreOrder.DataSource = creditList;
                           this.rptCoreOrder.DataBind();
                       }
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

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ModuleCore.Entity.Buy_Orders m = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(OrderCodeID);
            if (m != null)
            {
                //更改状态
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("isprinted",ModuleCore.BLL.Buy_Orders.Instance.GetUpdatePrint(m.IsPrinted,ModuleCore.SystemEnum.PrintType.购货单));
                ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dic, OrderCodeID);
                //添加操作日志
                ModuleCore.BLL.buy_orderlog.Instance.Add(m.OrderId.ToString(), "您的订单已受理，正等待出库", ModuleCore.SystemEnum.OrderLogType.全部显示);
                base.RunJs("PrintOrder()");
            }
        }

        protected void rptDataList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //查看是否开启了打印赠品
            if (Configs.Instance.Model.IsPrintGift)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    ModuleCore.Entity.Buy_OrderItem drData = (ModuleCore.Entity.Buy_OrderItem)e.Item.DataItem;
                    //提取分类ID 
                    long strID = drData.OrderItemKey;
                    List<ModuleCore.Entity.giftorderproduct> lsGift = ModuleCore.BLL.giftorderproduct.Instance.GetListArray("a.OrderItemID=" + strID);

                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rptGiveaWay");

                    if (lsGift != null && lsGift.Count > 0)
                    {
                        llClassList.DataSource = lsGift;
                        llClassList.DataBind();
                    }

                }
            }
        }
    }
}