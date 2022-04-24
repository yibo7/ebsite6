using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
//using EbSite.Core.Static.OneCreatManager;

/// <summary>
    /// Converts BBCode to XHTML in the comments.
    /// </summary>
    [Extension("生成静态页面前的某些处理-清除换行", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class HtmlMakeClear
    {
        static protected ExtensionSettings _settings = null;
        /**/
        /// <summary>
        /// Hooks up an event handler to the Post.Serving event.
        /// </summary>
        static HtmlMakeClear()
        {
               
            EbSite.Base.EBSiteEvents.HTMLMakeing += new EventHandler<MakeingEventArgs>(On_MakeHtmling);
        }

        /**/
        /// <summary>
        /// Handles the Post.Serving event to take care of logging IP.
        /// </summary>
        private static void On_MakeHtmling(object sender, MakeingEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Html))
            {
                
                e.Html = ClearBack(e.Html);
            }
        }

        /// <summary>
        /// 去掉字符串里的回车换行 空格
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string ClearBack(string strContent)
        {
            string strNew = strContent;
            strNew = strNew.Replace("\r", "");
            strNew = strNew.Replace("\n", "");
            strNew = strNew.Replace("\t", "");

            System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("\\s\\s\\s\\s\\s");
            strNew = rx.Replace(strNew, string.Empty);

            return strNew;
        }

    }