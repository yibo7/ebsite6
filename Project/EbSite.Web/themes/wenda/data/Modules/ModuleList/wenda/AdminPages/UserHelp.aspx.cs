using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.AdminPages
{
    public partial class UserHelp : MPage
    {  
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("8e62fafd-d79e-4c9f-abfa-b874afc8abc5");
            }
        }
        public override string PageName
        {
            get
            {
                return "用户积分";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 1) //
            {
                base.LoadAControl("PostUserAdd.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}