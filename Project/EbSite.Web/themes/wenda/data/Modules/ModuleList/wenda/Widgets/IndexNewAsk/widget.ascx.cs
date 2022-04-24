using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL;
using EbSite.BLL.Ctrtem;
using EbSite.BLL.User;
using EbSite.Modules.Wenda.ModuleCore.Entity;


namespace EbSite.Modules.Wenda.Widgets.IndexNewAsk
{
    public partial class widget : WidgetBase
    {

        // Methods
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
               
                StringDictionary settings = base.GetSettings();
                

                DataSet ds = EbSite.Modules.Wenda.ModuleCore.BLL.UserHelp.Instance.GetNewsContent5000(6);

                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    rpRssNewsContent.DataSource = dt;
                    rpRssNewsContent.DataBind();
                   
                }

            }
        }


        public string key
        {
            get
            {
                return "";
            }
        }

        public override bool IsEditable
        {
            get
            {
                return true;
            }
        }

        public override string Name
        {
            get
            {
                return "IndexNewAsk";
            }
        }


    }
}