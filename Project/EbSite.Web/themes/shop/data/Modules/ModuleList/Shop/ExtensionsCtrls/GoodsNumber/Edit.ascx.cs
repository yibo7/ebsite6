using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.Modules.Shop.ExtensionsCtrls.GoodsNumber
{
    public partial class Edit : ModelCtrlEditBase
    {
        public override void LoadData()
        {
            //if (!Page.IsPostBack)
            //{
            //    StringDictionary settings = GetSettings();
            //    if (!Equals(settings, null))
            //    {

            //        txtItems.Text = settings["DroItem"];

            //    }

            //}
        }

        public override void Save()
        {
            //StringDictionary settings = GetSettings();

            //settings["DroItem"] = txtItems.Text;

            //SaveSettings(settings);
        }
    }
}