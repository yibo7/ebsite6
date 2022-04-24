using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Amib.Threading;
using EbSite.Control.xsPage;

namespace EbSite.Base.Static.BatchCreatManager
{

    public class Special : ProgressBase
    {
        
        public static Special Instance(int _SiteID)
        {
            Special md = null;
            foreach (Special mdHtml in _Intances)
            {
                if (mdHtml.SiteID == _SiteID)
                {
                    md = mdHtml;
                    break;
                }
            }
            return md;
        }

        private static List<Special> _Intances = new List<Special>();

        public override void Dispose()
        {
            _Intances = new List<Special>();
            //foreach (Special md in _Intances)
            //{
            //    if (md.SiteID == this.SiteID)
            //    {
            //        _Intances.Remove(md);
            //    }
            //}
        }

        public Special(int _SiteID)
        {
           ProgressInfo =  pgInfo.BackProgressInfo;
            base.SiteID = _SiteID;
            _Intances.Add(this);
        }
        protected int iSearchCount(int iSpecialD)
        {

            return EbSite.BLL.SpecialNews.GetCount(iSpecialD);

        }
        private int PageSize
        {
            get
            {
                return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeSpecail;
            }

        }
        public override void Star()
        {
            CurrentProgress = 0; 
            if(Ids.Count>0)
            {
                foreach (int id in Ids)
                {
                    CurrentPageIndex = 0;
                    MakeOneClass(id);
                }
            }
            else  //全部生成
            {

                for (int iSpecialID = StarID; iSpecialID <= EndID; iSpecialID++)
                {
                    MakeOneClass(iSpecialID);
                }
            }
            ProgressInfo(string.Concat("生成完毕！！"), CurrentProgress);
            //摧毁当前对像 
            Dispose();
        }
        #region 将生成任务放到线程池中的方法
        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 定义一个委托，让外部能够及时向页面展示当前生成信息
        /// </summary>
        /// <param name="Info">当前生成信息</param>
        /// <param name="CurrentProgress">当前生成进度</param>
        public delegate void dlgAllProgressInfo(string Info, int CurrentProgress);
        public dlgAllProgressInfo AllProgressInfo;
        public void MakeOneToPool(int iClassID)
        {
            IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(MakeOneToPoolStart), iClassID);
        }
        public object MakeOneToPoolStart(object iClassID)
        {
            if (iClassID != null)
            {
                MakeOneClass(int.Parse(iClassID.ToString()));
            }

            return 1;
        }
        public void MakeSubToPool(int iClassID, int SiteID)
        {
            MakeInfo md = new MakeInfo { ClassID = iClassID, SiteID = SiteID };
            IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(MakeSubToPoolStart), md);
        }
        public object MakeSubToPoolStart(object ClassInfo)
        {
            if (ClassInfo != null)
            {
                MakeInfo md = (MakeInfo)ClassInfo;
                string IDs = EbSite.BLL.SpecialClass.GetSubIDs(md.ClassID, md.SiteID);
                string[] aID = IDs.Split(',');
                for (int i = 0; i < aID.Length; i++)
                {
                    int iClassID = int.Parse(aID[i]);
                    int iProgress = (i * 100 / aID.Length);
                    AllProgressInfo(string.Concat("专题ID为:", iClassID), iProgress);
                    MakeOneClass(iClassID);
                }



            }

            return 1;
        }
        #endregion
        /// <summary>
        /// 重写生成办法
        /// </summary>
        /// <returns></returns>
        public  void MakeOneClass(int SpecialID)
        {
            if (!EbSite.BLL.SpecialClass.Exists(SpecialID))
            {
                ProgressInfo(string.Concat("专题ID为", SpecialID, " 不存在"), CurrentProgress);
                return;
            }
            //IIS回收时记录日志用
            CurrentID = SpecialID;

            cAspxPages pgJzList = new cAspxPages();
                pgJzList.iTotalCount = iSearchCount(SpecialID);             //记录总数
                pgJzList.iPageSize = PageSize;                 //一首显示多少条
                int iCount = pgJzList.iPageNum;

                ProgressInfo(string.Concat("正在分成专题分页,专题ID:", SpecialID), 0);
                int j = 0;
            int StarPageIndex = CurrentPageIndex;
            for (int i = StarPageIndex; i <= iCount; i++)
                {
                    
                    //生成
                    OneCreatManager.Special.Instance.iPageIndex = i;
                    OneCreatManager.Special.Instance.iSpecialD = SpecialID;
                    OneCreatManager.Special.Instance.MakeHtml(base.SiteID);

                    CurrentProgress = (i * 100 / iCount);
                    ProgressInfo(string.Concat("共有专题", AllCount, "个,当前专题ID：", SpecialID, "，共生成", iCount, "个分页，正在生成", (i + 1), "个。"), CurrentProgress);
                    j++;
                    //IIS回收时记录日志用
                    CurrentPageIndex = i;
                }
                ProgressInfo("专题生成成功,成功" + j + "个,<a >失败" + (iCount - j) + "个</a>.&nbsp;<a  href=\"javascript:history.back();\">返回</a>", 100);
           
        }
    }
    
}
