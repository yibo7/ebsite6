using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.AdminPages
{
    public partial class Experts : MPage
    {  
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("3170e8a3-13be-4880-954c-05093c31e5ac");
            }
        }
        public override string PageName
        {
            get
            {
                return "专家列表";
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