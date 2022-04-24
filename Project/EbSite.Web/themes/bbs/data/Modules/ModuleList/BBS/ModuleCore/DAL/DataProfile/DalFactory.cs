using System;
using EbSite.Base.DataProfile;

namespace EbSite.Modules.BBS.ModuleCore.DAL.DataProfile
{
    public class DalFactory
    {
        public static DALInterface.IDataProvider DalProvider
        {
            get
            {
                #region �ýӿ�ʵ�ֶ����ݿ�İ취(����)
                //try
                //{

                //    return (DALInterface.IDataProvider)Activator.CreateInstance(Type.GetType(string.Format("EbSite.Modules.FriendLik.ModuleCore.DAL.{0}, EbSite.Modules.FriendLik", Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType), false, true));
                //}
                //catch
                //{
                //    throw new Exception("����Base.config�нڵ����ݿ������Ƿ���ȷ�����磺SqlServer��Access��MySql");
                //}
                #endregion

                //#region �����ݿ�ķ���(�Ƿ���)
                //if (SettingInfo.Instance.DataLayerType == "MySql")
                //{
                //    return new MySql.BBS();
                //}
                //else
                //{
                //    throw new Exception("����DataStore/Configs/Base.config��Dbtype�ڵ����ݿ������Ƿ���ȷ�����磺SqlServer��Access");
                //}

                //#endregion
                return new MySql.BBS();
            }


        }


        public static IDbProvider DataBaseTypeProvider
        {
            get
            {
                #region �ýӿ�ʵ�ֶ����ݿ�İ취(����)
                //try
                //{
                //    base.m_provider = (IDbProvider)Activator.CreateInstance(Type.GetType(string.Format("EbSite.Modules.FriendLik.ModuleCore.DAL.Helper.{0}Provider, EbSite.Modules.FriendLik", Base.Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType), false, true));
                //}
                //catch
                //{
                //    throw new Exception("����DataStore/Configs/Base.config��Dbtype�ڵ����ݿ������Ƿ���ȷ�����磺SqlServer��Access");
                //}
                #endregion

                //#region �����ݿ�ķ���(�Ƿ���)
                //if (SettingInfo.Instance.DataLayerType == "SqlServer")
                //{
                //    //return new SqlServer.Helper.SqlServerProvider();
                //    return new  EbSite.Base.DataProfile.SqlServerProvider();
                //}
                //else if (SettingInfo.Instance.DataLayerType == "Access")
                //{
                //    return new  AccessProvider();
                //}
                //else if (SettingInfo.Instance.DataLayerType == "MySql")
                //{
                //    return new MySqlProvider();
                //}
                //else
                //{
                //    throw new Exception("����DataStore/Configs/Base.config��Dbtype�ڵ����ݿ������Ƿ���ȷ�����磺SqlServer��Access");
                //}

                //#endregion
                return new MySqlProvider();
            }
            
                    
        }


    }
}