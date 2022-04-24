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
    [Extension("订制搜索条件", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class CusttomAskSearch
    {
        static protected ExtensionSettings _settings = null;
        /**/
        /// <summary>
        /// Hooks up an event handler to the Post.Serving event.
        /// </summary>
        static CusttomAskSearch()
        {

            EbSite.Base.EBSiteEvents.Searching += new EventHandler<SearchEventArgs>(On_Searching);
        }

        /**/
        /// <summary>
        /// 搜索之前可以进行一些业务处理
        /// </summary>
        private static void On_Searching(object sender, SearchEventArgs e)
        {      
            if (!string.IsNullOrEmpty(e.KeyWord))
            {
                 //e.KeyWord 当前搜索的关键词
                //e.Context  当前搜索的上下文        
                string strsql = "";
                string sType = e.Context.Request["askt"];
               

                if (!string.IsNullOrEmpty(sType))
                {
                    if (sType == "1") //悬赏问题
                    {     
                        strsql =  " Annex1>= " + 1;
                    }
                    if (sType == "2")//待解决
                    {             
                        strsql = " Annex4= " + 1;
                    }
                    if (sType == "3")//已解决
                    {               
                        strsql = " Annex4= " + 2;
                    }
                    e.Where = strsql;
                }
            }            
        }
    }