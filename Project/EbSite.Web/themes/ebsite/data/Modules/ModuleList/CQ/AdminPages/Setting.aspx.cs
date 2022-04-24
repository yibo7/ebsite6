using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages
{
    public partial class Setting : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("e6f1e810-eae4-459b-9abf-8b897f490820");
            }
        }
        public override string PageName
        {
            get
            {
                return "订单宝配置";
            }
        }
       
    }
}