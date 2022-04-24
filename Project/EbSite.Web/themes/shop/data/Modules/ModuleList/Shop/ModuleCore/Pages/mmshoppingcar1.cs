using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class mmshoppingcar1 : MshoppingcarBase
    {
        protected override void AddHeaderPram()
        {
            base.MobileAddHeaderPram();

        }

        protected override void InitStyle()
        {
            base.MobileInitStyle();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = "我的购物车";

           
        }
        protected string MTitle
        {
            get
            {
                return SiteName;
            }
        }

    }
}