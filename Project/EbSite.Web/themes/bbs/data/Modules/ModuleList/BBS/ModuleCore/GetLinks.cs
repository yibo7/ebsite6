using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.BBS.ModuleCore
{
    public class GetLinks
    {
        //public static string SavePostUrl(int cid, int siteid)
        //{
        //    return string.Concat(EbSite.Base.Host.Instance.IISPath, "bbs/", siteid, "/post/", cid, "/");
        //}
        public static string SavePostUrl(int cid, int siteid)
        {
            return string.Concat(EbSite.Base.Host.Instance.IISPath, "savepost-", siteid, "-", cid, ".html");
        }
        public static string SavePostUrlMobile(int cid, int siteid)
        {
            return string.Concat(EbSite.Base.Host.Instance.IISPath, "savepostm-", siteid, "-", cid, ".html");
        }
        public static string SavePostUrl(int cid, int siteid,long id)
        {
            return string.Concat(SavePostUrl(cid, siteid), "?id=", id);
        }
         public static string ContentPageRule(int ContentId,int SiteID,int ClassID)
         {
            //return string.Concat(EbSite.Base.AppStartInit.IISPath,ContentId, "-{0}-", SiteID, "-", ClassID, EbSite.Base.Host.Instance.ContentLinkRw(SiteID)); 
             string SiteFolder = Base.AppStartInit.Sites[SiteID].SiteFolder;
             if (string.IsNullOrEmpty(SiteFolder))
             {
                return string.Concat(EbSite.Base.AppStartInit.IISPath, Base.Host.Instance.ContentLinkRw(SiteID).Replace("{内容ID}", ContentId.ToString()).Replace("{分类ID}", ClassID.ToString()).Replace("{页码}", "0").Replace(".", "p{0}."));
            }
            else
            {
                return string.Concat(EbSite.Base.AppStartInit.IISPath, SiteFolder, "/", Base.Host.Instance.ContentLinkRw(SiteID).Replace("{内容ID}", ContentId.ToString()).Replace("{分类ID}", ClassID.ToString()).Replace("{页码}", "0").Replace(".", "p{0}."));
            }
        }

         public static string ContentPage(int ContentId, int PageIndex, int SiteID, int ClassID)
         {
            // /1044-{0}-8-12551{分类ID}a{内容ID}b{页码}c.html
            string sRule = ContentPageRule(ContentId, SiteID, ClassID);
                     
            return string.Format(sRule, PageIndex);
            //return sRule.Replace(".",string.Concat("p", PageIndex,"."));
        }
        /// <summary>
        /// 获取回复URL
        /// </summary>
        /// <param name="postid">回复帖子ID</param>
        /// <param name="siteid">站点ID</param>
        /// <param name="ReferenceID">引用ID</param>
        /// <param name="AllCount">总记录数</param>
        /// <param name="EndPageIndex">最后页码</param>
        /// <param name="IsReSendEmail">是否有人回复给我email提醒</param>
        /// <param name="UserID">帖子用户ID</param>
        /// <returns></returns>
         public static string Reply(long postid, int siteid, object ReferenceID, int AllCount, int EndPageIndex, long IsReSendEmail, int UserID, int ClassID)
         {
             string surl = string.Concat(EbSite.Base.Host.Instance.IISPath, "reply-", siteid, "-", postid, ".html?", "count=", AllCount, "&endindex=", EndPageIndex, "&rs=", IsReSendEmail, "&puid=", UserID, "&cid=", ClassID);
             if (!Equals(ReferenceID,null))
             {
                 return string.Concat(surl, "&rfid=", ReferenceID);
             }
             return surl;
         }
         public static string ReplyEdite(long postid, int siteid,int ClassID,object id)
         {
             return string.Concat(EbSite.Base.Host.Instance.IISPath, "reply-", siteid, "-", postid, ".html?id=", id, "&cid=", ClassID);
         }

         public static string Reply(long postid, int siteid, int AllCount, int EndPageIndex, long IsReSendEmail, int UserID,int ClassID)
         {
             return Reply(postid, siteid, null, AllCount, EndPageIndex, IsReSendEmail, UserID, ClassID);
         }
         public static string Operation(int siteid,int classid)
         {
             return string.Concat(EbSite.Base.Host.Instance.IISPath, "operation-", siteid,"-",classid, ".html");
         }
    }
}