using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;

namespace EbSite.Web.Pages
{
    public partial class UhomeTem : MasterBasePlace
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                rpTabs.DataSource = EbSite.BLL.SpaceTabs.Instance.GetTabsByUserID(CurrentUserID);
                rpTabs.DataBind();
            }
        }

        protected string GetCurrentCss(object tabid)
        {
            int iTabID = int.Parse(tabid.ToString());
            if (CurrentTabID == iTabID)
            {
                return "selectedtab";
            }
            else
            {
                return "";
            }
        }
    }
}