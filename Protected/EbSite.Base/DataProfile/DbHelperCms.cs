using System;
namespace EbSite.Base.DataProfile
{

    /// <summary>
    /// 数据访问助手类
    /// </summary>
    public class DbHelperCms : DbHelperBase
    {
        static public readonly DbHelperCms Instance = new DbHelperCms();
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public override string ConnectionString()
        {
            if (string.IsNullOrEmpty(base.m_connectionstring))
            {

                base.m_connectionstring = Configs.BaseCinfigs.ConfigsControl.Instance.GetConnectionStringSysCms();
                

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
                        try
                        {
                            m_provider = (IDbProvider)Activator.CreateInstance(Type.GetType(string.Format("EbSite.Data.{0}Provider, EbSite.Data.{0}", Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType), false, true));
                        }
                        catch
                        {
                            throw new Exception("请检查Base.config中Dbtype节点数据库类型是否正确，例如：SqlServer、Access、MySql");
                        }

                    }
                }
            }
            return m_provider;
        }

    }
   
}