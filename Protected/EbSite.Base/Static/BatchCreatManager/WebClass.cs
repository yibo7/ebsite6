using System.Collections.Generic;
using System.Linq;
using Amib.Threading;
using EbSite.BLL;
using EbSite.Control.xsPage;


namespace EbSite.Base.Static.BatchCreatManager
{
    public class WebClass : ProgressBase
    {

        public static WebClass Instance(int _SiteID)
        {
            WebClass md = null;
            foreach (WebClass mdHtml in _Intances)
            {
                if (mdHtml.SiteID == _SiteID)
                {
                    md = mdHtml;
                    break;
                }
            }
            return md;
        }

        private static List<WebClass> _Intances = new List<WebClass>();

        public override void Dispose()
        {
            _Intances = new List<WebClass>();
            //foreach (WebClass md in _Intances)
            //{
            //    if (md.SiteID == this.SiteID)
            //    {
            //        _Intances.Remove(md);
            //    }
            //}
        }

        //private static WebClass _Intance = null;

        //public static WebClass Instance
        //{
        //    get
        //    {
        //        if (_Intance == null)
        //        {
        //            _Intance = new WebClass();
        //        }
        //        return _Intance;
        //    }
        //}
        //public override void Dispose()
        //{

        //    //_Intance = null;
        //}


        public WebClass(int _SiteID)
        {
           ProgressInfo =  pgInfo.BackProgressInfo;
            base.SiteID = _SiteID;
            _Intances.Add(this);
        }
        protected int iSearchCount(int iClassID,int iSiteID)
        {
            NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(iClassID);//2014-2-11 YHL
            //获取当前分类的记录总数
            int iClassContentCount = NewsContentInst.GetCountOfClassid(iClassID, iSiteID);
            if (iClassContentCount < 1) //如果当前分类没有内容，获取子分类下的内容
            {
                //很占用内存，有等优化
                string SubIds = EbSite.BLL.NewsClass.GetSubIDs(iClassID, iSiteID);
                if (!string.IsNullOrEmpty(SubIds))
                {
                    string sWhere = string.Concat("  ClassID in(", SubIds, ")");

                    iClassContentCount = NewsContentInst.GetCount(sWhere, iSiteID);
                }
            }
            return iClassContentCount;
            //return BLL.NewsContent.GetCountOfClassid(iClassID);

        }
        private int PageSize
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeClass;
            }

        }
        public override void Star()
        {
            CurrentProgress = 0; 
            if(Ids.Count>0)
            {
                //AllCount = Ids.Count;
                foreach (int id in Ids)
                {
                    MakeOneClass(id);
                }
            }
            else  //全部生成
            {
                for (int iClassID = StarID; iClassID <= EndID; iClassID++)
                {
                    CurrentPageIndex = 0;
                    MakeOneClass(iClassID);
                }
            }
            ProgressInfo(string.Concat("生成完毕！！"), CurrentProgress);
            //摧毁当前对像 
            Dispose();
        }
        #region 将生成任务放到线程池中的方法
        public void MakeOneClassToPool(int iClassID)
        {
            IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(MakeOneClassToPoolStart), iClassID);
        }
        public object MakeOneClassToPoolStart(object iClassID)
        {
            if (iClassID != null)
            {
                MakeOneClass(int.Parse(iClassID.ToString()));
            }

            return 1;
        }
        public void MakeSubClassToPool(int iClassID,int SiteID)
        {
            MakeInfo md = new MakeInfo { ClassID = iClassID, SiteID = SiteID };
            IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(MakeSubClassToPoolStart), md);
        }
        public object MakeSubClassToPoolStart(object ClassInfo)
        {
            if (ClassInfo != null)
            {
                MakeInfo md = (MakeInfo) ClassInfo;
                //int pcid = int.Parse(iClassID.ToString());
                string IDs = EbSite.BLL.NewsClass.GetSubIDs(md.ClassID, md.SiteID);
                string[] aID = IDs.Split(',');
                for (int i = 0; i < aID.Length; i++)
                {
                    int iClassID = int.Parse(aID[i]);
                    int iProgress = (i * 100 / aID.Length);
                    AllProgressInfo(string.Concat("分类ID为:", iClassID), iProgress);
                    MakeOneClass(iClassID);
                }
                

                
            }

            return 1;
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 定义一个委托，让外部能够及时向页面展示当前生成信息
        /// </summary>
        /// <param name="Info">当前生成信息</param>
        /// <param name="CurrentProgress">当前生成进度</param>
        public delegate void dlgAllProgressInfo(string Info, int CurrentProgress);
        public dlgAllProgressInfo AllProgressInfo;
        /// <summary>
        /// 重写生成办法
        /// </summary>
        /// <returns></returns>
        public  void MakeOneClass(int iClassID)
        {
            if (!EbSite.BLL.NewsClass.Exists(iClassID))
            {
                ProgressInfo(string.Concat("分类ID为", iClassID, " 不存在"), CurrentProgress);
                return;
            }
            //IIS回收时记录日志用
            CurrentID = iClassID;

            cAspxPages pgJzList = new cAspxPages();
                pgJzList.iTotalCount = iSearchCount(iClassID,SiteID);             //记录总数
                pgJzList.iPageSize = PageSize;                 //一首显示多少条
                int iCount = pgJzList.iPageNum;

                ProgressInfo(string.Concat("正在生成分类分页,分类ID:", iClassID), 0);
                int j = 0;
            int StarPageIndex = CurrentPageIndex;
            for (int i = StarPageIndex; i <= iCount; i++)
                {
                    
                    //生成
                    OneCreatManager.NewsClass.Instance.iPageIndex = i;
                    OneCreatManager.NewsClass.Instance.iClassID = iClassID;
                    OneCreatManager.NewsClass.Instance.MakeHtml(base.SiteID);

                    CurrentProgress = (i * 100 / iCount);
                    ProgressInfo(string.Concat("共有分类", AllCount, "个,当前分类ID：", iClassID, "，共生成", iCount, "个分页，正在生成", (i + 1), "个。"), CurrentProgress);
                    j++;
                    //IIS回收时记录日志用
                    CurrentPageIndex = i;
                }
                ProgressInfo("分类生成成功,成功" + j + "个,<a >失败" + (iCount - j) + "个</a>.&nbsp;<a  href=\"javascript:history.back();\">返回</a>", 100);
           
        }
    }
    /// <summary>
    /// 辅助线程池参数传递
    /// </summary>
    public class MakeInfo
    {
        public int ClassID { get; set; }
        public int SiteID { get; set; }
    }

}
