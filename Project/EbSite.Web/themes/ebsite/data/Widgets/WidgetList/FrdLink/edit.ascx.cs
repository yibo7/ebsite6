using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.FrdLink
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
                    if (settings.ContainsKey("top"))
                    {
                        txtTop.Text = settings["top"];
                    }
                    if (settings.ContainsKey("tem"))
                    {
                        drpTem.CtrlValue = settings["tem"];
                    }

                }
                
            }


        }
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["top"] = txtTop.Text;
            settings["tem"] = drpTem.CtrlValue;
            
            SaveSettings(settings);
        }

    }
}