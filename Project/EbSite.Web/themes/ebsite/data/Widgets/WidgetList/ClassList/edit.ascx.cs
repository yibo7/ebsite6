using System;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI.WebControls;

using EbSite.Base.ExtWidgets.WidgetsManage;
using System.Collections.Generic;

namespace EbSite.Widgets.ClassList
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if(!IsPostBack)
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

                    drpTemMoreList.CtrlValue = settings["tem"];

                    txtIndexText.Text = settings["indextxt"];

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

                    string sCurClassFirst = settings["CurClassFirst"];
                    if (!string.IsNullOrEmpty(sCurClassFirst))
                    {
                        CkCurClassFirst.Checked = bool.Parse(sCurClassFirst);
                    }
                }
                //else
                //{
                //    drpSites.SelectedValue = base.GetSiteID.ToString();
                //}
                
            }
            

        }
        private void BindClass()
        {
            cblClass.DataValueField = "ID";
            cblClass.DataTextField = "ClassName";
            cblClass.DataSource = BLL.NewsClass.GetContentClassesTree(base.GetSiteID);
            cblClass.DataBind();

        }
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();

            //string sType = cblClass.SelectedValue;

            settings["ClassItem"] = GetItems();
            settings["tem"] = drpTemMoreList.CtrlValue;
            settings["indextxt"] = txtIndexText.Text;
            //settings["SiteID"] = drpSites.SelectedValue;
            settings["CurClassFirst"] = CkCurClassFirst.Checked.ToString();
            SaveSettings(settings);
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