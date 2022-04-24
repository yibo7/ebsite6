using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Web.Pagesm
{
    public class UccBase : EbSite.Base.Page.BasePageMobile
    {
        public UccBase()
        {
            

            base.Load += new EventHandler(this.UccBase_Load);
        }
        protected void UccBase_Load(object sender, EventArgs e)
        {
            MCheckCurrentUserIsLogin();
        }

    }
}