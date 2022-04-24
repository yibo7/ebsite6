
using System;
using System.Collections.Generic;
using System.Threading;
using EbSite.Base.Configs.HtmlConfigs;

namespace EbSite.Base.Static.BatchCreatManager
{
    public class MakeUtils
    {
        public static string GetProgressPageLink_Make(HtmlMakeType hmt)
        {
            int HtmlType = (int)hmt;
            return string.Concat("MakeProgress.aspx?mat=1&t=", HtmlType);
        }
        public static string GetProgressPageLink_Make(HtmlMakeType hmt, Guid ModelID)
        {
            int HtmlType = (int)hmt;
            return string.Concat("MakeProgress.aspx?mat=1&t=", HtmlType, "&modelid=",ModelID);
        }
        public static string GetProgressPageLink_Show(HtmlMakeType hmt)
        {
            int HtmlType = (int)hmt;
            return string.Concat("MakeProgress.aspx?mat=2&t=", HtmlType);
        }
        public static ProgressBase GetProgressObj(int GetMakeType, int SiteID)
        {
            HtmlMakeType ht = (HtmlMakeType)GetMakeType;
            return GetProgressObj(ht, SiteID, Guid.Empty);
        }
        public static ProgressBase GetProgressObj(int GetMakeType,int SiteID,Guid ModleID)
        {
           HtmlMakeType ht =  (HtmlMakeType) GetMakeType;
           return GetProgressObj(ht, SiteID,ModleID);
        }
        ///// <summary>
        ///// 生成未完成的任务
        ///// </summary>
        //public static void MakeUndone()
        //{
        //    List<MakeHtmlInfo> lst = ConfigsControl.Instance.HtmlUndoneMaked;
        //    foreach (MakeHtmlInfo model in lst)
        //    {
        //        ProgressBase pb = GetProgressObj(model.MakeType);
        //        pb.StarID = model.StarID;
        //        pb.EndID = model.EndID;
        //        pb.CurrentPageIndex = model.CurrentPageIndex;
        //       pb.CurrentThread = new Thread(pb.Star);
        //       pb.CurrentThread.Start();
        //    }
        //    //清空未完成日志
        //    Base.Configs.HtmlConfigs.ConfigsControl.Instance.HtmlUndoneMaked = null;
        //    Base.Configs.HtmlConfigs.ConfigsControl.SaveConfig();
        //}

        //public static void HtmlMakingLog()
        //{
        //    List<MakeHtmlInfo> lst = new List<MakeHtmlInfo>();

        //    MakeHtmlInfo model;

        //    if (WebClass.Instance.IsMakeing)
        //    {
        //        model = new MakeHtmlInfo();
        //        model.MakeType = HtmlMakeType.WebClass;
        //        model.StarID = WebClass.Instance.CurrentID;
        //        model.EndID = WebClass.Instance.EndID;
        //        model.CurrentPageIndex = WebClass.Instance.CurrentPageIndex;
        //        lst.Add(model);
        //    }
        //    if (WebContent.Instance.IsMakeing)
        //    {
        //        model = new MakeHtmlInfo();
        //        model.MakeType = HtmlMakeType.WebContent;
        //        model.StarID = WebContent.Instance.CurrentID;
        //        model.EndID = WebContent.Instance.EndID;
        //        model.CurrentPageIndex = WebContent.Instance.CurrentPageIndex;
        //        lst.Add(model);
        //    }
        //    if (TagList.Instance.IsMakeing)
        //    {
        //        model = new MakeHtmlInfo();
        //        model.MakeType = HtmlMakeType.TagList;
        //        model.StarID = TagList.Instance.CurrentID;
        //        model.EndID = TagList.Instance.EndID;
        //        model.CurrentPageIndex = TagList.Instance.CurrentPageIndex;
        //        lst.Add(model);
        //    }
        //    if (TagSearchList.Instance.IsMakeing)
        //    {
        //        model = new MakeHtmlInfo();
        //        model.MakeType = HtmlMakeType.TagSearchList;
        //        model.StarID = TagSearchList.Instance.CurrentID;
        //        model.EndID = TagSearchList.Instance.EndID;
        //        model.CurrentPageIndex = TagSearchList.Instance.CurrentPageIndex;
        //        lst.Add(model);
        //    }
        //    if (Special.Instance.IsMakeing)
        //    {
        //        model = new MakeHtmlInfo();
        //        model.MakeType = HtmlMakeType.Special;
        //        model.StarID = Special.Instance.CurrentID;
        //        model.EndID = Special.Instance.EndID;
        //        model.CurrentPageIndex = Special.Instance.CurrentPageIndex;
        //        lst.Add(model);
        //    }
        //    Base.Configs.HtmlConfigs.ConfigsControl.Instance.HtmlUndoneMaked = lst;
        //    Base.Configs.HtmlConfigs.ConfigsControl.SaveConfig();
        //}

        public static ProgressBase GetProgressObj(HtmlMakeType GetMakeType,int SiteID,Guid ModelID)
        {

            ProgressBase pb = null;
            switch (GetMakeType)
            {
                case HtmlMakeType.WebContent://生成内容页
                    pb = BatchCreatManager.WebContent.Instance(SiteID,ModelID);
                    //pb = new Core.Static.BatchCreatManager.WebContent(SiteID);
                    break;
                case HtmlMakeType.WebClass://生成列表页
                    //pb = new Core.Static.BatchCreatManager.WebClass(SiteID);
                    pb = BatchCreatManager.WebClass.Instance(SiteID);
                    break;
                case HtmlMakeType.TagList://生成标签列表页
                    //pb = new Core.Static.BatchCreatManager.TagList(SiteID);
                    pb = BatchCreatManager.TagList.Instance(SiteID);
                    break;
                case HtmlMakeType.TagSearchList://生成标签搜索页
                    //pb = new Core.Static.BatchCreatManager.TagSearchList(SiteID);
                    pb = BatchCreatManager.TagSearchList.Instance(SiteID);
                    break;
                case HtmlMakeType.Special://生成专题页
                    //pb = new Core.Static.BatchCreatManager.Special(SiteID);
                    pb =  BatchCreatManager.Special.Instance(SiteID);
                    break;
                default:
                    break;

            }
            return pb;

        }
    }
    public enum HtmlMakeType 
    {
        /// <summary>
        /// 生成类型为分类页
        /// </summary>
        WebClass = 1,
        /// <summary>
        /// 生成类型为内容页
        /// </summary>
        WebContent = 2,
        /// <summary>
        /// 专辑页
        /// </summary>
        Special = 3,
        /// <summary>
        /// 标签列表页
        /// </summary>
        TagList = 4,
        /// <summary>
        /// 标签搜索页
        /// </summary>
        TagSearchList = 5

    }
}
