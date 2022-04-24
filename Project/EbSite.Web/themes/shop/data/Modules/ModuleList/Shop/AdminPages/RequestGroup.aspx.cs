using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages
{
    
    public partial class RequestGroup : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("22e7c75d-e376-4119-bc86-df73cb27f579");
            }
        }
        public override string PageName
        {
            get
            {
                return "求团购";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("RequestShow.ascx");
            }
           
            else
            {
                base.AddControl();
            }
        }
    }
}