using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.SearchKeyWordMatch
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
                    txtTOP.Text = settings["txtTOP"];
                    drpType.SelectedValue = settings["drpType"];
                    drpTemTitle.CtrlValue = settings["txtTem"];
                    if (!string.IsNullOrEmpty(settings["IsImage"]))
                        cbIsImage.Checked = bool.Parse(settings["IsImage"]);

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
            settings["drpType"] = drpType.Text;
            settings["txtTem"] = drpTemTitle.CtrlValue;
            settings["IsImage"] = cbIsImage.Checked.ToString();
            settings["txtTOP"] = txtTOP.Text.Trim();
            //settings["SiteID"] = drpSites.SelectedValue;
            
            SaveSettings(settings);
        }

    }
}