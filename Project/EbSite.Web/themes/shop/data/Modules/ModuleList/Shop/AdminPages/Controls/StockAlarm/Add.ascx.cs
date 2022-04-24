using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.StockAlarm
{
    public partial class Add : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "库存补货";
            }
        }
        public override string Permission
        {
            get
            {
                return "92";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }
        override protected void InitModifyCtr()
        {
            //ModuleCore.BLL.Supplier.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            if (!string.IsNullOrEmpty(SID))
            {
                int id = int.Parse(SID);
                int stocks = Core.Utils.StrToInt(this.txtAddCount.Text.Trim(),0);
                if (id > 0 && stocks > 0)
                {
                    int flag = Core.Utils.StrToInt(Request.Params["m"], 0);
                    string txtMsg = this.txtContent.Text;
                    ModuleCore.Entity.productlog md = new ModuleCore.Entity.productlog();
                    txtMsg += string.Format("【此商品库存量增加了{0}个】",stocks);
                    md.Content = txtMsg;
                    md.UserID = base.UserID;
                    md.UserName = base.UserNiname;
                    md.AddDate = DateTime.Now;
                    md.Number = stocks;
                    
                    if (flag > 0)
                    {
                        ModuleCore.BLL.NormRelationProduct.Instance.UpdateStocksNoNorms(id, stocks, md);
                    }
                    else
                    {
                        ModuleCore.BLL.NormRelationProduct.Instance.UpdateStocks(id, stocks, md);
                    }
                    base.RunJs("alert('保存成功');ClosePage()");
                }
            }
        }
    }
}