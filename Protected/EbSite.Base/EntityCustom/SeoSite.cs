using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Base.EntityCustom
{
    [Serializable]
    public class SeoSite : XmlEntityBase<int>
    {
        #region seo

        private string _SeoClassTitle = string.Empty;
        private string _SeoClassKeyWord = string.Empty;
        private string _SeoClassDes = string.Empty;

        private string _SeoSpecialTitle = string.Empty;
        private string _SeoSpecialKeyWord = string.Empty;
        private string _SeoSpecialDes = string.Empty;

        private string _SeoContentTitle = string.Empty;
        private string _SeoContentKeyWord = string.Empty;
        private string _SeoContentDes = string.Empty;

        private string _SeoTagIndexTitle = string.Empty;
        private string _SeoTagIndexKeyWord = string.Empty;
        private string _SeoTagIndexDes = string.Empty;

        private string _SeoTagListTitle = string.Empty;
        private string _SeoTagListKeyWord = string.Empty;
        private string _SeoTagListDes = string.Empty;


        private string _SeoSiteIndexTitle = string.Empty;
        private string _SeoSiteIndexKeyWord = string.Empty;
        private string _SeoSiteIndexDes = string.Empty;

        private int _SiteID;


        /// <summary>
        /// 网站首页Seo标题规则
        /// </summary>
        public string SeoSiteIndexTitle
        {
            get
            {
                return _SeoSiteIndexTitle;
            }
            set
            {
                _SeoSiteIndexTitle = value;
            }
        }
        /// <summary>
        /// 网站首页Seo关键词规则
        /// </summary>
        public string SeoSiteIndexKeyWord
        {
            get
            {
                return _SeoSiteIndexKeyWord;
            }
            set
            {
                _SeoSiteIndexKeyWord = value;
            }
        }
        /// <summary>
        /// 网站首页Seo描述规则
        /// </summary>
        public string SeoSiteIndexDes
        {
            get
            {
                return _SeoSiteIndexDes;
            }
            set
            {
                _SeoSiteIndexDes = value;
            }
        }




        /// <summary>
        /// 标签列表页Seo标题规则
        /// </summary>
        public string SeoTagListTitle
        {
            get
            {
                return _SeoTagListTitle;
            }
            set
            {
                _SeoTagListTitle = value;
            }
        }
        /// <summary>
        /// 标签列表页Seo关键词规则
        /// </summary>
        public string SeoTagListKeyWord
        {
            get
            {
                return _SeoTagListKeyWord;
            }
            set
            {
                _SeoTagListKeyWord = value;
            }
        }
        /// <summary>
        /// 标签列表页Seo描述规则
        /// </summary>
        public string SeoTagListDes
        {
            get
            {
                return _SeoTagListDes;
            }
            set
            {
                _SeoTagListDes = value;
            }
        }


        /// <summary>
        /// 标签主页Seo标题规则
        /// </summary>
        public string SeoTagIndexTitle
        {
            get
            {
                return _SeoTagIndexTitle;
            }
            set
            {
                _SeoTagIndexTitle = value;
            }
        }
        /// <summary>
        /// 标签主页Seo关键词规则
        /// </summary>
        public string SeoTagIndexKeyWord
        {
            get
            {
                return _SeoTagIndexKeyWord;
            }
            set
            {
                _SeoTagIndexKeyWord = value;
            }
        }
        /// <summary>
        /// 标签主页Seo描述规则
        /// </summary>
        public string SeoTagIndexDes
        {
            get
            {
                return _SeoTagIndexDes;
            }
            set
            {
                _SeoTagIndexDes = value;
            }
        }

        /// <summary>
        /// 分类Seo标题规则
        /// </summary>
        public string SeoClassTitle
        {
            get
            {
                return _SeoClassTitle;
            }
            set
            {
                _SeoClassTitle = value;
            }
        }
        /// <summary>
        /// 分类Seo关键词规则
        /// </summary>
        public string SeoClassKeyWord
        {
            get
            {
                return _SeoClassKeyWord;
            }
            set
            {
                _SeoClassKeyWord = value;
            }
        }
        /// <summary>
        /// 分类Seo描述规则
        /// </summary>
        public string SeoClassDes
        {
            get
            {
                return _SeoClassDes;
            }
            set
            {
                _SeoClassDes = value;
            }
        }
        /// <summary>
        /// 专题Seo标题规则
        /// </summary>
        public string SeoSpecialTitle
        {
            get
            {
                return _SeoSpecialTitle;
            }
            set
            {
                _SeoSpecialTitle = value;
            }
        }
        /// <summary>
        /// 专题Seo关键词规则
        /// </summary>
        public string SeoSpecialKeyWord
        {
            get
            {
                return _SeoSpecialKeyWord;
            }
            set
            {
                _SeoSpecialKeyWord = value;
            }
        }
        /// <summary>
        /// 专题Seo描述规则
        /// </summary>
        public string SeoSpecialDes
        {
            get
            {
                return _SeoSpecialDes;
            }
            set
            {
                _SeoSpecialDes = value;
            }
        }
        /// <summary>
        /// 内容Seo标题规则
        /// </summary>
        public string SeoContentTitle
        {
            get
            {
                return _SeoContentTitle;
            }
            set
            {
                _SeoContentTitle = value;
            }
        }
        /// <summary>
        /// 内容Seo关键词规则
        /// </summary>
        public string SeoContentKeyWord
        {
            get
            {
                return _SeoContentKeyWord;
            }
            set
            {
                _SeoContentKeyWord = value;
            }
        }
        /// <summary>
        /// 内容Seo描述规则
        /// </summary>
        public string SeoContentDes
        {
            get
            {
                return _SeoContentDes;
            }
            set
            {
                _SeoContentDes = value;
            }
        }
        /// <summary>
        /// 站点ID
        /// </summary>
        public int SiteID
        {
            get
            {
                return _SiteID;
            }
            set
            {
                _SiteID = value;
            }
        }
        #endregion
    }
}
