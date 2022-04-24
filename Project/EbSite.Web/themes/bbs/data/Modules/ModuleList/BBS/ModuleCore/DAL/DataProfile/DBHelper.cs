using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.DataProfile;

namespace EbSite.Modules.BBS.ModuleCore.DAL.DataProfile
{
    public class DBHelper : DbHelperBase
    {
        //static readonly public DBHelper Instance = new DBHelper();
        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        public override string ConnectionString()
        {
            if (base.m_connectionstring == null)
            {
                //if(SettingInfo.Instance.IsUserSysConn)
                //{
                //    //ʹ��ϵͳ���ݿ����Ӵ�
                //    base.m_connectionstring = Base.Host.Instance.GetSysConn;//�������ȡ��������
                //}
                //else
                //{
                //    //ʹ��ģ�����ݿ����Ӵ�
                //    base.m_connectionstring = SettingInfo.Instance.ConnectionString;

                //}
                base.m_connectionstring = Base.Host.Instance.GetSysConn;//�������ȡ��������
            }
            return base.m_connectionstring;
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