using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL;
using EbSite.BLL.Ctrtem;


namespace EbSite.Modules.Wenda.Widgets.GetHotList
{
    public partial class widget : WidgetBase
    {
   
        // Methods
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                string sclass = GetClassIDs("192");
                rpSubClass.DataSource = EbSite.Base.AppStartInit.NewsContentInstDefault.GetListArray("classid in(" + sclass + ")", 6, "hits desc", "", 7);
                rpSubClass.DataBind();

            }
        }

        public string GetClassIDs(string parentId)
        {
            string sclass = "";
            List<EbSite.Entity.NewsClass> ls = EbSite.BLL.NewsClass.GetListArr("ParentID in("+parentId+")", 7);
            foreach (EbSite.Entity.NewsClass newsClass in ls)
            {
                sclass += newsClass.ID + ",";
            }
            if (!string.IsNullOrEmpty(sclass))
            {
                sclass = sclass.Remove(sclass.Length - 1, 1);
                parentId = sclass;
                sclass += GetClassIDs(parentId);
            }
            else
            {
                sclass = "0";
            }
            return sclass;
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
                return "GetHotList";
            }
        }

    }
}