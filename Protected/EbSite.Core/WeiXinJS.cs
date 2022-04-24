using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Core.WebApiUtils;
using NPOI.HPSF;

namespace EbSite.Core
{
    public class WeiXinJS
    {

        private static readonly string CacheClass = "WeiXinJS";

        private static string[] strs = new string[]
        {
           "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
           "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"
        };

        /// <summary>
        /// 创建随机字符串
        /// </summary>
        /// <returns></returns>
        public static string CreatenNonce_str()
        {
            Random r = new Random();
            var sb = new StringBuilder();
            var length = strs.Length;
            for (int i = 0; i < 15; i++)
            {
                sb.Append(strs[r.Next(length - 1)]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 创建时间戳
        /// </summary>
        /// <returns></returns>
        public static long CreatenTimestamp()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
        // <summary>
        /// 获取jsapi_ticket
        /// jsapi_ticket是公众号用于调用微信JS接口的临时票据。
        /// 正常情况下，jsapi_ticket的有效期为7200秒，通过access_token来获取。
        /// 由于获取jsapi_ticket的api调用次数非常有限，频繁刷新jsapi_ticket会导致api调用受限，影响自身业务，开发者必须在自己的服务全局缓存jsapi_ticket 。
        /// </summary>
        /// <param name="access_token">BasicAPI获取的access_token,也可以通过TokenHelper获取</param>
        /// <returns></returns>
        public static string GetTickect(string access_token)
        {
            string cachekey = string.Concat("GetTickect", access_token);
            string sTickect = Base.Host.CacheApp.GetCacheItem<string>(cachekey, CacheClass);

            if (string.IsNullOrEmpty(sTickect))
            {
                EbSite.Core.WebApiUtils.ApiBll bll = new ApiBll("https://api.weixin.qq.com");

                Dictionary<string, string> obj = bll.GetDic(string.Format("cgi-bin/ticket/getticket?access_token={0}&type=jsapi", access_token));

                if (obj.ContainsKey("ticket"))
                {
                    sTickect =  obj["ticket"];
                    if (!string.IsNullOrEmpty(sTickect))
                    {
                        Base.Host.CacheApp.AddCacheItem(cachekey, sTickect, 7200, ETimeSpanModel.M, CacheClass);
                    }
                    else
                    {
                        EbSite.Log.Factory.GetInstance().ErrorLog("获取微信Tickect失败,返回值不空");
                    }
                }
            }

            


            return sTickect;
        }

        public static string GetToken(string appid, string secret, string grant_type = "client_credential")
        {
            string cachekey = string.Concat("GetToken", appid);
             string sToken = Base.Host.CacheApp.GetCacheItem<string>(cachekey, CacheClass);

            if (string.IsNullOrEmpty(sToken))
            {
                var url = string.Format("cgi-bin/token?grant_type={0}&appid={1}&secret={2}",
                                    grant_type, appid, secret);

                EbSite.Core.WebApiUtils.ApiBll bll = new ApiBll("https://api.weixin.qq.com");

                Dictionary<string, string> obj = bll.GetDic(url);
                if (obj.ContainsKey("access_token"))
                    sToken =  obj["access_token"];
                if (!string.IsNullOrEmpty(sToken))
                {
                    Base.Host.CacheApp.AddCacheItem(cachekey, sToken, 7200, ETimeSpanModel.M, CacheClass);
                }
                else
                {
                    EbSite.Log.Factory.GetInstance().ErrorLog("获取微信Token失败,返回值不空");
                }
            }
            return sToken;
        }
        /// <summary>
        /// 签名算法
        /// </summary>
        /// <param name="jsapi_ticket">jsapi_ticket</param>
        /// <param name="noncestr">随机字符串(必须与wx.config中的nonceStr相同)</param>
        /// <param name="timestamp">时间戳(必须与wx.config中的timestamp相同)</param>
        /// <param name="url">当前网页的URL，不包含#及其后面部分(必须是调用JS接口页面的完整URL)</param>
        /// <returns></returns>
        public static string GetSignature(string jsapi_ticket, string noncestr, long timestamp, string url, out string string1)
        {
            var string1Builder = new StringBuilder();
            string1Builder.Append("jsapi_ticket=").Append(jsapi_ticket).Append("&")
             .Append("noncestr=").Append(noncestr).Append("&")
             .Append("timestamp=").Append(timestamp).Append("&")
             .Append("url=").Append(url.IndexOf("#") >= 0 ? url.Substring(0, url.IndexOf("#")) : url);
            string1 = string1Builder.ToString();
            
            return Strings.StringEncrypt.SHA1((string1));
        }

        public static Dictionary<string,string> GetSignature(string AppId,string AppSecret,ref string sUrl)
        {
            Dictionary < string,string> dic = new Dictionary<string, string>();
            string noncestr = CreatenNonce_str();
            long timestamp = CreatenTimestamp();
            string url = sUrl;
            url = url.IndexOf("#") >= 0 ? url.Substring(0, url.IndexOf("#")) : url;
            sUrl = url;
            dic.Add("noncestr", noncestr);
            dic.Add("timestamp", timestamp.ToString());

            string jsapi_ticket = GetTickect(GetToken(AppId, AppSecret));
            var string1Builder = new StringBuilder();
            string1Builder.Append("jsapi_ticket=").Append(jsapi_ticket).Append("&")
             .Append("noncestr=").Append(noncestr).Append("&")
             .Append("timestamp=").Append(timestamp).Append("&")
             .Append("url=").Append(url);
            
            //dic.Add("url", url);

            string string1 = string1Builder.ToString();

            dic.Add("sign", Strings.StringEncrypt.SHA1((string1)));

            return dic;
        }


    }
}
