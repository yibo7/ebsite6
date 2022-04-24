using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages
{
    public partial class MAddress : MPageForUerMobile
    {
        override public int OrderID
        {
            get
            {
                return 2;
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("df67a61e-9720-44d3-9b6f-77c6c4e2d3f6");
            }
        }

        public override string PageName
        {
            get
            {
                return "收货地址";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void AddControl()
        {
            if (PageType == 0) //
            {
                base.LoadAControl("Add.ascx");

            }
            else if (PageType == 1) //
            {
                base.LoadAControl("Show.ascx");
            }
            else if (PageType == 2) // 辅助一些删除等操作
            {
                base.LoadAControl("AddressList.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}