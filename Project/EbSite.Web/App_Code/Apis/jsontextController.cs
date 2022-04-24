using System;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using EbSite.BLL;
using EbSite.Mvc.Controllers;
using EbSite.Mvc;
namespace EbSite
{
    /*
编写api要注意：就算方法名一名，但参数变量的命名也不能一样，否则出错
如ebtest(string msg)与tokentest(string msg),msg都一样，会出错，可能是mvc的bug
   */ 
    public class jsontextController : ApiBaseController
    {
        public ApiMessage<Dictionary<string, string>> Get()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("1", "数据1");
            data.Add("2", "数据2");
            data.Add("3", "数据3");
            //要做的事情
            return new ApiMessage<Dictionary<string, string>> { Data = data, Message = "请求成功", Success = true };
        }
        public string Get(string username)
        {
            return "我的名称是" + username;
        }
        public string Get(string username,int age)
        {
            return "我的名称是" + username+" 年龄"+age;
        }

        public string Post(UserModel user)
        {
            return "这是用户名称:" + user.name;
        }



    }

    public class UserModel
    {
        public string name { get; set; }

    }


}
