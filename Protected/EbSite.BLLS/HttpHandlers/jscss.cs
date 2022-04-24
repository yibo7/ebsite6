using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Core.FSO;
using Yahoo.Yui.Compressor;

namespace EbSite.BLL.HttpHandlers
{
    /// <summary>
    /// Summary description for jscss
    /// </summary>
    public class jscss : IHttpHandler
    {

        private const string CacheKeyFormat = "_CacheKey_{0}_{1}_{2}";
        protected object lockObj = new object();
        //private const bool IsCompress = true; //需要压缩
        public void ProcessRequest(HttpContext context)
        {
            
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            DateTime dt;
            if (DateTime.TryParse(request.Headers["If-Modified-Since"], out dt))
            {
                // 注意：如果是60秒内，我就以304的方式响应。
                if ((DateTime.Now - dt).TotalSeconds < 60.0)
                {
                    response.StatusCode = 304;
                    response.End();
                    return;
                }
            }

            // 注意这个调用，它可以产生"Last-Modified"这个响应头，浏览器在收到这个头以后，
            // 在后续对这个页面访问时，就会将时间以"If-Modified-Since"的形式发到服务器
            // 这样，上面代码的判断就能生效。
            response.Cache.SetLastModified(DateTime.Now);

            string cachekey = string.Empty;

            string type = request.QueryString["t"];
            string spath = request.QueryString["p"];
            int siteid =Core.Utils.StrToInt(request.QueryString["s"],1);

            //string scustomcss = request.QueryString["cssc"];
            if (!string.IsNullOrEmpty(type) && (type == "css" || type == "js") && !string.IsNullOrEmpty(spath))
            {
                cachekey = string.Format(CacheKeyFormat, type, spath, siteid);

                CompressCacheItem cacheItem = HttpRuntime.Cache[cachekey] as CompressCacheItem;
                if (Equals(cacheItem, null))
                {
                    lock (lockObj)
                    {
                        Entity.Sites mdSites = Host.Instance.GetSite(siteid);
                       
                       
                        

                        string sIISpath = EbSite.Base.Host.Instance.IISPath;
                        List<string> lstDefaultPath = new List<string>();
                        //StringBuilder sbText = new StringBuilder();
                        string sContent = string.Empty;
                        if (type == "js")
                        {

                            if (spath == "pcdefault")
                            {
                                lstDefaultPath.Add("js/init.js");
                                lstDefaultPath.Add("js/inc.js");
                                lstDefaultPath.Add("js/jquery.js");
                                lstDefaultPath.Add("js/comm.js");
                                lstDefaultPath.Add("js/customctr.js");
                                lstDefaultPath.Add("js/json2.js");
                                //string scustomjs = request.QueryString["jsc"];
                                //BuilderCustom(lstDefaultPath, scustomjs, CustomCssJs.Instance.PcJs);

                                //string sThemePath = request.QueryString["tp"];
                                string sThemesPathPc = string.Empty;
                                if (!Equals(mdSites, null))
                                {
                                    sThemesPathPc = mdSites.ThemesPath("");
                                }
                                lstDefaultPath.Add(string.Concat(sThemesPathPc, "js/extensions.js"));

                                //订制
                                sContent = GetStrForListPath(lstDefaultPath, context, sIISpath);
                            }
                            else if (spath == "mbdefault")
                            {
                                lstDefaultPath.Add("js/mobile/init.js");
                                lstDefaultPath.Add("js/mobile/zepto.js");
                                lstDefaultPath.Add("js/mobile/infinitescroll.js");
                                lstDefaultPath.Add("js/mobile/gmu/js/core/gmu.js");
                                lstDefaultPath.Add("js/mobile/gmu/js/core/event.js");
                                lstDefaultPath.Add("js/mobile/gmu/js/core/widget.js");
                                lstDefaultPath.Add("js/mobile/inc.js");
                                lstDefaultPath.Add("js/mobile/com.js");

                                //string sThemePath = request.QueryString["tp"];
                                //lstDefaultPath.Add(string.Concat(sThemePath, "js/extensions.js"));
                                string sThemesPathMobile = string.Empty;
                                if (!Equals(mdSites, null))
                                {
                                    sThemesPathMobile = mdSites.MGetCurrentThemesPath();
                                }
                                lstDefaultPath.Add(string.Concat(sThemesPathMobile, "js/extensions.js"));

                                sContent = GetStrForListPath(lstDefaultPath, context, sIISpath);
                            }
                            else //相对路径处理
                            {
                                response.End();

                               // sContent = GetStrForListPath(spath, context);
                            }

                        }
                        else if (type == "css")
                        {
                            try
                            {
                                string fullpath = context.Server.MapPath(spath);
                                if (Core.FSO.FObject.IsExist(fullpath, FsoMethod.File))
                                {
                                    sContent = File.ReadAllText(fullpath, Encoding.Default);

                                }
                                else if (Core.FSO.FObject.IsExist(fullpath, FsoMethod.Folder))
                                {
                                    StringBuilder sbText = new StringBuilder();
                                    
                                        FileInfo[] fileInfos = FObject.GetFileListByType(fullpath, "css", true);
                                        foreach (FileInfo fileInfo in fileInfos)
                                        {
                                            string readstr = File.ReadAllText(fileInfo.FullName, Encoding.Default);
                                            sbText.Append(readstr);

                                        }
                                     
                                    sContent = sbText.ToString();
                                }
                            }
                            catch (Exception ex)
                            {

                                Log.Factory.GetInstance().ErrorLog(string.Format("调用jscss的type == \"css\"时发生错误，请注意，{0},源:{1},过程:{2}", ex.Message, ex.Source, ex.StackTrace));
                            }

                            
                        }


                        if (sContent.Length > 100) //随便一个值，太小压缩也没有意义
                        {
                            if (type.Equals("js"))
                            {
                                int enableJsCompression = ConfigsControl.Instance.EnableJsCompression;
                                if (enableJsCompression == 1)
                                    sContent = JavaScriptCompressor.Compress(sContent, true, true, false, false, -1, Encoding.UTF8, CultureInfo.CurrentCulture);
                            }
                            else if (type.Equals("css"))
                            {
                                //int enableCssCompression = ConfigsControl.Instance.EnableCssCompression;
                                //if (enableCssCompression == 1 || enableCssCompression == 2)
                                //    sContent = CssCompressor.Compress(sContent);
                            }
                        }

                        cacheItem = new CompressCacheItem() { Type = type, Content = sContent, Expires = DateTime.Now.AddDays(30) };
                        if (ConfigsControl.Instance.IsCacheJsCss)
                            HttpRuntime.Cache.Insert(cachekey, cacheItem, null, cacheItem.Expires, TimeSpan.Zero);

                    }
                    

                }
                if (type.Equals("js"))
                {
                    response.ContentType = "text/javascript";
                }
                else if (type.Equals("css"))
                {
                    response.ContentType = "text/css";
                }

                response.Write(cacheItem.Content);
                if (IsEncodingAccepted("gzip"))
                {
                    response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                    SetEncoding("gzip");
                }
               else if (IsEncodingAccepted("deflate"))
                {
                    response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                    SetEncoding("deflate");
                }
                  
                //SetClientCaching(response, cacheItem.Expires);

               

                #region 不使用

                //If-Modified-Since 在ie6刷新下某些服务器上运行有问题
                //string ifModifiedSince = request.Headers["If-Modified-Since"];
                //if (!string.IsNullOrEmpty(ifModifiedSince)
                //    && TimeSpan.FromTicks(cacheItem.Expires.Ticks - DateTime.Parse(ifModifiedSince).Ticks).Seconds < 0)
                //{
                //    response.StatusCode = (int)System.Net.HttpStatusCode.NotModified;
                //    response.StatusDescription = "Not Modified";
                //}
                //else
                //{



                //    response.Write(cacheItem.Content);
                //    if (IsEncodingAccepted("deflate"))
                //    {
                //        response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                //        SetEncoding("deflate");
                //    }
                //    else if (IsEncodingAccepted("gzip"))
                //    {
                //        response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                //        SetEncoding("gzip");
                //    }
                //    SetClientCaching(response, cacheItem.Expires);
                //}

                #endregion


            }
        }
        private void SetClientCaching(HttpResponse response, DateTime expires)
        {
            response.Cache.SetETag(DateTime.Now.Ticks.ToString());
            response.Cache.SetLastModified(DateTime.Now);

            //public 以指定响应能由客户端和共享（代理）缓存进行缓存。    
            response.Cache.SetCacheability(HttpCacheability.Public);

            //是允许文档在被视为陈旧之前存在的最长绝对时间。 
            response.Cache.SetMaxAge(TimeSpan.FromTicks(expires.Ticks));
            response.Cache.SetSlidingExpiration(true);
        }
        private class CompressCacheItem
        {
            /// <summary>
            /// 类型 js 或 css 
            /// </summary>
            public string Type { get; set; } // js css  
            /// <summary>
            /// 内容
            /// </summary>
            public string Content { set; get; }
            /// <summary>
            /// 过期时间
            /// </summary>
            public DateTime Expires { set; get; }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        //private string GetStrForListPath(string path, HttpContext context)
        //{
        //    string[] apath = path.Split(',');

