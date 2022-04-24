using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amib.Threading;

namespace EbSite.Base
{
    public class ThreadPoolManager
    {
        private static SmartThreadPool _instance;


        public static SmartThreadPool Instance
        {
            get
            {
                if (_instance == null)
                {
                    //return new Host(); //暂时这样
                    throw new InvalidOperationException("SmartThreadPool编程池未实例化!");
                }
                return _instance;
            }
            set { _instance = value; }
        }

        static ThreadPoolManager()
        {

        }

        public static IWorkItemsGroup aGrouppool
        {
            get
            {
                return Instance.CreateWorkItemsGroup(int.MaxValue);
            }
        }
        public static void Init(int MaxThread)
        {
            _instance = new SmartThreadPool(2 * 60 * 1000, MaxThread, 1);
        }

        #region //获取最大线程数  GetMaxThreadCount()
        public static int GetMaxThreadCount()
        {
            return Instance.MaxThreads;
        }
        #endregion

        #region  //获取等待的任务数量
        public static int GetWaitingCallbacks()
        {
            return Instance.WaitingCallbacks;
        }
        #endregion

        #region // 获取最小线程数  GetMinThreadCount()
        public static int GetMinThreadCount()
        {
            return Instance.MinThreads;
        }
        #endregion

        #region //活动线程数 GetActiveThreadCount()
        public static int GetActiveThreadCount()
        {
            return Instance.ActiveThreads;
        }
        #endregion

        #region //使用中的线程数 GetInUseThreadCount()
        public static int GetInUseThreadCount()
        {
            return Instance.InUseThreads;
        }
        #endregion
    }
}
