using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.DataProfile;

namespace EbSite.Modules.Shop.ModuleCore.DAL.DataProfile
{
    public class DalFactory
    {
        private static object _SyncRoot = new object();
        private static DALInterface.IDataProvider _DalProvider;
        public static DALInterface.IDataProvider DalProvider
        {
            get
            {

                if (_DalProvider == null)
                {
                    lock (_SyncRoot)
                    {
                        if (_DalProvider == null)
                        {
                            #region 用接口实现多数据库的办法(反射)
                            //try
                            //{

                            //    return (DALInterface.IDataProvider)Activator.CreateInstance(Type.GetType(string.Format("EbSite.Modules.BeiMai.ModuleCore.DAL.{0}, EbSite.Modules.BeiMai", Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType), false, true));
                            //}
                            //catch
                            //{
                            //    throw new Exception("请检查Base.config中节点数据库类型是否正确，例如：SqlServer、Access、MySql");
                            //}
                            #endregion

                            #region 单数据库的方法(非反射)
                            //if (SettingInfo.Instance.GetBaseConfig.Instance.DataLayerType == "SqlServer")
                            //{
                            //    return new SqlServer.Shop();
                            //}
                            //else 
                            //    if (SettingInfo.Instance.GetBaseConfig.Instance.DataLayerType == "Access")
                            //{
                            //    return null;
                            //}
                            //else 
                            //if (SettingInfo.Instance.DataLayerType == "MySql")
                            //{
                            //    _DalProvider = new MySql.Shop();
                            //}
                            //else
                            //{
                            //    throw new Exception("请检查DataStore/Configs/Base.config中Dbtype节点数据库类型是否正确，例如：SqlServer、Access");
                            //}
                            _DalProvider = new MySql.Shop();
                            #endregion
                        }
                    }
                }

                return _DalProvider;

                
            }


        }


        public static IDbProvider DataBaseTypeProvider
        {
            get
            {
                #region 用接口实现多数据库的办法(反射)
                //try
                //{
                //    base.m_provider = (IDbProvider)Activator.CreateInstance(Type.GetType(string.Format("EbSite.Modules.BeiMai.ModuleCore.DAL.Helper.{0}Provider, EbSite.Modules.BeiMai", Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType), false, true));
                //}
                //catch
                //{
                //    throw new Exception("请检查DataStore/Configs/Base.config中Dbtype节点数据库类型是否正确，例如：SqlServer、Access");
                //}
                #endregion

                #region 单数据库的方法(非反射)
                //if (SettingInfo.Instance.GetBaseConfig.Instance.DataLayerType == "SqlServer")
                //{
                //    //return new SqlServer.Helper.SqlServerProvider();
                //    return new EbSite.Base.DataProfile.SqlServerProvider();
                //}
                //else if (SettingInfo.Instance.GetBaseConfig.Instance.DataLayerType == "Access")
                //{
                //    return new AccessProvider();
                //}
                //else if (SettingInfo.Instance.GetBaseConfig.Instance.DataLayerType == "MySql")
                //{
                //    return new MySqlProvider();
                //}
                //else
                //{
                //    throw new Exception("请检查DataStore/Configs/Base.config中Dbtype节点数据库类型是否正确，例如：SqlServer、Access、MySQL");
                //}
                return new MySqlProvider();
                #endregion
            }


        }


    }
}