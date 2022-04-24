using System;
using System.Collections.Specialized;

using System.Text;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetSubSpecial
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
                    string sClassItem = settings["SpecialID"];
                    BindClass();
                    cblSpecial.SelectedValue = sClassItem;
                    drpTem.CtrlValue = settings["tem"];
                    if (settings.ContainsKey("cbIsKeepParentID"))
                    {
                        cbIsKeepParentID.Checked = bool.Parse(settings["cbIsKeepParentID"]);
                    }

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

            //string sType = cblClass.SelectedValue;

            settings["SpecialID"] = cblSpecial.SelectedValue;
            settings["tem"] = drpTem.CtrlValue;
            settings["cbIsKeepParentID"] = cbIsKeepParentID.Checked.ToString();
            //settings["SiteID"] = drpSites.SelectedValue;
            SaveSettings(settings);
        }

    }
}