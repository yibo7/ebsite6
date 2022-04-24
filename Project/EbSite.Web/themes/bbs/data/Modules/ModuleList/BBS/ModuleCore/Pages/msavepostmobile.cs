using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;
using EbSite.BLL;
using EbSite.Entity;
using EbSite.Modules.BBS.ModuleCore.BLL;

namespace EbSite.Modules.BBS.ModuleCore.Pages
{
    public class msavepostmobile : msavepost
    {

        protected global::System.Web.UI.WebControls.TextBox txtContentInfo;
        override protected string GoToLogin
        {
            get { return HostApi.MLoginRw; }
        }
        protected override void btnSavePost_Click(object sender, EventArgs e)
        {
            string sContent = txtContentInfo.Text;
            SavePost(sContent, "",true);
             
        }

        protected string MTitle
        {
            get
            {
                return SiteName;
            }
        }
        protected override void AddHeaderPram()
        {
            base.MobileAddHeaderPram();
        }
        protected override void InitStyle()
        {
            base.MobileInitStyle();
        }

    }
}