using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages
{
    public partial class Options : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("11960eb5-1d15-46ef-9393-aeaf43321f73");
            }
        }
        public override string PageName
        {
            get
            {
                return "自定义选项";
            }
        }
       
    }
}