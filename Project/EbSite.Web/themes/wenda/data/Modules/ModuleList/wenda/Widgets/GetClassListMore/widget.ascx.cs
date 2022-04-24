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

namespace EbSite.Modules.Wenda.Widgets.GetClassListMore
{
    public partial class widget : WidgetBase
    {
        // Fields
        protected Repeater rpAllClass;

        // Methods
        public string GetCurrentClass(object ob)
        {
            string str = "";
            if (!object.Equals(ob, null) && (int.Parse(ob.ToString()) == this.cid))
            {
                str = "onClassTree";
            }
            return str;
        }

        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                int num = 100;
                string id = "";
                StringDictionary settings = base.GetSettings();
                if (settings.ContainsKey("txtCount"))
                {
                    num = int.Parse(settings["txtCount"]);
                }
                if (settings.ContainsKey("txtTem"))
                {
                    id = settings["txtTem"];
                }
                int cid = 0;
                if (settings.ContainsKey("txtPid"))
                {
                    cid = int.Parse(settings["txtPid"]);
                }
                if (cid == 0)
                {
                    cid = this.cid;
                }
                else if (cid == -1)
                {
                    int parentID = NewsClass.GetModelByCache(this.cid).ParentID;
                    if (parentID > 0)
                    {
                        cid = parentID;
                    }
                    else
                    {
                        cid = this.cid;
                    }
                }
                this.rpAllClass.DataSource = NewsClass.GetSubClass(cid, num, 7);
                id = TemListInstace.TemBll(GetSiteID).GetTemPath(id);
                if (!string.IsNullOrEmpty(id))
                {
                    this.rpAllClass.ItemTemplate = base.LoadTemplate(id);
                }
                this.rpAllClass.DataBind();
            }
        }

        public void rpAll_ItemBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                EbSite.Entity.NewsClass dataItem = (EbSite.Entity.NewsClass)e.Item.DataItem;
                List<EbSite.Entity.NewsClass> objA = NewsClass.GetSubClass(dataItem.ID, 100, 7);
                if (!object.Equals(objA, null) && (objA.Count > 0))
                {
                    Repeater repeater = (Repeater)e.Item.FindControl("rpSubList");
                    if (repeater != null)
                    {
                        repeater.DataSource = objA;
                        repeater.DataBind();
                    }
                }
            }
        }

        // Properties
        protected int cid
        {
            get
            {
                if (!string.IsNullOrEmpty(base.Request["cid"]))
                {
                    return int.Parse(base.Request["cid"]);
                }
                return -1;
            }
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
                return "GetClassListMore";
            }
        }

    }
}