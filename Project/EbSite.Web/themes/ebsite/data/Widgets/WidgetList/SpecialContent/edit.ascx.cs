using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.SpecialContent
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
                    drpTemMoreList.CtrlValue = settings["txtTem"];
                    drpDataType.SelectedValue = settings["datatype"];
                    drpOrderType.SelectedValue = settings["ordertype"];

                }
                 
            }


        }
        

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["txtCount"] = txtCount.Text;
            settings["txtTem"] = drpTemMoreList.CtrlValue;
            settings["datatype"] = drpDataType.SelectedValue;
            settings["ordertype"] = drpOrderType.SelectedValue;

            SaveSettings(settings);
        }

    }
}