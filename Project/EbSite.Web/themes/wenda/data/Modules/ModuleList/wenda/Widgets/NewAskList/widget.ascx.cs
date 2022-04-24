using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Base.Modules;


namespace EbSite.Modules.Wenda.Widgets.NewAskList
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                StringDictionary settings = GetSettings(); 
                int iTOP = 10;

                int iBegin = 0;
                int iEnd = 0;
                string iClass = "0";

                if (settings.ContainsKey("txtTOP"))
                {
                    iTOP = int.Parse(settings["txtTOP"]);
                }
                if (settings.ContainsKey("txtBegin"))
                {
                    iBegin = int.Parse(settings["txtBegin"]);
                }
                if (settings.ContainsKey("txtEnd"))
                {
                    iEnd = int.Parse(settings["txtEnd"]);
                }
                if (settings.ContainsKey("classTs"))
                {
                    iClass = settings["classTs"];
                }
                
                string sqlWhere = " Annex21 in(" + iClass + ") ";
                List<Entity.NewsContent> ls = Base.AppStartInit.NewsContentInstDefault.GetListArray(sqlWhere, iEnd, "AddTime DESC", "*", SettingInfo.Instance.GetSiteID);
                List<Entity.NewsContent> nls = (from c in ls select c).Skip(iBegin).ToList();
                rpList.DataSource = nls;
                rpList.DataBind();
            }
        }
       
        public override string Name
        {
            get { return "NewAskList"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
      
    }
}