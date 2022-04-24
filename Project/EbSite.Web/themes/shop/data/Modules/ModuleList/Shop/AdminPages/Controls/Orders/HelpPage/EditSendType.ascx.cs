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
    public partial class EditSendType : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "修改配送方式";
            }
        }
    
        public override string Permission
        {
            get
            {
                return "77";
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
                    return Core.Utils.StrToInt(Request.Params["id"]);
                }
                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 //配送方式
                    List<EbSite.Entity.PsDelivery> lsSend = EbSite.BLL.PsDelivery.Instance.FillList();
                    if (lsSend != null && lsSend.Count > 0)
                    {
                        this.ddlSendType.DataTextField = "ModeName";
                        this.ddlSendType.DataValueField = "id";
                        this.ddlSendType.DataSource = lsSend;
                        this.ddlSendType.DataBind();
                    }
                this.ddlSendType.Items.Insert(0, new ListItem("", "-1"));
                ModuleCore.Entity.Buy_Orders md = ModuleCore.BLL.Buy_Orders.Instance.GetEntity(OrderCodeID);
                if (md.RealShippingModeId != null)
                {
                    this.ddlSendType.SelectedValue = md.RealShippingModeId.ToString();
                }
                else
                {
                    this.ddlSendType.SelectedValue = md.ShippingModeId.ToString();
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
            string selID = this.ddlSendType.SelectedValue;
            if (selID != "" && selID != "-1")
            { 
                 Dictionary<string, object> dicArray = new Dictionary<string, object>();
                 dicArray.Add("RealShippingModeId", selID);
                 dicArray.Add("RealModeName", string.Concat("'", this.ddlSendType.SelectedItem.Text, "'"));
                 if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArray, OrderCodeID))
                 {
                     //添加日志记录
                     ModuleCore.BLL.buy_orderlog.Instance.Add(OrderCodeID, "修改了配送方式", ModuleCore.SystemEnum.OrderLogType.全部显示);
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