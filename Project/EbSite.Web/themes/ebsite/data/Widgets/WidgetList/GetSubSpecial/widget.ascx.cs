
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetSubSpecial
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
                return 0;
            }
        }
        public override void LoadData()
        {
            if (!IsPostBack)
            {
                StringDictionary settings = GetSettings();
                int ParentID = 0;
               
                bool cbIsKeepParentID = false;
                if (settings.ContainsKey("cbIsKeepParentID"))
                {
                    cbIsKeepParentID = bool.Parse(settings["cbIsKeepParentID"]);
                }
                //if (settings.ContainsKey("SiteID"))
                //{
                //    SiteID = int.Parse(settings["SiteID"]);
                //}

                if (cbIsKeepParentID && sid > 0)
                {
                    ParentID = BLL.SpecialClass.GetModel(sid).ParentID;
                }
                else
                {
                    if (settings.ContainsKey("SpecialID"))
                    {
                        string SpecialID = settings["SpecialID"];

                        if (!string.IsNullOrEmpty(SpecialID))
                        {

                            ParentID = int.Parse(SpecialID);
                        }
                    }
                }


                if (ParentID > 0)
                {
                    rpSubSpecial.DataSource = BLL.SpecialClass.GetSub(ParentID, base.GetSiteID);
                }
                else
                {
                    rpSubSpecial.DataSource = BLL.SpecialClass.GetSub(sid, base.GetSiteID);
                }


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
            get { return "GetSubSpecial"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}