using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.AdminPages.Controls.GoodsManage
{
    public partial class AdGoodsType : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "商品类型添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "2";
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
            if(!IsPostBack)
            {
                tx_BrandIDs.DataSource = ModuleCore.BLL.GoodsBrand.Instance.GetListArrayCache(0, "", "");// ModuleCore.BLL.GoodsBrand.Instance.FillList();
                tx_BrandIDs.DataTextField = "brandname";
                tx_BrandIDs.DataValueField = "id";
                tx_BrandIDs.RepeatColumns = 5;
                tx_BrandIDs.DataBind();
            }
        }
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.Supplier.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            bool tag = true;
            if(string.IsNullOrEmpty(this.tx_TypeName.Text))
            {
                tag = false;
            }
            if (string.IsNullOrEmpty(this.tx_OrderID.Text))
            {
                tag = false;
            }
            if (tag)
            {
                int k = 0;
                ModuleCore.Entity.TypeNames md = new TypeNames();
                md.TypeName = this.tx_TypeName.Text;
                md.BrandIDs = tx_BrandIDs.SelectedValue;
                md.OrderID = Core.Utils.StrToInt(this.tx_OrderID.Text, 0);
                md.IsSpecial = Ck_IsSpecial.Checked;
                string brands = "";
                for (int i = 0; i < tx_BrandIDs.Items.Count; i++)
                {
                    if(tx_BrandIDs.Items[i].Selected)
                    {
                        brands += tx_BrandIDs.Items[i].Value + ",";
                    }
                }
                if (brands.Length > 0)
                    brands = brands.Remove(brands.Length - 1, 1);
                md.BrandIDs = brands;
                k = ModuleCore.BLL.TypeNames.Instance.Add(md);
                string sUrl =
                    "GoodsManage.aspx?muid=e8b2cdd7-4299-497b-9215-a94e8c3a6c88&mid=cfccc599-4585-43ed-ba31-fdb50024714b";
                Response.Redirect(sUrl + "&t=5&tid=" + k);
            }
        }
    }
}