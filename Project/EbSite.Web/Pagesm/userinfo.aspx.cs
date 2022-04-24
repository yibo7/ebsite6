using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.Pagesm
{
    public partial class userinfo : Pages.UserInfo
    {
       //new protected void Page_Load(object sender, EventArgs e)
       //{
       //    base.Page_Load(sender, e);
       //}

        protected string MTitle
        {
            get
            {
                return SiteName;
            }
        }
        protected override void AddHeaderPram()
        {
            base.MobileAddHeaderPram();
        }
        protected override void InitStyle()
        {
            base.MobileInitStyle();
        }
    }
}