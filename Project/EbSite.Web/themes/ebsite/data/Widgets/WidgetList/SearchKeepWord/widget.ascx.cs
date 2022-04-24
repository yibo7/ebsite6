using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.SearchKeepWord
{
    public partial class widget : WidgetBase
    {
        private StringDictionary settings;
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                
                string sTem = "";
                 settings = GetSettings();
                //if (settings.ContainsKey("Tem"))
                //{
                //    sTem = settings["Tem"];
                //    sSoPage = settings["SoPage"];
                //}
                //if (settings.ContainsKey("SoPage"))
                //{
                //    sSoPage = settings["SoPage"];
                //}
                 sTem = base.TemBll.GetTemPath(sTem);
                if (!string.IsNullOrEmpty(sTem))
                {
                    
                    rpData.ItemTemplate = LoadTemplate(sTem);
                }
                DataBind();

            }
        }

       protected string GetUrl(string sShortID,string sReWritePath)
       {
           return Utis.GetReWriteUrl(DataID.ToString(), sShortID, 1, sReWritePath);//BLL.SearchKeepWord.
       }
        private void DataBind()
        {
            
            if (!Equals(settings, null))
            {
                DataTable dt = GetSettingsTable();
                rpData.DataSource = dt;
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
            lst.Add("ReWritePath");
            lst.Add("Title");
            lst.Add("ShortId");
            
            return lst;
        }
        public override string Name
        {
            get { return "SearchKeepWord"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
        
    }
}