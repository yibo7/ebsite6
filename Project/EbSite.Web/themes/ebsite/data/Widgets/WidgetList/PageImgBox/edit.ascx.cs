using System;
using System.Collections.Specialized;

using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.PageImgBox
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
                    txtObjID.Text = settings["ObjID"];
                    txtWidth.Text = settings["Width"];
                    txtHeight.Text = settings["Height"];
                }
                   
            }

        }
        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["ObjID"] = txtObjID.Text.Trim();
            settings["Width"] = txtWidth.Text.Trim();
            settings["Height"] = txtHeight.Text.Trim();
            SaveSettings(settings);
        }
    }
}