using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;

namespace EbSite.Web.home
{
    public partial class MoveItems : UserPage
    {
        #region 杨欢乐添加 判断用户级别    允许排序空间菜单的用户级别
        private bool IsAllowOrderTabGroup
        {
            get
            {
                bool k = true;
                //int level = int.Parse(EbSite. SettingInfo.Instance.GetSysConfig.Instance.ModifyDefaultTabGroup);
                //if (EbSite.Base.Host.Instance.UserLevel >= level)
                //{
                //    k = true;
                //}
                return k;
            }
           
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            base.LoadComplete += new EventHandler(ManagePage_LoadComplete);
            if(!IsPostBack)
            {
                if (IsAllowOrderTabGroup)
                {
                    rpTabs.DataSource = EbSite.BLL.SpaceTabs.Instance.GetTabsByUserID(UserID);
                    rpTabs.DataBind();
                }
                else
                {
                    Tips("友情提示","您的级别不够，不能进行此操作。");
                }
              
            }

        }
        
         protected void ManagePage_LoadComplete(object sender, EventArgs e)
        {
            if (!Page.IsCallback)
            {

                AddJavaScriptInclude(string.Concat(Base.AppStartInit.IISPath, "home/js/homecomm.js"));
            }
        }

    }
}