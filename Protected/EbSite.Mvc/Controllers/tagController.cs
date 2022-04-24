using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using EbSite.ApiEntity;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Entity;
using EbSite.Mvc.Filters;
namespace EbSite.Mvc.Controllers
{
    /*
    编写api要注意：就算方法名一样，但参数变量的命名也不能一样，否则出错
    如ebtest(string msg)与tokentest(string msg),msg都一样，会出错，可能是mvc的bug
        */
    //[RoutePrefix("content")]
    public class tagController : ApiBaseController
    {

        /// <summary>
        /// 通过标题分词，生成内容的标签
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="siteid">The siteid.</param>
        /// <param name="show">if set to <c>true</c> [show].</param>
        /// <returns>System.String.</returns>
        [Token]
        public string Get(long id, int siteid, bool show)
        {

            string sRz = "no";
            NewsContentSplitTable ContentTable = EbSite.Base.AppStartInit.GetNewsContentInst("newscontent");
            if (ContentTable.Exists(id, siteid))
            {
                EbSite.Entity.NewsContent ThisModel = ContentTable.GetModel(id, siteid);
                if (!Equals(ThisModel, null))
                {
                    List<string> sSplitWords = EbSite.Base.Host.Instance.SegmentWords(ThisModel.NewsTitle, siteid);


                    if (sSplitWords.Count>0)
                    {
                        //sSplitWords = sSplitWords.Replace("/", ",");
                        //string[] aKeyWord = sSplitWords.Split('/');
                        StringBuilder sbKeyWord = new StringBuilder();
                        foreach (var key in sSplitWords)
                        {
                            if (key.Length > 1)
                            {
                                sbKeyWord.Append(key);
                                sbKeyWord.Append(",");
                            }

                        }

                        if (sbKeyWord.Length > 1)
                        {
                            sbKeyWord.Remove(sbKeyWord.Length - 1, 1);
                        }

                        if (!show)
                        {
                            ThisModel.TagIDs = sbKeyWord.ToString();
                            ContentTable.Update(ThisModel);
                            EbSite.BLL.TagKey.UpdateTag(sbKeyWord.ToString(), id, ThisModel.ClassID, siteid, 0);//用户ID只能设置为0,否则会出错，并且这些标签生成与用户无关

                            sRz = string.Format("成功生成标签:{0},来自:{1}", sbKeyWord, ThisModel.NewsTitle);
                        }
                        else
                        {
                            sRz = string.Format("{0}  源：{1}", sSplitWords, ThisModel.NewsTitle);

                        }
                    }

                }
            }
            else
            {
                sRz = string.Concat("找不到内容:", id);
            }

            return sRz;
        }


        //[HttpPost]
        //[Token]
        //public string make(long id,int siteid, bool show)
        //{
            
        //    string sRz = "no";
        //    NewsContentSplitTable ContentTable = EbSite.Base.AppStartInit.GetNewsContentInst("newscontent");
        //    if (ContentTable.Exists(id, siteid))
        //    {
        //        EbSite.Entity.NewsContent ThisModel = ContentTable.GetModel(id, siteid);
        //        if (!Equals(ThisModel, null))
        //        {
        //            string sSplitWords = EbSite.Base.Host.SegmentWords(ThisModel.NewsTitle);
                   

        //            if (!string.IsNullOrEmpty(sSplitWords))
        //            {
        //                //sSplitWords = sSplitWords.Replace("/", ",");
        //                string[] aKeyWord = sSplitWords.Split('/');
        //                StringBuilder sbKeyWord = new StringBuilder();
        //                foreach (var key in aKeyWord)
        //                {
        //                    if (key.Length > 1)
        //                    {
        //                        sbKeyWord.Append(key);
        //                        sbKeyWord.Append(",");
        //                    }

        //                }

        //                if (sbKeyWord.Length > 1)
        //                {
        //                    sbKeyWord.Remove(sbKeyWord.Length - 1, 1);
        //                }

        //                if (!show)
        //                {
        //                    ThisModel.TagIDs = sbKeyWord.ToString();
        //                    ContentTable.Update(ThisModel);
        //                    EbSite.BLL.TagKey.UpdateTag(sbKeyWord.ToString(), id, ThisModel.ClassID, siteid, 0);//用户ID只能设置为0,否则会出错，并且这些标签生成与用户无关

        //                    sRz = string.Format("成功生成标签:{0},来自:{1}", sbKeyWord, ThisModel.NewsTitle);
        //                }
        //                else
        //                {
        //                    sRz = string.Format("{0}  源：{1}", sSplitWords, ThisModel.NewsTitle);

        //                }
        //            }
                    
        //        }
        //    }
        //    else
        //    {
        //        sRz = string.Concat("找不到内容:", id);
        //    }

        //    return sRz;
        //}
         

    }
}
