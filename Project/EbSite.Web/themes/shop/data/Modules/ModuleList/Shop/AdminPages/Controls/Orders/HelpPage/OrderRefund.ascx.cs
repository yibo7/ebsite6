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
    public partial class OrderRefund : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "订单退款操作";
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
                        this.litFactPrice.Text = m.OrderTotal.ToString();
                        this.litOrderDate.Text = m.OrderAddDate.ToString();
                        this.rdoRefundReason.Items[1].Enabled =EbSite.Base.Host.Instance.IsOpenBalance(m.UserId);
                        if (m.GroupId > 0)
                        {
                            if (m.GroupBuyStatus == (int)ModuleCore.SystemEnum.GroupBuyState.成功结束)
                            {
                                this.txtRefundPrice.Text = m.GroupPrice.ToString();
                            }
                            else
                            {
                                ModuleCore.Entity.GroupBuy groupMD = ModuleCore.BLL.GroupBuy.Instance.GetEntity(Core.Utils.StrToInt(m.GroupId.ToString()));
                                if (groupMD != null)
                                {
                                    this.txtRefundPrice.Text = (m.GroupPrice - groupMD.NeedPrice).ToString();
                                }
                            }
                            this.txtRefundPrice.Enabled = false;
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

        protected void btnConfirmRefundPrice_Click(object sender, EventArgs e)
        {
            ModuleCore.Entity.Buy_Orders m = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(OrderCodeID);
            decimal tPrice = decimal.Parse(this.txtRefundPrice.Text.Trim());
            if (tPrice > 0 && m.OrderTotal >= tPrice)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("RefundStatus", this.rdoRefundReason.SelectedValue);
                dic.Add("RefundAmount",string.Format("'{0}'",tPrice));
                dic.Add("RefundRemark", string.Format("'{0}'",this.txtReamrk.Text));
                dic.Add("FinishDate", string.Format("'{0}'",DateTime.Now));
                dic.Add("OrderStatus", ModuleCore.BLL.Buy_Orders.Instance.GetStatusTips(ModuleCore.SystemEnum.OrderStatus.回收站));
                ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dic, m.id);
                string tWhere = "";
                //判断是否是退到预付款中
                if (this.rdoRefundReason.SelectedValue.Equals("2"))
                {
                    EbSite.Entity.PayPass pYFK =EbSite.BLL.PayPass.Instance.GetEntityByUserID(m.UserId);
                    pYFK.Balance = pYFK.Balance + tPrice;
                    
                    //EbSite.BLL.PayPass.Instance.Update(pYFK);
                    
                    EbSite.Entity.AccountMoneyLog am = new Entity.AccountMoneyLog();
                    am.UserId = m.UserId;
                    am.UserName = m.Username;
                    am.TradeDate = DateTime.Now;
                    am.TradeType = 5;
                    am.Income = tPrice;
                    am.Expenses = 0;
                    am.Balance = pYFK.Balance;
                    am.Remark = "后台退款";
                    tWhere = "退款至个人后台预付款";
                    //EbSite.BLL.AccountMoneyLog.Instance.Add(am);

                    EbSite.BLL.AccountMoneyLog.Instance.Add( am,pYFK);
                }
                //减积分
                EbSite.Base.Host.Instance.MinusUserCreditsByID(m.UserId,m.OrderPoint);
                //库存处理

                //添加操作日志
                ModuleCore.BLL.buy_orderlog.Instance.Add(OrderCodeID, string.Concat("退款成功!",(string.IsNullOrEmpty(tWhere)?"":","+tWhere)), ModuleCore.SystemEnum.OrderLogType.全部显示);
                base.RunJs("alert('退款成功!')");
            }
            else
            {
                base.RunJs("alert('输入的金额不符合要求!')");
            }
        }
    }
}