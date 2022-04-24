using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.TemListBox
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

                    rbList.SelectedValue = settings["drpBoxType"];
                    txtCustomItems.Text = settings["CustomItems"];

                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["drpBoxType"] = rbList.SelectedValue;
            settings["CustomItems"] = txtCustomItems.Text;
            SaveSettings(settings);
        }
    }
}