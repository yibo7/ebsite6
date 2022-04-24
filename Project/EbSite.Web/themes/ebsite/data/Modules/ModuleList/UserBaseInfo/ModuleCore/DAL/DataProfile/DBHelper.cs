using System;
using System.Collections.Generic;

using System.Web;

using EbSite.Base.DataProfile;
using EbSite.Modules.UserBaseInfo;

namespace EbSite.Modules.UserBaseInfo.ModuleCore.DAL.DataProfile
{
    public class DBHelper : DbHelperBase
    {
        public override string ConnectionString()
        {
            if(base.m_connectionstring==null)
            {
                //if (SettingInfo.Instance.GetBaseConfig.Instance.IsUserSysConn)
                //{
                //    //使用模块数据库连接串
                //    base.m_connectionstring = Base.Host.Instance.GetSysConn;//在这里获取数据连接
                //}
                //else
                //{
                //    //使用系统数据库连接串
                //    base.m_connectionstring = SettingInfo.Instance.GetBaseConfig.Instance.ConnectionString;

                //}
                base.m_connectionstring = Base.Host.Instance.GetSysConn;//在这里获取数据连接
            }
            return m_connectionstring;
            
        }
        /// <summary>
        /// IDbProvider接口
        /// </summary>
        public override IDbProvider Provider()
        {
            if(m_provider==null)
            {
                lock (lockHelper)
                {
                    #region 用接口实现多数据库的办法(反射)
                    #endregion
                    #region 单数据库的方法

                    m_provider = (IDbProvider)new SqlServer.Sys.SqlServerProvider();
                    #endregion
                }
               
            }
            return m_provider;
        }
    }
}