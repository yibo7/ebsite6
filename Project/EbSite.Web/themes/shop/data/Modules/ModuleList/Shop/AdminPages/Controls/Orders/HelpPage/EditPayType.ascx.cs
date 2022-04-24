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
    public partial class EditPayType : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "修改支付方式";
            }
        }
    
        public override string Permission
        {
            get
            {
                return "76";
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
                    ListItemCollection ls = new ListItemCollection();
                  
                    ls.Add(new ListItem("在线支付", "0"));
                    ls.Add(new ListItem("货到付款", "-1"));
                    this.ddlPayType.DataTextField = "text";
                    this.ddlPayType.DataValueField = "value";
                    this.ddlPayType.DataSource = ls;
                    this.ddlPayType.DataBind();
                    ModuleCore.Entity.Buy_Orders md = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(OrderCodeID);
                    if (md != null && md.PaymentTypeId >-2)
                    {
                        //this.ddlPayType.Items.FindByValue(md.PaymentTypeId.ToString()).Selected = true;
                        this.ddlPayType.SelectedValue = md.PaymentTypeId.ToString();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string selID = this.ddlPayType.SelectedValue;
            if (selID != "")
            {
                Dictionary<string, object> dicArray = new Dictionary<string, object>();
                dicArray.Add("PaymentTypeId", selID);
                dicArray.Add("PaymentType", string.Concat("'", this.ddlPayType.SelectedItem.Text, "'"));

                if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArray, OrderCodeID))
                {
                    //添加日志记录
                    ModuleCore.BLL.buy_orderlog.Instance.Add(OrderCodeID, "修改了支付方式", ModuleCore.SystemEnum.OrderLogType.全部显示);
                    base.RunJs("CloseOrder(1)");
                }
                else
                {
                    base.RunJs("CloseOrder(0)");
                }
            }
        }
    }
}