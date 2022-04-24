using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using EbSite.Base;
using EbSite.Base.DataProfile;
using EbSite.Base.EntityAPI;
using EbSite.Base.Extension;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;
using EbSite.Base.Plugin.Base;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Modules.BBS.ModuleCore.BLL;
using MySql.Data.MySqlClient;

namespace EbSite.Plugin.TimerTask
{

    public class SiteTask
    {
        public string ClassName { get; set; }
        public int ClassID { get; set; }
        public string StartTagTitle { get; set; }
        public string EndTagTitle { get; set; } 
        public string ListUrlRule { get; set; }
        public string SoureUrl { get; set; }
        public string TitleRule { get; set; } 
        public Dictionary<string,string> ReplaceTitle { get; set; } 
        public List<ContentTag>  ContentTags { get; set; }
    }

    public class ContentTag
    {
        public string Value { get; set; }
        public string TagName { get; set; }
        public string StartTag { get; set; }
        public string EndTag { get; set; }
        public string Rule { get; set; }
        public Dictionary<string, string> ReplaceTag { get; set; } 
    }   

    public class SiteInfo
    {
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }

        public List<SiteTask> SiteTasks { get; set; } 
    }

    [Extension("定时采集更新", "1.0", "<a href=\"http://www.ebsite.net\">小菜菜</a>")]
    public class BBSGet : ITimerTask
    {

        public ETimeSpanModel TimeSpanType
        {
            get { return ETimeSpanModel.FZ; }
        }
        public int Times
        {
            get { return 30; }
        }
        /// <summary>
        /// 处理定时执行的任务
        /// </summary>
        public void CallTask()
        {
            Sites = new List<SiteInfo>();
            SiteTask st = new SiteTask();
            st.SoureUrl = "http://www.bskk.com/forum-1-1.html";
            st.StartTagTitle = "版块主题</a></th><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>";
            st.EndTagTitle = "<!-- end of table";
            st.ListUrlRule = "thread-([0-9]+)-([0-9]+)-([0-9]+).html";
            st.TitleRule = "<span id=\"thread_subject\">(.*)</span>";

            st.ClassID = 12551;
            st.ClassName = "新产品发布 ";

            List<ContentTag> cts = new List<ContentTag>();
            ContentTag ct = new ContentTag();
            ct.TagName = "标题";
            ct.StartTag = "<span id=\"thread_subject\">";
            ct.EndTag = "</span>";
            cts.Add(ct);

             ct = new ContentTag();
            ct.TagName = "内容";
            ct.StartTag = "<table cellspacing=\"0\" cellpadding=\"0\"><tr><td class=\"t_f\"";
            ct.EndTag = "</td></tr></table>";
            cts.Add(ct);

            st.ContentTags = cts;

            List<SiteTask>  sts = new List<SiteTask>();
            sts.Add(st);

            Sites.Add(new SiteInfo() { SiteName = "bskk", SiteUrl = "http://www.bskk.com", SiteTasks = sts});

            foreach (var siteInfo in Sites)
            {
                foreach (SiteTask stTask in siteInfo.SiteTasks)
                {
                    string GetContent = Core.WebUtility.LoadURLString(stTask.SoureUrl);
                    List<string> ListUrls = new List<string>();
                    if (!string.IsNullOrEmpty(GetContent))
                    {
                        if (!string.IsNullOrEmpty(stTask.StartTagTitle) && !string.IsNullOrEmpty(stTask.EndTagTitle))
                        {
                            GetContent = Core.Strings.GetString.GetMidValue(GetContent, stTask.StartTagTitle,
                                stTask.EndTagTitle);
                        }

                        MatchCollection mcs = Regex.Matches(GetContent, stTask.ListUrlRule);

                         for (int i = 0; i < mcs.Count; i++)
                         {
                             string surl = string.Concat(siteInfo.SiteUrl, "/", mcs[i].Value);
                             if (!ListUrls.Contains(surl))
                                ListUrls.Add(surl);
                         }

                      
                    }

                    foreach (string url in ListUrls)
                    {

                        if (!ExistUrl(url))
                        {
                            List<ContentTag> ctgs = GetTags(url, stTask.ContentTags);

                            string sTitle = ctgs[0].Value;
                            string sContent = ctgs[1].Value;

                            SavePost(sTitle, sContent, stTask.ClassID, stTask.ClassName);

                            AddUrl(url);
                        }
                       
                         

                      

                    }

                  //List<string> Urls =   GetUrls(GetContent, stTask.ListUrlRule);

                  //  if (Urls.Count > 0)
                  //  {
                        
                  //  }

                }
            }
        }
        public bool ExistUrl(string url)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  gather");
            strSql.Append(" where url=?url ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?url",  MySqlDbType.VarChar,225)};
            parameters[0].Value = url;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }
        public void AddUrl(string url)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into gather(");
            strSql.Append("url)");
            strSql.Append(" values (");
            strSql.Append("?url)");
            MySqlParameter[] parameters = { 
                    new MySqlParameter("?url",MySqlDbType.VarChar,225)
                                        };
            parameters[0].Value = url;
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
           
        }

        private int imitateuserid = 1;
        private int isiteid = 8;
        private void SavePost(string title, string Content,int ClassID,string ClassName)
        {

            EbSite.Entity.NewsContent mdContent = new EbSite.Entity.NewsContent();
            mdContent.NewsTitle = title;
            mdContent.ContentInfo = Content;
            mdContent.ClassID = ClassID;
            mdContent.ClassName = ClassName;
            mdContent.Annex1 = Core.Utils.GetClientIP();
            mdContent.AddTime = DateTime.Now;
            mdContent.Annex4 = DateTime.Now.ToString();//最后回复时间
            mdContent.Annex21 = 1; 

            EbSite.Modules.BBS.ModuleCore.Entity.imitateuser mdimitateuser = imitateuser.Instance.GetRandByUserID(imitateuserid);
            if (!Equals(mdimitateuser, null)) //模拟发帖
            {
                if (mdimitateuser.UserID > 0)
                {
                    mdContent.UserID = mdimitateuser.ImitateUserID;
                    mdContent.UserName = mdimitateuser.ImitateUserName;
                    mdContent.UserNiName = mdimitateuser.ImitateUserRealName;
                    //默认初始化当前用户为最后回复人
                    mdContent.Annex2 = mdimitateuser.ImitateUserRealName; //最后回复人姓名
                    mdContent.Annex3 = mdimitateuser.ImitateUserID.ToString();//最后回复人ID
                    EbSite.Entity.NewsClass mdClass = BLL.NewsClass.GetModelByCache(ClassID);

                    long postid = EbSite.Base.AppStartInit.GetNewsContentInst(ClassID).AddBLL(mdContent, -1, true, isiteid, mdClass.ContentModelID);
                    if (postid > 0)
                    {
                        BBSClass.UpdateCountAddOne(mdContent.ClassID, true, postid, mdContent.NewsTitle, mdimitateuser.ImitateUserID, mdimitateuser.ImitateUserRealName);
                        
                    }
                }

            }
             
            
        }

        private List<ContentTag> GetTags(string ContentUrl, List<ContentTag> cts)
        {
            string GetContent = Core.WebUtility.LoadURLString(ContentUrl);
            foreach (ContentTag ct in cts)
            {
                string SoureCode = GetContent;
                if (!string.IsNullOrEmpty(ct.StartTag) && !string.IsNullOrEmpty(ct.EndTag))
                {
                    SoureCode = Core.Strings.GetString.GetMidValue(GetContent, ct.StartTag, ct.EndTag);
                }
                if (!string.IsNullOrEmpty(SoureCode))
                {
                    if (!string.IsNullOrEmpty(ct.Rule))
                    {
                        string v = Core.Strings.GetString.RegexFind(ct.Rule, SoureCode);
                        ct.Value = v;
                    }
                    else
                    {
                        ct.Value = SoureCode;
                    }
                      
                }
            }

            return cts;
        }

        #region 对插件底层接口的实现

        public ExtensionSettings GetSettings()
        {

            string sSettingsName = this.GetType().FullName;



            ExtensionSettings settings = new ExtensionSettings(sSettingsName);


            //settings.AddParameter("Description", "条款", 300, true, true, ParameterType.StringMax);
            //settings.AddParameter("ImgUpload", "图片上传", 300, true, true, ParameterType.Upload);
            //settings.Help = ConfigHelpHtml;
            ////是否单个
            //settings.IsScalar = true;

            PluginManager.Instance.ImportSettings(settings);

            return PluginManager.Instance.GetSettings(sSettingsName);

        }
        private Host HostApi;
        private ExtensionSettings ConfigString;
        private List<SiteInfo> Sites;
        /// <summary>
        /// 初始化插件。这是类调用的第一个方法。
        /// </summary>
        /// <param name="host">提供了访问主系统的api</param>
        /// <param name="config">Configuration string for the plugin.</param>
        public void Init(Host host, ExtensionSettings config)
        {
            this.HostApi = host;
            ConfigString = config;

          

            //ConfigString.GetSingleValue("Description");
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
                return @"
<div>
  <b>使用帮助:</b><br/>
  <ul>
    <li>在后台安装后，可以在系统的配置里选择。</li>
  </ul>
</div>
      ";
            }
        }

        #endregion
        
    }



}
