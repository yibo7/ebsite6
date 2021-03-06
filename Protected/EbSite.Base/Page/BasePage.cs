
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using EbSite.BLL;
using EbSite.BLL.User;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.EntityCustom;
using EbSite.Core;
using NewsClass = EbSite.Entity.NewsClass;

namespace EbSite.Base.Page
{
    public class BasePage : System.Web.UI.Page
    {
        //PageStatePersister _pers;
        //protected override PageStatePersister PageStatePersister
        //{
        //    get
        //    {
        //        if (_pers == null)
        //            _pers = new SessionPageStatePersister(this);
        //        return _pers;
        //    }
        //}
        virtual protected string GetNav(string Nav, bool IsAddCurrent, int FilterClassID)
        {
            return "";
        }

        //protected global::System.Web.UI.HtmlControls.HtmlGenericControl datacount;
        protected global::System.Web.UI.WebControls.Literal llFootInfo;
        public Host HostApi
        {
            get
            {
                return Host.Instance;
            }
        }

       virtual public EbSite.Entity.Sites CurrentSite
        {
            get
            {
                return HostApi.CurrentSite;
            }
        }
        
        public string ThemePage
        {
            get
            {
                return string.Concat(Host.Instance.CurrentSite.ThemesPath("pages"), "/");
            }
        }
        public string MThemePage
        {
            get
            {
                return HostApi.CurrentSite.MGetCurrentPageUrl("");
            }
        }
        public string ThemeCss
        {
            get
            {
                return string.Concat(Host.Instance.CurrentSite.ThemesPath("css"),"/");
            }
        }
        public string MThemeCss
        {
            get
            {
                return string.Concat(HostApi.CurrentSite.MThemesPath("css"),"/");
            }
        }

        public int CountUserOnline
        {
            get {return EbSite.BLL.User.UserOnline.GetCountAllUser(); }
        }

        /// <summary>
        /// ??????????????????ID????????????????????????url?????????site,????????????site???????????????????????????
        /// </summary>
        protected int GetSiteID
        {
            get
            {
                return  HostApi.GetSiteID;
            }
        }

        virtual protected void ShowCopyright()
        {
            //if (!Equals(datacount, null))
            //{
            //    string cnzz = string.Empty;
            //    if (!Configs.ContentSet.ConfigsControl.Instance.IsStopCnzz)
            //    {
            //        cnzz = Core.CNZZ.GetJs();
            //    }
            //    datacount.InnerHtml = string.Concat(KeepUserState(), cnzz);
            //}
            if (!Equals(llFootInfo, null))
            {
                llFootInfo.Text = Copyright;
            }
        }
       
        //public  void CachePage(int timespan)
        //{
        //    Response.Cache.VaryByParams["*"] = true;
        //    Response.Cache.SetCacheability(HttpCacheability.Public);
        //    Response.Cache.SetExpires(DateTime.Now.AddSeconds(timespan));
        //}
        /// <summary>
        /// YHL 2013-05-07 ?????????????????????
        /// </summary>
        protected EbSite.Base.EntityCustom.SeoSite SeoSite
        {
            get
            {
                List<EbSite.Base.EntityCustom.SeoSite> ls =EbSite.BLL.SeoSites.Instance.FillList();
                int siteid = GetSiteID;
                List<EbSite.Base.EntityCustom.SeoSite> md = (from i in ls where i.SiteID == siteid select i).ToList();
                if (md.Count > 0)
                {
                    return md[0];
                    
                }
                else
                {
                    EbSite.Base.EntityCustom.SeoSite mdDefault = new SeoSite();

                    mdDefault.SeoSiteIndexTitle = "{????????????}_??????????????????";
                    mdDefault.SeoTagIndexKeyWord = "{????????????}???????????????";
                    mdDefault.SeoSiteIndexDes = "{????????????}??????????????????????????????????????????";

                    mdDefault.SeoClassTitle = "{????????????}_{????????????}";
                    mdDefault.SeoSpecialTitle = "{????????????}_{????????????}";
                    mdDefault.SeoContentTitle = "{????????????}_{????????????}";
                    mdDefault.SeoTagIndexTitle = "????????????_{????????????}";
                    mdDefault.SeoTagListTitle = "{????????????}_{????????????}";

                    return mdDefault;
                }
                    
               

            }
        }

