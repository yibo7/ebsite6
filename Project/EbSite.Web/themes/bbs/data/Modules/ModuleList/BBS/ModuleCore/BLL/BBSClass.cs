using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Core.Strings;

namespace EbSite.Modules.BBS.ModuleCore.BLL
{
    static public class BBSClass
    {
        private static DateTime dtLastClearToDayCount = DateTime.Today;
        static public void ClearToDayCount()
        { 

            if (cConvert.DateDiff("day", dtLastClearToDayCount, DateTime.Today) >= 1)
            {
                dtLastClearToDayCount = DateTime.Now;
                EbSite.BLL.NewsClass.Update("1=1", "Annex14", "0");
            }
        }
        /// <summary>
        /// 更新分类里的统计数据:   性能优化建议，1.可以先收集，缓存过期后触发更新，对照count点击统计,2.在另一线程更新，开启队列
        /// 6.帖子总条数--Annex11 
        /// 7.主题总数--Annex12 
        /// 8.回复总条数--Annex13 
        /// 9.今日帖子的总数量--Annex14 
        /// 10.最后发表或回复主题的ID--Annex1 
        /// 11.最后发表或回复主题的标题--Annex4
        ///12.最后发表或回复主题人用户ID--Annex15 
        /// 13.最后发表或回复主题人姓名--Annex2 
        /// 14.最后发表或回复时间日期--Annex3
        /// </summary>
        /// <param name="ClassID">分类ID</param>
        /// <param name="IsPost">否则发表主题，如果为false,则是回复</param>
        /// <param name="ContentID">操作帖子的ID</param>
        /// <param name="ContentTitle">操作帖子的标题</param>
        /// <param name="iUserID">最后发表用户ID</param>
        /// <param name="UserNiName">最后发表用户昵称</param>
        static public void UpdateCountAddOne(int ClassID,bool IsPost, long ContentID,string ContentTitle,int iUserID,string UserNiName)
        {
            EbSite.Entity.NewsClass md = EbSite.BLL.NewsClass.GetModelByCache(ClassID);
            md.Annex11 = md.Annex11 + 1;
            if (IsPost)
            {
                md.Annex12 = md.Annex12 + 1;   
            }
            else
            {
                md.Annex13 = md.Annex13 + 1; 
            }
            //if(!string.IsNullOrEmpty( md.Annex3)) //最后回复时间
            //{
            //    DateTime DayHitsLastTime = DateTime.Parse(md.Annex3);
            //    if (cConvert.DateDiff("day", DayHitsLastTime, DateTime.Today) > 1)
            //    {
            //        md.Annex14 = 1;
            //    }
            //    else
            //    {
            //        md.Annex14 = md.Annex14 + 1; 
            //    }
            //}
            md.Annex14 = md.Annex14 + 1; 
            md.Annex1 = ContentID.ToString();
            md.Annex15 = iUserID;
            md.Annex2 = UserNiName;
            md.Annex3 = DateTime.Now.ToString();
            md.Annex4 = ContentTitle;

            EbSite.BLL.NewsClass.Update(md);

        }
    }
}