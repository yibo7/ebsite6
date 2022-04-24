using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.ModulesGenerate.Core
{
    public class ProjectInfo
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string dbtype;
        /// <summary>
        /// 数据库IP
        /// </summary>
        public string ServerIp;
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DbName;
        /// <summary>
        /// 数据库连接串
        /// </summary>
        public string sConn;
        /// <summary>
        /// 选择的表
        /// </summary>
        public List<string> Tables;
        /// <summary>
        /// 项目架构名称
        /// </summary>
        public string AppFrame;
        /// <summary>
        /// 项目的中文名称
        /// </summary>
        public string ProjectCnName;
        /// <summary>
        /// 项目的英文名称
        /// </summary>
        public string ProjectEnName;
        /// <summary>
        /// 表的前缘
        /// </summary>
        public string Tabpre;
        /// <summary>
        /// 版本号
        /// </summary>
        public string sVersion;
        /// <summary>
        /// 是否使用主系统数据库连接
        /// </summary>
        public bool IsUserSysConn = false;
        /// <summary>
        /// 模块开发者
        /// </summary>
        public string Author = "ebsite";
        /// <summary>
        /// 模块开发者的网站
        /// </summary>
        public string AuthorUrl = "www.ebsite.cn";
    }
}