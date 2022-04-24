using System;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI.WebControls;

using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.Shop.Widgets.GetProduct
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    string sType = settings["drpType"];
                    if (!string.IsNullOrEmpty(sType))
                    {
                        drpType.SelectedValue = sType;
                    }       
                    txtCountTitle.Text = settings["CountTitle"];
                    drpTemTitle.CtrlValue = settings["TemTitle"];       
                    string sIsGetSub = settings["IsGetSub"];
                    if (!string.IsNullOrEmpty(sIsGetSub))
                    {
                        cbIsGetSub.Checked = bool.Parse(sIsGetSub);
                    }        
                }
            }
        }
       
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            string sType = drpType.SelectedValue;
            settings["drpType"] = sType;
            settings["IsGetSub"] = cbIsGetSub.Checked.ToString();
            settings["CountTitle"] = txtCountTitle.Text;
            settings["TemTitle"] = drpTemTitle.CtrlValue;
            SaveSettings(settings);
        }

    }
}