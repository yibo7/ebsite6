using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EbSite.Web.Pagesm
{
    public partial class lostpassword : EbSite.Base.Page.BasePageMobile
    {
        override protected string MTitle
        {
            get
            {
                return "找回密码";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}