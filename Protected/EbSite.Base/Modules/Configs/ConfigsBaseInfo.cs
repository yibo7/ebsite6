
//using System;
//using EbSite.Core;

//namespace EbSite.Base.Modules.Configs
//{
    
//    /// <summary>
//    /// 模块配置实体类 对应模块下的 Base.Config
//    /// </summary>
//    public class ConfigsBaseInfo
//    {
//        private string _ColseInfo = "关闭提示信息";
//        private string _ConnectionString;
//        private string _DataLayerType;
//        private bool _IsClose;
//        private string _TablePrefix;
//        private Guid _ModuleID;
//        private bool _IsUserSysConn;
//        /// <summary>
//        /// 设置是不是使用主系统数据库连接串
//        /// </summary>
//        public bool IsUserSysConn
//        {
//            get
//            {
//                return this._IsUserSysConn;
//            }
//            set
//            {
//                this._IsUserSysConn = value;
//            }
//        }
//        /// <summary>
//        /// 当前模块安装的ID
//        /// </summary>
//        public Guid ModuleID
//        {
//            get
//            {
//                return this._ModuleID;
//            }
//            set
//            {
//                this._ModuleID = value;
//            }
//        }

//        private string _ModulePath;
//        public string ModulePath
//        {
//            get
//            {
//                return _ModulePath;
//            }
//            set
//            {
//                _ModulePath = value;
//            }
//        }

//        //private string _ModuleDLLName;
//        /// <summary>
//        /// 模块dll的名称  如 EbSite.Modules.FriendLik.dll
//        /// </summary>
//        public string ModuleDLLName { get; set; }

//        /// <summary>
//        /// 模块的数据连接串，如果不使用主系统连接串的话
//        /// </summary>
//        /// <returns></returns>
//        public string GetConnectionString()
//        {
//            if (object.Equals(this.DataLayerType, "Access"))
//            {
//                string mapPath = Utils.GetMapPath(this._ConnectionString);
//                return string.Format("Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Persist Security Info=True;", mapPath);
//            }
//            return this._ConnectionString;
//        }
//        /// <summary>
//        /// 关闭提示信息
//        /// </summary>
//        public string ColseInfo
//        {
//            get
//            {
//                return this._ColseInfo;
//            }
//            set
//            {
//                this._ColseInfo = value;
//            }
//        }
//        /// <summary>
//        /// 数据连接串
//        /// </summary>
//        public string ConnectionString
//        {
//            get
//            {
//                return this._ConnectionString;
//            }
//            set
//            {
//                this._ConnectionString = value;
//            }
//        }
//        /// <summary>
//        /// 数据库类型
//        /// </summary>
//        public string DataLayerType
//        {
//            get
//            {
//                return this._DataLayerType;
//            }
//            set
//            {
//                this._DataLayerType = value;
//            }
//        }
//        /// <summary>
//        /// 是否关闭模块
//        /// </summary>
//        public bool IsClose
//        {
//            get
//            {
//                return this._IsClose;
//            }
//            set
//            {
//                this._IsClose = value;
//            }
//        }
//        /// <summary>
//        /// 表前缀
//        /// </summary>
//        public string TablePrefix
//        {
//            get
//            {
//                return this._TablePrefix;
//            }
//            set
//            {
//                this._TablePrefix = value;
//            }
//        }
//    }
//}

