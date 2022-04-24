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
    public partial class CloseOrder : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "关闭订单";
            }
        }
    
        public override string Permission
        {
            get
            {
                return "71";
            }
        }

        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }
        protected string OrderCodeID
        {
            get 
            {
                if (Request.Params["id"] != null)
                {
                    return Request.Params["id"];
                }
                return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItemCollection ls = new ListItemCollection();
                ls.Add(new ListItem("请选择关闭的理由","-1"));
                ls.Add(new ListItem("联系不到买家", "0"));
                ls.Add(new ListItem("买家不想买了", "1"));
                ls.Add(new ListItem("已经同城见面交易", "2"));
                ls.Add(new ListItem("暂时缺货", "3"));
                ls.Add(new ListItem("其他原因","4"));
                this.ddlCloseReason.DataTextField = "text";
                this.ddlCloseReason.DataValueField = "value";
                this.ddlCloseReason.DataSource = ls;
                this.ddlCloseReason.DataBind();
            }
        }


        override protected void InitModifyCtr()
        {
           
        }
        override protected void SaveModel()
        {

        }
    }
}