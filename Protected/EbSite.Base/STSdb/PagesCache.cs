using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.STSdbUtils;

namespace EbSite.Base.STSDB
{
    public class PagesCache : STSdbHelper
    {
        public static readonly PagesCache Instance = new PagesCache();
        override protected string MongoDbName
        {
            get
            {
                if (!Equals(HttpContext.Current, null))
                {
                    return HttpContext.Current.Server.MapPath("~/Datastore/pagecache.dat");
                }
                else
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datastore\\pagecache.dat");
                }
            }
        }
    }
}
