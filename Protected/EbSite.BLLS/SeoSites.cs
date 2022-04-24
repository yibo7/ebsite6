using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Core;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class SeoSites : EbSite.Base.Datastore.XMLProviderBaseInt<Base.EntityCustom.SeoSite>
    {
        //public static CacheManager CacheApp;
        const double cachetime = 120.0;//
        private const string cacheseosites = "seosites"; //private static readonly string[] MasterCacheKeyArray = { "GlobalSiteCache" };

        public static readonly SeoSites Instance = new SeoSites();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return string.Concat(EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath, "datastore\\SeoSites\\");
            }
        }
        private SeoSites()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);

            }

           // CacheApp = new CacheManager(CacheDuration, MasterCacheKeyArray);
        }
       

    }
}
