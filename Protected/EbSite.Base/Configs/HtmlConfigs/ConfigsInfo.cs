
using System.Collections.Generic;
using EbSite.Base.Configs.ConfigsBase;

namespace EbSite.Base.Configs.HtmlConfigs
{
    /// <summary>
    /// 生成静态页面 配置文件实体类
    /// </summary>
    public class ConfigsInfo : IConfigInfo
    {
        private int _CreateSleep = 100;
        private string _DefualtName = "/index.htm";     //默认页面
        private string _GetHtmlErr = "获取HTML出错";

        private string _TagsList;   //获取标签搜索结果列表地址
        private string _TagsSearchList;   //获取标签搜索结果列表地址

        private int _HtmlTimeSpan = 0;

        private string _ClassHtmlRule;
        private string _ContentHtmlRule;
        private string _SpecialHtmlRule;
        private string _PageSplit = "p";
        /// <summary>
        /// 页码分隔符
        /// </summary>
        public string PageSplit
        {
            get
            {
                return _PageSplit;
            }
            set
            {
                _PageSplit = value;
            }
        }

        /// <summary>
        /// 专题静态页面的规则
        /// </summary>
        public string SpecialHtmlRule
        {
            get
            {
                return _SpecialHtmlRule;
            }
            set
            {
                _SpecialHtmlRule = value;
            }
        }
        ///// <summary>
        ///// 自动静态缓存模式,0为硬盘HTML，1为NoSql
        ///// </summary>
        //public int PageHtmlModel { get; set; }
        

        /// <summary>
        /// 自动静态页面时，页面过期时间
        /// </summary>
        public int HtmlTimeSpan
        {
            get
            {
                return _HtmlTimeSpan;
            }
            set
            {
                _HtmlTimeSpan = value;
            }
        }
        /// <summary>
        /// 过期方式,0.天，1小时,2分钟
        /// </summary>
        public int HtmlTimeSpanModel { get; set; }
        /// <summary>
        /// 分类页面生成路径及命名规则
        /// </summary>
        public string ClassHtmlRule
        {
            get
            {
                return _ClassHtmlRule;
            }
            set
            {
                _ClassHtmlRule = value;
            }
        }
        /// <summary>
        /// 内容页面生成路径及命名规则
        /// </summary>
        public string ContentHtmlRule
        {
            get
            {
                return _ContentHtmlRule;
            }
            set
            {
                _ContentHtmlRule = value;
            }
        }

        /// <summary>
        /// 创建速度
        /// </summary>
        public int CreateSleep
        {
            get
            {
                return _CreateSleep;
            }
            set
            {
                _CreateSleep = value;
            }
        }
        /// <summary>
        /// 默认页面
        /// </summary>
        public string DefualtName
        {
            get
            {
                return _DefualtName;
            }
            set
            {
                _DefualtName = value;
            }
        }
        /// <summary>
        /// 获取HTML出错
        /// </summary>
        public string GetHtmlErr
        {
            get
            {
                return _GetHtmlErr;
            }
            set
            {
                _GetHtmlErr = value;
            }
        }
        /// <summary>
        /// 获取标签搜索结果列表地址
        /// </summary>
        public string TagsList
        {
            get
            {
                return _TagsList;
            }
            set
            {
                _TagsList = value;
            }
        }
        /// <summary>
        /// 获取标签搜索结果列表地址
        /// </summary>
        public string TagsSearchList
        {
            get
            {
                return _TagsSearchList;
            }
            set
            {
                _TagsSearchList = value;
            }
        }

        /// <summary>
        /// 未完成的静态页面生成任务
        /// </summary>
        private List<MakeHtmlInfo> _HtmlUndoneMaked = new List<MakeHtmlInfo>();
        /// <summary>
        /// 未完成的静态页面生成任务
        /// </summary>
        public List<MakeHtmlInfo> HtmlUndoneMaked
        {
            get
            {
                return _HtmlUndoneMaked;
            }
            set
            {
                _HtmlUndoneMaked = value;
            }
        }

        
    }
}