        //    StringBuilder sbText = new StringBuilder();
        //    try
        //    {
        //        foreach (string spath in apath)
        //        {
        //            string pathfile = context.Server.MapPath(spath);
        //            if (File.Exists(pathfile))
        //            {
        //                string readstr = File.ReadAllText(pathfile, Encoding.Default);
        //                sbText.Append(readstr);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Factory.GetInstance().ErrorLog(string.Format("调用jscss的GetStrForListPath1时发生错误，请注意，{0},源:{1},过程:{2}", e.Message, e.Source, e.StackTrace));
        //    }

        //    return sbText.ToString();
        //}

        private string GetStrForListPath(List<string> lstDefaultJs, HttpContext context, string sIISpath)
        {
            StringBuilder sbText = new StringBuilder();
            try
            {
                foreach (string s in lstDefaultJs)
                {
                    string pathjs = context.Server.MapPath(string.Concat(sIISpath, s));
                    if (File.Exists(pathjs))
                    {
                        string readstr = File.ReadAllText(pathjs, Encoding.Default);
                        sbText.Append(readstr);
                    }
                }
            }
            catch (Exception e)
            {
                 Log.Factory.GetInstance().ErrorLog(string.Format("调用jscss的GetStrForListPath2时发生错误，请注意，{0},源:{1},过程:{2}", e.Message, e.Source, e.StackTrace));
            }
            
            return sbText.ToString();
        }
        //private void BuilderCustom(List<string> defaultpath, string customs, Dictionary<string, string> cCssJs)
        //{
        //    if (!string.IsNullOrEmpty(customs))
        //    {
        //        string[] acustom = customs.Split(',');
        //        foreach (string key in acustom)
        //        {
        //            if (cCssJs.ContainsKey(key))
        //            {
        //                defaultpath.Add(cCssJs[key]);
        //            }
        //            else
        //            {
        //                defaultpath.Add(key);
        //            }
        //        }
        //    }
        //}
        private static void SetEncoding(string encoding)
        {
            HttpContext.Current.Response.AppendHeader("Content-encoding", encoding);
        }
        private static bool IsEncodingAccepted(string encoding)
        {
            var context = HttpContext.Current;
            return context.Request.Headers["Accept-encoding"] != null &&
                   context.Request.Headers["Accept-encoding"].Contains(encoding);
        }
    }
}
