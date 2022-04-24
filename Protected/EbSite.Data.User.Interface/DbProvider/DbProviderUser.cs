using System;
using System.Reflection;
using System.Configuration;

namespace EbSite.Data.User.Interface
{
    public class DbProviderUser
    {
        //private static readonly string path =SwordWeb.Config.SysConst.WebDAL;

        //public  DataAccess() { }
        private static IDataProviderUser _instance = null;
        private static object lockHelper = new object();

        static DbProviderUser()
        {
            GetProvider();
        }

        private static void GetProvider()
        {
            try
            {

                _instance = (IDataProviderUser)Activator.CreateInstance(Type.GetType(string.Format("EbSite.Data.User.{0}.DataProviderUser, EbSite.Data.User.{0}", Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser), false, true));
            }
            catch
            {
                throw new Exception("请检查Base.config中节点数据库类型是否正确，例如：SqlServer、Access、MySql");
            }
        }

        public static IDataProviderUser GetInstance()
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
