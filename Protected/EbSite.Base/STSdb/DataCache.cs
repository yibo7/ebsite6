using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.STSdbUtils;

namespace EbSite.Base.STSDB
{
    public class DataCache : STSdbHelper
    {
        public static  readonly DataCache Instance = new DataCache();
        override protected string MongoDbName
        {
            get
            {
                if (!Equals(HttpContext.Current, null))
                {
                    return HttpContext.Current.Server.MapPath("~/Datastore/cache.dat");
                }
                else
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datastore\\cache.dat");
                }
            }
        }
    }
}
