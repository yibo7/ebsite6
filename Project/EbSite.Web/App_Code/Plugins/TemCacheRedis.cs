using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Policy;
using System.Text;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Core.RedisUtils;

/// <summary>
/// Converts BBCode to XHTML in the comments.
/// </summary>
[Extension("将静态页缓存到Redis", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
public class TemCacheRedis
{
        static protected ExtensionSettings _settings = null;
        static TemCacheRedis()
        {
            
            EbSite.Base.EBSiteEvents.TemCacheing += new EventHandler<TemCacheingEventArgs>(On_TemCacheing);

        string sSettingsName = "TemCacheRedis";//(注意，注意)要与类名相同,否则无法生成相关配置
        ExtensionSettings settings = new ExtensionSettings(sSettingsName);


        //ParameterType 内容控件类别
        settings.AddParameter("RedisServers", "Redis服务器IP,多台用逗号分开",0, false, false, ParameterType.String);
        settings.Help = @"将静态页面缓存到Redis，前提是在后台将链接方式修改成自动静态";
        settings.IsScalar = true;

        ExtensionManager.Instance.ImportSettings(settings);

        _settings = ExtensionManager.Instance.GetSettings(sSettingsName);

    }
     
        /**/
        /// <summary>
        /// Handles the Post.Serving event to take care of logging IP.
        /// </summary>
    private static void On_TemCacheing(object sender, TemCacheingEventArgs e)
        {
            e.IsStop = true;

        CacheRedisAsync xsCache = new CacheRedisAsync(RedisInstance);

        CacheGetValue gv = new CacheGetValue();
        gv.Url = e.HtmlInfo.GetUrl;
        gv.QueryStr = e.HtmlInfo.QueryStr;
        gv.sReferer = e.HtmlInfo.sReferer;
        gv.dID = e.HtmlInfo.dID.ToString();
        gv.MakeType = e.HtmlInfo.MakeType.ToString();
        string sKey = e.HtmlInfo.FullCacheUrl;
            string data;

         if (Equals(e.Context.Session["isupdatecahe"], null))
         {
                data = xsCache.GetCacheItem<string>(sKey, "ebtem", 1, ETimeSpanModel.M, gv.GetObjTest);
         }
        else //需要及时更新的地方可以为Session["isupdatecahe"]赋值
        {
                data = gv.GetObjTest().ToString();
                e.Context.Session["isupdatecahe"] = null;
         }
            e.Context.Response.Write(data);
            e.Context.Response.End();

        }

    private static object _SyncRoot = new object();
    private static RedisHelper _dbSerialize;
    /// <summary>
    /// 可以在外面改变序列方法
    /// </summary>
    static public RedisHelper RedisInstance
    {
        get
        {
            if (_dbSerialize == null)
            {
                lock (_SyncRoot)
                {
                    if (_dbSerialize == null)
                    {
                       string sServer =  _settings.GetSingleValue("RedisServers");
                        if (!string.IsNullOrEmpty(sServer))
                        {
                            _dbSerialize = new RedisHelper(sServer.Split(',')); //多台用逗号分开
                            //sServer = "192.168.3.164";//支持一台，可以分割让他支持两台
                        }
                        else
                        {
                            _dbSerialize = new RedisHelper(new[] { "192.168.3.164" }); //在后台没有配置时默认一个ip
                        }
                        
                        //指定最大的读写池,最大读池为20,最大写池为5
                        /*
                       当你有多台服务器的时候，可以指定当前这个实例将缓存存在到哪台服务器上:
                         _dbSerialize = new CacheRedis(Redis.Instance,3);//我要将这个缓存实例的缓存保存到第3台服务器上,前提是，你的Redis实例的时候要配置至少3个Ip哦
                  */
                        //_dbSerialize = new RedisHelper(new[] { "192.168.0.3", "192.168.0.5", "192.168.0.6" },20,5);
                    }
                }
            }
            return _dbSerialize;
        }

    }
    public class CacheGetValue
    {
        public string Url = "";
        public string QueryStr = string.Empty;
        public string sReferer = "";
        public string dID;
        public string MakeType;
        public object GetObjTest()
        {
            string fullurl = string.Empty;
            try
            {

                

                if (!string.IsNullOrEmpty(Url))
                {


                    //fullurl = string.Concat("http://", Authority, string.Concat(sUrl, QueryStr));
                    fullurl = string.Concat(Host.Instance.Domain, string.Concat(Url, QueryStr));
                    string shtml =EbSite.Core.WebUtility.LoadURLString(fullurl);

                    return shtml;

                }

            }
            catch (Exception e)
            {
                
                EbSite.Log.Factory.GetInstance().ErrorLog(string.Format("原因:1.可能请求的地址无法打开，请求静态页的源ID:{0},请求源类型{2},异常信息:{1},{3},{4},请求的网址:{5}", dID,
                        e.Message, MakeType, e.Source, e.StackTrace, fullurl));

            }
            return "访问了错，请查看Log4日志!";
        }
    }

}