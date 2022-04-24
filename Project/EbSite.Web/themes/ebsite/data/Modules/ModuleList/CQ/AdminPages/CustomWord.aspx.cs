using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages
{
    public partial class CustomWord : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("d62afcf8-ca81-41e1-89db-013d35454c95");
            }
        }
        public override string PageName
        {
            get
            {
                return "常用语句";
            }
        }
        
    }
}