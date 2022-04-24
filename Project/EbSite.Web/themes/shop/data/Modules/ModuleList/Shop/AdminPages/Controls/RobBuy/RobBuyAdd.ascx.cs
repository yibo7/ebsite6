using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.RobBuy
{
    public partial class RobBuyAdd : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "抢购添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "22";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
           
        }
       
       
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.CountDownBuy.Instance.InitModifyCtr(SID, phCtrList);
            ModuleCore.Entity.CountDownBuy md = ModuleCore.BLL.CountDownBuy.Instance.GetEntity(int.Parse(SID));
            this.editorContent.Text = md.Content;
            ProductIdX.ProductId = md.ProductId.ToString();
            ProductIdX.ProductName = Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse(md.ProductId.ToString()),GetSiteID).NewsTitle;
        }
        override protected void SaveModel()
        {
            decimal iPrice = decimal.Parse(this.Price.Text);
            decimal iCountDownPrice = decimal.Parse(this.CountDownPrice.Text);
            if (iPrice <= iCountDownPrice)
            {
                TipsAlert("抢购价要 低于商品价");
            }
            else
            {
                Base.BLL.OtherColumn cRealname = new OtherColumn("ProductId", ProductIdX.ProductId);
                lstOtherColumn.Add(cRealname);

                cRealname = new OtherColumn("content", editorContent.Text);
                lstOtherColumn.Add(cRealname);
                
                EbSite.Modules.Shop.ModuleCore.BLL.CountDownBuy.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            }
        }
       
    }
}