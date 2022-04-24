using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.AdminPages.Controls.RelatedProduct
{
    public partial class RecommendAdd : MPUCBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override string PageName
        {
            get
            {
                return "推荐配件添加";
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



        override protected void InitModifyCtr()
        {
            //this.ProductID.Text = Request.QueryString["id"];
            //this.ProductID.Enabled = false;
            this.ProductIDX.ProductName = Request.QueryString["id"];
            this.ProductIDX.ProductId = Request.QueryString["id"];
        }
        override protected void SaveModel()
        {

            List<InfoProduct> ls = this.BestParts.ProductInfo;
            if (!string.IsNullOrEmpty(SID))
            {
                // 先删除
                List<ModuleCore.Entity.P_BestGroup> lss =
                    ModuleCore.BLL.P_BestGroup.Instance.GetListArray("TypeID=2 and  ProductID=" + this.ProductIDX.ProductId);
                foreach (var productsImg in ls)
                {
                    ModuleCore.BLL.P_BestGroup.Instance.Delete(productsImg.ID);
                }
                //再添加
            }

            if (ls.Count > 0)
            {
                foreach (var infoProduct in ls)
                {
                    ModuleCore.Entity.P_BestGroup md = new P_BestGroup();
                    md.ProductID = Convert.ToInt32(this.ProductIDX.ProductId);
                    md.GoodsID = infoProduct.ID;
                    md.GoodsAvatarSmall = infoProduct.Title;
                    md.GoodsName = infoProduct.PicUrl;
                    md.OrderiD = 1;
                    md.TypeID = 2;
                    md.Add();
                }
            }
        }
    }
}