using System;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using EbSite.BLL;
using EbSite.BLL.Count.Strategy;
using EbSite.Core.Strings;

namespace EbSite.BLL.Count
{
    /// <summary>
    /// 添加基数
    /// </summary>
   abstract public class ContentBase : CountBase
    {
        //public static readonly ContentHits Instance = new ContentHits();
        public  string ContentCacheKey  //每类统计要重写不同的sCacheKey
        {
            get
            {
                return string.Concat("ContentHits-", TableName);
            }
        }

        
        protected NewsContentSplitTable NewsContentInst;
        protected string TableName = "";
        protected int ClassID = 0;
        public ContentBase(int _ClassID)
        {
            ClassID = _ClassID;
            TableName = EbSite.Base.AppStartInit.GetTableNameByClassID(ClassID);
            NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(TableName);
         
        }

        
    }
}
