using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Control;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.DatePicker
{
    public partial class Ctrl : ModelCtrlBase
    {
        

        public override void LoadData()
        {
            
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("defaultvalue"))
                {
                    string sValue = settings["defaultvalue"];
                    if (!string.IsNullOrEmpty(sValue))
                        ucDatePicker.Value = sValue;
                    else ucDatePicker.Value = DateTime.Now.ToShortDateString();
                    
                }
           
        }
        public override void SetValue(string sValue)
        {
            ucDatePicker.Value = sValue;
        }

        public override string Name
        {
            get { return "DatePicker"; }
        }

        public override string GetValue()
        {
            return ucDatePicker.Value;
        }
    }
}