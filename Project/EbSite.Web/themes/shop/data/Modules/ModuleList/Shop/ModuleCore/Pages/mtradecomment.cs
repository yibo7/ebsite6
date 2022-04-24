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
    public class mtradecomment : BasePageM
    {
        protected ModuleCore.Entity.Buy_Orders Model;
        protected global::System.Web.UI.WebControls.Repeater rptDataList;
        protected string labScore="0";

        /// <summary>
        /// 订单状态转换
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
            string orderID = Request.QueryString["orderid"];
            int iUserID = base.UserID;
            if (iUserID < 0)
            {
                Response.Redirect(EbSite.Base.Host.Instance.LoginRw);
            }

            if (!string.IsNullOrEmpty(orderID))
            {
                long lgOrderID = long.Parse(orderID);
                Model = ModuleCore.BLL.Buy_Orders.Instance.GetEntityByOrderID(lgOrderID);
                //加载列表
                if (!Equals(Model, null))
                {
                    List<ModuleCore.Entity.Buy_OrderItem> ls = ModuleCore.BLL.Buy_OrderItem.Instance.GetListArray("orderid=" + Model.OrderId);
                    this.rptDataList.DataSource = ls;
                    this.rptDataList.DataBind();
                }
                //
                int tScore=EbSite.Base.Configs.UserSetConfigs.ConfigsControl.Instance.ToCommentInCredit;
                if (tScore > 0)
                {
                    labScore = tScore.ToString();
                }
            }
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