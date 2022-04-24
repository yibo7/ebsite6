using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.Gift
{
    public partial class AddGift : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "赠品添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "30";
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
            ModuleCore.BLL.Gift.Instance.InitModifyCtr(SID, phCtrList);
            ModuleCore.Entity.Gift md = ModuleCore.BLL.Gift.Instance.GetEntity(int.Parse(SID));
            BuyProductIdX.ProductId = md.BuyProductId.ToString();
            BuyProductIdX.ProductName = Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse(md.BuyProductId.ToString()),GetSiteID).NewsTitle;

            GiftProductIdX.ProductId = md.GiftProductId.ToString();
            GiftProductIdX.ProductName = Base.AppStartInit.NewsContentInstDefault.GetModel(int.Parse(md.GiftProductId.ToString()),GetSiteID).NewsTitle;


        }
        override protected void SaveModel()
        {

            Base.BLL.OtherColumn cRealname = new OtherColumn("BuyProductId", BuyProductIdX.ProductId);
            lstOtherColumn.Add(cRealname);
            cRealname = new OtherColumn("GiftProductId", GiftProductIdX.ProductId);
            lstOtherColumn.Add(cRealname);

            EbSite.Modules.Shop.ModuleCore.BLL.Gift.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
        }

      
    }
}