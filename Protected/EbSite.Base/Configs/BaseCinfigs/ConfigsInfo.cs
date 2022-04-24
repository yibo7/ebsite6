using System;
using EbSite.Base.Configs.ConfigsBase;
using EbSite.Core;

namespace EbSite.Base.Configs.BaseCinfigs
{
    public class ConfigsInfo : IConfigInfo
    {
        private string _ConnectionStringSysCms;
        private string _ConnectionStringSysUser;
        private string _TablePrefix;
        private string _TablePrefixUser;
        private string _DataLayerType;
        private string _FounderuID = "";				// 创始人

        private string _DataLayerTypeUser;

        /// <summary>
        /// 创始人帐号
        /// </summary>
        public string FounderuID
        {
            get
            {
                return _FounderuID;
            }
            set
            {
                _FounderuID = value;
            }
        }
        /// <summary>
        /// 用户数据层程序集名称
        /// </summary>
        public string DataLayerTypeUser
        {
            get
            {
                return _DataLayerTypeUser;
            }
            set
            {
                _DataLayerTypeUser = value;
            }
        }
        /// <summary>
        /// 系统数据层程序集名称
        /// </summary>
        public string DataLayerType
        {
            get
            {
                return _DataLayerType;
            }
            set
            {
                _DataLayerType = value;
            }
        }
        public string GetConnectionStringSysCms()
        {
            if (SysConfigs.ConfigsControl.Instance.IsEndDataBaseStr)
            {
                string deskey = EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey;
                if (Equals(DataLayerType, "Access"))
                {

                    string sConn = Utils.GetMapPath(Core.DES.Decode(_ConnectionStringSysCms, deskey));

                    return string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Persist Security Info=True;", sConn);
                }
                else
                {
                    string conn =  Core.DES.Decode(_ConnectionStringSysCms, deskey);
                    if (string.IsNullOrEmpty(conn))
                    {
                        throw new Exception("调用 EbSite.Base.Configs.BaseCinfigs.ConfigsInfo.GetConnectionStringSysCms()出错，您设置了数据库连接串加密，可是无法正常解密,解决方法:修改ConfigsFile/SysConfig.config里的IsEndDataBaseStr为false。");
                    }
                    return conn;
                }
            }
            else
            {
                if (Equals(DataLayerType, "Access"))
                {

                    string sConn = Utils.GetMapPath(_ConnectionStringSysCms);

                    return string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Persist Security Info=True;", sConn);
                }
                else
                {
                    return _ConnectionStringSysCms;
                }
            }
            
        }

        public string GetConnectionStringSysCmsWrite()
        {
            if (SysConfigs.ConfigsControl.Instance.IsEndDataBaseStr)
            {
                string deskey = EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey;
                if (Equals(DataLayerType, "Access"))
                {

                    string sConn = Utils.GetMapPath(Core.DES.Decode(ConnectionStringSysCmsWrite, deskey));

                    return string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Persist Security Info=True;", sConn);
                }
                else
                {
                    string conn = Core.DES.Decode(ConnectionStringSysCmsWrite, deskey);
                    if (string.IsNullOrEmpty(conn))
                    {
                        throw new Exception("调用 EbSite.Base.Configs.BaseCinfigs.ConfigsInfo.GetConnectionStringSysCms()出错，您设置了数据库连接串加密，可是无法正常解密,解决方法:修改ConfigsFile/SysConfig.config里的IsEndDataBaseStr为false。");
                    }
                    return conn;
                }
            }
            else
            {
                if (Equals(DataLayerType, "Access"))
                {

                    string sConn = Utils.GetMapPath(ConnectionStringSysCmsWrite);

                    return string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Persist Security Info=True;", sConn);
                }
                else
                {
                    return ConnectionStringSysCmsWrite;
                }
            }

        }

        /// <summary>
        /// CMS系统用的数据库连接串
        /// </summary>
        public string ConnectionStringSysCmsWrite { get; set; }

        /// <summary>
        /// CMS系统用的数据库连接串
        /// </summary>
        public string ConnectionStringSysCms
        {
            get
            {

                return _ConnectionStringSysCms;

            }
            set
            {

                _ConnectionStringSysCms = value;
            }
        }
        public string GetConnectionStringSysUser()
        {
            if (SysConfigs.ConfigsControl.Instance.IsEndDataBaseStr)
            {
                string deskey = SysConfigs.ConfigsControl.Instance.EncryptionKey;
                if (Equals(DataLayerType, "Access"))
                {

                    string sConn = Utils.GetMapPath(Core.DES.Decode(_ConnectionStringSysUser, deskey));

                    return string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Persist Security Info=True;", sConn);
                }
                else
                {


                    string conn = Core.DES.Decode(_ConnectionStringSysUser, deskey);
                    if (string.IsNullOrEmpty(conn))
                    {
                        throw new Exception("调用 EbSite.Base.Configs.BaseCinfigs.ConfigsInfo.GetConnectionStringSysUser()出错，您设置了数据库连接串加密，可是无法正常解密,解决方法:修改ConfigsFile/SysConfig.config里的IsEndDataBaseStr为false。");
                    }
                    return conn;
                }
            }
            else
            {
                
                if (Equals(DataLayerType, "Access"))
                {

                    string sConn = Utils.GetMapPath(_ConnectionStringSysUser);

                    return string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Persist Security Info=True;", sConn);
                }
                else
                {
                    return _ConnectionStringSysUser;
                }
            }
            

        }

        public string GetConnectionStringSysUserWrite()
        {
            if (SysConfigs.ConfigsControl.Instance.IsEndDataBaseStr)
            {
                string deskey = SysConfigs.ConfigsControl.Instance.EncryptionKey;
                if (Equals(DataLayerType, "Access"))
                {

                    string sConn = Utils.GetMapPath(Core.DES.Decode(ConnectionStringSysUserWrite, deskey));

                    return string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Persist Security Info=True;", sConn);
                }
                else
                {


                    string conn = Core.DES.Decode(ConnectionStringSysUserWrite, deskey);
                    if (string.IsNullOrEmpty(conn))
                    {
                        throw new Exception("调用 EbSite.Base.Configs.BaseCinfigs.ConfigsInfo.GetConnectionStringSysUser()出错，您设置了数据库连接串加密，可是无法正常解密,解决方法:修改ConfigsFile/SysConfig.config里的IsEndDataBaseStr为false。");
                    }
                    return conn;
                }
            }
            else
            {

                if (Equals(DataLayerType, "Access"))
                {

                    string sConn = Utils.GetMapPath(ConnectionStringSysUserWrite);

                    return string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Persist Security Info=True;", sConn);
                }
                else
                {
                    return ConnectionStringSysUserWrite;
                }
            }


        }

        public string ConnectionStringSysUserWrite { get; set; }
        /// <summary>
        /// 用户系统用的数据库连接串
        /// </summary>
        public string ConnectionStringSysUser
        {
            get
            {

                return _ConnectionStringSysUser;
            }
            set
            {
                _ConnectionStringSysUser = value;
            }
        }

        /// <summary>
        /// 数据表前缀
        /// </summary>
        public string TablePrefix
        {
            get
            {
                return _TablePrefix;
            }
            set
            {
                _TablePrefix = value;
            }
        }
        /// <summary>
        /// 用户数据表前缀
        /// </summary>
        public string TablePrefixUser
        {
            get
            {
                return _TablePrefixUser;
            }
            set
            {
                _TablePrefixUser = value;
            }
        }
    }
}
