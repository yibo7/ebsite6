using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.History
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
                    txtNum.Text = settings["Top"];

                    //drpTem.CtrlValue = settings["txtTem"];

                    //drpType.SelectedValue = settings["drpType"];
                    drpTemMoreList.CtrlValue = settings["tem"];
                }

            }


        }

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["Top"] = txtNum.Text;
            settings["tem"] = drpTemMoreList.CtrlValue;
            SaveSettings(settings);
        }
    }
}