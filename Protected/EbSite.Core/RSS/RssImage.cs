using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Core.RSS
{
    /// <summary>
    /// RssImage--图片Logo输出
    /// </summary>
    public class RssImage
    {
        #region 必选
        private string _Url;
        /// <summary>
        /// 图片地址
        /// </summary>
        public string Url
        {
            get
            {
                return _Url;
            }
            set
            {
                _Url = value;
            }
        }
        private string _Title;
        /// <summary>
        /// 图片标题
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
        /// 提供图片的站点链接
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

    }
}
