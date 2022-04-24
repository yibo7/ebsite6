using System;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace EbSite.Modules.Shop.AdminPages.Controls.Orders.HelpPage
{
    public partial class SendOrder : MPUCBaseShow<ModuleCore.Entity.Buy_Orders>
	{
        public override string PageName
        {
            get
            {
                return "发货";
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
                    //配送方式
                    List<EbSite.Entity.PsDelivery> lsSend = EbSite.BLL.PsDelivery.Instance.FillList();
                    if (lsSend != null && lsSend.Count > 0)
                    {
                        this.rdoSendList.DataTextField = "ModeName";
                        this.rdoSendList.DataValueField = "id";
                        this.rdoSendList.DataSource = lsSend;
                        this.rdoSendList.DataBind();

                        if (m.RealShippingModeId>0)
                        {
                            this.rdoSendList.SelectedValue = m.RealShippingModeId.ToString();
                        }
                        else
                        {
                            this.rdoSendList.SelectedValue = m.ShippingModeId.ToString();
                        }
                        rdoSendList_SelectedIndexChanged(sender, e);
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

        protected void btnSendOrder_Click(object sender, EventArgs e)
        {
            if (this.rdoSendList.SelectedItem != null)
            {
                int id = int.Parse(GetKeyID);
                if (id > 0)
                {
                    string selID = this.rdoSendList.SelectedValue;
                    string selName = this.rdoSendList.SelectedItem.Text;
                    string sendNum = this.txtSendNum.Text;
                    //2:已发货
                    Dictionary<string, object> dicList = new Dictionary<string, object>();
                    dicList.Add("RealShippingModeId", selID);
                    dicList.Add("RealModeName", string.Format("'{0}'", selName));
                    dicList.Add("DeliveryOrderNumber", string.Format("'{0}'", sendNum));
                    dicList.Add("ExpressCompanyName", string.Format("'{0}'", this.rdoWlCompanyList.SelectedItem.Text));
                    dicList.Add("ExpressCompanyAbb", string.Format("'{0}'", this.rdoWlCompanyList.SelectedValue));
                    dicList.Add("OrderStatus",ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.已发货));
                    dicList.Add("SendDate", string.Format("'{0}'", DateTime.Now));
                    ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicList, id);
                    //添加日志
                    ModuleCore.BLL.buy_orderlog.Instance.Add(id, string.Format("您的货物已配送,物流公司为:{0},单号为:{1},请准备收货", this.rdoWlCompanyList.SelectedItem.Text,sendNum), ModuleCore.SystemEnum.OrderLogType.前台显示);
                    ModuleCore.Entity.Buy_Orders orderMd=ModuleCore.BLL.Buy_Orders.Instance.GetEntity(id);
                    //减少库存
                    //List<ModuleCore.Entity.Buy_OrderItem> itemList = ModuleCore.BLL.Buy_OrderItem.Instance.GetListArray("orderid="+orderMd.OrderId);
                    //if (itemList != null && itemList.Count > 0)
                    //{
                    //    foreach (ModuleCore.Entity.Buy_OrderItem item in itemList)
                    //    {
                    //        ModuleCore.Core.OutStore(item.SKU, item.ProductId, item.GiveQuantity + item.Quantity);
                    //    }
                    //}

                    base.RunJs("alert('发货成功!')");
                }
                else
                {
                    base.RunJs("alert('无法操作，请重新打开此页面')");
                }
            }
            else
            {
                base.RunJs("alert('配送方式不能为空！')");
            }
        }

        protected void rdoSendList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pid =Core.Utils.StrToInt(this.rdoSendList.SelectedValue);
            List<EbSite.Entity.PsDelivery> lsSend = EbSite.BLL.PsDelivery.Instance.FillList();
            List<EbSite.Entity.PsDelivery> mlst=(from c in lsSend where c.id==pid select c).ToList();
            if (mlst != null && mlst.Count > 0)
            {
                EbSite.Entity.PsDelivery m = mlst[0];

                string psIDs = m.PsCompanyIds;
                List<EbSite.Entity.PsCompany> psCompanyList = EbSite.BLL.PsCompany.Instance.FillList();
                List<EbSite.Entity.PsCompany> tmpList = new List<Entity.PsCompany>();
                if (!string.IsNullOrEmpty(psIDs))
                {
                    string[] strArr = psIDs.Split(',');
                    EbSite.Entity.PsCompany tmM;
                    foreach (string str in strArr)
                    {
                        int tmpID = Core.Utils.StrToInt(str, 0);
                        if (tmpID > 0)
                        {
                            tmM = (from b in psCompanyList where b.id == tmpID select b).ToList()[0];
                            tmpList.Add(tmM);
                        }
                    }
                }
                this.rdoWlCompanyList.DataTextField = "CompanyName";
                this.rdoWlCompanyList.DataValueField = "CompanyCode";
                this.rdoWlCompanyList.DataSource = tmpList;
                this.rdoWlCompanyList.DataBind();
            }
        }
        public void rptOrderItem_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
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
