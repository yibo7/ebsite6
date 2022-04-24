using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.HotKeyWord
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
                    txtCount.Text = settings["Count"];
                    drpTem.CtrlValue = settings["Tem"];
                     
                     


                } 

            }
 
       
        }
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
             
            settings["Count"] = txtCount.Text;
            settings["Tem"] = drpTem.CtrlValue; 
            
            //settings["SiteID"] = drpSites.SelectedValue;
            SaveSettings(settings);
        }

    }
}