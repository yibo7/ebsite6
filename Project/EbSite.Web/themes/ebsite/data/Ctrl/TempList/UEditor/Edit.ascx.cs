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

namespace EbSite.ExtensionsCtrls.UEditor
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

                     
                    txtHeight.Text = settings["txtHeight"];

                    txtWidth.Text = settings["txtWidth"];
                     


                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();
             

            settings["txtHeight"] = txtHeight.Text;

            settings["txtWidth"] = txtWidth.Text;
             
             
            SaveSettings(settings);
        }
    }
}