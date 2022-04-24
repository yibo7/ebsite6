
using System.Collections.Generic;
using System.Linq;
using EbSite.Control.xsPage;

namespace EbSite.Base.Static.BatchCreatManager
{
    public class TagSearchList : ProgressBase
    {
        public static TagSearchList Instance(int _SiteID)
        {
            TagSearchList md = null;
            foreach (TagSearchList mdHtml in _Intances)
            {
                if (mdHtml.SiteID == _SiteID)
                {
                    md = mdHtml;
                    break;
                }
            }
            return md;
        }

        private static List<TagSearchList> _Intances = new List<TagSearchList>();

        public override void Dispose()
        {
            _Intances = new List<TagSearchList>();
        }
        public TagSearchList(int _SiteID)
        {
           ProgressInfo =  pgInfo.BackProgressInfo;
            base.SiteID = _SiteID;
            _Intances.Add(this);
        }
        //private static TagSearchList _Intance = null;

        //public static TagSearchList Instance
        //{
        //    get
        //    {
        //        if (_Intance == null)
        //        {
        //            _Intance = new TagSearchList();
        //        }
        //        return _Intance;
        //    }
        //}
        //public override void Dispose()
        //{
        //    //_Intance = null;
        //}
        private int PageSize
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeTagValue;
            }

        }
        public override void Star()
        {
            //CurrentProgress = 0;

            //for (int TagID = StarID; TagID <= EndID; TagID++)
            //{
                
            //}
            //ProgressInfo(string.Concat("生成完毕！！"), CurrentProgress);
            ////摧毁当前对像 
            //Dispose();

            CurrentProgress = 0;
            if (Ids.Count > 0)
            {
                //AllCount = Ids.Count;
                foreach (int id in Ids)
                {
                    MakeOne(id);
                }
            }
            else  //全部生成
            {
                for (int TagID = StarID; TagID <= EndID; TagID++)
                {
                    CurrentPageIndex = 0;
                    MakeOne(TagID);
                }
            }
            ProgressInfo(string.Concat("生成完毕！！"), CurrentProgress);
            //摧毁当前对像 
            Dispose();
            
        }
        public void MakeOne(int TagID)
        {
            CurrentPageIndex = 1;
            if (!EbSite.BLL.TagKey.Exists(TagID))
            {
                ProgressInfo(string.Concat("标签ID为", TagID, " 不存在"), CurrentProgress);
                //StarID++;
                return;
            }

            //IIS回收时记录日志用
            CurrentID = TagID;
            int iSearchCount = 0;
            EbSite.Entity.TagKey TagModel = EbSite.BLL.TagKey.GetModel(TagID);
            if (!Equals(TagModel, null))
                iSearchCount = TagModel.Num;// EbSite.BLL.NewsContent.GetCountByTagID(TagID, SiteID);
           
            cAspxPages pgJzList = new cAspxPages();
            pgJzList.iTotalCount = iSearchCount;           //记录总数
            pgJzList.iPageSize = PageSize;                 //一首显示多少条
            int iCount = pgJzList.iPageNum;

            int j = 0;
            int StarPageIndex = CurrentPageIndex;
            for (int i = StarPageIndex; i <= iCount; i++)
            {
                OneCreatManager.TagSearchList.Instance.iPageIndex = i;
                OneCreatManager.TagSearchList.Instance.TagID = TagID;
                OneCreatManager.TagSearchList.Instance.MakeHtml(base.SiteID);
                CurrentProgress = (i * 100 / iCount);
                ProgressInfo(string.Concat("共有标签", AllCount, "个,当前标签ID为", TagID, " 共生成", iCount, "个分页，正在生成", (i + 1), "个。"), CurrentProgress);
                j++;

                //IIS回收时记录日志用
                CurrentPageIndex = i;
            }
        }


    }
}
