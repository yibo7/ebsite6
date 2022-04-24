using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages
{
    public partial class MsgHistorys : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("b22b3fdb-92a9-483d-86d4-49158510763f");
            }
        }
        public override string PageName
        {
            get
            {
                return "消息记录";
            }
        }
       
    }
}