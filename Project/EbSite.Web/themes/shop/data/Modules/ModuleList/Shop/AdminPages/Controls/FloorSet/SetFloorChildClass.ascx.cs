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
    public partial class SetFloorChildClass : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "设置楼层子分类";
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
                ModuleCore.Entity.FloorSmallClass md = ModuleCore.BLL.FloorSmallClassInfo.Instance.GetEntity(int.Parse(SID));
                this.txtClassName.Text = md.SmallClassName;
                this.txtURL.Text = md.SmallClassUrl;
            }
        }

        override protected void InitModifyCtr()
        {
            
        }

        override protected void SaveModel()
        {
            ModuleCore.Entity.FloorSmallClass md = new ModuleCore.Entity.FloorSmallClass();
            md.FloorSetId = fid;
            md.SmallClassName = this.txtClassName.Text;
            md.SmallClassUrl = this.txtURL.Text;
            md.SmallClsssId ="0";
            if (string.IsNullOrEmpty(SID))
            {
                ModuleCore.BLL.FloorSmallClassInfo.Instance.Add(md);
            }
            else
            {
                md.id = Core.Utils.StrToInt(SID);
                ModuleCore.BLL.FloorSmallClassInfo.Instance.Update(md);
            }
        }
    }
}