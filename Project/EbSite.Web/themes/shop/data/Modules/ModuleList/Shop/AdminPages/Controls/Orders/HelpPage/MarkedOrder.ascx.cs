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
    public partial class MarkedOrder : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "标注订单";
            }
        }
    
        public override string Permission
        {
            get
            {
                return "75";
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
                       this.litSuccessDate.Text = m.FinishDate.ToString();
                       this.litFactPrice.Text = m.OrderTotal.ToString();
                       if (m.MerchandiserMarkID > -1)
                       {
                           this.rdoflag.Items.FindByValue(m.MerchandiserMarkID.ToString()).Selected = true;
                           this.txtRemark.Text = m.MerchandiserRemark;
                       }
                   }
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.rdoflag.SelectedItem != null)
            {
                string selVal = this.rdoflag.SelectedValue;
                string strRemark = this.txtRemark.Text;
                Dictionary<string, object> dicArray = new Dictionary<string, object>();
                dicArray.Add("MerchandiserMarkID", selVal);
                dicArray.Add("MerchandiserRemark",string.Concat("'",strRemark,"'"));

                //记录操作日志
                ModuleCore.BLL.buy_orderlog.Instance.Add(OrderCodeID,string.Concat("标注了此订单",(string.IsNullOrEmpty(strRemark)?"":",留言："),strRemark), ModuleCore.SystemEnum.OrderLogType.全部显示);

                if (ModuleCore.BLL.Buy_Orders.Instance.UpdateByDic(dicArray,OrderCodeID))//修改方法
                {
                    base.RunJs("CloseOrder(1)");
                }
                else
                {
                    base.RunJs("CloseOrder(0)");
                }
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