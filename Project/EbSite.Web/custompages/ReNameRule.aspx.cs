using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using EbSite.BLL;
using EbSite.Core;
using EbSite.Pages;

namespace EbSite.CustomPages
{
    public partial class ReNameRule : EbSite.Base.Page.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {

            dlReNameList.DataSource = HtmlReNameRule.lst;
            dlReNameList.DataBind();
        }
    }
}
