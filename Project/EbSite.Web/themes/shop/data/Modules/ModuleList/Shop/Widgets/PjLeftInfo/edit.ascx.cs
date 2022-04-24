using System;
using System.Collections.Specialized;
using System.Text;
using System.Web.UI.WebControls;

using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.Shop.Widgets.PjLeftInfo
{
    public partial class edit : WidgetEditBase
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
            base.Save();
            StringDictionary settings = GetSettings();
          
            SaveSettings(settings);
        }

    }
}