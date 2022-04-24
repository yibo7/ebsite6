using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using EbSite.BLL;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using NewsContent = EbSite.Entity.NewsContent;
using System.IO;
using System.Linq;
using EbSite.Base.EBSiteEventArgs;

/// <summary>
/// Converts BBCode to XHTML in the comments.
/// </summary>
[Extension("防复制采集停用词替换", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
public class StopwordsReplace
{

    
    static protected ExtensionSettings _settings = null;
    //static private  Dictionary<string, string> lstDictionary ;
    //static private string[] aKeyWords;
    static private Dictionary<string,string> dicKeyWords;
    static StopwordsReplace()
    {
       
        EbSite.Base.EBSiteEvents.ContentShowEvent += new EventHandler<ContentShowEventArgs>(Post_Serving);

     
        string[] aKeyWord = new[] { "了", "多", "，", "一", "不", "！", "是", "的", "上", "少", "左", "右", "高", "。", "低", "下", "着", "好", "很", "小" };
        dicKeyWords = new Dictionary<string, string>();
        for (int i = 0; i < aKeyWord.Length; i++)
        {
            dicKeyWords.Add(aKeyWord[i], string.Concat("hs_kw",i));
        }
      
       
        //词库表每行一对，用*号分开
        //string  filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Code\\Plugins\\StopwordsReplace.txt");
        //string sKeyWords = EbSite.Core.FSO.FObject.ReadFile(filename);
        //string[] keys = EbSite.Core.Strings.GetString.GetArrByWrap(sKeyWords);

        //aKeyWords = keys.Distinct().ToArray();

        //string filejs =  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "themes\\stwrp.js");
        //StringBuilder sbJs = new StringBuilder("var Stopwords=[");
        //foreach (var key in aKeyWords)
        //{
        //    sbJs.AppendFormat("'{0}',",key);
        //}
        //if (sbJs.Length > 1)
        //    sbJs.Remove(sbJs.Length - 1, 1);
        //sbJs.Append("];$(function() {for (var i = 0; i < Stopwords.length; i++) {$(\".stwd\" + i).replaceWith(Stopwords[i]);}});");

        //EbSite.Core.FSO.FObject.WriteFileUtf8(filejs, sbJs.ToString());

        string sSettingsName = "StopwordsReplace";//(注意，注意)要与类名相同,否则无法生成相关配置
        ExtensionSettings settings = new ExtensionSettings(sSettingsName);


        //ParameterType 内容控件类别
        //settings.AddParameter("KeyWordNum", "最多替换几个词", 10, true, false, ParameterType.Integer);
        //settings.AddParameter("ReplaceColor", "替换后着色", 10, true, false, ParameterType.Boolean);
        settings.Help = @"显示文章时停用词替换";
        settings.IsScalar = true;

        ExtensionManager.Instance.ImportSettings(settings);

        _settings = ExtensionManager.Instance.GetSettings(sSettingsName);

        //EbSite.Log.Factory.GetInstance().InfoLog("有同义词:"+lstDictionary.Count);

    }

    private static void Post_Serving(object sender, ContentShowEventArgs e)
    {

        if (e.ContentID > 0 && !string.IsNullOrEmpty(e.ShowInfo) )
        {

            string ShowInf = e.ShowInfo;
            foreach (var model in dicKeyWords)
            {
                ShowInf = Regex.Replace(ShowInf, @"(?is)(?<!title=[""'][^""']*?)(?is)(?<!alt=[""'][^""']*?)" + model.Key, string.Format("<span class=\"{0}\"></span>", model.Value));
            }
            //for (int i = 0; i < aKeyWords.Length; i++)
            //{
            //    string key = aKeyWords[i];
            //    if (!string.IsNullOrEmpty(key))
            //    {
            //        //不替换title,atl里的内容
            //        ShowInf = Regex.Replace(ShowInf, @"(?is)(?<!title=[""'][^""']*?)(?is)(?<!alt=[""'][^""']*?)" + key, string.Format("<span class=\"stwd{0}\"></span>", i));
            //    }
            //        //ShowInf =  ShowInf.Replace(key, string.Format("<span class=\"stwd{0}\"></span>", i));
            //}
            e.ShowInfo = ShowInf;
        }
    }
     
}

 