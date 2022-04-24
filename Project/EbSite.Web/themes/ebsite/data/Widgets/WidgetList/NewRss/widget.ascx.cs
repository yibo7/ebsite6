using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml;

using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.NewRss
{
    public partial class widget : WidgetBase
    {
      
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("rssurl"))
                {
                    int iTop = 10;
                    string sUrl = settings["rssurl"];
                    if (settings.ContainsKey("Count"))
                        iTop = int.Parse(settings["Count"]);

                    if (settings.ContainsKey("tem") && settings["tem"] != "00000000-0000-0000-0000-000000000000") 
                    {
                        this.rpRssNewsContent.ItemTemplate = LoadTemplate(base.TemBll.GetTemPath(settings["tem"]));    
                    }
                    this.rpRssNewsContent.DataSource = null; //GetRss(sUrl, iTop);
                    this.rpRssNewsContent.DataBind();  
                }
            }
        }

        public override string Name
        {
            get { return "NewRss"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
        //要求 .net 3.5
        //static public List<SyndicationItem> GetRss(string rssurl, int iTop)
        //{

        //    string CacheKey = string.Concat("GetRss-", rssurl, "-", iTop);
        //    List<SyndicationItem> lst = Base.Host.CacheApp.GetCacheItem(CacheKey) as List<SyndicationItem>;
        //    if (lst == null)
        //    {
        //        Rss20FeedFormatter formatter = new Rss20FeedFormatter();
        //        using (XmlReader reader = XmlReader.Create(rssurl))
        //        {
        //            formatter.ReadFrom(reader);
        //        }
        //         lst = new List<SyndicationItem>();
        //        int i = 0;
        //        foreach (SyndicationItem it in formatter.Feed.Items)
        //        {
        //            i++;
        //            lst.Add(it);

        //            if (i > iTop)
        //            {
        //                break;
        //            }

        //        }
        //        Base.Host.CacheApp.AddCacheItem(CacheKey, lst);
        //    }
        //    return lst;
        //}
    }
}