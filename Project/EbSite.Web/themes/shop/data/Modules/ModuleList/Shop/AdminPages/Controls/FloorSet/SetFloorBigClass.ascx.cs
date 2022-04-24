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
    public partial class SetFloorBigClass : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "设置楼层分类";
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
                ModuleCore.Entity.FloorBigClass md = ModuleCore.BLL.FloorBigClassInfo.Instance.GetEntity(int.Parse(SID));
                this.txtClassName.Text=md.BigClassName;
                this.txtURL.Text=md.BigClassUrl;
            }
        }

        override protected void InitModifyCtr()
        {
           
        }

        override protected void SaveModel()
        {
            ModuleCore.Entity.FloorBigClass md = new ModuleCore.Entity.FloorBigClass();
            md.BigClassName = this.txtClassName.Text;
            md.BigClassUrl = this.txtURL.Text;
            md.BigClsssId = "0";
            md.FloorSetId = fid;
            if (string.IsNullOrEmpty(SID))
            {
                ModuleCore.BLL.FloorBigClassInfo.Instance.Add(md);
            }
            else
            {
                md.id = Core.Utils.StrToInt(SID);
                ModuleCore.BLL.FloorBigClassInfo.Instance.Update(md);
            }
        }
    }
}