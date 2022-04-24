using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.AdminPages
{
    public partial class ImitatePost : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("ba911e1f-d1a7-474d-a9f5-885252dab15b");
            }
        }
        public override string PageName
        {
            get
            {
                return "模拟发帖";
            }
        }
        //模拟发帖
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