using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetUserMsg
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
                    txtCountTitle.Text = settings["CountTitle"];

                    drpTemMoreList.CtrlValue = settings["tem"];
                }
            }
        }
      
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["CountTitle"] = txtCountTitle.Text;
            settings["tem"] = drpTemMoreList.CtrlValue;
            SaveSettings(settings);
        }

    }
}