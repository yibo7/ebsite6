//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Sockets;
//using System.Security;
//using System.Text;
//using System.Web;
//using System.Web.Caching;
//using Yahoo.Yui.Compressor;

//namespace EbSite.Core.HttpHandlers
//{
//    public class JsCssHandler : IHttpHandler
//    {
//        private const string CacheKeyFormat = "_CacheKey_{0}_";
   
//           private const bool IsCompress = true; //需要压缩
   
//           public bool IsReusable
//           {
//               get
//              {
//                 return false;
//              }
//          }
  
//          public void ProcessRequest(HttpContext context)
//          {
//              HttpRequest request = context.Request;
//              HttpResponse response = context.Response;
  
//              string cachekey = string.Empty;
  
//              string type = request.QueryString["type"];
//              if (!string.IsNullOrEmpty(type) && (type == "css" || type == "js"))
//              {
//                  if (type == "js")
//                  {
//                      response.ContentType = "text/javascript";
  
//                  }
//                  else if (type == "css")
//                  {
//                      response.ContentType = "text/css";
//                  }
 
//                  cachekey = string.Format(CacheKeyFormat, type);
  
//                  CompressCacheItem cacheItem = HttpRuntime.Cache[cachekey] as CompressCacheItem;
//                  if (cacheItem == null)
//                  {
//                      string content = string.Empty;
//                      string path = context.Server.MapPath("");
//                      //找到这个目录下所有的js或css文件，当然也可以进行配置，需求请求压缩哪些文件
//                      //这里就将所的有文件都请求压缩
//                      string[] files = Directory.GetFiles(path, "*." + type);
//                      StringBuilder sb = new StringBuilder();
//                      foreach (string fileName in files)
//                      {
//                          if (File.Exists(fileName))
//                          {
//                              string readstr = File.ReadAllText(fileName, Encoding.UTF8);
//                              sb.Append(readstr);
//                          }
//                      }
  
//                      content = sb.ToString();
  
//                      // 开始压缩文件
//                      if (IsCompress)
//                      {
//                          if (type.Equals("js"))
//                          {
//                              content = JavaScriptCompressor.Compress(content);
//                          }
//                          else if (type.Equals("css"))
//                          {
//                              content = CssCompressor.Compress(content);
//                          }
//                      }
  
//                      //输入到客户端还可以进行Gzip压缩 ,这里就省略了
  
//                      cacheItem = new CompressCacheItem() { Type = type, Content = content, Expires = DateTime.Now.AddDays(30) };
//                      HttpRuntime.Cache.Insert(cachekey, cacheItem, null, cacheItem.Expires, TimeSpan.Zero);
//                  }
  
//                  string ifModifiedSince = request.Headers["If-Modified-Since"];
//                  if (!string.IsNullOrEmpty(ifModifiedSince)
//                      && TimeSpan.FromTicks(cacheItem.Expires.Ticks - DateTime.Parse(ifModifiedSince).Ticks).Seconds < 0)
//                  {
//                      response.StatusCode = (int)System.Net.HttpStatusCode.NotModified;
//                      response.StatusDescription = "Not Modified";
//                  }
//                  else
//                  {
//                      response.Write(cacheItem.Content);
//                      SetClientCaching(response, cacheItem.Expires);
//                  }
//              }
  
//          }
  
//          private void SetClientCaching(HttpResponse response, DateTime expires)
//          {
//              response.Cache.SetETag(DateTime.Now.Ticks.ToString());
//              response.Cache.SetLastModified(DateTime.Now);
  
//              //public 以指定响应能由客户端和共享（代理）缓存进行缓存。    
//              response.Cache.SetCacheability(HttpCacheability.Public);
  
//             //是允许文档在被视为陈旧之前存在的最长绝对时间。 
//             response.Cache.SetMaxAge(TimeSpan.FromTicks(expires.Ticks)); 
//             response.Cache.SetSlidingExpiration(true);
//         }
//         private class CompressCacheItem
//         {
//             /// <summary>
//             /// 类型 js 或 css 
//             /// </summary>
//             public string Type { get; set; } // js css  
//             /// <summary>
//             /// 内容
//             /// </summary>
//             public string Content { set; get; }
//             /// <summary>
//             /// 过期时间
//             /// </summary>
//             public DateTime Expires { set; get; }
//         }
//    }
//}
