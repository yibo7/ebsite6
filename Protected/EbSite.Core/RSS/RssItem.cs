using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Core.RSS
{
    public class RssItem
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
        private string _Author;
        /// <summary>
        /// 规定项目作者的电子邮件地址
        /// </summary>
        public string Author
        {
            get
            {
                return _Author;
            }
            set
            {
                _Author = value;
            }
        }
        private string _Comments;
        /// <summary>
        /// 允许项目连接到有关此项目的注释（文件）
        /// </summary>
        public string Comments
        {
            get
            {
                return _Comments;
            }
            set
            {
                _Comments = value;
            }
        }
        private string _Enclosure;
        /// <summary>
        /// 允许将一个媒体文件导入一个项中
        /// </summary>
        public string Enclosure
        {
            get
            {
                return _Enclosure;
            }
            set
            {
                _Enclosure = value;
            }
        }
        private string _Guid;
        /// <summary>
        /// 为 项目定义一个唯一的标识符
        /// </summary>
        public string Guid
        {
            get
            {
                return _Guid;
            }
            set
            {
                _Guid = value;
            }
        }
        private string _PubDate;
        /// <summary>
        ///定义此项目的最后发布日期
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
        private string _Source;
        /// <summary>
        /// 为此项目指定一个第三方来源
        /// </summary>
        public string Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
            }
        }
        #endregion

    }
}
