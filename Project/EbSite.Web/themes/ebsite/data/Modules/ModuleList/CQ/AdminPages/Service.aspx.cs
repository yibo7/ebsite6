using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages
{
    public partial class Service : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("a3c081d7-0ef2-4053-beb3-dbc8b272a9c7");
            }
        }
        public override string PageName
        {
            get
            {
                return "客服管理";
            }
        }
       
    }
}