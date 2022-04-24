using EbSite.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Web;

namespace EbSite.UEditor
{
    /*
编写api要注意：就算方法名一名，但参数变量的命名也不能一样，否则出错
如ebtest(string msg)与tokentest(string msg),msg都一样，会出错，可能是mvc的bug
   */
    //[RoutePrefix("content")]
    public class searchpicController : ApiBaseController
    {


        /// <summary>
        /// 根据关键词搜索相关的图片列表 前端访问地址 /api/searchpic?key=abc
        /// </summary>
        /// <param name="key">关键词.</param>
        /// <returns>System.String.</returns>
        public List<ImgRz> Get(string key, int pageindex)
        {

            int iGetNum = (pageindex - 1) * 15;
            string sContent = Core.WebUtility.LoadURLString(
                 string.Format(
                     "http://image.baidu.com/search/index?tn=baiduimage&ie=utf-8&word={0}&pn={1}", key, iGetNum));

            List<string> strsList = EbSite.Core.Strings.GetString.RegexFinds("\"objURL\":\"(.*?)\",", sContent, 1);

            List<ImgRz> rz = new List<ImgRz>();

            foreach (string s in strsList)
            {
                rz.Add(new ImgRz() { ImgUrl = s });
            }

            return rz;
        }



    }

    public class ImgRz
    {
        public string ImgUrl { get; set; }
    }

}
