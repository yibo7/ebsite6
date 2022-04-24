using System;
using EbSite.Base.Entity;
using EbSite.Base.Modules;

namespace EbSite.Entity
{
    [Serializable]
    public class ModuleInfo : XmlEntityBase<Guid>
    {
        private string _ModuleName;
        private string _Author;
        private string _AuthorUrl;
        private string _Version = "1.0.0";
        private string _AccessFile = "";
        private string _SqlScript = "";
        private string _SetupPath;
        private string _Demo = "";
        private bool _IsClose = false;
        private string _UpdateUrl;
        private string _LastVersionUrl;
        public int SiteID { get; set; }
        public ModuleInfo()
        {
        }
        /// <summary>
        /// 获取最新版本号的地址 如 http://www.server.com/Version.txt
        /// 返回值为最新版本号如 2.0.0,不得包含其他字符
        /// </summary>
        public string LastVersionUrl
        {
            get
            {
                return this._LastVersionUrl;
            }
            set
            {
                this._LastVersionUrl = value;
            }
        }
        /// <summary>
        /// 模块升级更新包地址，如 http://www.server.com/update.rar
        /// 用户更新时将下载此安装包并覆盖到模块根目录，
        /// 如果有要执行的sql 脚本，请放在DataStore/UpdateSql/下，只支持sql server
        /// </summary>
        public string UpdateUrl
        {
            get
            {
                return this._UpdateUrl;
            }
            set
            {
                this._UpdateUrl = value;
            }
        }
        public string ModuleDLLName { get; set; }
        public ModuleInfo(ModuleAttribute ma, int _SiteID, Guid Moduleid,string DllName)
        {
            _ModuleName = ma.ModuleName;
            _Author = ma.Author;
            _AuthorUrl = ma.AuthorUrl;
            _Version = ma.Version;
            //_AccessFile = ma.AccessFile;
            //_SqlScript = ma.SqlScript;
            //id = new Guid(ma.ModuleID);
            //if (!string.IsNullOrEmpty(ma.ModuleID))
            //    id = new Guid(ma.ModuleID);
            //id = Guid.NewGuid();
            id = Moduleid;
            SiteID = _SiteID;
            ModuleDLLName = DllName;
        }
        /// <summary>
        /// 是否关闭
        /// </summary>
        public bool IsClose
        {
            get { return _IsClose; }
            set { _IsClose = value; }
        }
        /// <summary>
        /// 模块说明
        /// </summary>
        public string Demo
        {
            get { return _Demo; }
            set { _Demo = value; }
        }
        /// <summary>
        /// 安装目录
        /// </summary>
        public string SetupPath
        {
            get { return _SetupPath; }
            set { _SetupPath = value; }
        }
        /// <summary>
        /// Access 文件的存放路径(相对路径，如db/test.config)，如果此路径不为空，则表示当前模块支持Access数据安装
        /// </summary>
        public string AccessFile
        {
            get { return _AccessFile; }
            set { _AccessFile = value; }
        }
        /// <summary>
        /// Sql Server安装脚本文件路径（相对路径，如db/test.sql）,如果此路径不为空，则表示当前模块支持SqlServer数据安装
        /// </summary>
        public string SqlScript
        {
            get { return _SqlScript; }
            set { _SqlScript = value; }
        }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName
        {
            get { return _ModuleName; }
            set { _ModuleName = value; }
        }

        /// <summary>
        /// 版本
        /// </summary>
        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }

        /// <summary>
        /// 作者网址
        /// </summary>
        public string AuthorUrl
        {
            get { return _AuthorUrl; }
            set { _AuthorUrl = value; }
        }
    }
}