        #region ??????
        protected string[] MasterCacheKeyArray = new string[1];
        //protected CacheManager ebCache;
        /// <summary>
       /// ????????????
       /// </summary>
        protected string SiteName
        {
            get
            {
                return HostApi.CurrentSite.SiteName;
            }
        }
        /// <summary>
        /// ????????????
        /// </summary>
        protected string DomainName
        {
            get
            {
                return AppStartInit.DomainName;
            }
        }
        /// <summary>
        /// ????????????
        /// </summary>
        protected string Copyright
        {
            get
            {
                return AppStartInit.Copyright;
            }
        }


        protected int UserID = AppStartInit.UserID;
        protected string UserNiName = AppStartInit.UserNiName;
        protected string UserName = AppStartInit.UserName;
        
        /// <summary>
        /// ??????????????????
        /// </summary>
        protected static string IISPath
        {
            get
            {
                return EbSite.Base.AppStartInit.IISPath;
            }
        }
        /// <summary>
        /// ??????????????????????????????
        /// </summary>
        protected string AdminPath
        {
            get
            {
                return EbSite.Base.AppStartInit.AdminPath;
            }
        }
        ///// <summary>
        ///// ????????????????????????????????????
        ///// </summary>
        //protected string UserPath
        //{
        //    get
        //    {
        //        return AppStartInit.UserPath;
        //    }
        //}
        //protected EbSite.Control.PagesContrl pgCtr;
        #endregion

       
        /// <summary>
        /// ???????????????????????????
        /// </summary>
        //protected UserProfile UserInfos;
        public BasePage()
        {

            //this.ebCache = new CacheManager(60.0, this.MasterCacheKeyArray);
            //??????????????????????????????
#if DEBUG
            if (ConfigsControl.Instance.IsOpenSql)
            {
               
                DataProfile.DbHelperBase.QueryCount = 0;
                DataProfile.DbHelperBase.QueryDetail = "";
            }
                
#endif

        }
        //virtual protected int iPageSize
        // {
        //     get
        //     {
        //         return 20;
        //     }
        // }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //if (!Equals(pgCtr, null))
            //{
            //    pgCtr.PageSize = iPageSize;
            //}


            if (!Page.IsCallback)
            {
                
                AddHeaderPram();

                
                ShowCopyright();
                
                //??????????????????????????????????????????
                //EbSite.BLL.User.UserOnline.SetUserOnline();


            }
             
        }
        protected string KeepUserState(string sPram)
        {
            //if (!string.IsNullOrEmpty(sPram)) sPram = string.Concat("?", sPram);
            //string sUrl = string.Concat(EbSite.Base.AppStartInit.IISPath, "count.ashx", sPram);
            return string.Format("<script> scountpram='{0}';</script>", sPram);
            //string sUrl = string.Concat(EbSite.Base.AppStartInit.IISPath, "count.ashx", sPram);
            //return string.Format("<img src=\"{0}\" width=0 height=0 border=0 />", sUrl);
        }
        virtual protected string KeepUserState()
        {
            return KeepUserState("");
        }

//        protected override void OnUnload(EventArgs e)
//        {

//#if DEBUG
//            if (ConfigsControl.Instance.IsOpenSql)
//                System.Web.HttpContext.Current.Response.Write(DataProfile.DbHelperBase.QueryDetail);
//#endif
//            base.OnUnload(e);
//        }

        protected string SeoTitle;
        protected string SeoKeyWord;
        protected string SeoDes;

        protected virtual void AddHeaderPram()
        {
            AddHeaderPramPC();
        }

