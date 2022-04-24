
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.Bulletin
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {

            if (!base.IsPostBack)
            {
                int iTop = 10;
                string TemPath = "";

                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("txtCount"))
                {
                   // iTop = int.Parse(settings["txtCount"]);

                }

                if (settings.ContainsKey("txtTem"))
                {

                    TemPath = settings["txtTem"];
                }

                DataTable dt = GetSettingsTable();

                rpBulletin.DataSource = dt;
                TemPath = base.TemBll.GetTemPath(TemPath);
                if (!string.IsNullOrEmpty(TemPath))
                {
                    
                    rpBulletin.ItemTemplate = LoadTemplate(TemPath);
                }
                rpBulletin.DataBind();
                
            }
        }
        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();
            lst.Add("Title");
            lst.Add("Info");
            return lst;
        }
        public override string Name
        {
            get { return "Bulletin"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


        //////////////////////////////////////
        protected string uid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["uid"]))
                {
                    return Request["uid"];
                }
                else
                {
                    return AppStartInit.UserName;
                }
               
            }
        }
        
    }
}