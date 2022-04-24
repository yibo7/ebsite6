using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;

namespace EbSite.Web.home
{
    public partial class ChangeTheme : UserPage
    {
        #region 杨欢乐添加 判断用户级别    允许更换皮肤的用户级别
        private bool IsUseThemeGroup
        {
            get
            {
                bool k = true;
                //int level = int.Parse(EbSite.SettingInfo.Instance.GetSysConfig.Instance.ModifyDefaultTabGroup);
                //if (EbSite.Base.Host.Instance.UserLevel >= level)
                //{
                //    k = true;
                //}
                return k;
            }
           
        }
        #endregion

        protected static string themeClassIDs = "";//yhl 2012-01-05 添加 用户ID --用户组--皮肤的分类集合。
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (IsUseThemeGroup)
                {


                    //yhl 2012-01-05 添加 
                    //int iGroupID = EbSite.Base.Host.Instance.CurrentFirstGroup.Id; //得到用户的组ID
                    int iGroupID = EbSite.Base.AppStartInit.RoleID; //得到用户的组ID
                    drpClass.DataTextField = "ClassName";
                    drpClass.DataValueField = "id";
                    List<Entity.SpaceThemeClass> ls =
                        EbSite.BLL.SpaceThemeClass.Instance.GetListArray(" UserGroupID=0 or UserGroupID=" + iGroupID);
                    foreach (Entity.SpaceThemeClass c in ls)
                    {
                        themeClassIDs += c.id + ",";
                    }
                    if (themeClassIDs.Length > 0)
                        themeClassIDs = themeClassIDs.Remove(themeClassIDs.Length - 1, 1);

                    drpClass.DataSource = ls;
                    drpClass.DataBind();

                    drpClass.Items.Insert(0, new ListItem("所有皮肤", "0"));

                    BindData();
                }
                else
                {
                    Tips("友情提示","您的级别不够，不能进行此操作。");
                }
            }
        }
        private void BindData()
        {
            int iClassID = int.Parse(drpClass.SelectedValue);
            rpThemes.DataSource = EbSite.BLL.SpaceThemes.Instance.GetListArrayByClassID(iClassID,txtClassName.Text.Trim().Replace("'",""),themeClassIDs);
            rpThemes.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
             string sThemeID =  txtSelItemID.Value.Trim();
            string sThemePath = txtSelItemPath.Value.Trim();
            if (!string.IsNullOrEmpty(sThemeID) && !string.IsNullOrEmpty(sThemePath))
            {
                EbSite.BLL.SpaceSetting.Instance.UpdateTheme(UserID, int.Parse(sThemeID), sThemePath);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "RefeshParent();", true);
            }
        }
        
    }
}