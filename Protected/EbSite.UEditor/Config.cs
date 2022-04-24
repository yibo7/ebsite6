using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;

namespace EbSite.UEditor
{

    /// <summary>
    /// Config 的摘要说明
    /// </summary>
    public static class Config
    {
        public static string GetIISPath
        {
            get
            {


                string AppPath = "";
                HttpContext HttpCurrent = HttpContext.Current;
                HttpRequest Req;
                if (HttpCurrent != null)
                {
                    Req = HttpCurrent.Request;

                    string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                    //UrlAuthority 如 http://www.ebsite.net:8088
                    if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                    {
                        //直接安装在   Web   站点   

                        AppPath = "/";
                    }
                    else
                    {
                        //安装在虚拟子目录下   
                        AppPath = string.Concat(Req.ApplicationPath, "/");
                    }

                }
                return AppPath;
            }
        }
        private static bool noCache = true;
        private static JObject BuildItems()
        {
            var json = File.ReadAllText(HttpContext.Current.Server.MapPath(string.Concat(EbSite.Base.Host.Instance.IISPath, "js/ueditor/config.json")));
            return JObject.Parse(json);
        }

        public static JObject Items
        {
            get
            {
                if (noCache || _Items == null)
                {
                    _Items = BuildItems();
                }
                return _Items;
            }
        }
        private static JObject _Items;


        public static T GetValue<T>(string key)
        {
            return Items[key].Value<T>();
        }

        public static String[] GetStringList(string key)
        {
            return Items[key].Select(x => x.Value<String>()).ToArray();
        }

        public static String GetString(string key)
        {
            return GetValue<String>(key);
        }

        public static int GetInt(string key)
        {
            return GetValue<int>(key);
        }
    }
}
