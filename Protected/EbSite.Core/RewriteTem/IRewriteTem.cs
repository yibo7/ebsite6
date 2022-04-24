//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Web;

//namespace EbSite.Core.RewriteTem
//{
//    public abstract class IRewriteTem
//    {
        
//        public HttpContext httpContext
//        {
//            get
//            {
//                return HttpContext.Current;
//            }
//            //set
//            //{
//            //    _httpContext = value;
//            //}
//        }
//        /// <summary>
//        /// 首页
//        /// </summary>
//        /// <returns></returns>
//        public abstract string GetIndexTemPath();
//        /// <summary>
//        /// 分类页
//        /// </summary>
//        /// <returns></returns>
//        public abstract string GetClassTemPath();
//        /// <summary>
//        /// 内容页
//        /// </summary>
//        /// <returns></returns>
//        public abstract string GetContentTemPath();
//        /// <summary>
//        /// 专题页
//        /// </summary>
//        /// <returns></returns>
//        public abstract string GetSpecialTemPath(); 
//        /// <summary>
//        /// 标签列表页
//        /// </summary>
//        /// <returns></returns>
//        public abstract string GetTagsListTemPath();
//        /// <summary>
//        /// 标签搜索页
//        /// </summary>
//        /// <returns></returns>
//        public abstract string GetTagsSearchTemPath(); 
//    }
//}
