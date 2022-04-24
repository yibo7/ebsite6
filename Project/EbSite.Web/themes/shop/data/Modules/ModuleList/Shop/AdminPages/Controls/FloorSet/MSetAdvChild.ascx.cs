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
    public partial class MSetAdvChild : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "手机设置广告链接";
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
                ModuleCore.Entity.MFloorSmallClass md = ModuleCore.BLL.MFloorSmallClassInfo.Instance.GetEntity(int.Parse(SID));
                this.txtClassName.Text = md.SmallClassName;
                this.txtURL.Text = md.SmallClassUrl;
            }
        }

        override protected void InitModifyCtr()
        {
           
        }

        override protected void SaveModel()
        {
            ModuleCore.Entity.MFloorSmallClass md = new ModuleCore.Entity.MFloorSmallClass();
            md.SmallClassName = this.txtClassName.Text;
            md.SmallClassUrl = this.txtURL.Text;
            md.FloorSetId = fid;
            if (string.IsNullOrEmpty(SID))
            {
                ModuleCore.BLL.MFloorSmallClassInfo.Instance.Add(md);
            }
            else
            {
                md.id = Core.Utils.StrToInt(SID);
                ModuleCore.BLL.MFloorSmallClassInfo.Instance.Update(md);
            }
        }
    }
}