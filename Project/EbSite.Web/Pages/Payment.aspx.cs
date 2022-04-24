using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace EbSite.Web.Pages
{
    public partial class Payment : EbSite.Base.Page.CustomPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindParams();
                BindMenuData();

                base.Title = "选择支付方式及支付";
            }
        }
        private void BindParams()
        {
            string strVal = "";
            if (Request.Params["info"] != null)
            {
                strVal = Request.Params["info"].ToString();
            }
            this.hidorderinfo.Value = strVal;
        }
        private void BindMenuData()
        {
            //加载数据源
            List<Entity.PayTypeInfo> ls = BLL.PayTypeInfo.Instance.GetListArray("");
            List<Entity.PayTypeInfo> nls = (from i in ls where i.ParentID == 0 select i).ToList();
            if (nls != null && nls.Count > 0)
            {
                this.rpt_tab.DataSource = nls;
                this.rpt_tab.DataBind();
            }
            nls = (from i in ls where i.ParentID == 1 select i).ToList();
            if (nls != null && nls.Count > 0)
            {
                this.rpt_fir.DataSource = nls;
                this.rpt_fir.DataBind();
            }
            //绑定信用卡快捷支付
            List<Entity.Payment> creditLs = BLL.Payment.Instance.GetListArray("classid=4 and isopend=1");
            this.rpt_creditpay.DataSource = creditLs;
            this.rpt_creditpay.DataBind();

            //绑定储蓄卡快捷支付
            List<Entity.Payment> saveLs = BLL.Payment.Instance.GetListArray("classid=5 and isopend=1");
            this.rpt_savepay.DataSource = saveLs;
            this.rpt_savepay.DataBind();
        }
        protected void rpt_fir_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Entity.PayTypeInfo md = (Entity.PayTypeInfo)e.Item.DataItem;
            List<Entity.Payment> firLs = BLL.Payment.Instance.GetListArray("classid="+md.id+" and isopend=1");
            Repeater rptSec=(Repeater)e.Item.FindControl("rpt_sec");
            if (firLs != null && firLs.Count > 0)
            {
                rptSec.DataSource = firLs;
                rptSec.DataBind();
            }
        }
    }
}