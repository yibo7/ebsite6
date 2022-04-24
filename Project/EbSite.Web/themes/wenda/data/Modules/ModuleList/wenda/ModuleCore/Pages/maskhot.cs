using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
    public class maskhot : EbSite.Base.Page.BasePage
    {
        #region 控件定义

        protected global::EbSite.Control.Repeater rpHotList;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Equals(rpHotList,null))
            {

                rpHotList.DataSource = Base.AppStartInit.NewsContentInstDefault.GetListArray("", 1000, "hits desc", "", GetSiteID);
                rpHotList.DataBind();
            }
           
        }
       
    }
}