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

namespace EbSite.ExtensionsCtrls.CheckBox
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
                    string sValue = settings["cbValue"];
                    if (!string.IsNullOrEmpty(sValue))
                        cbBox.Checked = bool.Parse(sValue);

                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["cbValue"] = cbBox.Checked.ToString();

            SaveSettings(settings);
        }
    }
}