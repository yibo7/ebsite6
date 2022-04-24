using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages
{
    public partial class Plugins : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("74db02e1-d585-4c43-af45-75bc88d724c9");
            }
        }
        public override string PageName
        {
            get
            {
                return "聊天插件";
            }
        }
       
    }
}