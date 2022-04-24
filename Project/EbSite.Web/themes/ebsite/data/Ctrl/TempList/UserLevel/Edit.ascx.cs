using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.UserLevel
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
                    this.drpDataSource.SelectedValue = settings["UserDataSourceType"];
                    this.rdoModelList.SelectedValue = settings["UserShowModel"];
                    this.chkIsMastItem.Checked = Core.Utils.StrToInt(settings["IsMustChoose"], 0) > 0 ? true : false;
                }
            }
        }

        public override void Save()
        {
            StringDictionary settings = GetSettings();
            settings["UserDataSourceType"]=this.drpDataSource.SelectedValue;
            settings["UserShowModel"]=this.rdoModelList.SelectedValue;
            settings["IsMustChoose"] = this.chkIsMastItem.Checked ? "1" : "0";
            SaveSettings(settings);
        }
    }
}