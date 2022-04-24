using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.WebUpFile
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

                    txtAllowType.Text = settings["txtAllowType"]; 

                    txtAllowSize.Text = settings["txtAllowSize"];
                     

                    drpUploadModel.SelectedValue = settings["UploadModel"];
                    txtSaveFolder.Text = settings["SaveFolder"];

                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["txtAllowType"] = txtAllowType.Text.Trim();
             

            settings["txtAllowSize"] = txtAllowSize.Text;             

            settings["UploadModel"] = drpUploadModel.SelectedValue;
            settings["SaveFolder"] = txtSaveFolder.Text;

            SaveSettings(settings);
        }
    }
}