using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetTags
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
                    txtCount.Text = settings["Count"];
                    drpTem.CtrlValue = settings["Tem"];

                    drpListModel.SelectedValue =   settings["ListModel"];

                    drpClass.SelectedValue = settings["cid"];


                    txtNum.Text = settings["Num"];

                    ////yhl 2012-02-14添加

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


                }
                //else
                //{
                //    drpSites.SelectedValue = base.GetSiteID.ToString();
                //}
                BindClass();

            }


        }
        private void BindClass()
        {
            drpClass.DataValueField = "ID";
            drpClass.DataTextField = "ClassName";
            drpClass.DataSource = BLL.NewsClass.GetContentClassesTree(base.GetSiteID);
            drpClass.DataBind();

        }
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();

            settings["ListModel"] = drpListModel.SelectedValue;
            settings["Count"] = txtCount.Text;
            settings["Tem"] = drpTem.CtrlValue;
            settings["cid"] = drpClass.SelectedValue;
            settings["Num"] = txtNum.Text;
            
            //settings["SiteID"] = drpSites.SelectedValue;
            SaveSettings(settings);
        }

    }
}