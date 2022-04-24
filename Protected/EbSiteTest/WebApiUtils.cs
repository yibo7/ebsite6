  
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.ApiEntity;
using NUnit.Framework;
using XS.Core.WebApiUtils;

namespace EbSiteTest
{


    /// <summary>
    ///This is a test class for BBSGetTest and is intended
    ///to contain all BBSGetTest Unit Tests
    ///</summary>
    [TestFixture]
    public class WebApiUtils
    {
        //这个是为每个用户生成的key
        private  string key = "3z0Pt7mTIieshFoPvpzGws2YoBZQ8XXASuDyILPmH1Mv8cUsfE+Phb2WNmBHbt4SDwenN9HGOq2BfWVxVWYFKcG9w3uwn2JuZjwkD1ryAyAr3ky4jrSjpqvi7gjl90/ht45LZE2rmBu7e6diU9HeT6szs0wlQn2RiwpuBFswL+2z1rdhbcu7tpVYw/CtM9Kah7tuHC5ZT+kUfiXX28vu3g==";
        private string apiurl = "http://localhost:2015/api";
        //[TestInitialize]
        //public void FixtureSetUp()
        //{
        //    //这样获取当前HttpContext
        //    HttpContext.Current = new HttpContext(new HttpRequest("", "http://www.ebsite.net", ""), new HttpResponse(new StringWriter(new StringBuilder())));

        //}
        [Test]
        public void GetPageBody()
        {


            Dictionary<string, string> dic = EbSite.Core.WebUtility.GetBodyKewordDis("http://news.beimai.com");
            foreach (var md in dic)
            {
                System.Console.WriteLine(string.Format("{0}:{1}", md.Key, md.Value));
            }




            //return rg.Match(str).Value;
        }
        [Test]
        public void GetClassSubs()
        {
            ApiBll bll = new ApiBll(apiurl, key);

            Dictionary<string, string> sites = bll.GetDic("classq?site=1&pid=13036");

            foreach (var s in sites)
            {
                System.Console.WriteLine("ID:" + s.Key);
                System.Console.WriteLine("分类:" + s.Value);
            }

        }

        [Test]
        public void GetClassTree()
        {
            ApiBll bll = new ApiBll(apiurl, key);

            Dictionary<string, string> sites = bll.GetDic("classq?site=1");

            foreach (var s in sites)
            {
                System.Console.WriteLine("ID:" + s.Key);
                System.Console.WriteLine("分类:" + s.Value);
            }

        }
        [Test]
        public void GetSites()
        {
            ApiBll bll = new ApiBll(apiurl, key);

            Dictionary<string,string> sites =   bll.GetDic("siteq");

            foreach (var s in sites)
            {
                System.Console.WriteLine("ID:"+s.Key);
                System.Console.WriteLine("站点名称:" + s.Value);
            }

        }

        [Test]
        public void AddContent()
        {
            ApiBll bll = new ApiBll(apiurl, key);
            List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<string, string>>();

            paramList.Add(new KeyValuePair<string, string>("siteid", "1"));
            paramList.Add(new KeyValuePair<string, string>("classid", "13087"));
            paramList.Add(new KeyValuePair<string, string>("title", "fsdfsdfsdf"));
            paramList.Add(new KeyValuePair<string, string>("content", "wwwwwwwwwwwwwwwwwwwwwwwww")); 
            
            //paramList.Add(new KeyValuePair<string, string>("data", "fffffffffffff"));

            ApiMessage<int> rz = bll.PostPram<ApiMessage<int>>("content", paramList);

            if (rz.Success)
            {
                System.Console.WriteLine("添加成功");
                System.Console.WriteLine(rz.Data);
            }
            else
            {
                System.Console.WriteLine(rz.Message);
            }
            
        }

        [Test]
        public void UpdateContent()
        {
            ApiBll bll = new ApiBll(apiurl, key);
            List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<string, string>>();

            paramList.Add(new KeyValuePair<string, string>("siteid", "1"));
            paramList.Add(new KeyValuePair<string, string>("classid", "13087"));
            paramList.Add(new KeyValuePair<string, string>("title", "fffff"));
            paramList.Add(new KeyValuePair<string, string>("content", "wwwwwwwwwwwwwwwwwwwwwwwww")); 
            paramList.Add(new KeyValuePair<string, string>("id", "1051"));

            //paramList.Add(new KeyValuePair<string, string>("data", "fffffffffffff"));

            ApiMessage<int> rz = bll.PostPram<ApiMessage<int>>("content", paramList);

            if (rz.Success)
            {
                System.Console.WriteLine("修改成功");
                System.Console.WriteLine(rz.Data);
                System.Console.WriteLine(rz.Message);
            }
            else
            {
                System.Console.WriteLine(rz.Message);
            }

        }

