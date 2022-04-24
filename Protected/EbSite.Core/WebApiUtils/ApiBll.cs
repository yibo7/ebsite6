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
    
    public class ApiBll : IApiBll
    {
        
        public ApiBll (string ApiUrl):base(ApiUrl)
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="API">Api的相对地址,如api/products</param>
        /// <returns></returns>
       override public IEnumerable<T> GetObjectList<T>(string API)
        {
            HttpResponseMessage response = client.GetAsync(API).Result;  // Blocking call（阻塞调用）! 
            if (response.IsSuccessStatusCode)
            {
                // 解析响应体。阻塞！
               return response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                
            }
            else
            {
               return null;
            }
        }

       override public string GetJson(string api)
        {
            HttpResponseMessage response = client.GetAsync(api).Result;  // Blocking call（阻塞调用）! 
            if (response.IsSuccessStatusCode)
            {

                // 解析响应体。阻塞！
                return response.Content.ReadAsStringAsync().Result;

            }
            else
            {
                return null;
            }
        }

        public override void PostPram(string api)
        {
            client.PostAsync(api, null);
        }

       public override T PostPram<T>(string api)
       {
           HttpResponseMessage response = client.PostAsync(api,null).Result;

           if (response.IsSuccessStatusCode)
           {
               // 解析响应体。阻塞！
               return response.Content.ReadAsAsync<T>().Result;

           }
           else
           {
               return null;
           }
        }

        override public T PostPram<T>(string api, List<KeyValuePair<String, String>> paramList)
       {
           StringBuilder sb = new StringBuilder(api);
           if (api.IndexOf("?") > -1)
           { sb.Append("&"); }
           else
           {
               sb.Append("?");
           }
            foreach (var pram in paramList)
            {
                sb.Append(pram.Key);
                sb.Append("=");
                sb.Append(pram.Value);
                sb.Append("&");
            }

            sb.Remove(sb.Length - 1, 1);

            return PostPram<T>(sb.ToString());

       }

        override public T PostModel<T>(string api, object model)
        {
            HttpResponseMessage response = client.PostAsJsonAsync(api, model).Result;

            if (response.IsSuccessStatusCode)
            {
                // 解析响应体。阻塞！
                return response.Content.ReadAsAsync<T>().Result;

            }
            else
            {
                return null;
            }
        }

     
      override public List<Dictionary<string, string>> GetDicList(string api)
      {
          return GetObject<List<Dictionary<string, string>>>(api); 
      }
      override public List<Dictionary<string, object>> GetDicList2(string api)
      {
           

          return GetObject<List<Dictionary<string, object>>>(api);
           
      }
      override public Dictionary<string, string> GetDic(string api)
      {
          return GetObject<Dictionary<string, string>>(api);
      }
      override public Dictionary<string, object> GetDic2(string api)
      {
          return GetObject<Dictionary<string, object>>(api);
      }
      override public void Put<T>(string api, T model)
      {
          client.PutAsJsonAsync(api, model);
      }
      override public void Delete(string api)
      {
          client.DeleteAsync(api);

      }
      override public T GetObject<T>(string api) 
      {
          HttpResponseMessage response = client.GetAsync(api).Result;  // Blocking call（阻塞调用）! 
          if (response.IsSuccessStatusCode)
          {

              // 解析响应体。阻塞！
              return response.Content.ReadAsAsync<T>().Result;

          }
          else
          {
              return null;
          }
      }

    }
}