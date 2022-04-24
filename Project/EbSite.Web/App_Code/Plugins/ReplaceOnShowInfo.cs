using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using System.Text.RegularExpressions;
/// <summary>
/// Converts BBCode to XHTML in the comments.
/// </summary>
[Extension("在文章展示时替换文字链", "1.5", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class ReplaceOnShowInfo
{
        static protected ExtensionSettings _settings = null;
        /**/
        /// <summary>
        /// Hooks up an event handler to the Post.Serving event.
        /// </summary>
        static ReplaceOnShowInfo()
        {

            
            EbSite.Base.EBSiteEvents.ContentShowEvent += new EventHandler<ContentShowEventArgs>(Post_Serving);

            //要与类名相同,否则无法生成相关配置
            string sSettingsName = "ReplaceOnShowInfo";
            ExtensionSettings settings = new ExtensionSettings(sSettingsName);

            settings.AddParameter("KeyWord", "添加关键字", 100, true, true);
            settings.AddParameter("Url", "添加连接", 150, true);
            settings.AddParameter("Description", "描述（可选）");

            settings.Help = @"可以在内容发布时给一些关键字加上连接";

            ExtensionManager.Instance.ImportSettings(settings);
            _settings = ExtensionManager.Instance.GetSettings(sSettingsName);
              table = _settings.GetDataTable();
    }

     private static DataTable table;
        /**/
        /// <summary>
        /// Handles the Post.Serving event to take care of logging IP.
        /// </summary>
    private static void Post_Serving(object sender, ContentShowEventArgs e)
        {
        
        if (e.ContentID > 0&&!string.IsNullOrEmpty(e.ShowInfo)&&!Equals(table,null))
            {
            
            string ShowInf = e.ShowInfo;
            
                foreach (DataRow row in table.Rows)
                {
               
                    if (!string.IsNullOrEmpty((string)row["KeyWord"]) && !string.IsNullOrEmpty((string)row["Url"]))
                        {
                   
                        string sKey = row["KeyWord"].ToString();
                            string sUrl = row["Url"].ToString();
                            string sDescriptionUrl = row["Description"].ToString();

                   
                    Regex r = new Regex(sKey);
                    e.ShowInfo  = r.Replace(ShowInf, string.Format("<a title=\"{2}\" href='{0}' style='color:#ff0000' target=_blank>{1}</a>", sUrl, sKey, sDescriptionUrl), 1);

                    //e.ShowInfo = ShowInf.Replace(sKey,string.Format("<a title=\"{2}\" href='{0}' target=_blank>{1}</a>", sUrl, sKey, sDescriptionUrl));
                        //EbSite.Core.Log.LoggerOfDebug.Debug(ShowInf);
                    }

                }
            }
        }
       

    }