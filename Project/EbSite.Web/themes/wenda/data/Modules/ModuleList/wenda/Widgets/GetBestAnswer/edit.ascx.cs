using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.BmAsk.Widgets.GetBestAnswer
{
    public partial class edit : WidgetEditBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public override void LoadData()
        {
            if (!this.Page.IsPostBack)
            {
                StringDictionary settings = base.GetSettings();
                if (!object.Equals(settings, null))
                {
                    
                  
                }
            }

        }

        public override void Save()
        {
            base.Save();
            StringDictionary settings = base.GetSettings();
           
            this.SaveSettings(settings);
        }
    }
}