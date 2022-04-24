using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage;
using System.Collections.Generic;

namespace EbSite.Widgets.GetSubClass
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
                        //cblClass.SelectedValue = sClassItem;

                        string sIsSetID = settings["IsSetID"];
                        if (sIsSetID == "1")
                        {
                            txtIDs.Text = sClassItem;
                        }
                        else
                        {
                            cblClass.SelectedValue = sClassItem;
                        }

                    }

                    //txtTem.Text = settings["tem"];
                    drpType.SelectedValue = settings["drpType"];

                    txtTop.Text = settings["Top"];
                    drpTem.CtrlValue = settings["tem"];

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
            string sClassID = string.Empty;
            if (!string.IsNullOrEmpty(txtIDs.Text.Trim()))
            {
                sClassID = txtIDs.Text.Trim();
                settings["IsSetID"] = "1";
            }
            else
            {
                sClassID = cblClass.SelectedValue;

                settings["IsSetID"] = "0";
            }
            settings["ClassItem"] =sClassID ;
            settings["tem"] = drpTem.CtrlValue;
            settings["drpType"] = drpType.SelectedValue;
            settings["Top"] = txtTop.Text;
            //settings["SiteID"] = drpSites.SelectedValue;
            
            SaveSettings(settings);
        }

    }
}