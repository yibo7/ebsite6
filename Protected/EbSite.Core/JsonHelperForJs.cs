using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace EbSite.Core
{
    /// <summary>
    /// 对于js中的json,比较好用，如{uuid:"1",billCode:"20131120032656",state:"true",msg:"传输成功"} 可以转换成一个类
    /// </summary>
    public class JsonHelperForJs
    {
        public static string ObjToJson<T>(T model) where T : new()
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            // 序列化对象为JSON字符串
            return json.Serialize(model);
        }

        public static T JsonToObj<T>(string content) where T : new()
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            // 反序列化JSON字符串到对象
            return json.Deserialize<T>(content);
        }
    }
}
