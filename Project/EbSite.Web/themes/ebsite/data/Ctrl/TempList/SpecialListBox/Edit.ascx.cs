using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.SpecialListBox
{
    public partial class Edit : ModelCtrlEditBase
    {
        public override void LoadData()
        {
            if (!this.Page.IsPostBack)
            {
                StringDictionary settings = base.GetSettings();
                if (!object.Equals(settings, null))
                {
                    this.txtClassNum.Text = settings["ClassNum"];
                    this.txtCustomItems.Text = settings["CustomItems"];

                    this.txtValueRule.Text = settings["ValueRule"];
                    this.txtTextRule.Text = settings["TextRule"];
                    this.txtOnchange.Text = settings["Onchange"];
                }
            }
        }

        public override void Save()
        {
            StringDictionary settings = base.GetSettings();
            settings["ClassNum"] = this.txtClassNum.Text.Trim();
            settings["CustomItems"] = this.txtCustomItems.Text.Trim();
            settings["ValueRule"] = this.txtValueRule.Text.Trim();
            settings["TextRule"] = this.txtTextRule.Text.Trim();
            settings["Onchange"] = this.txtOnchange.Text.Trim();
            
            

            this.SaveSettings(settings);
        }

    }
}