using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Amib.Threading;
namespace EbSite.Core.ThreadPool
{
    public class ThreadPoolManager
    {
        public static SmartThreadPool stThreadPool = new SmartThreadPool(2 * 60 * 1000, 5, 1);

        static ThreadPoolManager()
        {

        }

        public static IWorkItemsGroup aGrouppool
        {
            get
            {
                return stThreadPool.CreateWorkItemsGroup(int.MaxValue);
            }
        }


        #region //获取最大线程数  GetMaxThreadCount()
        public static int GetMaxThreadCount()
        {
            return stThreadPool.MaxThreads;
        }
        #endregion

        #region  //获取等待的任务数量
        public static int GetWaitingCallbacks()
        {
            return stThreadPool.WaitingCallbacks;
        }
        #endregion

        #region // 获取最小线程数  GetMinThreadCount()
        public static int GetMinThreadCount()
        {
            return stThreadPool.MinThreads;
        }
        #endregion

        #region //活动线程数 GetActiveThreadCount()
        public static int GetActiveThreadCount()
        {
            return stThreadPool.ActiveThreads;
        }
        #endregion

        #region //用户线程数 GetInUseThreadCount()
        public static int GetInUseThreadCount()
        {
            return stThreadPool.InUseThreads;
        }
        #endregion

    }
}
