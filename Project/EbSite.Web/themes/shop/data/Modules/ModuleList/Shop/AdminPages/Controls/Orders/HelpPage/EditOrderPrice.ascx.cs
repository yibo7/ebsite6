using System;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage
{
    public partial class EditOrderPrice : MPUCBaseShow<ModuleCore.Entity.Buy_Orders>
	{
        public override string PageName
        {
            get
            {
                return "修改订单价格";
            }
        }
		/// <summary>
		/// 权限全部
		/// </summary>
		public override string Permission
		{
			get
			{
				return "70";
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
                    this.txtYF.Text =m.AdjustedFreight > 0 ? m.AdjustedFreight.ToString() :m.Freight.ToString();
                    this.txtPayPrice.Text = m.PayFree > 0 ? m.PayFree.ToString() : "0.00";
                    this.txtAdjusted.Text =string.Format("{0}",m.AdjustedDiscount);
                    this.litSendName.Text = string.Format("({0})", string.IsNullOrEmpty(m.RealModeName) ? (string.IsNullOrEmpty(m.ModeName) ? "暂无" : m.ModeName) : m.RealModeName);
                    this.litPayName.Text = string.Format("({0})", m.PaymentType);
                    this.litDisAmount.Text = string.Format("{0}", m.DiscountAmount > 0 ? m.DiscountAmount.ToString() : "暂无");
                    this.litActName.Text = string.Format("{0}",string.IsNullOrEmpty(m.ActivityName)?"暂无":m.ActivityName);
                    this.litOrderOptionPrice.Text = string.Format("&yen;{0}", m.OptionPrice > 0 ? m.OptionPrice.ToString() : "0.00");
                    this.litCouponValue.Text = string.Format("&yen;{0}", m.CouponValue > 0 ? m.CouponValue.ToString() : "0.00");
                    this.litOrderScore.Text = string.Format("{0}", m.OrderPoint > 0 ? m.OrderPoint.ToString() : "0");
                    this.litOrderTotal.Text = string.Format("&yen;{0}", m.OrderTotal > 0 ? m.OrderTotal.ToString() : "0.00");

                    //订单可选项费用
                    this.litOrderOptionPrice.Text = string.Format("&yen;{0}", m.OptionPrice > 0 ? m.OptionPrice.ToString() : "0.00");
                    List<EbSite.Entity.OrderOptionValue> orderoptionList = EbSite.BLL.OrderOptionValue.Instance.GetListArray("orderid=" + m.OrderId);
                    if (orderoptionList != null && orderoptionList.Count > 0)
                    {
                        StringBuilder strOption = new StringBuilder();
                        foreach (EbSite.Entity.OrderOptionValue optionMd in orderoptionList)
                        {
                            strOption.AppendFormat("{0}{1}:&nbsp;&yen;{2}，", optionMd.ListDescription, optionMd.ItemDescription, optionMd.AdjustedPrice);
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

        protected void btonSubmit_Click(object sender, EventArgs e)
        {
            ModuleCore.Entity.Buy_Orders m = LoadModel();
            string yfFree = this.txtYF.Text;//运费
            string payFree = this.txtPayPrice.Text;//支付费
            string adjFree = this.txtAdjusted.Text;//差价
            //计算总金额
            decimal yfs = decimal.Parse(yfFree) - (m.AdjustedFreight>0?(decimal)m.AdjustedFreight:m.Freight);
            decimal pays = decimal.Parse(payFree) - (m.PayFree == null ? 0 : (decimal)m.PayFree);
            decimal adjs = decimal.Parse(adjFree) - (m.AdjustedDiscount == null ? 0 : (decimal)m.AdjustedDiscount); 
            decimal totals = (decimal)m.OrderTotal+yfs+pays+adjs; 

            Dictionary<string, object> dicArray = new Dictionary<string, object>();
            dicArray.Add("AdjustedFreight", yfFree);
            dicArray.Add("PayFree", payFree);
            dicArray.Add("AdjustedDiscount", adjFree);
            dicArray.Add("OrderTotal", totals);
            //dicArray.Add("OrderPoint", totals);
            if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArray, m.id))
            { 
                //添加操作日志
                ModuleCore.BLL.buy_orderlog.Instance.Add(m.id,string.Concat("修改了订单费用(不是商品价格),修改后的总价是:",totals), ModuleCore.SystemEnum.OrderLogType.全部显示);
                base.RunJs("CloseOrder(1)");
            }
            else
            {
                base.RunJs("CloseOrder(0)");
            }
        }

        protected void rptOrderItem_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
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
