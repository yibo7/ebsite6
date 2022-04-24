
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.Simple
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
           
            StringDictionary settings = GetSettings();
            if (settings.ContainsKey("CustomTem"))
            {
                string TemPath = base.TemBll.GetTemPath(settings["CustomTem"]);
                if (!string.IsNullOrEmpty(TemPath))
                    rpDataList.ItemTemplate = LoadTemplate(TemPath);
            }

            rpDataList.DataSource = GetSettingsTable();
            rpDataList.DataBind();
        

    }
         
        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();
            lst.Add("imgpth");
            lst.Add("url");
            lst.Add("txttitle");
            lst.Add("Info");
            lst.Add("Pram1");
            lst.Add("Pram2"); 
            return lst;
        }
        public override string Name
        {
            get { return "AdSimple"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
        
    }
}