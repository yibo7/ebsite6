using System;
using EbSite.Base.DataProfile;

namespace EbSite.Modules.Wenda.ModuleCore.DAL.DataProfile
{
    public class DalFactory
    {
        public static DALInterface.IDataProvider DalProvider
        {
            get
            {
                return new MySQL.Ask();
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