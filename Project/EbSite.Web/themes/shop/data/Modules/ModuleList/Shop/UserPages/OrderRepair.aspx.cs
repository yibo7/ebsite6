using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.UserPages
{
    public partial class OrderRepair : MPageForUer
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("33785853-143d-45f0-82a7-0a6e55034cd8");
            }
        }
        public override string PageName
        {
            get
            {
                return "退换货管理";
            }
        }

        protected override void AddControl()
        {
            if (PageType == 0)
            {
                base.LoadAControl("Add.ascx");
            }
            else if (PageType ==5)
            {
                base.LoadAControl("Show.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}