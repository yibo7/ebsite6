using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.UserPages
{
    public partial class MWenDaManage : MPageForUerMobile
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("592f5fd7-650f-4f7e-8a2a-10d4fa6f3171");
            }
        }
        public override string PageName
        {
            get
            {
                return "问答管理";
            }
        }

       
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0) //
            {
                base.LoadAControl("MyAskAdd.ascx");

            }
            else if (PageType == 2)
            {
                base.LoadAControl("MyAskList.ascx");
            }
            else
            {
                base.AddControl();
            }
        }

    }
}