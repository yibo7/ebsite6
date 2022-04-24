using System;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI.WebControls;

using EbSite.Base.ExtWidgets.WidgetsManage;
using System.Collections.Generic;

namespace EbSite.Widgets.ClassListMore
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

                        string sIsSetID = settings["IsSetID"];
                        if (sIsSetID == "1")
                        {
                            txtIDs.Text = sClassItem;
                        }
                        else
                        {
                            string[] aItems = sClassItem.Split(',');
                            foreach (ListItem li in cblClass.Items)
                            {
                                if (Core.Strings.Validate.InArray(li.Value, aItems))
                                {
                                    li.Selected = true;
                                }
                            }
                        }



                    }

                    drpType.SelectedValue = settings["drpType"];
                    drpListModel.SelectedValue = settings["ListModel"];
                    drpTemTitle.CtrlValue = settings["TemTitle"];
                    drpTemImg.CtrlValue = settings["TemImg"];
                    txtCountTitle.Text = settings["CountTitle"];
                    txtCountImg.Text = settings["CountImg"];
                    drpTemMoreList.CtrlValue = settings["TemMoreList"];


                    rbListSubClassOrContent.SelectedValue = settings["SubClassOrContent"];
                    drpTemSubClass.CtrlValue = settings["TemSubClass"];
                    txtCountSubClass.Text = settings["CountSubClass"];
                    drpOrderBySubClass.SelectedValue = settings["OrderBySubClass"];


                    string sIsShowNum = settings["IsShowNum"];


                    if (!string.IsNullOrEmpty(sIsShowNum))
                    {
                        cbIsShowNum.Checked = bool.Parse(sIsShowNum);
                    }
                    string sIsGetSub = settings["IsGetSub"];
                    if (!string.IsNullOrEmpty(sIsGetSub))
                    {
                        cbIsGetSub.Checked = bool.Parse(sIsGetSub);
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
            cblClass.DataValueField = "ID";
            cblClass.DataTextField = "ClassName";
            cblClass.DataSource = BLL.NewsClass.GetContentClassesTree(base.GetSiteID);
            cblClass.DataBind();

        }
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();

            string sType = drpType.SelectedValue;

            string sListModel = drpListModel.SelectedValue;

            settings["ListModel"] = sListModel;

            settings["drpType"] = sType;

            settings["CountTitle"] = txtCountTitle.Text;
            settings["TemTitle"] = drpTemTitle.CtrlValue;

            settings["TemMoreList"] = drpTemMoreList.CtrlValue;
            settings["CountImg"] = txtCountImg.Text;
            settings["TemImg"] = drpTemImg.CtrlValue;

            settings["SubClassOrContent"] = rbListSubClassOrContent.SelectedValue;
            settings["TemSubClass"] = drpTemSubClass.CtrlValue;
            settings["CountSubClass"] = txtCountSubClass.Text;
            settings["OrderBySubClass"] = drpOrderBySubClass.SelectedValue;

            string sClassID = string.Empty;
            if (!string.IsNullOrEmpty(txtIDs.Text.Trim()))
            {
                sClassID = txtIDs.Text.Trim();
                settings["IsSetID"] = "1";
            }
            else
            {
                sClassID = GetItems();

                settings["IsSetID"] = "0";
            }
            settings["ClassItem"] = sClassID;
            settings["IsShowNum"] = cbIsShowNum.Checked.ToString();
            settings["IsGetSub"] = cbIsGetSub.Checked.ToString();
            //settings["SiteID"] = drpSites.SelectedValue;
            SaveSettings(settings);
        }

        private string GetItems()
        {
            if (!IsAptID.Checked)
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
            else
            {
                return "";
            }


        }

        protected void IsAptID_CheckedChanged(object sender, EventArgs e)
        {
            if (IsAptID.Checked)
            {
                cblClass.Enabled = false;
            }
            else
            {
                cblClass.Enabled = true;
            }
        }
    }
}