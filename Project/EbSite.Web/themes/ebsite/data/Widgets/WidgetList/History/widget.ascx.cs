using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.History
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {

                if (UserID > 0)
                {
                     int iTop = 10;
                    string TemPath = "";


                    StringDictionary settings = GetSettings();
                    if (settings.ContainsKey("Top"))
                    {
                        iTop = int.Parse(settings["Top"]);

                    }

                    if (settings.ContainsKey("tem"))
                    {
                        TemPath = settings["tem"];
                    }

                    TemPath = base.TemBll.GetTemPath(TemPath);
                    if (!string.IsNullOrEmpty(TemPath))
                    {

                        rpList.ItemTemplate = LoadTemplate(TemPath);
                    }
                    rpList.DataSource = EbSite.BLL.goods_visite.Instance.GetVisiteByUserID(UserID);
                    rpList.DataBind();
                }
                else
                {
                    List<Entity.NewsContent> 
                }

               


            }
        }

        public override string Name
        {
            get { return "History"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}