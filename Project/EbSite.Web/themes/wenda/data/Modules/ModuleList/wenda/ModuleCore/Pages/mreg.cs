using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
    public class mreg : EbSite.Base.Page.BasePage
    {
        #region 控件定义

        protected global::EbSite.Control.Repeater rpUserList;
        protected global::System.Web.UI.WebControls.Literal llUserCount;
        protected global::System.Web.UI.WebControls.Literal llSolve;
        protected global::System.Web.UI.WebControls.Literal llaskCount;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //rpUserList.ItemDataBound += new RepeaterItemEventHandler(rpUserList_ItemDataBound);
            rpUserList.DataSource = EbSite.BLL.User.MembershipUserEb.Instance.GetListArrayCache(36, "", "UserID desc");
            rpUserList.DataBind();

            if(!Equals(llUserCount,null))
            {
                llUserCount.Text = EbSite.BLL.User.MembershipUserEb.Instance.GetCountCache("").ToString();
            }
            if (!Equals(llSolve, null))
            {
                llSolve.Text = ModuleCore.BLL.UserHelp.Instance.SumAskNum().ToString(); //ModuleCore.BLL.ConfigControl.Instance.AnswerNum.ToString();
            }
            if(!Equals(llaskCount,null))
            {
                llaskCount.Text = Base.AppStartInit.NewsContentInstDefault.GetCount("", SettingInfo.Instance.GetSiteID).ToString();
            }

            
        }
      

    }
}