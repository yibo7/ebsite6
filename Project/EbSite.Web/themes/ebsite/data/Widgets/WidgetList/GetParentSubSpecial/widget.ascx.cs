
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetParentSubSpecial
{
    public partial class widget : WidgetBase
    {
        protected int sid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["sid"]))
                {
                    return int.Parse(Request["sid"]);
                }
                return -1;
            }
        }
        public override void LoadData()
        {
            if (!IsPostBack)
            {
                 settings = GetSettings();



                //int ParentID = 0;
                
                //if (settings.ContainsKey("SpecialID"))
                //{
                //    string SpecialID = settings["SpecialID"];

                //    if (!string.IsNullOrEmpty(SpecialID))
                //    {

                //        ParentID = int.Parse(SpecialID);
                //    }
                //}

                //if (ParentID > 0)
                //{
                //    rpSubSpecial.DataSource = BLL.SpecialClass.GetSub(ParentID, base.GetSiteID);

                //}

                rpSubSpecial.DataSource = GetData();

                if (settings.ContainsKey("tem"))
                {
                    string sTem = settings["tem"];
                    sTem = base.TemBll.GetTemPath(sTem);
                    if (!string.IsNullOrEmpty(sTem))
                    {
                        rpSubSpecial.ItemTemplate = LoadTemplate(sTem);
                    }
                }

                rpSubSpecial.DataBind();


            }
        }
        private List<EbSite.Entity.SpecialClass> GetData()
        {
            string parenttype = settings["ptype"];
            if (parenttype == "1")
            {
                string ParentIDs = settings["pitems"];
                return BLL.SpecialClass.GetListInIDs(ParentIDs,0,1, base.GetSiteID);
            }
            else
            {
               
                int ParentID = 0;

                if (settings.ContainsKey("SpecialID"))
                {
                    string SpecialID = settings["SpecialID"];

                    if (!string.IsNullOrEmpty(SpecialID))
                    {

                        ParentID = int.Parse(SpecialID);
                    }
                }
                if (ParentID>0)
                {
                    return BLL.SpecialClass.GetSub(ParentID, base.GetSiteID);

                }
                else
                {
                    return BLL.SpecialClass.GetSub(sid, base.GetSiteID);
                }

            }


        }
        private StringDictionary settings;
        public void rpSubSpecial_ItemBound(object sender, RepeaterItemEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Entity.SpecialClass drData = (Entity.SpecialClass)e.Item.DataItem;
                int classid = drData.id;
                if (classid>0)
                {
                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSSubSpecial");

                    if (settings.ContainsKey("subtem"))
                    {
                        string sTmID = settings["subtem"];
                        string sTem = string.Empty;
                        if (!string.IsNullOrEmpty(sTmID) && sTmID != "00000000-0000-0000-0000-000000000000")
                        {
                            sTem = base.TemBll.GetTemPath(sTmID);
                            
                        }
                        else
                        {
                            sTem = string.Concat("~/", EbSite.Base.Host.Instance.CurrentSite.GetPathWidgetsWidgetList(), "/GetParentSubSpecial/defaultsubtem.ascx");
                            //llClassList.ItemTemplate = LoadTemplate(defaulttem);
                        }
                        if(!string.IsNullOrEmpty(sTem))
                        {
                            int itop = 0;
                            if (settings.ContainsKey("stop"))
                            {
                                itop = Core.Utils.StrToInt(settings["stop"], 0);
                            }
                            llClassList.ItemTemplate = LoadTemplate(sTem);
                            llClassList.DataSource = BLL.SpecialClass.GetSub(itop,classid, base.GetSiteID);
                            llClassList.DataBind();
                        }
                    }

                    //llClassList.Controls.Add(llClassList);

                }
            }
        }

        public string GetCurrentClass(object ob)
        {

            string sCss = "";

            if (!Equals(ob, null))
            {
                int ID = int.Parse(ob.ToString());

                if (ID == sid)
                {
                    sCss = "spcurrent";
                }
            }

            return sCss;
        }
        public override string Name
        {
            get { return "GetParentSubSpecial"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}