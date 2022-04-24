using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Control.xsPage
{
    abstract public class XsPages
    {
        private bool _IsNoFollow = false;
        public bool IsNoFollow
        {
            get { return _IsNoFollow; }
            set { _IsNoFollow = value; }
        }
        private int _iCurrentPage = 0;//当前页码

        private ArrayList _arrCurrentPages = new ArrayList();

        private int _CurrentCode = 5;

        private int _iTotalCount;//记录总数
        private int _iPageSize;   //每页显示的记录数

        private string _ReWritePatchUrl = "../";
        public string ReWritePatchUrl
        {
            get
            {
                return _ReWritePatchUrl;
            }
            set
            {
                _ReWritePatchUrl = value;
            }
        }
        //默认第一页url,如果不设置将采用默认,有时候你可能用index.aspx来替换第一页，这个时候不必再用index.aspx?p=1来访问
        public string FirstPageUrl { get; set; }
        abstract public string showpages(); //页面显示样式

        /// <summary>
        /// 设置页码连接
        /// </summary>
        protected abstract string BuildURL(int PageNumber);
        /// <summary>
        /// 显示多少个页码
        /// </summary>
        public int ShowCodeNum
        {
            get
            {
                return _CurrentCode;
            }
            set
            {
                _CurrentCode = value;
            }
        }
        /// <summary>
        /// 获取当前显示页码数组
        /// </summary>
        protected ArrayList alsCurrentPages
        {
            get
            {
                for (int k = iCurrentPage - ShowCodeNum; k <= iCurrentPage + ShowCodeNum; k++)
                {
                    if (k < 0) continue;
                    if (k >= iPageNum) break;

                    _arrCurrentPages.Add(k);
                }
                return _arrCurrentPages;
            }
        }

        private string _CurrentCss = "active";
        public string CurrentCss
        {
            get
            {
                return _CurrentCss;
            }
            set
            {
                _CurrentCss = value;
            }
        }

        private string _PageClassName = "PageClass";
        /// <summary>
        /// 页码样式
        /// </summary>
        public string PageClassName
        {
            get
            {
                return _PageClassName;
            }
            set
            {
                _PageClassName = value;
            }
        }

        private string _ParentClassName = "PageParent";
        public string ParentClassName
        {
            get
            {
                return _ParentClassName;
            }
            set
            {
                _ParentClassName = value;
            }
        }
        private string _UpPageHtml = "上一页";//<img src=\"/images/Button_11.gif\">
        /// <summary>
        /// 下一页代码
        /// </summary>
        public string UpPageHtml
        {
            get
            {
                return _UpPageHtml;
            }
            set
            {
                _UpPageHtml = value;
            }
        }
        private string _NextPageHtml = "下一页";//<img src=\"/images/Button_10.gif\">
        /// <summary>
        /// 上一页代码
        /// </summary>
        public string NextPageHtml
        {
            get
            {
                return _NextPageHtml;
            }
            set
            {
                _NextPageHtml = value;
            }
        }

        protected string NextPageCss = "nextpage";
        protected string UpPageCss = "uppage";

        private Hashtable _htPrams;
        /// <summary>
        /// 设置页码连接
        /// </summary>
        public Hashtable htPrams
        {
            get
            {
                return _htPrams;
            }
            set
            {
                _htPrams = value;
            }
        }
        /// <summary>
        /// 设置当前页码
        /// </summary>
        public int iCurrentPage
        {
            get
            {
                return _iCurrentPage;
            }
            set
            {
                _iCurrentPage = value;
            }
        }
        /// <summary>
        /// 设置每页显示的记录数
        /// </summary>
        public int iPageSize
        {
            get
            {
                return _iPageSize;
            }
            set
            {
                _iPageSize = value;
            }
        }
        /// <summary>
        /// 设置记录总数
        /// </summary>
        public int iTotalCount
        {
            get
            {
                return _iTotalCount;
            }
            set
            {
                _iTotalCount = value;
            }
        }
        /// <summary>
        /// 算出总共多少页
        /// </summary>
        public int iPageNum
        {
            get
            {
                if (_iTotalCount <= 0 || _iPageSize <= 0)
                    return 1;
                else
                    return ((_iTotalCount + _iPageSize) - 1) / _iPageSize;
            }
        }

        protected string GetHref(string sText,string sUrl)
        { 
            return GetHref(sText, sUrl,"");
        }
        protected string GetHref(string sText, string sUrl,string sClass)
        {
            return string.Format("<a {3} href=\"{0}\" {1}>{2}</a>", sUrl, IsNoFollow ? "rel=\"nofollow\"" : "", sText,string.IsNullOrEmpty(sClass)?"": string.Format("class=\"{0}\"", sClass));
        }

    }
}
