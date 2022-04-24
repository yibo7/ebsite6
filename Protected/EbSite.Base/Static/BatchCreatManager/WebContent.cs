using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Amib.Threading;
using EbSite.BLL;
using NewsContent = EbSite.Entity.NewsContent;

namespace EbSite.Base.Static.BatchCreatManager
{

    public class WebContent : ProgressBase
    {
        private  Guid ModelID = Guid.Empty;
        private int ClassID = 0;
        public WebContent(int _SiteID, Guid Modelid, int _ClassID)
        {
            ModelID = Modelid;
            ClassID = _ClassID;
            ProgressInfo = pgInfo.BackProgressInfo;
            base.SiteID = _SiteID;
            _Intances.Add(this);
        }
        public static WebContent Instance(int _SiteID)
        {
           
            WebContent md = null;
            foreach (WebContent webContent in _Intances)
            {
                if (webContent.SiteID == _SiteID)
                {
                    md = webContent;
                    break;
                }
            }
            return md;
        }
        //private static Guid _modelid = Guid.Empty;
        public static WebContent Instance(int _SiteID, Guid ModelID)
        {
            //_modelid = ModelID;

            WebContent md = null;
            foreach (WebContent webContent in _Intances)
            {
                if (webContent.SiteID == _SiteID && webContent.ModelID == ModelID)
                {
                    md = webContent;
                    break;
                }
            }
            return md;
        }

        private static List<WebContent> _Intances = new List<WebContent>();

        public override void Dispose()
        {
            _Intances = new List<WebContent>();
        }

        //public static WebContent Instance
        //{
        //    get
        //    {
        //        if (_Intance == null)
        //        {
        //            _Intance = new WebContent();
        //        }
        //        return _Intance;
        //    }
        //}


        /// <summary>
        /// 生成内容面页
        /// </summary>
        public override void Star()
        {

            //AllCount = EndID - StarID;
            int i = 1;
            CurrentProgress = 0;

            if (Ids.Count > 0)
            {
                foreach (int id in Ids)
                {
                    MakeOneContent(id, i);
                    i++;
                }
            }

            for (int ContentID = StarID; ContentID <= EndID; ContentID++)
            {

                MakeOneContent(ContentID, i);
                i++;
            }
            ProgressInfo(string.Concat("生成完毕！！"), CurrentProgress);
            //摧毁当前对像 
            //Dispose();

        }

        #region 将生成任务放到线程池中的方法
        public void MakeClassContentToPool(int iClassID, int iSiteID)
        {
            MakeInfo md = new MakeInfo { ClassID = iClassID, SiteID = SiteID };
            IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(MakeClassContentToPoolStart), md);
        }
        public object MakeClassContentToPoolStart(object ClassInfo)
        {
            if (ClassInfo != null)
            {
                MakeInfo md = (MakeInfo)ClassInfo;
                NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(md.ClassID);//2014-2-11 YHL
                List<EbSite.Entity.NewsContent> lst = NewsContentInst.GetListNewOfNewsClass(md.ClassID, 0, false, false, "id", md.SiteID);

                foreach (NewsContent newsContent in lst)
                {
                    Ids.Add(newsContent.ID);
                }
                Star();
            }

            return 1;
        }
        #endregion

        public void MakeOneContent(int ContentID, int i)
        {
            if (ContentID > 0)
            {
                Thread.Sleep(MakeSleep);

                if (!EbSite.Base.AppStartInit.GetNewsContentInst(ModelID, SiteID).Exists(ContentID, SiteID)) //  if (!EbSite.BLL.NewsContent.Exists(ContentID))
                {
                    ProgressInfo(string.Concat("不存在ID为", ContentID, "的记录，跳过..."), CurrentProgress);
                    return;
                }
                OneCreatManager.NewsContent.Instance.ModelID = ModelID;
                OneCreatManager.NewsContent.Instance.ClassID = ClassID;
                OneCreatManager.NewsContent.Instance.ContentID = ContentID;

                string sRz = OneCreatManager.NewsContent.Instance.MakeHtml(base.SiteID);

                CurrentProgress = (i * 100 / AllCount);
                if (!Equals(ProgressInfo, null))
                {
                    ProgressInfo(string.Concat("正在生成内容页", AllCount, "个面页,已经完成", i, "个,当前ID为:", ContentID), CurrentProgress);
                }
                //IIS回收时记录日志用
                CurrentID = ContentID;
                //IIS回收时记录日志用 没有分页，所以不用这个
                //CurrentPageIndex = i;
            }
       
        }
    }

}
