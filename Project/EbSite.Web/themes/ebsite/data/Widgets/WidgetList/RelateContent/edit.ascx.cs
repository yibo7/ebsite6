using System;
using System.Collections;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage;
using System.Collections.Generic;
namespace EbSite.Widgets.RelateContent
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
                    txtCount.Text = settings["txtCount"];

                    drpTem.CtrlValue = settings["txtTem"];
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

            //string sType = cblClass.SelectedValue;

            settings["txtCount"] = txtCount.Text;
            settings["txtTem"] = drpTem.CtrlValue;
            //settings["SiteID"] = drpSites.SelectedValue;
            SaveSettings(settings);
        }

    }
}