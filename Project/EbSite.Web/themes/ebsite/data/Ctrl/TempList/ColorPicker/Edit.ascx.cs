using System;
using System.Collections.Specialized;

using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.ColorPicker
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
                    if (settings.ContainsKey("Color"))
                    {
                        cpColor.Color = settings["Color"];
                    }

                    

                    
                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["Color"] = cpColor.Color;

           

            SaveSettings(settings);
        }
    }
}