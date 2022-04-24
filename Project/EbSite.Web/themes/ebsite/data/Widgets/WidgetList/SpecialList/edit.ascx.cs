using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage;
using System.Collections.Generic;
namespace EbSite.Widgets.SpecialList
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
                    string sSpecialID = settings["SpecialID"];
                    BindClass();
                    if (!string.IsNullOrEmpty(sSpecialID))
                    {
                        cblSpecial.SelectedValue = sSpecialID;
                    }

                    drpTem.CtrlValue = settings["tem"];
                    txtCount.Text = settings["Count"];
                    if (!string.IsNullOrEmpty(settings["IsGetSub"]))
                        cbIsGetSub.Checked = bool.Parse(settings["IsGetSub"]);

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
        private void BindClass()
        {
            cblSpecial.DataValueField = "ID";
            cblSpecial.DataTextField = "SpecialName";
            cblSpecial.DataSource = BLL.SpecialClass.GetTree(base.GetSiteID);
            cblSpecial.DataBind();

        }
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();


            settings["SpecialID"] = cblSpecial.SelectedValue;
            settings["tem"] = drpTem.CtrlValue;
            settings["Count"] = txtCount.Text;
            settings["IsGetSub"] = cbIsGetSub.Checked.ToString();

            //settings["SiteID"] = drpSites.SelectedValue;
            SaveSettings(settings);
        }
    }
}