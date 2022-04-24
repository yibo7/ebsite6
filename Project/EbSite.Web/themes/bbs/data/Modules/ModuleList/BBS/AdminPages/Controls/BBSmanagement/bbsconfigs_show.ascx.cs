using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement
{
    public partial class bbsconfigs_show : MPUCBaseShow<ModuleCore.Entity.Channels>
    {
        public override string Permission
        {
            get
            {
                return "9";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }
        }

        protected override void Delete()
        {
            ModuleCore.BLL.Channels.Instance.Delete(int.Parse(GetKeyID));
        }
        protected override ModuleCore.Entity.Channels LoadModel()
        {
            ModuleCore.Entity.Channels md = ModuleCore.BLL.Channels.Instance.GetEntity(int.Parse(GetKeyID));
            if (Equals(md, null)) md = new ModuleCore.Entity.Channels();//防止删除后的页面出错
            return md;
        }
    }
}