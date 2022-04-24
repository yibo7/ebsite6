using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages
{
    public partial class ReturnManage : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("ad7e3f51-6ed9-4459-b0f3-652e989033f1");
            }
        }
        public override string PageName
        {
            get
            {
                return "退换货管理";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("Show.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}