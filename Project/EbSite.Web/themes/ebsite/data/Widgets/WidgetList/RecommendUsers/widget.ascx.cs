using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.RecommendUsers
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
                    iTop = int.Parse(settings["txtCount"]);

                }

                if (settings.ContainsKey("txtTem"))
                {
                    TemPath = settings["txtTem"];
                }
                List<RecommendUsers> nls = new List<RecommendUsers>();
                List<RecommendUsers> ls = RecommendUsersControl.Instance.FillList();
                 if(ls.Count>iTop)
                 {
                     nls = (from i in ls select i).Take(iTop).ToList();
                 }
                 else
                 {
                     nls = ls;
                 }
                rpAllClass.DataSource = nls;
                TemPath = base.TemBll.GetTemPath(TemPath);
                if (!string.IsNullOrEmpty(TemPath))
                {
                    
                    rpAllClass.ItemTemplate = LoadTemplate(TemPath);
                }
                rpAllClass.DataBind();
                
            }
        }

        public override string Name
        {
            get { return "RecommendUsers"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


     
    }
}