using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.UserPages
{
    public partial class MOrderManage : MPageForUerMobile
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("fd8177fb-66f3-4c32-936e-ca226a95549c");
            }
        }
        public override string PageName
        {
            get
            {
                return "我的交易记录";
            }
        }

        protected override void AddControl()
        {
            if (PageType == 0) //
            {
                base.LoadAControl("MyComment.ascx");

            }
            else if (PageType == 1)
            {
                base.LoadAControl("MyCloseOrder.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}