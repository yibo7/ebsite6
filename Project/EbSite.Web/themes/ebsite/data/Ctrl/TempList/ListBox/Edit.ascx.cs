using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.ListBox
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
                    txtItems.Text = settings["Items"];
                    drpSelectionMode.SelectedValue = settings["SelectionMode"];
                    txtWidth.Text = settings["Width"];
                    txtHeigth.Text = settings["Heigth"];
                    txtDefaultSelect.Text = settings["DefaultSelect"];
                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["Items"] = txtItems.Text;
            settings["SelectionMode"] = drpSelectionMode.SelectedValue;
            settings["Width"] = txtWidth.Text;
            settings["Heigth"] = txtHeigth.Text;
            settings["DefaultSelect"] = txtDefaultSelect.Text;
            SaveSettings(settings);
        }


    }
}