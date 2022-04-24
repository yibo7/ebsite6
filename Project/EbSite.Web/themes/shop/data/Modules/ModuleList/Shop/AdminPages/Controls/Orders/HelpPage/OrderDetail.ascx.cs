using System;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage
{
    public partial class OrderDetail : MPUCBaseShow<ModuleCore.Entity.Buy_Orders>
	{
        public override string PageName
        {
            get
            {
                return "订单详情";
            }
        }
		/// <summary>
		/// 权限全部
		/// </summary>
		public override string Permission
		{
			get
			{
				return "72";
			}
		}
		/// <summary>
		/// 重写删除
		/// </summary>
		protected override  void Delete()
		{
			//Model.Delete();
		}
		/// <summary>
		/// 重写Load事件
		/// </summary>
		protected override ModuleCore.Entity.Buy_Orders LoadModel()
		{
            ModuleCore.Entity.Buy_Orders md =ModuleCore.BLL.Buy_Orders.Instance.GetEntity(int.Parse(GetKeyID));
            if (Equals(md, null))
            {
                md = new ModuleCore.Entity.Buy_Orders();//防止删除后的页面出错
            }
            

            return md;
		}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ModuleCore.Entity.Buy_Orders m = LoadModel();
                if (m != null)
                {
                    string stepCss = "step1";
                    string liCss1 = " class=\"licss\"", liCss2 = "", liCss3 = "", liCss4 = "";
                    if (m.OrderStatus ==ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.等待付款))
                    {
                        liCss1 = "";
                        liCss2 = " class=\"licss\"";
                        stepCss = "step2";
                    }
                    else if (m.OrderStatus ==ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.已发货))
                    {
                        liCss1 = "";
                        liCss3 = " class=\"licss\"";
                        stepCss = "step3";
                    }
                    else if (m.OrderStatus == ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.交易完成))
                    {
                        liCss1 = "";
                        liCss4 = " class=\"licss\"";
                        stepCss = "step4";
                    }
                    else if (m.OrderStatus == ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.回收站))
                    {
                        stepCss = "";
                    }
                    if (!string.IsNullOrEmpty(stepCss))
                    {
                        //初始数据(订单步骤)
                        string strStepHtml = "<div class=\"step " + stepCss + "\"><ul class=\"stepul\"><li" + liCss1 + "><span>第1步</span>&nbsp;&nbsp;买家已下单</li><li" + liCss2 + "><span>第2步</span>&nbsp;&nbsp;买家付款</li>";
                        strStepHtml += "<li" + liCss3 + "><span>第3步</span>&nbsp;&nbsp;发货</li><li" + liCss4 + "><span>第4步</span>&nbsp;&nbsp;交易完成</li></ul></div>";
                        this.labStep.Text = strStepHtml;
                    }
                    else
                    {
                        this.labStep.Text = "";
                    }

                    this.litAdjFrei.Text = string.Format("&yen;{0}",m.AdjustedFreight > 0 ? m.AdjustedFreight.ToString() :m.Freight.ToString());
                    this.litPayFree.Text = string.Format("&yen;{0}", m.PayFree > 0 ? m.PayFree.ToString() : "0.00");
                    this.litAdjusted.Text = string.Format("&yen;{0}", m.AdjustedDiscount);

                    this.litDisAmount.Text = string.Format("{0}", m.DiscountAmount > 0 ? m.DiscountAmount.ToString() : "暂无");
                    this.litActName.Text = string.Format("{0}", string.IsNullOrEmpty(m.ActivityName) ? "暂无" : m.ActivityName);

                    //订单可选项费用
                    this.litOrderOptionPrice.Text = string.Format("&yen;{0}", m.OptionPrice > 0 ? m.OptionPrice.ToString() : "0.00");
                    List<EbSite.Entity.OrderOptionValue> orderoptionList =EbSite.BLL.OrderOptionValue.Instance.GetListArray("orderid="+m.OrderId);
                    if (orderoptionList != null && orderoptionList.Count > 0)
                    {
                        StringBuilder strOption = new StringBuilder();
                        foreach (EbSite.Entity.OrderOptionValue optionMd in orderoptionList)
                        {
                            strOption.AppendFormat("{0}{1}:&nbsp;&yen;{2}，",optionMd.ListDescription,optionMd.ItemDescription,optionMd.AdjustedPrice);
                        }
                        if (strOption.Length > 0)
                        {
                            this.litOrderOptionName.Text = strOption.ToString().TrimEnd('，');
                        }
                        else
                        {
                            this.litOrderOptionName.Text = "暂无";
                        }
                    }
                    else
                    {
                        this.litOrderOptionName.Text = "暂无";
                    }
                    this.litCouponValue.Text = string.Format("&yen;{0}", m.CouponValue > 0 ? m.CouponValue.ToString() : "0.00");
                    this.litOrderScore.Text = string.Format("{0}", m.OrderPoint > 0 ? m.OrderPoint.ToString() : "0");
                    this.litOrderTotal.Text = string.Format("&yen;{0}", m.OrderTotal > 0 ? m.OrderTotal.ToString() : "0.00");
                    this.litOrderState.Text = ModuleCore.BLL.Buy_Orders.Instance.ParseOrderState(m.OrderStatus.ToString());
                    this.litAdjFreiName.Text = string.IsNullOrEmpty(m.RealModeName) ? (string.IsNullOrEmpty(m.ModeName) ? "暂无" : m.ModeName) : m.RealModeName;
                    this.litPayFreeName.Text = string.IsNullOrEmpty(m.PaymentType) ? "暂无" : m.PaymentType;
                    this.litUserBalance.Text = m.UserBalance.ToString();

                    //加载商品列表
                    List<ModuleCore.Entity.Buy_OrderItem> ls = ModuleCore.BLL.Buy_OrderItem.Instance.GetListArray(string.Format("orderid=\"{0}\"",m.OrderId));
                    if (ls != null && ls.Count > 0)
                    {
                        this.rptOrderItem.DataSource = ls;
                        this.rptOrderItem.DataBind();
                    }


                    //加载积分 兑换商品列表
                    List<ModuleCore.Entity.creditproductorder> creditList = ModuleCore.BLL.creditproductorder.Instance.GetListArray(string.Format("a.orderid=\"{0}\"", m.OrderId));
                    if (creditList != null && creditList.Count > 0)
                    {
                        this.RepCredits.DataSource = creditList;
                        this.RepCredits.DataBind();
                    }
                   
                }
            }
        }

        public void rptOrderItem_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
               ModuleCore.Entity.Buy_OrderItem drData = (ModuleCore.Entity.Buy_OrderItem)e.Item.DataItem;
                //提取分类ID 
                long strID = drData.OrderItemKey;
                List<ModuleCore.Entity.giftorderproduct> lsGift = ModuleCore.BLL.giftorderproduct.Instance.GetListArray("a.OrderItemID="+strID);
                
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
