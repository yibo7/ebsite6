using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.RemarkAskPg
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                txtCID.Text = settings["txtCid"];
       
            }
        }

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["txtCid"] = txtCID.Text;         
            SaveSettings(settings);
        }

    }
}