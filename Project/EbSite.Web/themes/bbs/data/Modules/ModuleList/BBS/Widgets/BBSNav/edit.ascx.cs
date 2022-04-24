using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.BBS.Widgets.BBSNav
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
                    txtNum.Text = settings["txtCount"];
                    

                }

            }


        }
   

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["txtCount"] = txtNum.Text;
         
            SaveSettings(settings);
        }

    }
}