using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EbSite.Base.Static.BatchCreatManager
{
    public abstract class ProgressBase
    {
        /// <summary>
        /// 定义一个全局式缓存处理业务对象
        /// </summary>
        //public static CacheManager CacheApp;
        //const double CacheDuration = 120.0;//
        //private static readonly string[] MasterCacheKeyArray = { "StaticHtml" };
        //public ProgressBase()
        //{
        //    CacheApp = new CacheManager(CacheDuration, MasterCacheKeyArray);
        //}
        private int _SiteID = 1;
        public int SiteID
        {
            get
            {
                return _SiteID;
            }
            set
            {
                _SiteID = value;
            }
        }
        /// <summary>
        /// 用来开启一个线程来执行生成动作，从而异步执行生成
        /// </summary>
        public  Thread CurrentThread;
        /// <summary>
        /// 创建这个类用来代理输出异步进度信息
        /// </summary>
       public ProgressInfo pgInfo = new ProgressInfo();

       protected List<long> Ids = new List<long>();

        /// <summary>
        /// 如果不是全部生成时可以使用此办法，生成指定ID列表
        /// </summary>
        /// <param name="ID"></param>
        public void AddIDs(int ID)
        {
            Ids.Add(ID);
        }

        private int _CurrentProgress = -1;
        /// <summary>
        /// 当前生成进度
        /// </summary>
        public int CurrentProgress
        {
            get
            {
                return _CurrentProgress;
            }
            set
            {
                _CurrentProgress = value;
            }
        }
        /// <summary>
        /// 是否正在生成
        /// </summary>
        public bool IsMakeing
        {
            get
            {
                if (CurrentProgress > -1 && CurrentProgress < 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //private int _AllCount;
        /// <summary>
        /// 总共要生成多少条
        /// </summary>
        protected int AllCount
        {
            get
            {
                int c = 1;
                if (Ids.Count > 0)
                {
                    c =  Ids.Count;
                }
                else
                {
                    if (EndID > StarID)
                        c =  EndID - StarID;
                }
                return c;
            }
            
        }

        
        protected int MakeSleep
        {
            get
            {
                return Base.Configs.HtmlConfigs.ConfigsControl.Instance.CreateSleep;
            }
        }
        private int _StarID;
        public int StarID
        {
            get
            {
                return _StarID;
            }
            set
            {
                _StarID = value;
            }
        }
        private int _EndID;
        public int EndID
        {
            get
            {
                return _EndID;
            }
            set
            {
                _EndID = value;
            }
        }

        //////////////////////////////////记录日志用//////////////////////////
        /// <summary>
        /// 
        /// </summary>
        private int _GetCurrentID;
        /// <summary>
        /// 获取当前正在生成的ID
        /// </summary>
        public int CurrentID
        {
            get
            {
                return _GetCurrentID;
            }
            set
            {
                _GetCurrentID = value;
            }
        }
        private int _CurrentPageIndex  =1;
        /// <summary>
        /// 获取当前页码 IIS回收时记录日志用 像内容页这样的没有分页用不到
        /// </summary>
        public int CurrentPageIndex
        {
            get
            {
                return _CurrentPageIndex;
            }
            set
            {
                _CurrentPageIndex = value;
            }
        }
        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 定义一个委托，让外部能够及时向页面展示当前生成信息
        /// </summary>
        /// <param name="Info">当前生成信息</param>
        /// <param name="CurrentProgress">当前生成进度</param>
        public delegate void dlgProgressInfo(string Info, int CurrentProgress);
        public dlgProgressInfo ProgressInfo;

        //需要重写的办法
        public abstract void Star();
        public abstract void Dispose();
    }
}
