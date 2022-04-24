//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using EbSite.Core.STSdbUtils;
//using STSdb4.Database;

//namespace EbSite.Core.EbCache
//{
//    public class CacheBll : BllBase<CacheEntity, string>
//    {
//        static public readonly CacheBll Instance = new CacheBll();
//        override protected string TableName
//        {
//            get
//            {
//                return "EBCache";
//            }
//        }

//        public void ClearByClass(string ClassName)
//        {
//            DeleteTable();

//        }

//    }
//}
