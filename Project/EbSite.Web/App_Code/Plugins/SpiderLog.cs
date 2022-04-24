using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using Amib.Threading;
using EbSite.Base;
using EbSite.Base.DataProfile;
using EbSite.BLL;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using MySql.Data.MySqlClient;
using NewsContent = EbSite.Entity.NewsContent;

/// <summary>
/// Converts BBCode to XHTML in the comments.
/// </summary>
[Extension("记录搜索引擎蜘蛛来访", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
public class SpiderLog
{


    static protected ExtensionSettings _settings = null;
   
    /// <summary>
    /// Hooks up an event handler to the Post.Serving event.
    /// </summary>
    static SpiderLog()
    {
        EBSiteEvents.ApplicationBeginRequest += new EventHandler<EventArgs>(On_SpiderFrom);
        lst = EbSite.BLL.IISLOG.SpiderBll.Instance.FillList();

    }

    static protected void On_SpiderFrom(object sender, EventArgs e)
    {
        HttpApplication app = (HttpApplication)sender;
        HttpContext context = app.Context;
        string sUserAgent = context.Request.UserAgent;
        DataInfo data = new DataInfo();
        data.Url = context.Request.Url.ToString();
        data.UserAgent = sUserAgent;
        data.HttpState = context.Response.StatusCode;
        IWorkItemResult wir = ThreadPoolManager.Instance.QueueWorkItem(new WorkItemCallback(AddLog), data);
    }

    private static object AddLog(object model)
    {
        DataInfo data = model as  DataInfo;
        if (!Equals(data, null))
        {
            
            EbSite.BLL.IISLOG.SpiderEntity mdSpiderEntity = GetSpider(data.UserAgent);
            if (!Equals(mdSpiderEntity, null))
            {
                string sUrlPath = "";
                string sDomain = "";
                if (!string.IsNullOrEmpty(data.Url))
                {
                    List<string> strsList = EbSite.Core.Strings.GetString.RegexFinds(@"(?<=[^/]/)[^/]+(?=/)", data.Url, 0);
                    if (strsList.Count > 0)
                        sUrlPath = strsList[0];
                    strsList = EbSite.Core.Strings.GetString.RegexFinds(@"(?<=http://)[\w\.]+[^/]", data.Url, 0);
                    if (strsList.Count > 0)
                        sDomain = strsList[0];
                }
                


                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("insert into {0}spiderlog(", EbSite.Base.Host.Instance.GetSysTablePrefix);
                strSql.Append("SpiderName,SpiderId,Url,AddDateTime,AddDateTimeInt,UserAgent,HttpState,UrlPath,Domain)");
                strSql.Append(" values (");
                strSql.Append("?SpiderName,?SpiderId,?Url,?AddDateTime,?AddDateTimeInt,?UserAgent,?HttpState,?UrlPath,?Domain)");
                strSql.Append(";SELECT @@session.identity");
                MySqlParameter[] parameters = {
                    new MySqlParameter("?SpiderName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?SpiderId", MySqlDbType.Int32,11),
                    new MySqlParameter("?Url", MySqlDbType.VarChar,300),
                    new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
                    new MySqlParameter("?AddDateTimeInt", MySqlDbType.Bit,20),
                    new MySqlParameter("?UserAgent", MySqlDbType.VarChar,500),
                     new MySqlParameter("?HttpState", MySqlDbType.Int32,3),
                      new MySqlParameter("?UrlPath", MySqlDbType.VarChar,255),
                       new MySqlParameter("?Domain", MySqlDbType.VarChar,255)
                };
                parameters[0].Value = mdSpiderEntity.SpiderCnName;
                parameters[1].Value = mdSpiderEntity.id;
                parameters[2].Value = data.Url;
                parameters[3].Value = DateTime.Now;
                parameters[4].Value = EbSite.Core.SqlDateTimeInt.GetSecond(DateTime.Now);
                parameters[5].Value = data.UserAgent;
                parameters[6].Value = data.HttpState;
                parameters[7].Value = sUrlPath;
                parameters[8].Value = sDomain;

                DbHelperCms.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            }
        }
        
        return 1;
    }
    private static List<EbSite.BLL.IISLOG.SpiderEntity> lst;
    /// <summary>  
    /// 获取蜘蛛名称  
    /// </summary>  
    /// <param name="userAgent">user-agent header</param>  
    /// <returns>返回已知蜘蛛名称</returns>  
    private static EbSite.BLL.IISLOG.SpiderEntity GetSpider(string userAgent)
    {
        
        foreach (EbSite.BLL.IISLOG.SpiderEntity model in lst)
        {
            if (ContainsAny(userAgent, model.SpiderEnName))
                return model;
        }

        return null;

    }
    //包含任意，用于在指定的文本中，包含其中一个文本就返回true  
    private static bool ContainsAny(string text, params string[] values)
    {
        if (string.IsNullOrEmpty(text))
            return false;
        if (values == null || values.Length == 0)
            return false;
        bool result = false;
        foreach (var item in values)
        {
            if (text.IndexOf(item, StringComparison.OrdinalIgnoreCase) != -1)
            {
                result = true;
                break;
            }
        }

        return result;
    }

}

public class DataInfo
{
    public string Url { get; set; }
    public string UserAgent { get; set; }
    public int HttpState { get; set; }
}