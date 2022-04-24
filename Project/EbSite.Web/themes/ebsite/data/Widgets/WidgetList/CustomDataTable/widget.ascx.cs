
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Entity;

namespace EbSite.Widgets.CustomDataTable
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                string sTem = "";
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("TemList"))
                {
                    sTem = settings["TemList"];

                }
                DataTable dt = GetSettingsTable();
                rpData.DataSource = dt;
                sTem = TemBll.GetTemPath(sTem);
                if (!string.IsNullOrEmpty(sTem))
                {
                    
                    rpData.ItemTemplate = LoadTemplate(sTem);
                }
                rpData.DataBind();

            }
        }
    
        /// <summary>
        /// 返回部件数据构成所需要列格式
        /// </summary>
        /// <returns></returns>
        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();

            StringDictionary settings = GetSettings();
            if (!Equals(settings, null))
            {
                string sRowConfigs = settings["Fileds"];
                Regex re = new Regex("\r\n");
                string[] Fileds = re.Split(sRowConfigs);
                foreach (string s in Fileds)
                {
                    string[] sc = s.Split('|');
                    lst.Add(sc[1]);
                }
            }

            return lst;
        }
        public override string Name
        {
            get { return "CustomDataTable"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
        
    }
}