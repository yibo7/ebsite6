//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Web;

//namespace EbSite.Core.RewriteTem
//{
//    public class AspxTemPath : IRewriteTem
//    {
        
//        /// <summary>
//        /// 首页
//        /// </summary>
//        /// <returns></returns>
//        public override string GetIndexTemPath()
//        {
//            Guid IndexTemID = Configs.SysConfigs.ConfigsControl.Instance.IndexTemID;
//            return BLL.Templates.GetModelByCache(IndexTemID).TemPath;
//        }
//        /// <summary>
//        /// 分类页
//        /// </summary>
//        /// <returns></returns>
//        public override string GetClassTemPath()
//        {
//            Model.Templates tm = null;
//            if (!string.IsNullOrEmpty(httpContext.Request["cid"]))
//            {
//                int cid = int.Parse(httpContext.Request["cid"]);

//                Model.NewsClass md = BLL.NewsClass.GetModelByCache(cid);

//                if (!Equals(md, null))
//                {
//                    tm =  BLL.Templates.GetModelByCache(md.ClassTemID);
//                }
//            }
//            if(!Equals(tm,null))
//                return tm.TemPath;
//            else
//            {
//                return string.Empty;
//            }
//        }
//        /// <summary>
//        /// 内容页
//        /// </summary>
//        /// <returns></returns>
//        public override string GetContentTemPath()
//        {
//            Model.Templates tm = null;
//            if (!string.IsNullOrEmpty(httpContext.Request["id"]))
//            {
//                int id = int.Parse(httpContext.Request["id"]);

//                //if (!BLL.NewsContent.Exists(id))
//                //    return;

//                Model.NewsContent mdContent = BLL.NewsContent.GetModelByCache(id);

//                if (!Equals(mdContent, null))
//                {
//                    //查询当前内容所在的分类
//                    Model.NewsClass mdClass = BLL.NewsClass.GetModelByCache(mdContent.ClassID);

//                    tm = BLL.Templates.GetModelByCache(mdClass.ContentTemID);
//                }
//            }
//            if (!Equals(tm, null))
//                return tm.TemPath;
//            else
//            {
//                return string.Empty;
//            }
//        }
//        /// <summary>
//        /// 专题页
//        /// </summary>
//        /// <returns></returns>
//        public override string GetSpecialTemPath()
//        {
//            return null;
//        }
//        /// <summary>
//        /// 标签列表页
//        /// </summary>
//        /// <returns></returns>
//        public override string GetTagsListTemPath()
//        {
//            return null;
//        }
//        /// <summary>
//        /// 标签搜索页
//        /// </summary>
//        /// <returns></returns>
//        public override string GetTagsSearchTemPath()
//        {
//            return null;
//        }
//    }
//}
