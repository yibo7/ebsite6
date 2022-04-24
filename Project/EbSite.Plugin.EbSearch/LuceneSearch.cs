using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager; 
using EbSite.Base.Plugin;
using PanGu;
using PanGu.Match;

namespace EbSite.Plugin.EbSearch
{
    [Extension("基于Lucene的内容搜索", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class LuceneSearch : ISearchEngine
    {
        static private PanGu.Match.MatchOptions _Options = new MatchOptions();
        static private PanGu.Match.MatchParameter _Parameters = new MatchParameter();
        public List<string> SegmentWords(string Content, int Len, int Top)
        {
            //词频优先
            _Options.FrequencyFirst = true;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Segment segment = new Segment();
            ICollection<WordInfo> words = segment.DoSegment(Content, _Options, _Parameters);
            watch.Stop();

            List<string> lstWords = new List<string>();
            int iIndex = 1;
            foreach (WordInfo wordInfo in words)
            {
                string sWord = wordInfo.Word.Trim();
                if (!string.IsNullOrEmpty(sWord))
                {
                    if (!EbSite.Core.Strings.Validate.IsCN(sWord))
                        continue;
                    if (Len > 0)
                    {
                        if (wordInfo.Word.Length < Len)
                            continue;
                    }
                    if (!lstWords.Contains(wordInfo.Word))
                    {
                        lstWords.Add(wordInfo.Word);
                        if (Top > 0)
                        {
                            if (iIndex >= Top)
                                break;
                        }
                        iIndex++;

                    }


                }

                //wordsString.AppendFormat("{0}/", wordInfo.Word);
            }

            return lstWords;

        }
        public object Query(String KeyWord, int PageSize, int PageIndex, out int recCount, string OrderBy,
                                    HttpContext httpContext, int SiteID,out long time)
        {
            Base.LuceneUtils.Content search = new Base.LuceneUtils.Content(SiteID);
            return search.Query(KeyWord, PageSize, PageIndex, out recCount, OrderBy, out time);
        }

        #region 对插件底层接口的实现

        public ExtensionSettings GetSettings()
        {

            string sSettingsName = this.GetType().FullName;
            ExtensionSettings settings = new ExtensionSettings(sSettingsName);
            //settings.AddParameter("InsurancePrice", "保险金额", 100, true, true, ParameterType.String);

            //settings.AddParameter("MoreThanPrice", "满多少免运费", 100, true, true, ParameterType.String);

            settings.Help = ConfigHelpHtml;
            //是否单个
            settings.IsScalar = true;

            PluginManager.Instance.ImportSettings(settings);

            return PluginManager.Instance.GetSettings(sSettingsName);

        }
        private Host HostApi;
        private ExtensionSettings ConfigString;
        /// <summary>
        /// 初始化插件。这是类调用的第一个方法。
        /// </summary>
        /// <param name="host">提供了访问主系统的api</param>
        /// <param name="config">Configuration string for the plugin.</param>
        public void Init(Host host, ExtensionSettings config)
        {
            this.HostApi = host;
            ConfigString = config;
        }

        /// <summary>
        /// 注销插件后将调用此办法
        /// </summary>
        public void Shutdown()
        {

        }

        /// <summary>
        /// HTML文本显示为插件的帮助配置信息
        /// </summary>
        public string ConfigHelpHtml
        {
            get
            {
                return @"基于Lucene的内容搜索。要在后台生成索引";

            }
        }

        #endregion
    }
}
