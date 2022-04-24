using System;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Wenda.ModuleCore.DAL.DataProfile
{
    public class DBHelper : DbHelperBase
    {
        public override string ConnectionString()
        {
            if (base.m_connectionstring == null)
            {
                base.m_connectionstring = Base.Host.Instance.GetSysConn;
                //if (SettingInfo.Instance.GetBaseConfig.Instance.IsUserSysConn)
                //{
                //    //ʹ��ģ�����ݿ����Ӵ�
                //    base.m_connectionstring = Base.Host.Instance.GetSysConn;//�������ȡ��������
                //}
                //else
                //{
                //    //ʹ��ϵͳ���ݿ����Ӵ�
                //    base.m_connectionstring = SettingInfo.Instance.GetBaseConfig.Instance.GetConnectionString();

                //}
            }
            return m_connectionstring;

        }
        /// <summary>
        /// IDbProvider�ӿ�
        /// </summary>
        public override IDbProvider Provider()
        {
            if (m_provider == null)
            {
                lock (lockHelper)
                {
                    base.m_provider = DalFactory.DataBaseTypeProvider;
                }

            }
            return m_provider;
        }
    }
}