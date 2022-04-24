using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Widgets.ClassTreeDh
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    string sClassItem = settings["ClassItem"];
                    BindClass();
                    if (!string.IsNullOrEmpty(sClassItem))
                    {
                        string[] aItems = sClassItem.Split(',');
                        foreach (ListItem li in cblClass.Items)
                        {
                            if (Core.Strings.Validate.InArray(li.Value, aItems))  //aItems.Contains(li.Value)
                            {
                                li.Selected = true;
                            }
                        }

                    }
                    txtCount.Text = settings["txtCount"];

                    drpTem.CtrlValue = settings["txtTem"];

                    txtPid.Text = settings["txtPid"];
                    string sIsCurrent = settings["IsCurrent"];
                    if (!string.IsNullOrEmpty(sIsCurrent))
                    {
                        CkCurrent.Checked = bool.Parse(sIsCurrent);
                    }
                    #region
                    //yhl 2012-02-14添加

                    //drpSites.DataTextField = "SiteName";
                    //drpSites.DataValueField = "id";
                    //List<EbSite.Entity.Sites> ls = EbSite.BLL.Sites.Instance.FillList();

                    //Entity.Sites md = new Entity.Sites();
                    //md.SiteName = "自动适应";
                    //md.id = 0;
                    //ls.Add(md);

                    //drpSites.DataSource = ls;
                    //drpSites.DataBind();
                    //if (!string.IsNullOrEmpty(settings["SiteID"]))
                    //{
                    //    drpSites.SelectedValue = settings["SiteID"].ToString();
                    //}
                    //else
                    //{
                    //    drpSites.SelectedValue = base.GetSiteID.ToString();
                    //}
                    #endregion

                }
                //else
                //{
                //    drpSites.SelectedValue = base.GetSiteID.ToString();
                //}

            }


        }
       
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["ClassItem"] = GetItems();
            //string sType = cblClass.SelectedValue;

            settings["txtCount"] = txtCount.Text;
            settings["txtTem"] = drpTem.CtrlValue;
            settings["txtPid"] = txtPid.Text;
            settings["IsCurrent"] = CkCurrent.Checked.ToString();
            //settings["SiteID"] = drpSites.SelectedValue;
            
            SaveSettings(settings);
        }
        private void BindClass()
        {
            cblClass.DataValueField = "ID";
            cblClass.DataTextField = "ClassName";
            cblClass.DataSource = EbSite.BLL.NewsClass.GetContentClassesTree(base.GetSiteID);
            cblClass.DataBind();

        }
        private string GetItems()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ListItem li in cblClass.Items)
            {
                if (li.Selected)
                {
                    sb.Append(li.Value);
                    sb.Append(",");
                }
            }
            if (sb.Length > 1) sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}