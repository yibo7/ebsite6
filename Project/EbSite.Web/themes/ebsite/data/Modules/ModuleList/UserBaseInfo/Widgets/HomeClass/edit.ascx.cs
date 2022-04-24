using System;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI.WebControls;

using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.UserBaseInfo.Widgets.HomeClass
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            cblClass.DataTextField = "TabName";
            cblClass.DataValueField = "id";
            cblClass.DataSource = EbSite.BLL.SpaceTabs.Instance.GetTabsByUserID(EbSite.Base.AppStartInit.UserID);
            cblClass.DataBind();
            StringDictionary settings = GetSettings();
            if (!Equals(settings, null))
            {
                string sClassItem = settings["delvalue"];
                cblClass.SelectedValue = sClassItem;

            }

        }

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();

            settings["delvalue"] = cblClass.SelectedValue;

            SaveSettings(settings);
        }

    }
}