using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetUsers
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

                    drpType.SelectedValue = settings["drpType"];
                    
                }

            }


        }
       
        public override void Save()
        {
            base.Save();

            StringDictionary settings = GetSettings();

            //string sType = cblClass.SelectedValue;

            settings["txtCount"] = txtCount.Text;
            settings["txtTem"] = drpTem.CtrlValue;
            settings["drpType"] = drpType.SelectedValue;
            
            SaveSettings(settings);
        }

    }
}