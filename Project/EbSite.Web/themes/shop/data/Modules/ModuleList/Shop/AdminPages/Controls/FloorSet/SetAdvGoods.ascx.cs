using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.FloorSet
{
    public partial class SetAdvGoods : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "设置楼层中间商品";
            }
        }
        public override string Permission
        {
            get
            {
                return "96";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }
        protected int fid
        {
            get {
                return Core.Utils.StrToInt(Request.Params["fid"],0);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        override protected void InitModifyCtr()
        {
           
        }

        override protected void SaveModel()
        {
            if (!ModuleCore.BLL.FloorProductsInfo.Instance.Exist(fid))
            {
                ModuleCore.Entity.FloorProducts md = new ModuleCore.Entity.FloorProducts();
                md.FloorSetId = fid;
                StringBuilder IDs = new StringBuilder();
                List<InfoProduct> list = this.FloorGoods.ProductInfo;
                if (list != null && list.Count > 0)
                {
                    foreach (InfoProduct m in list)
                    {
                        IDs.AppendFormat("{0},", m.ID);
                    }
                }
                if (IDs != null && IDs.Length > 0)
                {
                    md.ProductIds = IDs.ToString().TrimEnd(',');
                    ModuleCore.BLL.FloorProductsInfo.Instance.Add(md);
                }
            }
            else
            {
                base.RunJs("alert(\"此楼层已经设置过商品，请删除后再添加\")");
            }
        }
    }
}