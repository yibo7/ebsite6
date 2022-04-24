using System;
using System.Collections.Generic;

using System.Text;
using EbSite.Core;
using EbSite.Entity;

namespace EbSite.Base.PageLink
{
    public class BaseLinks : IBase
    {
        public BaseLinks(int _SiteID)
        {
            this.SiteID = _SiteID;
        }
    }
    public class GetBaseLinks
    {
        //protected static CacheRaw CacheApp;
        //const double CacheDuration = 3600.0;//一个小时
        //private static readonly string[] MasterCacheKeyArray = { "GetBaseLinks" };
        //static GetBaseLinks()
        //{
        //    CacheApp = new CacheRaw(CacheDuration, MasterCacheKeyArray);
        //}
        static public BaseLinks Get(int iSiteID)
        {
            return AppStartInit.EbBaseLinks[iSiteID];
            //if (AppStartInit.EbBaseLinks.Count>0)
            //    return AppStartInit.EbBaseLinks[iSiteID];
            //else
            //{
            //    AppStartInit.LoadNewContentBllAndTableNameModelClass();
            //    return AppStartInit.EbBaseLinks[iSiteID];
            //}
            //string rawKey = string.Concat("Get", iSiteID);
            //BaseLinks _Instance = CacheApp.GetCacheItem(rawKey) as BaseLinks;
            //if (_Instance == null)
            //{
            //    _Instance = new BaseLinks(iSiteID);
            //    CacheApp.AddCacheItem(rawKey, _Instance);
            //}
            //return _Instance;
        }
        static public BaseLinks GetDefault
        {
            get
            {
                return Get(1);
            }

        }
    }
}
