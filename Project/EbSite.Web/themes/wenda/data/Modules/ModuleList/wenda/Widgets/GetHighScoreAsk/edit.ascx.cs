using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.BmAsk.Widgets.GetHighScoreAsk
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
                    //drpType.SelectedValue = settings["drpType"];
                    drpTemTitle.CtrlValue = settings["txtTem"];
                    if (!string.IsNullOrEmpty(settings["IsImage"]))
                        cbIsImage.Checked = bool.Parse(settings["IsImage"]);
                    //drpUserFrom.SelectedValue = settings["UserFrom"];
                }
            }
        }

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            //settings["drpType"] = drpType.Text;
            settings["txtTem"] = drpTemTitle.CtrlValue;
            settings["IsImage"] = cbIsImage.Checked.ToString();
            settings["txtTOP"] = txtTOP.Text.Trim();
            //settings["UserFrom"] = drpUserFrom.SelectedValue;


            SaveSettings(settings);
        }

    }
}