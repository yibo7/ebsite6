using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.ModelListBox
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

                    rbList.SelectedValue = settings["ModelType"];
                    txtCustomItems.Text = settings["CustomItems"];


                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["ModelType"] = rbList.SelectedValue;
            settings["CustomItems"] = txtCustomItems.Text;

            SaveSettings(settings);
        }
    }
}