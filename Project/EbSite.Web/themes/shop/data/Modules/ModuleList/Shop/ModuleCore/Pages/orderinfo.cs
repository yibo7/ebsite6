using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.EntityAPI;
using EbSite.Base.Json;
using EbSite.Base.Page;
using EbSite.Entity;

using System.Text;
using EbSite.Modules.Shop.ModuleCore.BLL;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class orderinfo : BasePageM
    {
       

        protected global::System.Web.UI.WebControls.Repeater orderItem;
        protected global::System.Web.UI.WebControls.Repeater orderrecod;
        protected global::System.Web.UI.WebControls.Repeater rpKuaiDi;
        protected global::System.Web.UI.WebControls.Repeater rptCoreOrder;

        protected ModuleCore.Entity.Buy_Orders Model;
        //订单状态说明
        protected string OrderStateMark
        {
            get
            {
                if (Model.PaymentTypeId == -1)//货到付款
                {
                    switch (Model.OrderStatus) //订单状态  0.等待买家付款 1.等待发货 2.已发货 3.成功订单 4.已关闭 5.历史订单 6.已删除  
                    {
                        case 0:
                            return "尊敬的客户，您选择了货到付款，我们正在为您备货，请耐心等待。";
                        case 1:
                            return "尊敬的客户，您选择了货到付款，我们已经准备为您发货，请耐心等待。";
                        case 2:
                            return "尊敬的客户，我们的物流人员正在为您打包商品，请耐心等待。";
                        case 3:
                            return "商品已经出库。";
                        case 4:
                            return "订单已经完成，感谢您在本站购物，欢迎您对本次交易及所购商品进行评价。";
                        case 5:
                            return "历史订单";
                        case 6:
                            return "已删除订单";

                    }
                }
                else
                {
                    switch (Model.OrderStatus) //订单状态  0.等待买家付款 1.等待发货 2.已发货 3.成功订单 4.已关闭 5.历史订单 6.已删除  
                    {
                        case 0:
                            return "尊敬的客户，我们还未收到该订单的款项，请您尽快付款（在线支付帮助），如果您已经付款，请务必填写付款确认。该订单会为您保留24小时（从下单之日算起），24小时之后如果还未付款，系统将自动取消该订单。";
                        case 1:
                            return "尊敬的客户，我们还未收到该订单的款项，请您尽快付款（在线支付帮助），如果您已经付款，请务必填写付款确认。该订单会为您保留24小时（从下单之日算起），24小时之后如果还未付款，系统将自动取消该订单。";
                        case 2:
                            return "尊敬的客户，我们的物流人员正在为您打包商品，请耐心等待。";
                        case 3:
                            return "商品已经出库。";
                        case 4:
                            return "订单已经完成，感谢您在本站购物，欢迎您对本次交易及所购商品进行评价。";
                        case 5:
                            return "历史订单";
                        case 6:
                            return "已删除订单";

                    }
                }
               
                return "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Status">订单状态  0.提交订单 (1.审核订单-货到付款 2.等待付款-在线支付)  3.已发货 4.确认收货 5.交易完成 6.回收站 </param>
        /// <param name="PayModel"></param>
        /// <returns></returns>
        public string GetStatusTips(int Status)
        {
            return Buy_Orders.Instance.GetStatusTips(Status);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string orderID = Request.QueryString["oid"];
            int iUserID = base.UserID;
            if (iUserID < 0)
            {
                base.CheckCurrentUserIsLogin();
               // Response.Redirect(EbSite.Base.Host.Instance.LoginRw);
            }

            if (!string.IsNullOrEmpty(orderID))
            {
                long lgOrderID = long.Parse(orderID);
                Model = ModuleCore.BLL.Buy_Orders.Instance.GetEntityByOrderID(lgOrderID); 
                //加载列表
                if (!Equals(Model, null))
                {

                    #region 订单商品列表

                    List<ModuleCore.Entity.Buy_OrderItem> ls = ModuleCore.BLL.Buy_OrderItem.Instance.GetListArray("orderid=" + Model.OrderId);
                    if (ls != null && ls.Count > 0)
                    {
                        this.orderItem.DataSource = ls;
                        this.orderItem.DataBind();
                    }

                    #endregion 订单商品列表

                    //积分商品
                    List<ModuleCore.Entity.creditproductorder> creditList = ModuleCore.BLL.creditproductorder.Instance.GetListArray(string.Format("a.orderid=\"{0}\"", Model.OrderId));
                    if (creditList != null && creditList.Count > 0)
                    {
                        this.rptCoreOrder.DataSource = creditList;
                        this.rptCoreOrder.DataBind();
                    }

                  //订单操作记录
                    orderrecod.DataSource = ModuleCore.BLL.buy_orderlog.Instance.GetLogByOrderID(lgOrderID,false);
                    orderrecod.DataBind();

                    //物流配送信息
                    BindKuaiDi(Model.ExpressCompanyAbb, Model.DeliveryOrderNumber);


                }
            }
        }

        protected KuaiDi MKuaiDi;
        private void BindKuaiDi(string com,string Number)
        {
            if (!string.IsNullOrEmpty(com) && !string.IsNullOrEmpty(Number))
            {
                //有bug YHL 2013-09-24
                //检测是否是 kuaidi100的插件
                if (!string.IsNullOrEmpty(ConfigsControl.Instance.KuaiDiPluginName) &&ConfigsControl.Instance.KuaiDiPluginName == "EbSite.Plugin.Delivery.KuaiDi100")
                {

                    MKuaiDi = EbSite.Base.Plugin.Factory.GetKuaiDi().GetStatusList(com, Number, 1);
                    if (MKuaiDi != null&&MKuaiDi.Data!=null&&MKuaiDi.Data.Count>0)
                    {
                        rpKuaiDi.DataSource = MKuaiDi.Data;
                        rpKuaiDi.DataBind();
                    }
                }
            }
            if (Equals(MKuaiDi, null))
            {
                MKuaiDi = new KuaiDi();//不让出错
            }
            //else
            //{
            //    MKuaiDi = new KuaiDi();//不让出错
            //}
            
        }


        #region 解决重写url后，保持postback地址不改变的问题

        //// <summary>
        ///  重写默认的HtmlTextWriter方法，修改form标记中的value属性，使其值为重写的URL而不是真实URL。
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (writer is System.Web.UI.Html32TextWriter)
            {
                writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
            }
            else
            {
                writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
            }

            base.Render(writer);
        }
        #endregion
    }
}