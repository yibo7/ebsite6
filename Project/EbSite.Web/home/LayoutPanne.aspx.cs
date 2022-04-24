using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;
using EbSite.Entity;

namespace EbSite.Web.home
{
    public partial class LayoutPanne : UserPage
    {
        #region 杨欢乐添加 判断用户级别    允许更换版式的用户级别
        private bool IsUseLayout
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
            if(!IsPostBack)
            {
                if (IsUseLayout)
                {
                    rpLayouts.DataSource = EbSite.BLL.LayoutPane.Instance.FillList();
                    rpLayouts.DataBind();
                }
                else
                {
                    Tips("友情提示", "您的级别不够，不能进行此操作。");
                }
              
            }
        }
        private int GetTabID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["tid"]))
                {
                    return int.Parse(Request.QueryString["tid"]);
                }
                return 0;
            }
        }
        private bool IsUpdateSubTab
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["t"]);
            }
        }

        private int GetSubTabID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["t"]))
                {
                    return EbSite.BLL.SpaceTabs.Instance.GetTabIDFormMark(GetTabID, Request.QueryString["t"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        protected string GetLayoutPath(object FileName)
        {
            return string.Concat(IISPath, "home/layoutpanes/", FileName, ".jpg");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sLayoutName = txtLayoutName.Value.Trim();
            if (!string.IsNullOrEmpty(sLayoutName))
            {

                if (IsUpdateSubTab)
                {
                  bool isHave =   EbSite.BLL.SpaceTabs.Instance.Exists(GetSubTabID);
                    if(isHave)
                    {
                        EbSite.BLL.SpaceTabs.Instance.UpdateLayout(UserID, GetSubTabID, sLayoutName);
                    }
                    else
                    {
                        Entity.SpaceTabs md = new SpaceTabs();
                        md.UserID = UserID;
                        md.ParentID = GetTabID;
                        md.TabName = string.Concat("Module", Request.QueryString["t"]);
                        md.Layout = sLayoutName;
                        md.Mark = Request.QueryString["t"];
                        EbSite.BLL.SpaceTabs.Instance.Add(md);
                    }
                }
                else if (GetTabID > 0)
                {
                    EbSite.BLL.SpaceTabs.Instance.UpdateLayout(UserID, GetTabID, sLayoutName);
                }
                
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "RefeshParent();", true);
            }
        }
        
    }
}