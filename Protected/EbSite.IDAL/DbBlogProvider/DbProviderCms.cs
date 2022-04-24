using System;
using System.Reflection;
using System.Configuration;

namespace EbSite.Data.Interface
{
    public class DbProviderCms
    {
        //private static readonly string path =SwordWeb.Config.SysConst.WebDAL;

        //public  DataAccess() { }
        private static IDataProviderCms _instance = null;
        private static object lockHelper = new object();

        static DbProviderCms()
        {
            GetProvider();
        }

        private static void GetProvider()
        {
            try
            {

                _instance = (IDataProviderCms)Activator.CreateInstance(Type.GetType(string.Format("EbSite.Data.{0}.DataProviderCms, EbSite.Data.{0}", Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType), false, true));

               
            }
            catch
            {
                throw new Exception("请检查Base.config中节点数据库类型是否正确，例如：SqlServer、Access、MySql");
            }
        }

        public static IDataProviderCms GetInstance()
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

        public static void ResetDbProvider()
        {
            _instance = null;
        }
    }
}
