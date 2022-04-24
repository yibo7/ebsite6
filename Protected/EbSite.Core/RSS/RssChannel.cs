using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Core.RSS
{
    public class RssChannel
    {
        #region 必选
        private string _Title;
        /// <summary>
        /// 定义频道的标题
        /// </summary>
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
        private string _Link;
        /// <summary>
        /// 定义指向频道的超链接
        /// </summary>
        public string Link
        {
            get
            {
                return _Link;
            }
            set
            {
                _Link = value;
            }
        }
        private string _Description;
        /// <summary>
        /// 描述频道
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        #endregion

        #region 可选
        private string _Category;
        /// <summary>
        /// 为 feed 定义所属的一个或多个种类
        /// </summary>
        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
            }
        }
        private string _Cloud;
        /// <summary>
        /// 注册进程，以获得 feed 更新的立即通知
        /// </summary>
        public string Cloud
        {
            get
            {
                return _Cloud;
            }
            set
            {
                _Cloud = value;
            }
        }
        private string _Copyright;
        /// <summary>
        /// 告知版权资料
        /// </summary>
        public string Copyright
        {
            get
            {
                return _Copyright;
            }
            set
            {
                _Copyright = value;
            }
        }
        private string _Docs;
        /// <summary>
        /// 规定指向当前 RSS 文件所用格式说明的 URL
        /// </summary>
        public string Docs
        {
            get
            {
                return _Docs;
            }
            set
            {
                _Docs = value;
            }
        }
        private string _Generator;
        /// <summary>
        /// 规定指向当前 RSS 文件所用格式说明的 URL
        /// </summary>
        public string Generator
        {
            get
            {
                return _Generator;
            }
            set
            {
                _Generator = value;
            }
        }
        private string _Language = "zh-cn";
        /// <summary>
        /// 规定编写 feed 所用的语言
        /// </summary>
        public string Language
        {
            get
            {
                return _Language;
            }
            set
            {
                _Language = value;
            }
        }

        private string _LastBuildDate;
        /// <summary>
        /// 定义 feed 内容的最后修改日期
        /// </summary>
        public string LastBuildDate
        {
            get
            {
                return _LastBuildDate;
            }
            set
            {
                _LastBuildDate = value;
            }
        }
        private string _ManagingEditor;
        /// <summary>
        /// 定义 feed 内容编辑的电子邮件地址
        /// </summary>
        public string ManagingEditor
        {
            get
            {
                return _ManagingEditor;
            }
            set
            {
                _ManagingEditor = value;
            }
        }
        private string _PubDate;
        /// <summary>
        /// 为 feed 的内容定义最后发布日期
        /// </summary>
        public string PubDate
        {
            get
            {
                return _PubDate;
            }
            set
            {
                _PubDate = value;
            }
        }
        private string _Rating;
        /// <summary>
        /// feed 的 PICS 级别
        /// </summary>
        public string Rating
        {
            get
            {
                return _Rating;
            }
            set
            {
                _Rating = value;
            }
        }
        private string _SkipDays;
        /// <summary>
        /// 规定忽略 feed 更新的天
        /// </summary>
        public string SkipDays
        {
            get
            {
                return _SkipDays;
            }
            set
            {
                _SkipDays = value;
            }
        }
        private string _SkipHours;
        /// <summary>
        /// 规定忽略 feed 更新的小时
        /// </summary>
        public string SkipHours
        {
            get
            {
                return _SkipHours;
            }
            set
            {
                _SkipHours = value;
            }
        }
        private string _TextInput;
        /// <summary>
        /// 规定应当与 feed 一同显示的文本输入域
        /// </summary>
        public string TextInput
        {
            get
            {
                return _TextInput;
            }
            set
            {
                _TextInput = value;
            }
        }
        private string _Ttl;
        /// <summary>
        /// 指定从 feed 源更新此 feed 之前，feed 可被缓存的分钟数
        /// </summary>
        public string Ttl
        {
            get
            {
                return _Ttl;
            }
            set
            {
                _Ttl = value;
            }
        }
        private string _WebMaster;
        /// <summary>
        /// 定义此 feed 的 web 管理员的电子邮件地址
        /// </summary>
        public string WebMaster
        {
            get
            {
                return _WebMaster;
            }
            set
            {
                _WebMaster = value;
            }
        }
        #endregion

        private string _RssImage;
        /// <summary>
        /// 定义此 feed 的 图片Logo
        /// </summary>
        public string RssImage
        {
            get
            {
                return _RssImage;
            }
            set
            {
                _RssImage = value;
            }
        }
        private List<RssItem> _Items = new List<RssItem>();
        public List<RssItem> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
            }
        }

    }
}
