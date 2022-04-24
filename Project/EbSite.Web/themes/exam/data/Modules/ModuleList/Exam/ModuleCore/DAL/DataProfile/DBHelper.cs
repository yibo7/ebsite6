using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.DataProfile;
using EbSite.Modules.Exam;

namespace EbSite.Modules.Exam.ModuleCore.DAL.DataProfile
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
                if (!SettingInfo.Instance.GetBaseConfig.Instance.IsUserSysConn)
                {
                    //ʹ��ϵͳ���ݿ����Ӵ�
                    base.m_connectionstring = Base.Host.Instance.GetSysConn;//�������ȡ��������
                }
                else
                {
                    //ʹ��ģ�����ݿ����Ӵ�
                    base.m_connectionstring = SettingInfo.Instance.GetBaseConfig.Instance.ConnectionString;
                    
                }
                
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
                    if (m_provider == null)
                    {

                       m_provider = new SqlServer.Sys.SqlServerProvider();



                    }
                }
            }
            return m_provider;
        }

    }
}