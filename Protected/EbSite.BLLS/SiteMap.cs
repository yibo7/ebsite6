using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.Configs.ContentSet;
using EbSite.Core;

namespace EbSite.BLL
{
    public class SiteMap : Core.SiteMap
    {
        
        override public List<PageInfo> urls
        {
            get
            {
                

                List<PageInfo> _urls = new List<PageInfo>();

                foreach (var mdInst in EbSite.Base.AppStartInit.NewsContentInsts)
                {
                    List<EbSite.Entity.NewsContent> urldata = mdInst.Value.GetListNew(ConfigsControl.Instance.MapSl, 0);
                    foreach (Entity.NewsContent newsContent in urldata)
                    {
                        _urls.Add(new PageInfo { loc = string.Concat(EbSite.Base.Host.Instance.Domain, EbSite.Base.Host.Instance.GetContentLink(newsContent.ID, newsContent.HtmlName, newsContent.SiteID, newsContent.ClassID)), lastmod = newsContent.AddTime });
                    }
                }
                

                
                return _urls;
            }
        }
        override public string FilePath 
       { 
           get
           {
               string filename = "";
               if (!Equals(HttpContext.Current, null))
               {
                   filename = HttpContext.Current.Server.MapPath("~/sitemapindex.xml");
               }
               else
               {
                   filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sitemapindex.xml");
               }
               return filename;
           }
       }
    }
}
