using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web;
using EbSite.Base.Plugin;
using EbSite.Base.Static;
using EbSite.Core; 
using EbSite.Entity;
using PanGu;
using PanGu.Match;

namespace EbSite.Base
{
    /// <summary>
    /// 添加一些主系统常用数据api
    /// </summary>
    public partial class Host
    {
        private static object _SyncRoot = new object();

        /// <summary>
        /// 定义一个全局式缓存处理业务对象
        /// </summary>
        //public static CacheManager CacheApp;
        //const double CacheDuration = 3600.0;//
        //private static readonly string[] MasterCacheKeyArray = { "GlobalCache" };

        //private static ICache _CacheApp;

        public static ICache CacheApp;
        //{
        //    get
        //    {
        //        if (Equals(_CacheApp, null))
        //        {
        //            lock (_SyncRoot)
        //            {
        //                if (Equals(_CacheApp, null))
        //                {
        //                    _CacheApp = Factory.GetCache(Configs.SysConfigs.ConfigsControl.Instance.CacheBll);
        //                }

        //            }

        //        }
        //        return _CacheApp;
        //    }
        //}

        //private static ICache _CacheRawApp;
        /// <summary>
        /// 内存缓存对象
        /// </summary>
        public static ICache CacheRawApp;
        //{
        //    get
        //    {
        //        if (Equals(_CacheRawApp, null))
        //        {
        //            lock (_SyncRoot)
        //            {
        //                if (Equals(_CacheRawApp, null))
        //                {
        //                    _CacheRawApp = Plugin.Factory.GetDefaultCache();
        //                }

        //            }
                    
        //        }
        //        return _CacheRawApp;
        //    }
        //} 
        public Host()
        {

           
             
        }

        //public void ClearCache()
        //{
        //    _CacheApp = null;
        //}

        public void Init()
        {
            CacheRawApp = Plugin.Factory.GetDefaultCache();
            CacheApp = Factory.GetCache(Configs.SysConfigs.ConfigsControl.Instance.CacheBll);
        }

        //private static Host _instance;

        /// <summary>
        /// 获取或设置 Host 实例对象,将在系统载入时初始化
        /// </summary>
        public static readonly Host Instance = new Host();
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            //return new Host(); //暂时这样
        //            throw new InvalidOperationException("Host.Instance is null");
        //        }
        //        return _instance;
        //    }
        //    set { _instance = value; }
        //}

        #region IHost Members

       
        /// <summary>
        /// 获取提供者（插件）配置
        /// </summary>
        /// <param name="providerTypeName">提供者类型名称</param>
        /// <returns></returns>
        public string GetProviderConfiguration(string providerTypeName)
        {
            throw new NotImplementedException();
        }
        

        #endregion


        /// <summary>
        /// 获取ebsite的数据库连接串,非用户数据库连接串
        /// </summary>
        public  string GetSysConn
        {
            get
            {
               
                return Configs.BaseCinfigs.ConfigsControl.Instance.GetConnectionStringSysCms();
            }
        }
        /// <summary>
        /// 获取ebsite数据库表前缀
        /// </summary>
        public  string GetSysTablePrefix
        {
            get
            {
                return Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;
            }
        }
        /// <summary>
        /// 获取一个ip的区域信息，国家，地区，城市等
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public ClientIpInfo GetAreaByIP(string ip)
        {
            try
            {

                return EbSite.Base.Plugin.Factory.GetIPToArea(Configs.SysConfigs.ConfigsControl.Instance.IpToAreaPluginName).Query(ip);
            }
            catch  { }
            return null;
        }
        /// <summary>
        /// 获取内容简介
        /// </summary>
        /// <param name="ContentInfo"></param>
        /// <param name="iLen"></param>
        /// <returns></returns>
        public string GetSimpleContent(string ContentInfo,int iLen =200)
        {
            
                if (!string.IsNullOrEmpty(ContentInfo.Trim()))
                {
                    string sC = Core.Strings.GetString.ClearHtml(ContentInfo);
                    sC = Core.Strings.GetString.NoUbb(sC);
                    sC = Core.Strings.GetString.SubStr(sC, iLen);
                    return sC;

                }
                return string.Empty;
            
        }

        /// <summary>
        /// 获取当前内容选中的样式
        /// </summary>
        /// <param name="ob">当前内容ID</param>
        /// <param name="sCurrentClassName">当前样式名称</param>
        /// <returns></returns>
        public string GetCurrentContent(object ob, string sCurrentClassName)
        {
            int cid = Core.Utils.StrToInt(HttpContext.Current.Request["id"], 0);
            string sCss = "";

            if (!Equals(ob, null))
            {
                int ID = int.Parse(ob.ToString());

                if (ID == cid) //先判断当前分类ID
                {
                    sCss = sCurrentClassName;
                }
            }

            return sCss;
        }
        /// <summary>
        /// 获取当前分类的样式
        /// </summary>
        /// <param name="ob">当前分类ID</param>
        /// <param name="sCurrentClassName">当前样式名称</param>
        /// <param name="OrthertClassName"></param>
        /// <returns></returns>
         public string GetCurrentClass(object ob, string sCurrentClassName, string OrthertClassName)
        {
            int cid = Core.Utils.StrToInt(HttpContext.Current.Request["cid"], 0);


            string sCss = OrthertClassName;

            if (!Equals(ob, null))
            {
                int ID = int.Parse(ob.ToString());

                if (ID == cid) //先判断当前分类ID
                {
                    sCss = sCurrentClassName;
                }
                else
                {
                    if (ID > 0)  //如果同一个页面有两个导航，那么子类的正常显示，父类的将调用父ID
                    {
                        EbSite.Entity.NewsClass mdCurrent = EbSite.BLL.NewsClass.GetModelByCache(cid);

                        if (mdCurrent.ParentID > 0)
                        {
                            if (mdCurrent.ParentID == ID) //先判断当前分类ID
                            {
                                sCss = sCurrentClassName;
                            }
                        }

                    }

                }
            }

            return sCss;
        }
         public string GetCurrentCSS(string dataid, string sCurrentClassName, string RequestTagid)
         {
             string tagid = HttpContext.Current.Request[RequestTagid];
             string sCss = "";

             if (string.IsNullOrEmpty(tagid))
             {
                 tagid = "0";

             }
             if (Equals(dataid, tagid))
             {
                 sCss = string.Concat("class='", sCurrentClassName, "'");
             }

             return sCss;
         }

        public List<string> SegmentWords(string sSource,int SiteId,int Len,int iTop)
        {
            string stype = Configs.SysConfigs.ConfigsControl.Instance.GetSearchEngineType(SiteId);
            return EbSite.Base.Plugin.Factory.GetSearchEngine(stype).SegmentWords(sSource, Len, iTop);
        }
        public List<string> SegmentWords(string sSource,  int Len, int iTop)
        {
            string stype = Configs.SysConfigs.ConfigsControl.Instance.GetSearchEngineType(GetSiteID);
            return EbSite.Base.Plugin.Factory.GetSearchEngine(stype).SegmentWords(sSource, Len, iTop);
        }
        //分词
        public List<string> SegmentWords(string sSource, int SiteId)
        {
             
            return SegmentWords(sSource, SiteId, 0,0);
        }
        public List<string> SegmentWords(string sSource)
        {

            return SegmentWords(sSource, GetSiteID, 0, 0);
        }

    }
}
