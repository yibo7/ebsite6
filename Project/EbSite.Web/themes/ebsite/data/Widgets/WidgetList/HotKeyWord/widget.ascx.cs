
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage; 

namespace EbSite.Widgets.HotKeyWord
{
    public partial class widget : WidgetBase
    {
       
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                int iTop = 0;
               
                if (settings.ContainsKey("Count"))
                {
                    string sCount = settings["Count"];

                    iTop = int.Parse(sCount);
                }
                if (settings.ContainsKey("Tem"))
                {
                    string sTem = settings["Tem"];
                    sTem = base.TemBll.GetTemPath(sTem);
                    if (!string.IsNullOrEmpty(sTem))
                    {

                        rpList.ItemTemplate = LoadTemplate(sTem);
                    }
                }

                rpList.DataSource = BLL.searchword.Instance.GetListArrayCache(iTop, "", "searchcount desc");
                rpList.DataBind();
            }
        }

        public override string Name
        {
            get { return "HotKeyWord"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
         
    }
}