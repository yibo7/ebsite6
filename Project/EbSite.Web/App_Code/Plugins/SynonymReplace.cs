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
/// <summary>
/// Converts BBCode to XHTML in the comments.
/// </summary>
[Extension("添加文章时替换同义词", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
public class SynonymReplace
{

    
    static protected ExtensionSettings _settings = null;
    static private  Dictionary<string, string> lstDictionary ;
   
    static SynonymReplace()
    {
        EbSite.Base.EBSiteEvents.ContentAdding += new EventHandler<EbSite.Base.EBSiteEventArgs.AddingContentEventArgs>(On_Adding);
        //去掉此注,修改文章也将被替换
        //EbSite.Base.EBSiteEvents.ContentUpdateing += new EventHandler<EbSite.Base.EBSiteEventArgs.UpdateingContentEventArgs>(On_Updateing);

        lstDictionary = new Dictionary<string, string>();
        //词库表每行一对，用*号分开
        string  filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Code\\Plugins\\SynonymReplace.txt");
        string sKeyWords = EbSite.Core.FSO.FObject.ReadFile(filename);
        string[] aKeyWords = EbSite.Core.Strings.GetString.GetArrByWrap(sKeyWords);
        foreach (string s in aKeyWords)
        {
            string[] SynonymKey = s.Split('*');
            if (SynonymKey.Length == 2)
            {
                string sSourKey = SynonymKey[0];
                if(!lstDictionary.ContainsKey(sSourKey))
                    lstDictionary.Add(sSourKey, SynonymKey[1]);
            }
        }

        string sSettingsName = "SynonymReplace";
        ExtensionSettings settings = new ExtensionSettings(sSettingsName);


        //ParameterType 内容控件类别
        settings.AddParameter("KeyWordNum", "最多替换几个词", 10, true, false, ParameterType.Integer);
        settings.AddParameter("ReplaceColor", "替换后着色", 10, true, false, ParameterType.Boolean);
        settings.Help = @"添加文章时替换同义词";
        settings.IsScalar = true;

        ExtensionManager.Instance.ImportSettings(settings);

        _settings = ExtensionManager.Instance.GetSettings(sSettingsName);

        //EbSite.Log.Factory.GetInstance().InfoLog("有同义词:"+lstDictionary.Count);

    }

    private static void On_Updateing(object sender, EbSite.Base.EBSiteEventArgs.UpdateingContentEventArgs e)
    {
        EbSite.Entity.NewsContent nc = (EbSite.Entity.NewsContent)sender;

        ToReplace(nc);
    }

    /**/
    /// <summary>
    /// Handles the Post.Serving event to take care of logging IP.
    /// </summary>
    private static void On_Adding(object sender, EbSite.Base.EBSiteEventArgs.AddingContentEventArgs e)
    {
        EbSite.Entity.NewsContent nc = (EbSite.Entity.NewsContent)sender;

        ToReplace(nc);
    }

    private static void ToReplace(EbSite.Entity.NewsContent nc)
    {
        if (!Equals(nc, null))
        {
            //e.StopAdd = true;//阻住当前的添加操作
            if (!string.IsNullOrEmpty(nc.ContentInfo))
            {
                //EbSite.Base.Host.Instance.SegmentWords(nc.ContentInfo,2,)
                int iIndex = 0;
                int iReplaceNum =   EbSite.Core.Utils.StrToInt(_settings.GetSingleValue("KeyWordNum"), 10); 
                bool blReplaceColor = EbSite.Core.Utils.StrToBool(_settings.GetSingleValue("ReplaceColor").ToString(),false);
                foreach (var kewors in lstDictionary)
                {
                    if (kewors.Key.Length > 1&& nc.ContentInfo.IndexOf(kewors.Key)>-1)
                    {
                        if (!blReplaceColor)
                        {
                            nc.ContentInfo = nc.ContentInfo.Replace(kewors.Key, string.Format("{0}", kewors.Value));
                        }
                        else
                        {
                            nc.ContentInfo = nc.ContentInfo.Replace(kewors.Key, string.Format("<font color=\"#0066CC\">{0}</font>", kewors.Value));
                        }
                            
                        iIndex++;
                    }
                    if(iIndex> iReplaceNum)   
                        break;
                }
            }

        }
    }

}

 