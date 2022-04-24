using System;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI.WebControls;

using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.Shop.Widgets.IndexDay
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                
                StringDictionary settings = GetSettings();
                drpType.SelectedValue = settings["delvalue"];
                txtCountTitle.Text=settings["CountTitle"];
                drpTemTitle.CtrlValue = settings["TemTitle"];
            }
        }

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();

            settings["delvalue"] = drpType.SelectedValue;
            settings["CountTitle"] = txtCountTitle.Text;
            settings["TemTitle"]= drpTemTitle.CtrlValue;

            SaveSettings(settings);
        }

    }
}