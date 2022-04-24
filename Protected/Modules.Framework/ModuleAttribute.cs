using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modules.Framework
{
    /// <summary>
    /// 模块的属性
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ModuleAttribute : Attribute
    { 
        private string _Author;
        private string _AuthorUrl;
        private string _ModuleName;
        private decimal _Price; 
        private string _Version;
        private string _UpdateUrl;
        private string _LastVersionUrl; 
        public ModuleAttribute()
        {
            this._Version = "1.0.0"; 
            this._Price = 0M;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="Name">模块名称</param>
        public ModuleAttribute(string Name)
        {
            this._Version = "1.0.0"; 
            this._Price = 0M;
            this._ModuleName = Name;
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
        ///// <summary>
        ///// access版本的文件地址 相对，如 db/sql.config 共安装时用
        ///// </summary>
        //public string AccessFile
        //{
        //    get
        //    {
        //        return this._AccessFile;
        //    }
        //    set
        //    {
        //        this._AccessFile = value;
        //    }
        //}
        /// <summary>
        /// 模块开发者
        /// </summary>
        public string Author
        {
            get
            {
                return this._Author;
            }
            set
            {
                this._Author = value;
            }
        }
        /// <summary>
        /// 模块开发者的网址
        /// </summary>
        public string AuthorUrl
        {
            get
            {
                return this._AuthorUrl;
            }
            set
            {
                this._AuthorUrl = value;
            }
        }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName
        {
            get
            {
                return this._ModuleName;
            }
            set
            {
                this._ModuleName = value;
            }
        }
        /// <summary>
        /// 出售单价
        /// </summary>
        public decimal Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                this._Price = value;
            }
        }
        ///// <summary>
        ///// 模块sql server 版的安装脚本
        ///// </summary>
        //public string SqlScript
        //{
        //    get
        //    {
        //        return this._SqlScript;
        //    }
        //    set
        //    {
        //        this._SqlScript = value;
        //    }
        //}
        /// <summary>
        /// 模块版本号 如 1.0.0.1
        /// </summary>
        public string Version
        {
            get
            {
                return this._Version;
            }
            set
            {
                this._Version = value;
            }
        }
        public string IndexUrl { get; set; }
    }
}