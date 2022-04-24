using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.CheckBox
{
    public partial class Ctrl : ModelCtrlBase
    {
        

        public override void LoadData()
        {
            if (!IsPostBack)
            {

                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("cbValue"))
                {
                    string sValue = settings["cbValue"];
                    //if (!IsChange)
                        cbBox.Checked = bool.Parse(sValue);
                }

            }
        }

        //private bool IsChange = false;
        public override string Name
        {
            get { return "CheckBox"; }
        }
        public override void SetValue(string sValue)
        {
            //IsChange = true;
                    cbBox.Checked = bool.Parse(sValue);
        }
        public override string GetValue()
        {
            return cbBox.Checked.ToString();
        }
    }
}