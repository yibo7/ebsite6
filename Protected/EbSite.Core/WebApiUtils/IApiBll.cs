using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web; 
using fastJSON;

namespace EbSite.Core.WebApiUtils
{
    abstract public class IApiBll
    {
        protected HttpClient client;

        public IApiBll(string ApiUrl)
        {
            
            client = new HttpClient();
            client.BaseAddress = new Uri(string.Concat(ApiUrl, "/"));  
            // 为JSON格式添加一个Accept报头
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //可以做为参数在外面传进来
            //string token = Core.Utils.GetSingleVlue("ebu", "Token");
            //if (!string.IsNullOrEmpty(token))
            //    client.DefaultRequestHeaders.Add("Token", token); 
            //client.DefaultRequestHeaders.Add("BMSessionId", Utils.GetSessionId);
        }
        /// <summary>
        /// 获取一个数据集合
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="api">Api的相对地址,如api/products</param>
        /// <returns></returns>
        abstract public IEnumerable<T> GetObjectList<T>(string api);
        /// <summary>
        /// 获取Json数据
        /// </summary>
        /// <param name="api">Api的相对地址,如api/products</param>
        /// <returns></returns>
        abstract public string GetJson(string api);

        /// <summary>
        /// Post提交数据
        /// </summary>
        /// <typeparam name="T">提交的对象名称，对象字段为参数名称</typeparam>
        /// <param name="api">Api的相对地址,如api/products</param>
        /// <param name="paramList">参数列表</param>
        /// <returns></returns> 
        public abstract T PostPram<T>(string api, List<KeyValuePair<String, String>> paramList) where T : class;
        public abstract T PostPram<T>(string api) where T : class;
       
        public abstract T PostModel<T>(string api,object model) where T : class;
         public abstract void PostPram(string api);
        /// <summary>
        /// 获取一个字典列表，但要注意，返回的数据格式是否符合，否则转换出错
        /// </summary>
        /// <param name="api">Api的相对地址,如api/products</param>
        /// <returns></returns>
        abstract public  List<Dictionary<string, string>> GetDicList(string api);
        /// <summary>
        /// 获取一个字典列表，但要注意，返回的数据格式是否符合，否则转换出错
        /// </summary>
        /// <param name="api">Api的相对地址,如api/products</param>
        /// <returns></returns>
        abstract public List<Dictionary<string, object>> GetDicList2(string api);
        /// <summary>
        /// Api的相对地址,如api/products
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api">Api的相对地址,如api/products</param>
        /// <param name="model"></param>
        abstract public  void Put<T>(string api, T model);
        /// <summary>
        /// Api的相对地址,如api/products
        /// </summary>
        /// <param name="api">Api的相对地址,如api/products</param>
        abstract public  void Delete(string api);
        /// <summary>
        /// 获取一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="api">Api的相对地址,如api/products</param>
        /// <returns></returns>
        abstract public  T GetObject<T>(string api) where T : class;
        /// <summary>
        /// 获取一个字典
        /// </summary>
        /// <param name="api">Api的相对地址,如api/products</param>
        /// <returns></returns>
        abstract public Dictionary<string, string> GetDic(string api);
        /// <summary>
        /// 获取一个字典
        /// </summary>
        /// <param name="api">Api的相对地址,如api/products</param>
        /// <returns></returns>
        abstract public Dictionary<string, object> GetDic2(string api);
    }
}