using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class BasePageM : EbSite.Base.Page.BasePage
    {
        public GetLinks ShopLinkApi
        {
            get
            {
                return GetLinks.Instance;
            }
        }
    }
}