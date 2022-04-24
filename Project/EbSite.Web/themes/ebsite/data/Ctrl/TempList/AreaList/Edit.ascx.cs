using System;
using System.Collections.Specialized;

using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.AreaList
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
                    drpArea1.DataTextField = "Name";
                    drpArea1.DataValueField = "id";
                    drpArea1.DataSource = BLL.AreaInfo.Instance.GetListByParentID(0);
                    drpArea1.DataBind();
                    drpArea1.SelectedValue = settings["drpArea1"];
                    
                }

            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();

            settings["drpArea1"] = drpArea1.SelectedValue;
            
            SaveSettings(settings);
        }
    }
}