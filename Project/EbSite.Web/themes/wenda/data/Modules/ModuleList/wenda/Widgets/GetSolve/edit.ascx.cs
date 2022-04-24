using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.Wenda.Widgets.GetSolve
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
                    string sType = settings["drpType"];

                    if (!string.IsNullOrEmpty(sType))
                    {
                        drpType.SelectedValue = sType;
                    }

                    txtCountTitle.Text = settings["CountTitle"];
                    drpTemTitle.CtrlValue = settings["TemTitle"];

                    txtCountImg.Text = settings["CountImg"];
                    drpTemImg.CtrlValue = settings["TemImg"];

                    drpListModel.SelectedValue = settings["ListModel"];

                    string sClassID = settings["ClassID"];

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

                    BindClass();
                    if (!string.IsNullOrEmpty(sClassID))
                    {
                        string sIsSetID = settings["IsSetID"];
                        if (sIsSetID == "1")
                        {
                            txtIDs.Text = sClassID;
                        }
                        else
                        {
                            drpClass.SelectedValue = sClassID;
                        }
                    }
                }
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

            string sType = drpType.SelectedValue;

            string sListModel = drpListModel.SelectedValue;

            settings["ListModel"] = sListModel;

            settings["drpType"] = sType;


            settings["CountTitle"] = txtCountTitle.Text;
            settings["TemTitle"] = drpTemTitle.CtrlValue;

            settings["CountImg"] = txtCountImg.Text;
            settings["TemImg"] = drpTemImg.CtrlValue;
            string sClassID = string.Empty;
            if (!string.IsNullOrEmpty(txtIDs.Text.Trim()))
            {
                sClassID = txtIDs.Text.Trim();
                settings["IsSetID"] = "1";
            }
            else
            {
                sClassID = drpClass.SelectedValue;

                settings["IsSetID"] = "0";
            }
            settings["ClassID"] = sClassID;

            settings["IsShowNum"] = cbIsShowNum.Checked.ToString();

            settings["IsGetSub"] = cbIsGetSub.Checked.ToString();

            SaveSettings(settings);
        }

    }
}