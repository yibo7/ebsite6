//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace EbSite.Core.RewriteTem
//{
//    public class AutoHtmTemPath : IRewriteTem
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
//            string sPath = string.Empty;
//            string url = httpContext.Request.Path;
//            url = url.Replace(EbSite.Base.AppStartInit.IISPath, "");
//            Match mc = Regex.Match(url, string.Concat("([0-9]+)-([0-9]+)", GetLink.HrefFactory.GetInstance().ClassLink));
//            int ClassId = 0;
//            int PageIndex = 0;
//            if (mc.Success)
//            {
//                ClassId = int.Parse(mc.Groups[1].Value);
//                PageIndex = int.Parse(mc.Groups[2].Value);
//            }
//            Model.NewsClass md = BLL.NewsClass.GetModelByCache(ClassId);
//            Model.Templates tm = null;

//            if (!Equals(md, null))
//            {
//                tm = BLL.Templates.GetModelByCache(md.ClassTemID);
//            }
//            if (!Equals(tm, null))
//            {
//                sPath = string.Concat(tm.TemPath, "?cid=", ClassId, "&p=", PageIndex);
//            }

//            return sPath;
//        }
//        /// <summary>
//        /// 内容页
//        /// </summary>
//        /// <returns></returns>
//        public override string GetContentTemPath()
//        {
//            string sPath = string.Empty;
//            string url = httpContext.Request.Path;
//            url = url.Replace(EbSite.Base.AppStartInit.IISPath, "");
//            Match mc = Regex.Match(url, string.Concat("([0-9]+)", GetLink.HrefFactory.GetInstance().ContentLink));
//            int ContentId = 0;
//            if (mc.Success)
//            {
//                ContentId = int.Parse(mc.Groups[1].Value);
//            }
//            Model.NewsContent mdContent = BLL.NewsContent.GetModelByCache(ContentId);
//            Model.Templates tm = null;

//            if (!Equals(mdContent, null))
//            {
//                Model.NewsClass mdClass = BLL.NewsClass.GetModelByCache(mdContent.ClassID);
//                tm = BLL.Templates.GetModelByCache(mdClass.ContentTemID);
//            }
//            if (!Equals(tm, null))
//            {
//                sPath = string.Concat(tm.TemPath, "?id=", ContentId);
//            }

//            return sPath;
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
//            string sPath = string.Empty;
//            string url = httpContext.Request.Path;
//            url = url.Replace(EbSite.Base.AppStartInit.IISPath, "");
//            if (url.IndexOf("/") == -1) //只对一级地址处理
//            {
//                Match mc = Regex.Match(url, string.Concat("([0-9]+)", GetLink.HrefFactory.GetInstance().TaglistLink));
//                int TagPageIndex = 1;
//                if (mc.Success)
//                {
//                    TagPageIndex = int.Parse(mc.Groups[1].Value);
//                }
//                sPath = GetLink.HrefFactory.GetAspxInstance().TagsList(TagPageIndex).Replace(EbSite.Base.AppStartInit.IISPath, "");
//            }
//            return sPath;
//        }
//        /// <summary>
//        /// 标签搜索页
//        /// </summary>
//        /// <returns></returns>
//        public override string GetTagsSearchTemPath()
//        {
//            string sPath = string.Empty;
//            string url = httpContext.Request.Path;
//            Match mc = Regex.Match(url, string.Concat("([0-9]+)-([0-9]+)", GetLink.HrefFactory.GetInstance().TagsSearchListLink));
//            int TagPageIndex = 1;
//            int TagID = 1;
//            if (mc.Success)
//            {
//                TagID = int.Parse(mc.Groups[1].Value);
//                TagPageIndex = int.Parse(mc.Groups[2].Value);
//            }
//            sPath = GetLink.HrefFactory.GetAspxInstance().TagsSearchList(TagID, TagPageIndex).Replace(EbSite.Base.AppStartInit.IISPath, "");

//            return sPath;
//        }
//    }
//}
