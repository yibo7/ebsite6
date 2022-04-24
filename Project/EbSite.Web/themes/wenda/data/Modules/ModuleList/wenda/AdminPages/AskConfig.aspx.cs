using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.AdminPages
{
    public partial class AskConfig : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("0d8c8736-2215-4999-9d41-aab7305904a5");
            }
        }
        public override string PageName
        {
            get
            {
                return "问题配置";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 1) //
            {
                base.LoadAControl("PostUserAdd.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}