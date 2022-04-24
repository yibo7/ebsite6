using System;
using System.Threading;
using Amib.Threading;

namespace EbSite.Core
{
    public class cThreadPool
    {

        public static Thread myThread;
        public static SmartThreadPool smartThreadPool = new SmartThreadPool(2 * 60 * 1000, 5, 1);



        #region //获取最大线程数  GetMaxThreadCount()
        public static int GetMaxThreadCount()
        {
            return smartThreadPool.MaxThreads;
        }
        #endregion

        #region  //获取等待的任务数量
        public static int GetWaitingCallbacks()
        {
            return smartThreadPool.WaitingCallbacks;
        }
        #endregion

        #region // 获取最小线程数  GetMinThreadCount()
        public static int GetMinThreadCount()
        {
            return smartThreadPool.MinThreads;
        }
        #endregion

        #region //活动线程数 GetActiveThreadCount()
        public static int GetActiveThreadCount()
        {
            return smartThreadPool.ActiveThreads;
        }
        #endregion

        #region //用户线程数 GetInUseThreadCount()
        public static int GetInUseThreadCount()
        {
            return smartThreadPool.InUseThreads;
        }
        #endregion
    }
}
