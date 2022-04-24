
using System;
using System.Web;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Plugin;
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.Entity;

namespace EbSite.Base.Page
{
    public class SearchBase: BasePage
    {
        

        /////////////////////////////////////////////////////////////////////
        //const double CacheDuration = 60.0;//
        //private static readonly string[] MasterCacheKeyArray = { "Search" };
        //private static CacheManager bllCache;
        private ISearchEngine SearchInstance;
        protected virtual int PageIndex
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["p"]))
                    return Convert.ToInt32(Request.QueryString["p"]);
                else
                    return 1;
            }
        }
        

        private string _KeyWord;
        /// <summary>
        /// 搜索的关键词
        /// </summary>
        protected  string KeyWord
        {
            get
            {
                return _KeyWord;
            }
            set
            {
                _KeyWord = Core.Utils.CleanInput(value);
            }
        }

        private int _iSearchCount = 0;
        /// <summary>
        /// 搜索的总记录条数
        /// </summary>
        protected  int iSearchCount
        {
            get
            {
                return _iSearchCount;
                
            }
            set
            {
                _iSearchCount = value;
            }

        }
        /// <summary>
        /// 每页显示多少条记录
        /// </summary>
        protected virtual int iPageSize
        {
            get
            {
                if (!Equals(pgCtr, null) && pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return Configs.ContentSet.ConfigsControl.Instance.PageSizeTagValue;
                }
                
            }
            set{}

        }
        protected global::EbSite.Control.PagesContrl pgCtr;
        protected long searchtime = 0;
        protected object Query(out int iCount,string OrderBy)
        {

           //string sKeyWord = cConvert.ConvertSql(KeyWord);
            string sKeyWord = KeyWord;
            if (ConfigsControl.Instance.IsAddSearchKeyword)
            {
                EbSite.BLL.searchword.AddWordToPool(sKeyWord);
            }

            return SearchInstance.Query(sKeyWord, iPageSize, PageIndex, out iCount, "", HttpContext.Current, GetSiteID, out searchtime); 
        }
        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBase_Load(object sender, EventArgs e)
        {
            //bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
            string stype =  Configs.SysConfigs.ConfigsControl.Instance.GetSearchEngineType(GetSiteID);
            SearchInstance = EbSite.Base.Plugin.Factory.GetSearchEngine(stype);

        }
        
        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBase_LoadComplete(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public SearchBase()
        {
            this.Load += new EventHandler(SearchBase_Load);
            this.LoadComplete += new EventHandler(SearchBase_LoadComplete);
        }

        protected string MakKeyWord(string sContent)
        {
            if (!string.IsNullOrEmpty(sContent) && !string.IsNullOrEmpty(KeyWord))
            {
                return sContent.Replace(KeyWord, string.Format("<span style=\"color:#FF0000\" >{0}</span>", KeyWord));    
            }
            else
            {
                return sContent;
            }
           
            
        }
        //protected string CutContent(string Content, int leng)
        //{
        //    return GetString.CutLen(Content, leng);
        //}
    }
        
}