        /// <summary>
        /// PC???
        /// </summary>
        protected  void AddHeaderPramPC()
        {
            if(!string.IsNullOrEmpty(SeoTitle))
            {
                Page.Title = SeoTitle;// string.Concat(SeoTitle, " - Powered by EbSite");
            }
            //SeoKeyWord = string.Concat(SeoKeyWord, "   EbSite???????????????");
            if (!string.IsNullOrEmpty(SeoKeyWord))
            {
                SetMeta("keywords", SeoKeyWord);
            }
            if (!string.IsNullOrEmpty(SeoDes))
            {
                SetMeta("Description", SeoDes);
            }
            string ThemePath = Host.Instance.ThemePath;
            //??????????????????,?????????,??????????????????
            int enableJsCompression = ConfigsControl.Instance.EnableJsCompression;
            InitStyle();
            if (enableJsCompression>0)
            {
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "jscss.ashx?t=js&p=pcdefault&s=",GetSiteID));
                //AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "jscss.ashx?t=js&p=pcdefault&jsc=", string.Concat(ThemePath, "js/extensions.js")));
            }
            else
            {
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/jquery.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/init.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/inc.js"));

                //AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/init.js"));

                //HtmlGenericControl script = new HtmlGenericControl("script");
                //script.Attributes["type"] = "text/javascript";
                //script.Attributes["src"] = string.Concat(EbSite.Base.AppStartInit.IISPath, "js/inc.js");
                //script.Attributes["autoload"] = "true";
                //script.Attributes["core"] = string.Concat(EbSite.Base.AppStartInit.IISPath, "js/jquery.js");
                //Page.Header.Controls.Add(script);

                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/comm.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/customctr.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/json2.js"));
                AddJavaScriptInclude(string.Concat(ThemePath, "js/extensions.js"));

                

            }
            
            
            HtmlMeta encode = new HtmlMeta();
            encode.HttpEquiv = "Content-Type";
            encode.Content = "text/html; charset=utf-8";
            Page.Header.Controls.Add(encode);
            if(InitOrtherJavaScript.Length>0)
            {
                foreach (string sJsPath in InitOrtherJavaScript)
                {
                    AddJavaScriptInclude(sJsPath);
                }
            }

            if (GetSiteID > 0)
            {
                HtmlGenericControl sc = new HtmlGenericControl("script");
                sc.Attributes["type"] = "text/javascript";
                sc.InnerHtml = string.Concat("inisite(", GetSiteID, ",'", ThemePath, "');");
                Page.Header.Controls.Add(sc);
            }
        }
        public void SetMeta(string Name, string Content)
        {
            HtmlMeta hm = new HtmlMeta();
            hm.Name = Name;
            hm.Content = Content;
            Page.Header.Controls.Add(hm);

        }
        /// <summary>
        /// PC???
        /// </summary>
        protected virtual void InitStyle()
        {
            int enableCssCompression = ConfigsControl.Instance.EnableCssCompression;
            if (enableCssCompression > 0)
            {
                if (enableCssCompression == 1 || enableCssCompression == 3) //??????
                {
                    AddStylesheetInclude(Host.Instance.GetCssFolderUrl(string.Concat(IISPath, "themes")));
                }
                else //??????
                {
                    AddStylesheetInclude(Host.Instance.GetCssFileUrl(string.Concat(IISPath, "themes/base.css")));
                }
                
                string sCss = "default";

                if (!string.IsNullOrEmpty(CurrentSite.PageTheme))
                {
                    sCss = CurrentSite.PageTheme;
                }

                if (enableCssCompression == 1 || enableCssCompression == 3) //??????
                {
                    AddStylesheetInclude(Host.Instance.GetCssFolderUrl(string.Concat(EbSite.Base.AppStartInit.IISPath, "themes/", sCss, "/css")));
                }
                else //??????
                {
                    AddStylesheetInclude(Host.Instance.GetCssFileUrl(string.Concat(EbSite.Base.AppStartInit.IISPath, "themes/", sCss, "/css/index.css")));
                }

            }
            else
            {
                AddStylesheetInclude(string.Concat(IISPath, "themes/base.css"));
                string sCss = "default";

                if (!string.IsNullOrEmpty(CurrentSite.PageTheme))
                {
                    sCss = CurrentSite.PageTheme;
                }
                AddStylesheetInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "themes/", sCss, "/css/index.css"));
            }
        }

        /// <summary>
        /// ?????????
        /// </summary>
        protected void MobileAddHeaderPram()
        {

            if (!string.IsNullOrEmpty(SeoTitle))
            {
                Page.Title = SeoTitle;
            }
            if (!string.IsNullOrEmpty(SeoKeyWord))
            {
                SetMeta("keywords", SeoKeyWord);
            }
            if (!string.IsNullOrEmpty(SeoDes))
            {
                SetMeta("Description", SeoDes);
            }
            SetMeta("viewport", "width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0");
            //??????????????????,?????????,??????????????????
            InitStyle();

            int enableJsCompression =   ConfigsControl.Instance.MEnableJsCompression;

             


            string ThemePath = Host.Instance.MThemesPath;

            if (enableJsCompression > 0)
            {

                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "jscss.ashx?t=js&p=mbdefault&s=", GetSiteID));
            }
            else
            {
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/mobile/init.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/mobile/zepto.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/mobile/infinitescroll.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/mobile/gmu/js/core/gmu.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/mobile/gmu/js/core/event.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/mobile/gmu/js/core/widget.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/mobile/com.js"));
                AddJavaScriptInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "js/mobile/inc.js"));
                AddJavaScriptInclude(string.Concat(ThemePath, "js/extensions.js"));
            }
            

            

            HtmlMeta encode = new HtmlMeta();
            encode.HttpEquiv = "Content-Type";
            encode.Content = "text/html; charset=utf-8";
            Page.Header.Controls.Add(encode);

            if (InitOrtherJavaScript.Length > 0)
            {
                foreach (string sJsPath in InitOrtherJavaScript)
                {
                    AddJavaScriptInclude(sJsPath);
                }
            }
            if (GetSiteID > 0)
            {
                HtmlGenericControl sc = new HtmlGenericControl("script");
                sc.Attributes["type"] = "text/javascript";
                sc.InnerHtml = string.Concat("inisite(", GetSiteID, ",'", Host.Instance.MThemesPath, "');");
                Page.Header.Controls.Add(sc);
            }


        }
        /// <summary>
        /// ?????????
        /// </summary>
        protected  void MobileInitStyle()
        {
           

            //??????????????????
            AddStylesheetInclude(string.Concat(IISPath, "themesm/base.css"));
            string sCss = "default";

            if (!string.IsNullOrEmpty(CurrentSite.MobileTheme))
            {
                sCss = CurrentSite.MobileTheme;
            }
            AddStylesheetInclude(string.Concat(EbSite.Base.AppStartInit.IISPath, "themesm/", sCss, "/css/index.css"));


        }

        /// <summary>
        /// ????????????????????????js,????????????js????????????????????? ??? /js/comm.js ?????????????????????header?????????????????????
        /// </summary>
        protected virtual string[] InitOrtherJavaScript
        {
            get
            {
                return new string[0];
            }
        }

        /// <summary>
        /// Adds a JavaScript reference to the HTML head tag.
        /// </summary>
        public virtual void AddJavaScriptInclude(string url,string ID)
        {

            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes["type"] = "text/javascript";
            script.Attributes["src"] = url;
            if (!string.IsNullOrEmpty(ID))
                script.Attributes["id"] = ID;
           
            Page.Header.Controls.Add(script);

            
            
        }
        public virtual void AddJavaScriptInclude(string url)
        {

            AddJavaScriptInclude(url,"");
             
        }
        /// <summary>
        /// ????????????????????????????????????,?????????????????????????????????????????? ??????,????????????????????????????????????????????????????????????
        /// </summary>
        protected void CheckCurrentUserIsLogin()
        {
            //string UserName = EbSite.Base.AppStartInit.UserName;
            //string UserPass = EbSite.Base.AppStartInit.UserPass;

            //if(!string.IsNullOrEmpty(UserName)&&!string.IsNullOrEmpty(UserPass))
            //{
                
            //    //??????cookie???????????????????????????????????????false
            //    bool Isok = EbSite.BLL.User.MembershipUserEb.Instance.ValidateUserSimple(UserName, UserPass);
            //    if(!Isok)
            //        EbSite.Base.AppStartInit.UserLoginReurl();
            //}
            //else
            //{
            //    EbSite.Base.AppStartInit.UserLoginReurl();
            //}
            if (!CurrentUserIsLogin)
            {
                EbSite.Base.AppStartInit.UserLoginReurl();
            }
        }

        private bool CurrentUserIsLogin
        {
            get
            {
                string UserName = EbSite.Base.AppStartInit.UserName;
                string UserPass = EbSite.Base.AppStartInit.UserPass;
                bool islogin = false;
                if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(UserPass))
                {
                    //??????cookie???????????????????????????????????????false
                    islogin = EbSite.BLL.User.MembershipUserEb.Instance.ValidateUserSimple(UserName, UserPass);
                    
                }
                return islogin;
            }
        }

        protected void MCheckCurrentUserIsLogin()
        {
            if (!CurrentUserIsLogin)
            {
                EbSite.Base.AppStartInit.MUserLoginReurl();
            }
        }

        /// <summary>
        /// Adds a Stylesheet reference to the HTML head tag.
        /// </summary>
        /// <param name="url">The relative URL.</param>
        public virtual void AddStylesheetInclude(string url)
        {
            HtmlLink link = new HtmlLink();
            link.Attributes["type"] = "text/css";
            link.Attributes["href"] = url;
            link.Attributes["rel"] = "stylesheet";
            Page.Header.Controls.Add(link);
        }
        public void Tips(string Tips)
        {
            HttpContext.Current.Response.Redirect(HostApi.GetTips(Tips));
        }
        protected void Tips(string Title,string Info)
        {
            string sUrl = "";
            if (!Equals(Request.UrlReferrer,null))
                sUrl = Request.UrlReferrer.ToString();
            EbSite.Base.AppStartInit.TipsPageRender(Title, Info, sUrl);
        }
        protected void Tips(string Title, string Info,string Url)
        {
            EbSite.Base.AppStartInit.TipsPageRender(Title, Info, Url);
        }
        //??????
        protected string GetSeoWord(string Rule, string sTitle)
        {
            string sSeo = Rule.Replace("{????????????}", sTitle).Replace("{????????????}", SiteName).Replace("{????????????}", sTitle).Replace("{????????????}", sTitle);
            return sSeo;
        }
        //??????
        protected void GetSeoWord(ref string RuleTitle, ref string RuleKeyWord, ref string RuleDes, string ClassName, int ClassID)
        {

            RuleTitle = RuleTitle.Replace("{????????????}", ClassName).Replace("{????????????}", SiteName);
            RuleKeyWord = RuleKeyWord.Replace("{????????????}", ClassName).Replace("{????????????}", SiteName);
            RuleDes = RuleDes.Replace("{????????????}", ClassName).Replace("{????????????}", SiteName);
            if (RuleTitle.IndexOf("{?????????") > -1 || RuleKeyWord.IndexOf("{?????????") > -1 || RuleDes.IndexOf("{?????????") > -1)
            {
                List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetParents(ClassID);
                int iCount = lst.Count;
                for (int i = 0; i < iCount; i++)
                {
                    string RulString = string.Concat("{?????????", i, "}");
                    string sClassName = lst[i].ClassName;
                    RuleTitle = RuleTitle.Replace(RulString, sClassName);
                    RuleKeyWord = RuleKeyWord.Replace(RulString, sClassName);
                    RuleDes = RuleDes.Replace(RulString, sClassName);
                }
                int iEndCount = iCount + 5;//?????????????????????,?????????????????????????????????????????????5??????????????????
                for (int i = iCount; i < iEndCount; i++)
                {
                    string RulString2 = string.Concat("{?????????", i, "}");
                    RuleTitle = RuleTitle.Replace(RulString2, "");
                    RuleKeyWord = RuleKeyWord.Replace(RulString2, "");
                    RuleDes = RuleDes.Replace(RulString2, "");
                }
            }
            
        }
        //protected string GetSeoWord(string Rule, string ClassName, int ClassID)
        //{
           
        //    string sSeo = Rule.Replace("#Title#", ClassName).Replace("#SiteName#", SiteName);
        //    List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetParents(ClassID);
        //    int iCount = lst.Count;
        //    for (int i = 0; i < iCount; i++)
        //    {
        //        sSeo = sSeo.Replace(string.Concat("#PClassName", i, "#"), lst[i].ClassName);
        //    }
        //    int iEndCount = lst.Count+5;//?????????????????????,?????????????????????????????????????????????5??????????????????
        //    for (int i = iCount; i < iEndCount; i++)
        //    {
        //        sSeo = sSeo.Replace(string.Concat("#PClassName", i, "#"), "");
        //    }
        //    return sSeo;
        //}
        //??????

        protected void GetSeoWord(ref string RuleTitle, ref string RuleKeyWord, ref string RuleDes, string Title, string ClassName, int ClassID,string Tags,string Content)
        {

            RuleTitle = RuleTitle.Replace("{????????????}", Title).Replace("{????????????}", SiteName).Replace("{????????????}", ClassName).Replace("{????????????}", Tags); 
            
            RuleKeyWord = RuleKeyWord.Replace("{????????????}", Title).Replace("{????????????}", SiteName).Replace("{????????????}", ClassName).Replace("{????????????}", Tags);
            
            RuleDes = RuleDes.Replace("{????????????}", Title).Replace("{????????????}", SiteName).Replace("{????????????}", ClassName).Replace("{????????????}", Tags);

            if (RuleDes.IndexOf("{????????????}") > -1)
            {
                RuleDes = RuleDes.Replace("{????????????}", HostApi.GetSimpleContent(Content, 100));
            }
            if (RuleTitle.IndexOf("{?????????") > -1 || RuleKeyWord.IndexOf("{?????????") > -1 || RuleDes.IndexOf("{?????????") > -1)
            {
                List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetParents(ClassID);
                int iCount = lst.Count;
                for (int i = 0; i < iCount; i++)
                {
                    string RulString = string.Concat("{?????????", i, "}");
                    string sClassName = lst[i].ClassName;
                    RuleTitle = RuleTitle.Replace(RulString, sClassName);
                    RuleKeyWord = RuleKeyWord.Replace(RulString, sClassName);
                    RuleDes = RuleDes.Replace(RulString, sClassName);
                }
                int iEndCount = iCount + 5;//?????????????????????,?????????????????????????????????????????????5??????????????????
                for (int i = iCount; i < iEndCount; i++)
                {
                    string RulString2 = string.Concat("{?????????", i, "}");
                    RuleTitle = RuleTitle.Replace(RulString2, "");
                    RuleKeyWord = RuleKeyWord.Replace(RulString2, "");
                    RuleDes = RuleDes.Replace(RulString2, "");
                }
            }
            
        }
         

        protected string GetTipsUrl(int id)
        {
            return Host.Instance.GetTipsUrl(id);
        }
        protected string GetCurrentCss(string dataid, string sCurrentClassName, string RequestTagid)
        {
            string tagid = HttpContext.Current.Request[RequestTagid];
            string sCss = "";

            if (string.IsNullOrEmpty(tagid))
            {
                tagid = "0";

            }
            if (Equals(dataid, tagid))
            {
                sCss = string.Concat("class='", sCurrentClassName, "'");
            }

            return sCss;
        }
        /// <summary>
        /// ?????????????????????????????????
        /// </summary>
        /// <param name="ob">????????????ID</param>
        /// <param name="sCurrentClassName">??????????????????</param>
        /// <returns></returns>
        protected string GetCurrentContent(object ob, string sCurrentClassName)
        {
            int cid = Core.Utils.StrToInt(HttpContext.Current.Request["id"], 0);
            string sCss = "";

            if (!Equals(ob, null))
            {
                int ID = int.Parse(ob.ToString());

                if (ID == cid) //?????????????????????ID
                {
                    sCss = sCurrentClassName;
                }
            }

            return sCss;
        }
       

    }

#region ????????????url????????????postback???????????????????????? ?????????

    public class FormFixerHtml32TextWriter : System.Web.UI.Html32TextWriter
    {
        public FormFixerHtml32TextWriter(TextWriter writer)
            : base(writer)
        {
        }

        public override void WriteAttribute(string name, string value, bool encode)
        {
            // ??????????????????????????????form?????????action????????????????????????????????????????????????URL
            if (string.Compare(name, "action", true) == 0)
            {
                value = HttpContext.Current.Request.RawUrl;
            }
            base.WriteAttribute(name, value, encode);
        }
    }
    public class FormFixerHtmlTextWriter : System.Web.UI.HtmlTextWriter
    {
        public FormFixerHtmlTextWriter(TextWriter writer)
            : base(writer)
        {
        }

        public override void WriteAttribute(string name, string value, bool encode)
        {
            if (string.Compare(name, "action", true) == 0)
            {
                value = HttpContext.Current.Request.RawUrl;
            }

            base.WriteAttribute(name, value, encode);
        }
    }

#endregion
}
