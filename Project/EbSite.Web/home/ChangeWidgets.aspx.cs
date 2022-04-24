using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;
using EbSite.Entity;

namespace EbSite.Web.home
{
    public partial class ChangeWidgets : UserPage
    {

        #region 杨欢乐添加 判断用户级别    允许更换部件的用户级别
        private bool IsUseWidgets
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
                if (IsUseWidgets)
                {


                    if (IsUpdateSubTab)
                    {
                        bool isHave = EbSite.BLL.SpaceTabs.Instance.Exists(GetSubTabID);
                        if (!isHave)
                        {
                            Entity.SpaceTabs md = new SpaceTabs();
                            md.UserID = UserID;
                            md.ParentID = ParentTabID;
                            md.TabName = string.Concat("Module", Request.QueryString["t"]);
                            md.Mark = Request.QueryString["t"];
                            EbSite.BLL.SpaceTabs.Instance.Add(md);
                        }
                    }

                    rpWidgets.DataSource = BLL.HomeWidget.Instance.FillList();
                    rpWidgets.DataBind();

                }
                else
                {
                    Tips("友情提示", "您的级别不够，不能进行此操作。");
                }

            }
        }
        protected int CurrentTabID
        {
            get
            {
                if(IsUpdateSubTab)
                {
                    return GetSubTabID;
                }
                else
                {
                    return ParentTabID;
                }
            }
        }
        private int ParentTabID
        {
            get
            {
                  if (!string.IsNullOrEmpty(Request.QueryString["tid"]))
                    {
                        return int.Parse(Request.QueryString["tid"]);
                    }
                    else
                    {
                        return 0;
                    }
              
                
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
                    return EbSite.BLL.SpaceTabs.Instance.GetTabIDFormMark(ParentTabID, Request.QueryString["t"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        protected string GetWidgetsID
        {
            get
            {

                StringBuilder sb = new StringBuilder();

                List<Entity.SpaceTabWidget> lst = BLL.SpaceTabWidget.Instance.GetListWidgets(UserID, CurrentTabID);
                foreach (SpaceTabWidget tabwidget in lst)
                {
                    sb.Append("\"");
                    sb.Append(tabwidget.WidgetID);
                    sb.Append("\"");
                    sb.Append(",");
                }
                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
           

        }
    }
}