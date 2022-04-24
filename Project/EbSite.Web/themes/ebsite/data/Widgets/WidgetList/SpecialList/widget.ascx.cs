using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.SpecialList
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
            if (!base.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                int SiteID = GetSiteID;
                    int iTop = 10;
                    int iSpecialID = 0;
                    //if (settings.ContainsKey("SiteID"))
                    //{
                    //    SiteID = int.Parse(settings["SiteID"]);
                    //}
                   if(settings.ContainsKey("SpecialID"))
                   {
                       iSpecialID = int.Parse(settings["SpecialID"]);
                       if (iSpecialID == 0)
                           iSpecialID = sid;
                   }
                    if (settings.ContainsKey("Count"))
                        iTop = int.Parse(settings["Count"]);

                    if (settings.ContainsKey("tem") && !string.IsNullOrEmpty(settings["tem"]))
                    {
                        string sTem = settings["tem"];
                        sTem = base.TemBll.GetTemPath(sTem);
                        if (!string.IsNullOrEmpty(sTem))
                        this.rpSpecialContent.ItemTemplate = LoadTemplate(sTem);
                    }
                bool IsGetSuB = false;
                    if (settings.ContainsKey("IsGetSub") && !string.IsNullOrEmpty(settings["IsGetSub"]))
                    {
                         IsGetSuB = bool.Parse(settings["IsGetSub"]);
                      
                    }
                    //string sContentIDs = BLL.SpecialNews.GetNewsIDBySid(iSpecialID);
                    if (iSpecialID > 0)
                    {
                        if (SiteID == 0)
                        {
                            
                            this.rpSpecialContent.DataSource =EbSite.Base.AppStartInit.NewsContentInstDefault.GetListFromSpecialID(iSpecialID, iTop, IsGetSuB, base.GetSiteID);

                        }
                        else
                        {
                            this.rpSpecialContent.DataSource = EbSite.Base.AppStartInit.NewsContentInstDefault.GetListFromSpecialID(iSpecialID, iTop, IsGetSuB, SiteID);

                        }
                        this.rpSpecialContent.DataBind();
                    }
                   
               
            }
        }

        public override string Name
        {
            get { return "SpecialList"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
       
    }
}