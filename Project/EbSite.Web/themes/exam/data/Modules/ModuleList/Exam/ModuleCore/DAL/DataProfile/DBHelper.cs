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
        /// 数据库连接字符串
        /// </summary>
        public override string ConnectionString()
        {
            if (base.m_connectionstring == null)
            {
                if (!SettingInfo.Instance.GetBaseConfig.Instance.IsUserSysConn)
                {
                    //使用系统数据库连接串
                    base.m_connectionstring = Base.Host.Instance.GetSysConn;//在这里获取数据连接
                }
                else
                {
                    //使用模块数据库连接串
                    base.m_connectionstring = SettingInfo.Instance.GetBaseConfig.Instance.ConnectionString;
                    
                }
                
            }
            return base.m_connectionstring;
        }

        /// <summary>
        /// IDbProvider接口
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