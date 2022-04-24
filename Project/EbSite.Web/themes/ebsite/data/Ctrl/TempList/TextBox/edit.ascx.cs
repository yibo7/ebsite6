using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.TextBox
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

                    drpBoxType.SelectedValue = settings["drpBoxType"];

                    //txtHeight.Text = settings["txtHeight"];

                    txtWidth.Text = settings["txtWidth"];

                    if (!string.IsNullOrEmpty(settings["cbIsCanNull"]))
                        drpCanNull.SelectedValue = settings["cbIsCanNull"];

                    drpRequiredFieldType.SelectedValue = settings["drpRequiredFieldType"];
                    if (settings.ContainsKey("defaultvalue"))
                        txtDefaultValue.Text = settings["defaultvalue"];

                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["drpBoxType"] = drpBoxType.SelectedValue;

            //settings["txtHeight"] = txtHeight.Text;

            settings["txtWidth"] = txtWidth.Text;

            settings["cbIsCanNull"] = drpCanNull.SelectedValue;

            settings["drpRequiredFieldType"] = drpRequiredFieldType.SelectedValue;
            settings["defaultvalue"] = txtDefaultValue.Text.Trim();

            SaveSettings(settings);
        }
    }
}