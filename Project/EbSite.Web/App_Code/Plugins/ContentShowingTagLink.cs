using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using System.Text.RegularExpressions;
using EbSite.Data.Interface;

/// <summary>
/// Converts BBCode to XHTML in the comments.
/// </summary>
[Extension("在文章展示适配标签链接", "1.5", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class ContentShowingTagLink
{
    static protected ExtensionSettings _settings = null;
    static ContentShowingTagLink()
        {
            
            EbSite.Base.EBSiteEvents.ContentShowEvent += new EventHandler<ContentShowEventArgs>(Post_Serving);

        string sSettingsName = "ContentShowingTagLink";//(注意，注意)要与类名相同,否则无法生成相关配置
        ExtensionSettings settings = new ExtensionSettings(sSettingsName);


        //ParameterType 内容控件类别
        settings.AddParameter("KeyWordNum", "替换几个词", 10, true, false, ParameterType.Integer);
        settings.AddParameter("SourWordNum", "分词数", 10, true, false, ParameterType.Integer);
        settings.AddParameter("SourWordLen", "分词长度", 10, true, false, ParameterType.Integer);
        settings.Help = @"在文章展示时替换关键词链接到相应的专题";
        settings.IsScalar = true;

        ExtensionManager.Instance.ImportSettings(settings);

        _settings = ExtensionManager.Instance.GetSettings(sSettingsName);

    }
     
        /**/
        /// <summary>
        /// Handles the Post.Serving event to take care of logging IP.
        /// </summary>
    private static void Post_Serving(object sender, ContentShowEventArgs e)
        {
        
        if (e.ContentID > 0&&!string.IsNullOrEmpty(e.ShowInfo))
            {
            int iSourWordNum = EbSite.Core.Utils.StrToInt(_settings.GetSingleValue("SourWordNum"), 50);
            int iSourWordLen = EbSite.Core.Utils.StrToInt(_settings.GetSingleValue("SourWordLen"), 4);

            string sShowInfo = e.ShowInfo;
            //分词至少3个字，返回前50个
            List<string> sp = EbSite.Base.Host.Instance.SegmentWords(sShowInfo, iSourWordLen, iSourWordNum);
            if (sp.Count > 1)
            {
                int iKeyWordNum = EbSite.Core.Utils.StrToInt(_settings.GetSingleValue("KeyWordNum"), 3);
                string sWords = string.Join("','", sp.ToArray());
                string sWhere = string.Format(" TagName in('{0}')", sWords);
                
                List<EbSite.Entity.TagKey> lst =  DbProviderCms.GetInstance().TagKey_GetListArr(sWhere, iKeyWordNum, "", EbSite.Base.Host.Instance.GetSiteID, 5);//内容至少有5条

                foreach (var model in lst)
                {
                    string sKey = model.TagName;
                    string sUrl = EbSite.Base.Host.Instance.TagsSearchList(model.id,1);
                    string sTips = model.TagName;


                    Regex r = new Regex(sKey);
                    e.ShowInfo = r.Replace(sShowInfo, string.Format("<a  href='{0}' style='color:#ff0000' target=_blank>{1}</a>", sUrl, sKey), 1);
                }
             

            }
             
        }
        }
       

    }