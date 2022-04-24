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
    public partial class SetAdvLink : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "设置广告链接";
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
                ModuleCore.Entity.FloorRightAd md = ModuleCore.BLL.FloorRightAdInfo.Instance.GetEntity(int.Parse(SID));
                this.txtClassName.Text = md.AdTitle;
                this.txtURL.Text = md.AdUrl;
            }
        }

        override protected void InitModifyCtr()
        {
           
        }

        override protected void SaveModel()
        {
            ModuleCore.Entity.FloorRightAd md = new ModuleCore.Entity.FloorRightAd();
            md.AdTitle = this.txtClassName.Text;
            md.AdUrl = this.txtURL.Text;
            md.FloorSetId = fid;
            if (string.IsNullOrEmpty(SID))
            {
                ModuleCore.BLL.FloorRightAdInfo.Instance.Add(md);
            }
            else
            {
                md.id = Core.Utils.StrToInt(SID);
                ModuleCore.BLL.FloorRightAdInfo.Instance.Update(md);
            }
        }
    }
}