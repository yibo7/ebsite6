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
                #region �ýӿ�ʵ�ֶ����ݿ�İ취(����)
                //try
                //{
                //    base.m_provider = (IDbProvider)Activator.CreateInstance(Type.GetType(string.Format("EbSite.Modules.BeiMai.ModuleCore.DAL.Helper.{0}Provider, EbSite.Modules.BeiMai", Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType), false, true));
                //}
                //catch
                //{
                //    throw new Exception("����DataStore/Configs/Base.config��Dbtype�ڵ����ݿ������Ƿ���ȷ�����磺SqlServer��Access");
                //}
                #endregion

                #region �����ݿ�ķ���(�Ƿ���)
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
                //    throw new Exception("����DataStore/Configs/Base.config��Dbtype�ڵ����ݿ������Ƿ���ȷ�����磺SqlServer��Access��MySQL");
                //}
                return new MySqlProvider();
                #endregion
            }


        }


    }
}