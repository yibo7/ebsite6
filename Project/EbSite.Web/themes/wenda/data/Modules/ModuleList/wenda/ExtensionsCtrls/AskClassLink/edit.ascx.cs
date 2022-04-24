using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.ModelCtr;
namespace EbSite.Modules.Wenda.ExtensionsCtrls.AskClassLink
{
    public partial class edit : ModelCtrlEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();
            SaveSettings(settings);
        }
    }
}