        [Test]
        public void GetContentModels()
        {
             
            ApiBll bll = new ApiBll("http://localhost:2015/api/queryc", key);

            EbSite.ApiEntity.QueryModel model = new QueryModel();
            model.SiteId = 1;
            model.Fields = "";
            model.PageSize = 3;
            model.PageIndex = 1;



            List<ContentQuery> cqs = new List<ContentQuery>();
            ContentQuery cq = new ContentQuery();
            cq.ColumName = "newstitle";
            cq.ColumValue = "的";//注意，如果是区间查询，这里要填写两个值，用逗号分开
            cq.QueryType = ContentQueryType.模糊;//默认为精确查询
            cq.LinkType = ContentQueryLinkType.OR;//与下一个字段的链接方式，如果是最后一个字段，可不用填写
            cqs.Add(cq);

            cq = new ContentQuery();
            cq.ColumName = "classname";
            cq.ColumValue = "5555";
            cqs.Add(cq);


            model.Wheres = cqs;//你可以注掉此条件，将查找所有数据

            ContentQueryRezult rz = bll.PostModel<ContentQueryRezult>("loadlist", model);

            System.Console.WriteLine("找到记录："+ rz.Count+ "条");

            foreach (var m in rz.Data)
            {
                System.Console.WriteLine(m.NewsTitle);
            }

            //List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<string, string>>();
            //paramList.Add(new KeyValuePair<string, string>("model", "1"));
            //ApiMessage<int> rz = bll.PostPram<ApiMessage<int>>("loadlist", paramList);


        }

        [Test]
        public void UpdateContentModel()
        {
            ApiBll bll = new ApiBll(apiurl, key);

            EbSite.ApiEntity.Content model = new Content();
            model.ID = 1054;
            model.ClassID = 13087;
            model.SiteID = 1;
            model.NewsTitle = "发射点发生";
            model.ContentInfo = "发射点发生fffffffffffff";

            ApiMessage<int> rz = bll.PostModel<ApiMessage<int>>("content", model);

            if (rz.Success)
            {
                System.Console.WriteLine("修改成功");
                System.Console.WriteLine(rz.Data);
                System.Console.WriteLine(rz.Message);
            }
            else
            {
                System.Console.WriteLine(rz.Message);
            }

        }
        [Test]
        public void  GetContentModel()
        {
            ApiBll bll = new ApiBll(apiurl, key);
            //List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<string, string>>();

            //paramList.Add(new KeyValuePair<string, string>("siteid", "2"));
            //paramList.Add(new KeyValuePair<string, string>("classid", "158"));
            //paramList.Add(new KeyValuePair<string, string>("id", "9222"));

            //EbSite.ApiEntity.Content rz = bll.GetObject<Content>(string.Format("content?siteid={0}&classid={1}&id={2}",1,13030,499)); 
            EbSite.ApiEntity.Content rz = bll.GetObject<Content>(string.Format("content?siteid={0}&id={1}", 1,  123));
            System.Console.WriteLine(rz.NewsTitle);

        }

        /// <summary>
        ///A test for CallTask
        ///</summary>
        [Test]
        public void CallTaskTest()
        {
            //EbSite.Core.WebApiUtils.ApiBll bll = new ApiBll("https://api.weixin.qq.com");

           //Dictionary<string,string> obj = bll.GetDic("cgi-bin/ticket/getticket?access_token=Wpi2w-NfqOuLWuHaPAGkN97vs4w3x7xPF735UCf-WjOD17-dGKbzSI4XiZ3L6JOdk-W81FV8LNdpU5DQie0nwEkd_vU--EZK-hCGk-xPh6A&type=jsapi");

            //Debug.Print(obj.Count.ToString());
            //System.Console.WriteLine(obj.Count);
        }

        [Test]
        public void IpTest()
        {
            string sIP = "10.168.44.39, 211.139.92.11";
            if (sIP.Contains(","))
            {
                sIP =  sIP.Split(',').Last().Trim();
                System.Console.WriteLine("结果:"+ sIP);
            }
            else
            {
                System.Console.WriteLine("没有结果");
            }
            
        }
        [Test]
        public void GetMaxId()
        {
            ApiBll bll = new ApiBll(apiurl, key);

            string rz = bll.GetObject<string>("content?t=1");
            System.Console.WriteLine("结果:" + rz);

        }
        [Test]
        public void MakeTag()
        {
            ApiBll bll = new ApiBll(apiurl, key);

            string rz = bll.GetObject<string>("tag?id=117&siteid=1&show=true");
            System.Console.WriteLine("结果:" + rz);

            //string rz = bll.GetObject<string>("tag?t=1");
            //System.Console.WriteLine("结果:" + rz);

        }
        [Test]
        public void ClassLink()
        {
            ApiBll bll = new ApiBll(apiurl, key);

            string rz = bll.GetObject<string>("linkclass?id=33&p=1&s=1&ispc=false");  //参数id为分类Id，s为站点Id,ispc为是否PC链接，fase为移动链接
            System.Console.WriteLine("结果:" + rz);

        }
        [Test]
        public void SpecialLink()
        {
            ApiBll bll = new ApiBll(apiurl, key);

            string rz = bll.GetObject<string>("linkspecial?id=318&p=1&s=1&ispc=false");  //参数id为分类Id，s为站点Id,ispc为是否PC链接，fase为移动链接
            System.Console.WriteLine("结果:" + rz);

        }
        [Test]
        public void Getspecial()
        {
            ApiBll bll = new ApiBll(apiurl, key);

            Dictionary<string, string> sites = bll.GetDic("special?site=1");

            foreach (var s in sites)
            {
                System.Console.WriteLine("ID:" + s.Key);
                System.Console.WriteLine("专题名称:" + s.Value);
            }

        }
        


    }
}
