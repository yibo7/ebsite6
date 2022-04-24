using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
    public class mexpert : EbSite.Base.Page.BasePage
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

            List<ModuleCore.Entity.ExpertsInfo> models=  ModuleCore.BLL.ExpertsControl.Instance.FillList();
            if (models != null && models.Count > 0)
            {
                List<ModuleCore.Entity.ExpertsInfo> dataList =
                    (from i in models where i.IsAudit == 1 orderby i.id descending select i).Take(50).ToList();
                if (dataList != null && dataList.Count > 0)
                {
                    rpUserList.DataSource = dataList;

                    rpUserList.DataBind();
                }
            }
           

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