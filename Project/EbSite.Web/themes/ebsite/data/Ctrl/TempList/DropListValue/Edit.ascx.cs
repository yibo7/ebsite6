using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.DropListValue
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

                    txtItems.Text = settings["DroItem"];

                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["DroItem"] = txtItems.Text;
            
            SaveSettings(settings);
        }


    }
}