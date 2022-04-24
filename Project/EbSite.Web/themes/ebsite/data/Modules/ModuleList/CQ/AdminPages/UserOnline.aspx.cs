using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages
{
    public partial class UserOnline : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("d754b2cb-d7e3-4a54-b3d6-a6d18c9a52d3");
            }
        }
        public override string PageName
        {
            get
            {
                return "在线用户";
            }
        }
       
    }
}