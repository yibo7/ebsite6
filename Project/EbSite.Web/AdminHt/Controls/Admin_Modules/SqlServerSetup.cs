using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.DataProfile;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{

    public class SetupDBHelper : DbHelperBase
    {
        private string _conn;
        public SetupDBHelper(string conn)
        {
            this._conn = conn;
        }
        public override string ConnectionString()
        {
            if (base.m_connectionstring == null)
            {
                base.m_connectionstring = _conn;
            }
            return m_connectionstring;

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
                    base.m_provider = new SqlServerProvider();
                }

            }
            return m_provider;
        }
    }
}