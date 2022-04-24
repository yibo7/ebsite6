using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.UserPages
{
    public partial class OrderManage : MPageForUer
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("acd22185-6164-40ba-9a11-3c039d76c396");
            }
        }
        public override string PageName
        {
            get
            {
                return "我的交易记录";
            }
        }

        protected override void AddControl()
        {
            if (PageType == 0) //
            {
                base.LoadAControl("MyComment.ascx");

            }
            else if (PageType == 1)
            {
                base.LoadAControl("MyCloseOrder.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}