using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.HtmlBox
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

                    txtHeight.Text = settings["txtHeight"];

                    txtWidth.Text = settings["txtWidth"];

                    if (!string.IsNullOrEmpty(settings["cbDownfile"]))
                        cbDownfile.Checked = bool.Parse(settings["cbDownfile"]);

                    if (!string.IsNullOrEmpty(settings["cbPicAddMak"]))
                        cbPicAddMak.Checked = bool.Parse(settings["cbPicAddMak"]);

                    if (!string.IsNullOrEmpty(settings["cbUbb"]))
                        cbUbb.Checked = bool.Parse(settings["cbUbb"]);

                    this.txtSaveFolder.Text = settings["SaveFolder"];
                    this.txtSize.Text = settings["Size"];
                    this.txtExtLink.Text = settings["ExtLink"];
                    this.txtExtImg.Text = settings["ExtImg"];
                    this.txtExtFlash.Text = settings["ExtFlash"];
                    this.txtExtMedia.Text = settings["ExtMedia"];


                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["drpBoxType"] = drpBoxType.SelectedValue;

            settings["txtHeight"] = txtHeight.Text;

            settings["txtWidth"] = txtWidth.Text;

            settings["cbDownfile"] = cbDownfile.Checked.ToString();

            settings["cbPicAddMak"] = cbPicAddMak.Checked.ToString();

            settings["cbUbb"] = cbUbb.Checked.ToString();

            settings["SaveFolder"] = this.txtSaveFolder.Text;
            settings["Size"] = this.txtSize.Text;
            settings["ExtLink"] = this.txtExtLink.Text;
            settings["ExtImg"] = this.txtExtImg.Text; 
             settings["ExtFlash"] = this.txtExtFlash.Text;
            settings["ExtMedia"] =  this.txtExtMedia.Text;  
             
            SaveSettings(settings);
        }
    }
}