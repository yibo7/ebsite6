using System.Collections.Generic;
using System.Linq;
using EbSite.BLL;
using EbSite.Control.xsPage;

namespace EbSite.Base.Static.BatchCreatManager
{
    public class TagList : ProgressBase
    {
        public static TagList Instance(int _SiteID)
        {
            //return _Intances.Single(d => d.SiteID == _SiteID);
            TagList md = null;
            foreach (TagList mdHtml in _Intances)
            {
                if (mdHtml.SiteID == _SiteID)
                {
                    md = mdHtml;
                    break;
                }
            }
            return md;
        }

        private static List<TagList> _Intances = new List<TagList>();

        public override void Dispose()
        {
            _Intances = new List<TagList>();
        }
        public TagList(int _SiteID)
        {
            ProgressInfo = pgInfo.BackProgressInfo;
            base.SiteID = _SiteID;
            _Intances.Add(this);
        }
        //private static TagList _Intance = null;

        //public static TagList Instance
        //{
        //    get
        //    {
        //        if (_Intance == null)
        //        {
        //            _Intance = new TagList();
        //        }
        //        return _Intance;
        //    }
        //}
        //protected int iSearchCount
        //{
        //    get
        //    {
        //        return  
        //    }

        //}
        private int PageSize
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeTagList;
            }

        }
        //public override void Dispose()
        //{
        //    //_Intance = null;
        //}
        public override void Star()
        {
            CurrentProgress = 0;
            cAspxPages pgJzList = new cAspxPages();
            pgJzList.iTotalCount = TagKey.GetCount(SiteID);             //记录总数
            pgJzList.iPageSize = PageSize;                 //一首显示多少条
            int iCount = pgJzList.iPageNum;

            ProgressInfo("正在标签列表页", 0);
            int j = 0;
            int StarPageIndex = CurrentPageIndex;
            for (int i = StarPageIndex; i <= iCount; i++)
            {
                OneCreatManager.TagList.Instance.iPageIndex = i;
                OneCreatManager.TagList.Instance.MakeHtml(base.SiteID);
                CurrentProgress = (i * 100 / iCount);
                ProgressInfo(string.Concat("共有标签", AllCount, "个,共生成" + iCount + "个分页，正在生成" + (i + 1) + "个。"), ((i + 1) * 100 / iCount));
                j++;
                //IIS回收时记录日志用
                CurrentPageIndex = i;
                StarPageIndex++;
            }
            ProgressInfo("生成完毕,成功" + j + "个,<a >失败" + (iCount - j) + "个</a>.&nbsp;<a  href=\"javascript:history.back();\">返回</a>", 100);

            //摧毁当前对像 
            Dispose();
        }
    }
}
