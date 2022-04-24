using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Threading;
using System.Web;
using EbSite.Base.DataProfile;
using EbSite.BLL;
using EbSite.Data.Interface;
using EbSite.Mvc.Controllers;
using EbSite.Mvc.Filters;

namespace EbSite
{
 
    /// <summary>
    ///匹配内容到专题,将文章添加到专题
    /// </summary>
    public class tospecialController : JobApiBase
    {
        private static int LastIndex = 0;
        /// <summary>
        /// 是否将Execute放入线程池异步执行
        /// </summary>
        override protected bool IsAsyn
        {
            get { return true; }

        }
        /// <summary>
        /// 到期执行的方法
        /// </summary>
        /// <param name="key">在后台添加任务时的键值，一般没用到</param>
        /// <returns></returns>
        override protected string Execute(string key)
        {
            /*
                需求:
                调用专题里的keyword(多个要求用逗号分开)，查询与keyword相应的内容，添加到当前专题下
            */

            try
            {
                List<EbSite.Entity.SpecialClass> lst = DbProviderCms.GetInstance().SpecialClass_GetListArray("", 0, "");

                foreach (var model in lst)
                {
                    string sKeyWord = string.Concat(model.SeoKeyWord, ",", model.SpecialName);

                    if (!string.IsNullOrEmpty(sKeyWord))
                    {
                        string[] aKeyWords = sKeyWord.Split(',');

                        foreach (var keyw in aKeyWords)
                        {
                            if (string.IsNullOrEmpty(keyw))
                                continue;

                            int iKeyCount = 3;//包含关键词多少次
                            int iAddNum = 30;//添加多少条
                            string strSql = string.Format("SELECT id,ClassID, (LENGTH(ContentInfo)-LENGTH(REPLACE(ContentInfo,'{0}','')))/LENGTH('{0}') AS CT FROM eb_newscontent WHERE (LENGTH(ContentInfo)-LENGTH(REPLACE(ContentInfo,'{0}','')))/LENGTH('{0}') >{1} or newstitle LIKE '%{0}%' ORDER BY CT DESC LIMIT {2}", keyw, iKeyCount, iAddNum);
                            if (LastIndex == 1)
                                //只取最近两天内的
                                strSql = string.Format("SELECT id,ClassID, (LENGTH(ContentInfo)-LENGTH(REPLACE(ContentInfo,'{0}','')))/LENGTH('{0}') AS CT FROM eb_newscontent WHERE ((LENGTH(ContentInfo)-LENGTH(REPLACE(ContentInfo,'{0}','')))/LENGTH('{0}') >{1} or newstitle LIKE '%{0}%') AND AddTime>DATE_FORMAT(DATE_ADD(now(),INTERVAL -2 DAY),'%Y-%m-%d') ORDER BY CT DESC LIMIT {2}", keyw, iKeyCount, iAddNum);

                            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
                            {
                                while (dataReader.Read())
                                {
                                    long Id = dataReader.GetInt64(0);
                                    int ClassId = dataReader.GetInt32(1);

                                    Entity.SpecialNews mdSpecialNews = new Entity.SpecialNews();

                                    mdSpecialNews.NewsID = Id;

                                    mdSpecialNews.SpecialClassID = model.id;

                                    mdSpecialNews.ClassID = ClassId;

                                    if (!BLL.SpecialNews.ExistsContent(mdSpecialNews))
                                        BLL.SpecialNews.Add(mdSpecialNews);
                                }
                            }


                        }


                    }

                }

                LastIndex = 1; //标记一下，表示已经执行过，下次来，只调用最近两天的数据

            }
            catch (Exception e)
            {

                Log.Factory.GetInstance().ErrorLog(string.Format("自动匹配内容到专题发生错误：{0},错误追踪:{1}", e.Message, e.StackTrace));

            }
            Log.Factory.GetInstance().InfoLog("成功添加内容到专题");
            return "成功添加内容到专题";
             
        }
        
         
         
    }
     
}
