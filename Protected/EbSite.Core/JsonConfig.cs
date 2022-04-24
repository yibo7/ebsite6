using System;
using System.Linq;
using EbSite.Core.FSO;
using Newtonsoft.Json.Linq;
using System.IO;
namespace EbSite.Core
{
    public  class Config
    {

        /// <summary>
        /// 处理一个json文件
        /// </summary>
        /// <param name="sPath">json文件的绝路径，调用时可以这样获取 HttpContext.Current.Server.MapPath("config.json")</param>
        public Config(string sPath)
        {
            var json = File.ReadAllText(sPath);
            Items =  JObject.Parse(json);
        }
        private  JObject Items;

        public  T GetValue<T>(string key)
        {
            return Items[key].Value<T>();
        }

        public  String[] GetStringList(string key)
        {
            return Items[key].Select(x => x.Value<String>()).ToArray();
        }

        public  String GetString(string key)
        {
            return GetValue<String>(key);
        }

        public  int GetInt(string key)
        {
            return GetValue<int>(key);
        }
    }
}