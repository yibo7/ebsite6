using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EbSite.Base.DataProfile
{
    public class AccessProvider : IDbProvider
    {
        public void DeriveParameters(IDbCommand cmd)
        {
            if (cmd is OleDbCommand)
            {
                OleDbCommandBuilder.DeriveParameters(cmd as OleDbCommand);
            }
        }

        public string GetLastIdSql()
        {
            return "SELECT @@IDENTITY";
        }

        public DbProviderFactory Instance()
        {
            return OleDbFactory.Instance;
        }

        public bool IsBackupDatabase()
        {
            return false;
        }

        public bool IsCompactDatabase()
        {
            return false;
        }

        public bool IsDbOptimize()
        {
            return false;
        }

        public bool IsFullTextSearchEnabled()
        {
            return false;
        }

        public bool IsShrinkData()
        {
            return false;
        }

        public bool IsStoreProc()
        {
            return false;
        }

        public DbParameter MakeParam(string ParamName, DbType DbType, int Size)
        {
            if (Size > 0)
            {
                return new OleDbParameter(ParamName, (OleDbType)DbType, Size);
            }
            return new OleDbParameter(ParamName, (OleDbType)DbType);
        }
    }
}
