
using System.Collections.Specialized;
using System.Text;
using System.Web.UI;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.LocoySpider
{
    public partial class widget : WidgetBase
    {
        protected string AddPage
        {
            get
            {
                return string.Concat(Base.AppStartInit.IISPath,"Widgets/LocoySpider/AddContent.aspx");
            }
        }
        public override void LoadData()
        {
            if(!IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("Columns"))
                {
                    string sColumn = settings["Columns"];
                    if(!string.IsNullOrEmpty(sColumn))
                    {
                        string[] aColumns = sColumn.Split(',');
                        StringBuilder sb = new StringBuilder();
                        foreach (string column in aColumns)
                        {
                            string[] ac = column.Split('|');
                            sb.AppendFormat("{0}=[标签:{1}]&", ac[0], ac[1]);
                        }
                        sb.AppendFormat("id={0}", DataID);
                        txtPostData.Text = sb.ToString();
                    }
                }
                txtAddPage.Text = AddPage;
                txtFromPage.Text = AddPage;
                
            }
            
        }

        public override string Name
        {
            get { return "LocoySpider"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}