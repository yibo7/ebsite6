using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Control;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.ColorPicker
{
    public partial class Ctrl : ModelCtrlBase
    {
       

        public override void LoadData()
        {

            StringDictionary settings = GetSettings();
            if (settings.ContainsKey("Color"))
            {
                string sColor = settings["Color"];
                if (!string.IsNullOrEmpty(sColor))
                {
                    cpColor.Color = sColor;
                }

            }
           
        }
        public override void SetValue(string sValue)
        {
            cpColor.Color = sValue;
        }

        public override string Name
        {
            get { return "ColorPicker"; }
        }

        public override string GetValue()
        {
            return cpColor.Color;
        }
    }
}