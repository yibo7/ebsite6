using System;
using System.Collections.Specialized;

using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.NewRss
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (!Equals(settings,null))
                {
                    txtRssUrl.Text = settings["rssurl"];
                    txtCount.Text = settings["Count"];
                    drpTem.CtrlValue = settings["tem"];
                }
                    
            }

        }
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["rssurl"] = txtRssUrl.Text;
            settings["Count"] = txtCount.Text;
            settings["tem"] = drpTem.CtrlValue;
            SaveSettings(settings);
        }
    }
}