using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages
{
    public partial class UseCorde : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("c461e8f5-db24-4400-9c2b-485abf5e56c9");
            }
        }
        public override string PageName
        {
            get
            {
                return "代码引用";
            }
        }
 


        
    }
}