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
    public partial class SetBrandList : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "设置品牌列表";
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
            if (!string.IsNullOrEmpty(SID))
            {
                ModuleCore.Entity.FloorRightBrand md = ModuleCore.BLL.FloorRightBrandInfo.Instance.GetEntity(int.Parse(SID));
                this.txtClassName.Text = md.BrandTitle;
                this.txtURL.Text = md.BrandUrl;
            }
        }

        override protected void InitModifyCtr()
        {
           
        }

        override protected void SaveModel()
        {
            ModuleCore.Entity.FloorRightBrand md = new ModuleCore.Entity.FloorRightBrand();
            md.FloorSetId = fid;
            md.BrandTitle = this.txtClassName.Text;
            md.BrandUrl = this.txtURL.Text;
            md.BrandPicUrl = UploadImg.CtrValue;
            if (string.IsNullOrEmpty(SID))
            {
                ModuleCore.BLL.FloorRightBrandInfo.Instance.Add(md);
            }
            else
            {
                md.id = Core.Utils.StrToInt(SID);
                ModuleCore.BLL.FloorRightBrandInfo.Instance.Update(md);
            }
        }
    }
}