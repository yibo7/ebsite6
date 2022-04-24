using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Control;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.TextBox
{
    public partial class Ctrl : ModelCtrlBase
    {
       

        public override void LoadData()
        {
            if (!IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("drpBoxType"))
                {
                    string sType = settings["drpBoxType"];
                    if(!string.IsNullOrEmpty(sType))
                    {
                        if(sType=="0")
                        {
                            txtBox.TextMode = TextBoxMode.SingleLine;
                        }
                        else
                        {
                            txtBox.TextMode = TextBoxMode.MultiLine;
                        }
                    }
                    
                }
                //if (settings.ContainsKey("txtHeight"))
                //{
                //    string sSetingV = settings["txtHeight"];
                //    if (!string.IsNullOrEmpty(sSetingV))
                //    {
                //        txtBox.Height = int.Parse(sSetingV);
                //    }
                //}
                if (settings.ContainsKey("txtWidth"))
                {
                    string sSetingV = settings["txtWidth"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        txtBox.Width = int.Parse(sSetingV);
                    }
                }
                if (settings.ContainsKey("cbIsCanNull"))
                {
                    string sSetingV = settings["cbIsCanNull"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        if (sSetingV == "必填")
                        {
                            txtBox.IsAllowNull = false;
                        }
                        else {
                            txtBox.IsAllowNull = true;
                        }
                        
                    }
                }
                if (settings.ContainsKey("drpRequiredFieldType"))
                {
                    string sSetingV = settings["drpRequiredFieldType"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        if (Core.Strings.Validate.IsNum(sSetingV))
                        {
                            txtBox.ValidateType = (BoxValidateType)int.Parse(sSetingV);
                        }
                        
                    }
                }
                if (settings.ContainsKey("defaultvalue"))
                {
                    txtBox.Text = settings["defaultvalue"];
                }

                txtBox.ValidationGroup = "savedata";

            }
        }
        public override void SetValue(string sValue)
        {
            txtBox.Text = sValue;
        }

        public override string Name
        {
            get { return "TextBox"; }
        }

        public override string GetValue()
        {
            return txtBox.Text;
        }
    }
}