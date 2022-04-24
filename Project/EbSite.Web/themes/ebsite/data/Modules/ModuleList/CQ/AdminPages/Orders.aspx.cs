using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages
{
    public partial class Orders : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("3680fe51-9e6e-4760-9468-23e4ef248c6d");
            }
        }
        public override string PageName
        {
            get
            {
                return "订单管理";
            }
        }
       
    }
}