using System;
using System.Collections.Specialized;

using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.DatePicker
{
    public partial class Edit : ModelCtrlEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {

                    ucDatePicker.Value = settings["defaultvalue"];

                    
                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["defaultvalue"] = ucDatePicker.Value;

            SaveSettings(settings);
        }
    }
}