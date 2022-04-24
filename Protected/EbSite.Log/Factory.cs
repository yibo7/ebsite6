using System;
using System.Configuration;
using System.Reflection; 

namespace EbSite.Log
{
    public class Factory
    {
        private static readonly string profilePath = ConfigurationManager.AppSettings["LogProvider"];

        private static void GetProvider()
        {
            try
            {
                //_instance = new LogProvider();
                string className = profilePath + ".LogProvider";
                _instance = (Ilog)Assembly.Load(profilePath).CreateInstance(className);
            }
            catch(Exception e)
            {
                throw new Exception(string.Format("请检查Web.config中的AppSettings，查看LogProvider是否配置正确:{0}",e.Message));
            }
           
        }
        private static Ilog _instance = null;
        private static object lockHelper = new object();
        public static Ilog GetInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                    {
                        GetProvider();
                    }
                }
            }
            return _instance;
        }
    }
}