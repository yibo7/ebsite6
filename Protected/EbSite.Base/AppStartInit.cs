using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.EntityAPI;
using EbSite.Base.PageLink;
using EbSite.BLL;
using EbSite.Core;
using EbSite.Core.HttpModules;
using EbSite.Core.Strings;
using EbSite.Entity;
using Sites = EbSite.Entity.Sites;
using EbSite.Base.Configs.UserSetConfigs;
using Common.Logging; 

namespace EbSite.Base
{
    public static class AppStartInit
    {
        //public static ILog ErrorLog = LogManager.GetLogger("ErrorLogger");
        //public static ILog InfoLog = LogManager.GetLogger("InfoLogger");
        //public static ILog EmailLog = LogManager.GetLogger("EmailLogger");
       public static readonly string CacheFolder = "cacheforebsite/";
       public static string ContentPageSplit = "_ueditor_page_break_tag_";
       public static string LastErr = string.Empty;
       public const string ASSEMBLY_VERSION = "6.0.0";
       public const string OfficialsUrl = "http://www.ebsite.net";
       static public string IISPath = Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath;
       static public string MPathUrl = UrlRules.MPathUrl; //手机版目录，如 /m/
       public static string DomainName = string.Empty; //域名，如 http//www.ebsite.net
       public static string AdminPath = string.Empty; //后台目录 /adminht/
       public static string UserUploadPath = string.Empty; //上传目录 /upload
       public static readonly string DefaultNewsContentName = "newscontent";
       public static Dictionary<int,EbSite.Entity.Sites> Sites = new Dictionary<int, Sites>();//所有站点
       public static List<string> UserRandIco = new List<string>();//没有头像的用户随机头像集合

       public static Dictionary<int, BaseLinks> EbBaseLinks = new Dictionary<int, BaseLinks>();//所有站点连接对象

       public static Dictionary<string, TemplatesPC> EbTemplatesPCs = new Dictionary<string, TemplatesPC>();//所有站点PC模板对象
       public static Dictionary<string, TemplatesMobile> EbTemplatesMobiles = new Dictionary<string, TemplatesMobile>();//所有站点Mobile模板对象
        
       public static Dictionary<string, ModelClass> TableNameModelClass = new Dictionary<string, ModelClass>();//表名称对应一个模型

        public static Dictionary<string,int> AllRewriteKey = new Dictionary<string, int>(); //用来在载入时或添加时判断重复键,int,为0,表示分类,1专题,2分类内容

        public static Dictionary<string, EbSite.BLL.NewsContentSplitTable> NewsContentInsts = new Dictionary<string, EbSite.BLL.NewsContentSplitTable>();
       public readonly static NewsContentSplitTable NewsContentInstDefault = new NewsContentSplitTable(DefaultNewsContentName);

       #region  常用属性
       /// <summary>
       /// 当前访问用户IP
       /// </summary>
       public static string CurrentUserIP
       {
           get
           {
               return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
           }
       }
       /// <summary>
       /// 版权信息
       /// </summary>
       public static string Copyright
       {
           get
           {
               return Base.Configs.SysConfigs.ConfigsControl.Instance.Copyright;
           }
       }
       /////// <summary>
       /////// 个人用户后台存放目录名称
       /////// </summary>
       //public static string UserPath
       //{
       //    get
       //    {
       //        return GetUserPath(UserName);
       //    }

       //}

       static public AdminPrincipal CheckAdmin()
       {
           AdminPrincipal ap = null;

           //如果还没有登录,或不是管理员,定向到登录页
           EbSite.Base.EntityAPI.MembershipUserEb mue = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(UserName);
           if (mue != null && (mue.ManagerID < 1 || !EbSite.BLL.User.UserIdentity.IsAdminLogIn()))
           {
               //再到管理员表里查看有没有此管理员
               EbSite.Base.AppStartInit.AdminerLoginReurl();
           }
           else
           {
               ap = AdminPrincipal.ValidateLogin(UserName);
           }
           return ap;
       }
       /// <summary>
       /// 定向到管理员登录页
       /// </summary>
       public static void AdminerLoginReurl()
       {
           string sReurl = HttpContext.Current.Request.RawUrl;
           HttpContext.Current.Response.Redirect(AdminPath + "SysLogin.aspx" + "?ru=" + sReurl);
       }
       /// <summary>
       /// 定向到首页
       /// </summary>
       public static void RedirectToIndex()
       {
           HttpContext.Current.Response.Redirect(IISPath);
       }
       /// <summary>
       /// 获取来路
       /// </summary>
       public static string GetReurl
       {
           get
           {
               return HttpContext.Current.Request["ru"];
           }
       }
       /// <summary>
       /// 定向到用户登录页
       /// </summary>
       /// <param name="url"></param>
       public static void UserLoginReurl()
       {

           string sReurl = HttpContext.Current.Request.RawUrl;
           HttpContext.Current.Response.Redirect(Base.Host.Instance.LoginRw + "?ru=" + sReurl);
       }
       public static void MUserLoginReurl()
       {
           string sReurl = HttpContext.Current.Request.RawUrl;
           HttpContext.Current.Response.Redirect(Base.Host.Instance.MLoginRw + "?ru=" + sReurl);
       }
       /// <summary>
       /// 登录后定向到来源页,或用户管理页
       /// </summary>
       public static void LoginToReurl()
       {
           if (!string.IsNullOrEmpty(GetReurl)) //如果有来源url,将定向到来源页面
           {
               HttpContext.Current.Response.Redirect(GetReurl);
           }
           else
           {
               HttpContext.Current.Response.Redirect(Base.Host.Instance.UccUrl);
           }
       }
       /// <summary>
       /// 登录后定向到来源页,或用户 指定默认页
       /// </summary>
       public static void LoginToReurl(string ReUrl)
       {
           if (!string.IsNullOrEmpty(GetReurl)) //如果有来源url,将定向到来源页面
           {
               HttpContext.Current.Response.Redirect(GetReurl);
           }
           else
           {
               HttpContext.Current.Response.Redirect(ReUrl);
           }
       }

        public static void TipsPageRender(string sTitle, string Msg, string reUrl)
        {
            TipsPageRender(sTitle, Msg, reUrl, 200);
        }

        static public void TipsPageRender(string sTitle, string Msg, string reUrl, int iStatusCode)
       {
           System.Web.HttpContext.Current.Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
           System.Web.HttpContext.Current.Response.Write("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
           System.Web.HttpContext.Current.Response.Write("<head ><title>" + sTitle + "</title>");
           System.Web.HttpContext.Current.Response.Write("<LINK media=all href=\"" + EbSite.Base.AppStartInit.AdminPath + "themes/blues/css.css\" type=\"text/css\" rel=\"Stylesheet\" >");

           if (!string.IsNullOrEmpty(reUrl))
               System.Web.HttpContext.Current.Response.Write("<meta http-equiv=\"refresh\" content=\"10; url=" + reUrl + "\"> ");



           System.Web.HttpContext.Current.Response.Write("</head><body style=\"text-align:center;text-align: -moz-center !important;padding-top:20px;\">");
           System.Web.HttpContext.Current.Response.Write("<center><div style='width:50%;' >");
           System.Web.HttpContext.Current.Response.Write("<div class=\"box-p\">");
           System.Web.HttpContext.Current.Response.Write("<div  class=\"box-s\">");
           System.Web.HttpContext.Current.Response.Write("<div class=\"box-title\" >" + sTitle + "</div>");
           System.Web.HttpContext.Current.Response.Write("<div class=\"box-content\" style=\"padding-left:20px;\" >");
           System.Web.HttpContext.Current.Response.Write("<br />");
           //内容
           System.Web.HttpContext.Current.Response.Write("<li><span style=\"word-wrap:bread-word;word-break:break-all;font-size:11.5px;\">" + Msg + "</span></li>");

           if (!string.IsNullOrEmpty(reUrl))
           {
               System.Web.HttpContext.Current.Response.Write("<li>系统3秒钟后自动返回...</li><li><a href='javascript:history.back();'><font color=\"red\">返回上一级</font></a>&nbsp;&nbsp;&nbsp;&nbsp;</li>");
           }
           else
           {
               System.Web.HttpContext.Current.Response.Write(string.Concat("<br/><li><a href='", IISPath, "'><font color=\"red\">返回网站首页</font></a>&nbsp;&nbsp;&nbsp;&nbsp;</li>"));
           }

           //if (string.IsNullOrEmpty(reUrl))
           //{
           //    System.Web.HttpContext.Current.Response.Write("<li><a href='javascript:history.back();'><font color=\"red\">返回上一级</font></a>&nbsp;&nbsp;&nbsp;&nbsp;</li>");

           //}
           //else
           //{
           //    System.Web.HttpContext.Current.Response.Write("<li>系统3秒钟后自动返回...</li><li><a href='javascript:history.back();'><font color=\"red\">返回上一级</font></a>&nbsp;&nbsp;&nbsp;&nbsp;</li>");

           //}
           System.Web.HttpContext.Current.Response.Write("</div>");
           System.Web.HttpContext.Current.Response.Write("</div>");
           System.Web.HttpContext.Current.Response.Write("</div>");
           System.Web.HttpContext.Current.Response.Write("</div></center>");
           System.Web.HttpContext.Current.Response.Write("</body>");
           System.Web.HttpContext.Current.Response.Write("</html>");

           System.Web.HttpContext.Current.Response.StatusCode = iStatusCode;

           System.Web.HttpContext.Current.Response.End();

       }
      
       /// <summary>
       /// 当前登录的用户名,未登录为空
       /// </summary>
       public static string UserName
       {
           get
           {
               return EbSite.BLL.User.UserIdentity.GetUserName;
           }
       }

       /// <summary>
       /// 当前登录的用户ID,未登录为-1
       /// </summary>
       public static int UserID
       {
           get
           {
               return EbSite.BLL.User.UserIdentity.GetUserID;
           }
       }
       public static int RoleID
       {
           get
           {
               return   EbSite.BLL.User.UserIdentity.GetRoleID;
           }
       }

        public static string RoleName 
        {
            get
            {
                if (UserID > 0)
                {
                    UserGroupProfileShort md =  EbSite.BLL.User.UserGroupProfile.GroupShortByUserID(UserID);
                    if (!Equals(md, null) && !string.IsNullOrEmpty(md.GroupName))
                    {
                        return md.GroupName;
                    }
                }
                
                return "未知用户组";
            }
        }

       public static int GetHomeID
       {
           get
           {
               if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["uid"]))
               {
                   return Utils.StrToInt(HttpContext.Current.Request.QueryString["uid"], 0);
               }
               else
               {
                   return UserID;
               }

           }
       }
       /// <summary>
       /// 当前登录的用户昵称，以后添加到cookie里方便点
       /// </summary>
       public static string UserNiName
       {
           get
           {
               return EbSite.BLL.User.UserIdentity.GetUserNiName;

           }
       }
       /// <summary>
       /// 当前登录的用户密码(已解密),未登录为空
       /// </summary>
       public static string UserPass
       {
           get
           {
               return EbSite.BLL.User.UserIdentity.GetUserPass;
           }
       }

       #endregion

       public static ModelClass GetModelClassByTableName(string TableName,int SiteID)
       {
           string sKey = string.Empty;
           if (!string.IsNullOrEmpty(TableName) && SiteID>0)
           {
                sKey = GetTableNameModelClassKey(TableName, SiteID);
               if (TableNameModelClass.ContainsKey(sKey))
                   return TableNameModelClass[sKey];

           }
           else if (!string.IsNullOrEmpty(TableName) && SiteID == 0)
           {
               return null;
           }


           throw new Exception("找不到表名称为" + TableName + "的内容模型!模型ID为:" + sKey);
       }

        public static string GetTableNameByClassID(int ClassID)
       {
            string sName=EbSite.BLL.ClassConfigs.Instance.GetNewContentTableName(ClassID);
            if (string.IsNullOrEmpty(sName))
                sName = DefaultNewsContentName;
            return sName;
       }
        /// <summary>
        /// 获取一个内容表业务处理对象
        /// </summary>
        /// <param name="TableName">表名称</param>
        /// <returns></returns>
        public static EbSite.BLL.NewsContentSplitTable GetNewsContentInst(string TableName)
        {
            if (!string.IsNullOrEmpty(TableName) && !Equals(TableName, DefaultNewsContentName))
            {
                if (NewsContentInsts.ContainsKey(TableName))
                    return NewsContentInsts[TableName];
               
            }
            return NewsContentInstDefault;
            //if (NewsContentInst.ContainsKey(TableName))
            //    return NewsContentInst[TableName];
            //return NewsContentInst["NewsContent"];
        }
        /// <summary>
        /// 获取一个内容表业务处理对象
        /// </summary>
        /// <param name="ModelID">模型ID</param>
        /// <returns></returns>
        public static EbSite.BLL.NewsContentSplitTable GetNewsContentInst(Guid ModelID,int SiteID)
        {

            if (ModelID == Guid.Empty)
            {
                return NewsContentInstDefault;
            }
            else
            {
                string tbName = EbSite.BLL.WebModel.InstanceObj(SiteID).GetTableName(ModelID);

                return GetNewsContentInst(tbName);
            }
           

        }
        /// <summary>
        /// 获取一个内容表业务处理对象
        /// </summary>
        /// <param name="ClassID">分类ID</param>
        /// <returns></returns>
        public static EbSite.BLL.NewsContentSplitTable GetNewsContentInst(int ClassID)
        {
            if(ClassID>0)
                return GetNewsContentInst(GetTableNameByClassID(ClassID));
            return NewsContentInstDefault;
        }

        public static string GetRandICO()
        {
            string sIco = string.Empty;
            if (UserRandIco.Count>0)
            {
                sIco = (from i in UserRandIco orderby Guid.NewGuid() select i).Take(1).ToList()[0];
            }
           
            return sIco;
        }

       /// <summary>
       /// 网站启动时招行一些数据初始化操作,需要预先缓存的全局数据可以在这里载入
       /// </summary>
       public static void ApplicationStartInitData()
       {
           // Load Host
           //Host.Instance = new Host();



           //初始化一些基基础配置
           Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath = Utils.GetIISPath;
            if(Configs.SysConfigs.ConfigsControl.Instance.IsAutoUpdateDomain)
                Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName = GetString.GetSite();

           Base.Configs.SysConfigs.ConfigsControl.Instance.sMapPath = AppDomain.CurrentDomain.BaseDirectory;
           Base.Configs.SysConfigs.ConfigsControl.SaveConfig();
           InitCustomData();

           LoadNewContentBllAndTableNameModelClass();

           UpdateInitJs();

           ThreadPoolManager.Init(Configs.SysConfigs.ConfigsControl.Instance.MaxThreadForPool);
           
       }

       static private string GetTableNameModelClassKey(string TableName,int SiteID)
        {
            return string.Concat(TableName.ToLower(), "-site", SiteID);
        }

        static public void LoadEbBaseLinksAndTemp()
        {
            List<EbSite.Entity.Sites> sites = EbSite.BLL.Sites.Instance.FillList();

            foreach (var site in sites)
            {
                if (!EbBaseLinks.ContainsKey(site.id))
                    EbBaseLinks.Add(site.id, new BaseLinks(site.id));

                //if (!string.IsNullOrEmpty(site.PageTheme) && !EbTemplatesPCs.ContainsKey(site.PageTheme))
                //    EbTemplatesPCs.Add(site.PageTheme, new TemplatesPC(site.PageTheme));

                //if (!string.IsNullOrEmpty(site.MobileTheme) && !EbTemplatesMobiles.ContainsKey(site.MobileTheme))
                //    EbTemplatesMobiles.Add(site.MobileTheme, new TemplatesMobile(site.MobileTheme));

            }


        }
       
        public static void LoadUrlRuleToCache()
        {
            UrlRules.ClassRule = string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.ListPathRw.Replace("{分类ID}", "([0-9]+)").Replace("{页码}", "([0-9]+)").Replace("{排序类别}", "([0-9]+)"));
            UrlRules.ContentRule = string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.ContentPathRw.Replace("{分类ID}", "([0-9]+)").Replace("{页码}", "([0-9]+)").Replace("{内容ID}", "([0-9]+)"));

            UrlRules.SpecialRule = string.Concat(IISPath, Base.Configs.ContentSet.ConfigsControl.Instance.SpecialPathRw.Replace("{专题ID}", "([0-9]+)").Replace("{页码}", "([0-9]+)"));

            //UrlRules.ContentCusttomRule = Base.Configs.ContentSet.ConfigsControl.Instance.ContentPathRw2.Replace("{分类ID}", "([0-9]+)").Replace("{页码}", "([0-9]+)").Replace("{内容ID}", "([0-9]+)");

            //自定义分类前缀，不加/,可以广泛匹配,然后再获取ID
            UrlRules.ContentCusttomRule =  Base.Configs.ContentSet.ConfigsControl.Instance.ContentPathRw.Replace("{分类ID}", "([0-9]+)").Replace("{页码}", "([0-9]+)").Replace("{内容ID}", "([0-9]+)");
            
            List<EbSite.Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetListHtmlNameReWrite();

            foreach (var model in lst)
            {
                if (model.IsHtmlNameReWrite)
                {
                    //string key = string.Concat("/", model.HtmlName, "/");
                    string key = string.Concat(IISPath, model.HtmlName, "/");
                    if (!UrlRules.ClassRuleHtmlNames.ContainsKey(key)) //不所以不能添加重复的记录
                    {
                        UrlRules.ClassRuleHtmlNames.Add(key, model.ID);
                        UrlRules.ClassRuleHtmlNames2.Add(model.ID, key);
                        if (!AllRewriteKey.ContainsKey(key))
                        {
                            AllRewriteKey.Add(key,0);
                        }
                        else
                        {
                            EbSite.BLL.Web040Log.InsertLogs(string.Format("添加了重复键{0}", key), string.Format("发生在分类ID为{0}", model.ID));
                        }

                    }
                    else
                    {
                        EbSite.BLL.Web040Log.InsertLogs(string.Format("ClassRuleHtmlNames的操作：分类添加了重复键{0}", key),
                                   string.Format("发生在分类ID为{0}，分类键:{1}", model.ID, key));
                    }

                }

                if (model.IsHtmlNameReWriteContent) //在分类里设置了这个内容是否开启前缀重写
                {
                    //string key = model.ContentHtmlPath; 
                    string key = string.Concat(IISPath,model.ContentHtmlPath) ;
                    if (!UrlRules.ClassRuleHtmlNameForContentPre2.ContainsKey(model.ID)) //不所以不能添加重复的记录
                    {
                        //UrlRules.ClassRuleHtmlNameForContentPre.Add(key, model.ID);
                        UrlRules.ClassRuleHtmlNameForContentPre2.Add(model.ID, key);

                        //AllRewriteKey.Add(key);

                        if (!AllRewriteKey.ContainsKey(key))
                        {
                            AllRewriteKey.Add(key,2);
                        }
                        else
                        {
                            EbSite.BLL.Web040Log.InsertLogs(string.Format("添加了重复键{0}", key), string.Format("发生在分类内容ID为{0}", model.ID));
                        }
                    }
                    else
                    {
                        EbSite.BLL.Web040Log.InsertLogs(string.Format("ClassRuleHtmlNameForContentPre2的操作：分类下的内容设置添加了重复键{0}", key),
                                   string.Format("发生在分类ID为{0}，分类内容键:{1}", model.ID, key));
                    }

                }

            }





            //foreach (var ncinstance in NewsContentInsts)
            //{
            //    List<EbSite.Entity.NewsContent> lstC = ncinstance.Value.GetListHtmlNameReWrite(0);
            //    //UrlRules.ContentRuleHtmlNames
            //    foreach (var model in lstC)
            //    {
            //        string key = model.HtmlReName;
            //        if (UrlRules.ContentRuleHtmlNames.ContainsKey(key))
            //        {
            //            UrlRules.ContentRuleHtmlNames.Add(key, model.ID);
            //            UrlRules.ContentRuleHtmlNames2.Add(model.ID, key);
            //        }
            //    }
            //}

            List<EbSite.Entity.SpecialClass> lstSpecal = EbSite.BLL.SpecialClass.GetListHtmlNameReWrite();

            foreach (var model in lstSpecal)
            {
                if (model.IsCusttomRw) //这个地方可以不判断，因为取出来都是自定义的数据
                {
                    if (!string.IsNullOrEmpty(model.HtmlName))
                    {
                        string key = string.Concat("/", model.HtmlName, "/"); 
                        //if (!model.HtmlName.StartsWith("/"))
                         //   key = string.Concat("/", model.HtmlName,"/");

                        if (!UrlRules.SpecialRuleHtmlNames.ContainsKey(key)) //不所以不能添加重复的记录
                        {
                            UrlRules.SpecialRuleHtmlNames.Add(key, model.id);
                            UrlRules.SpecialRuleHtmlNames2.Add(model.id, key);
                            if (!AllRewriteKey.ContainsKey(key))
                            {
                                AllRewriteKey.Add(key, 1);
                            }
                            else
                            {
                                EbSite.BLL.Web040Log.InsertLogs(string.Format("专题添加了重复键{0}", key),
                                    string.Format("发生在专题ID为{0}", model.id));
                            }
                        }
                        else
                        {
                            EbSite.BLL.Web040Log.InsertLogs(string.Format("SpecialRuleHtmlNames的操作：专题添加了重复键{0}", key),
                                   string.Format("发生在专题ID为{0}，专题键:{1}", model.id, key));
                        }
                    }
                    
                } 

            }

        }

        /// <summary>
        /// 读取所有皮肤到缓存中
        /// </summary>
        static public void LoadTemplatesToCache()
        {
           var pcTheme = ThemesPC.Instance.FillList();
           foreach (var theme in pcTheme)
            {
                if (!string.IsNullOrEmpty(theme.ThemePath) && !EbTemplatesPCs.ContainsKey(theme.ThemePath))
                    EbTemplatesPCs.Add(theme.ThemePath, new TemplatesPC(theme.ThemePath));
            }

           var mbTheme = new ThemesMobile().FillList();
           foreach (var mbt in mbTheme)
           {
               if (!string.IsNullOrEmpty(mbt.ThemePath) && !EbTemplatesMobiles.ContainsKey(mbt.ThemePath))
                   EbTemplatesMobiles.Add(mbt.ThemePath, new TemplatesMobile(mbt.ThemePath));
           }
        }
       static public void LoadNewContentBllAndTableNameModelClass()
       {

           List<EbSite.Entity.Sites> sites = EbSite.BLL.Sites.Instance.FillList();

           foreach (var site in sites)
           {
              

               List<EbSite.Entity.ModelClass> list = Configs.Model.ConfigsControl.GetModelList(EbSite.BLL.WebModel.Instance.WebModelName, site.id);
               foreach (EbSite.Entity.ModelClass md in list)
               {
                   string tbName = md.TableName;
                   if (!string.IsNullOrEmpty(tbName))
                   {
                       string keytbName = GetTableNameModelClassKey(tbName, site.id);
                       //载入表名称对应的模型关系数据
                       if (!TableNameModelClass.ContainsKey(keytbName))//if (!TableNameModelClass.ContainsKey(tbName))
                       {
                           TableNameModelClass.Add(keytbName, md);//GetTableNameModelClassKey(tbName, site.id)
                       }

                       //载入列表名称对应的内容业务处理对应关系
                       if (!NewsContentInsts.ContainsKey(tbName))
                       {
                           NewsContentInsts.Add(tbName, new NewsContentSplitTable(tbName));
                       }
                       
                   }
               }
           }
           
            
            if (!NewsContentInsts.ContainsKey(DefaultNewsContentName))
            {
                NewsContentInsts.Add(DefaultNewsContentName, NewsContentInstDefault);
            }
        }

      

       public static void InitCustomData()
       {
           IISPath = Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath;
           AdminPath = string.Concat(IISPath, Base.Configs.SysConfigs.ConfigsControl.Instance.AdminPath);
           DomainName = Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName;
           string sUpPath = Base.Configs.SysConfigs.ConfigsControl.Instance.UploadPath;
           
           //规范上传目录 
           if (sUpPath.EndsWith("/"))
               sUpPath = sUpPath.Substring(0, sUpPath.LastIndexOf("/"));
           if (sUpPath.StartsWith("/"))
           {
               UserUploadPath = sUpPath;
           }
           else
           {
               UserUploadPath = string.Concat(IISPath, sUpPath);
           }

             

           //MPathUrl = EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPathUrl.ToLower();

          

           if (UserRandIco.Count == 0)
           {
               //加载随机头像
               List<FileInfo> fileInfos = Core.FSO.FObject.GetFileListByTypes(string.Concat(IISPath, "UserRandIco/"), new string[3] { "png", "jpg", "gif" });
               foreach (FileInfo fileInfo in fileInfos)
               {
                   UserRandIco.Add(fileInfo.FullName);
               }
           }


       }

        public static void InitSites()
        {
            List<EbSite.Entity.Sites> lst = EbSite.BLL.Sites.Instance.FillList();

            foreach (Sites mdsites in lst)
            {
                if (!Sites.ContainsKey(mdsites.id))
                    Sites.Add(mdsites.id, mdsites);
            }
        }
       
       public static void UpdateInitJs()
       {
           EbSite.Entity.Sites CurrentSite = EbSite.BLL.Sites.Instance.GetEntity(GetSiteID);

           if (!Equals(CurrentSite, null))
           {
               try
               {
                   //初始一些全局性的js数据及重写地址
                   StringBuilder sbStartInitDataPC = new StringBuilder();
                   sbStartInitDataPC.Append("var SiteConfigs ={");
                   sbStartInitDataPC.Append("id: 1,");
                   sbStartInitDataPC.AppendFormat("UrlIISPath: \"{0}\",", IISPath);
                     
                    sbStartInitDataPC.AppendFormat("UrlUcc: \"{0}\",", Base.Host.Instance.UccIndexRw);
                   sbStartInitDataPC.AppendFormat("UrlLogin: \"{0}\",", Base.Host.Instance.LoginRw);
                   sbStartInitDataPC.AppendFormat("UrlLostpassword: \"{0}\",", Base.Host.Instance.LostpasswordRw);
                   sbStartInitDataPC.AppendFormat("UrlReg: \"{0}\",", Base.Host.Instance.RegRw);
                   sbStartInitDataPC.AppendFormat("UrlSearch: \"{0}\",", Base.Host.Instance.SearchRw);
                   sbStartInitDataPC.AppendFormat("Urluhome: \"{0}\",", Base.Host.Instance.UhomeRw);
                   sbStartInitDataPC.AppendFormat("LogOut: \"{0}\",", Base.Host.Instance.LogOutRw);
                   sbStartInitDataPC.AppendFormat("DomainName: \"{0}\",",Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName);
                   sbStartInitDataPC.AppendFormat("MobileIndex: \"{0}\",", UrlRules.sMIndexNoPram);
                     
                    sbStartInitDataPC.AppendFormat("ThemePath: \"{0}\",", CurrentSite.ThemesPath(""));
                    sbStartInitDataPC.AppendFormat("IsShowSql: \"{0}\"", Configs.SysConfigs.ConfigsControl.Instance.IsOpenSql?"1":"0");

                    sbStartInitDataPC.Append("};");

                    
                   EbSite.Core.FSO.FObject.WriteFileUtf8(
                       HttpContext.Current.Server.MapPath(string.Concat(IISPath, "js/init.js")),
                       sbStartInitDataPC.ToString());
                     
                   StringBuilder sbStartInitDataMobile = new StringBuilder();
                   sbStartInitDataMobile.Append("var SiteConfigs ={");
                   sbStartInitDataMobile.Append("id: 1,");
                   sbStartInitDataMobile.AppendFormat("UrlIISPath: \"{0}\",", IISPath);
                   sbStartInitDataMobile.AppendFormat("UrlUcc: \"{0}\",", Base.Host.Instance.MUccIndexRw);
                   sbStartInitDataMobile.AppendFormat("UrlLogin: \"{0}\",", Base.Host.Instance.MLoginRw);
                   sbStartInitDataMobile.AppendFormat("UrlLostpassword: \"{0}\",", Base.Host.Instance.MLostpasswordRw);
                   sbStartInitDataMobile.AppendFormat("UrlReg: \"{0}\",", Base.Host.Instance.MRegRw);
                   sbStartInitDataMobile.AppendFormat("UrlSearch: \"{0}\",", Base.Host.Instance.MSearchRw);
                   sbStartInitDataMobile.AppendFormat("Urluhome: \"{0}\",", "");
                   sbStartInitDataMobile.AppendFormat("LogOut: \"{0}\",", Base.Host.Instance.MLogOutRw);
                   sbStartInitDataMobile.AppendFormat("DomainName: \"{0}\",",
                       Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName);
                     
                    sbStartInitDataMobile.AppendFormat("ThemePath: \"{0}\",", CurrentSite.MGetCurrentThemesPath());
                    sbStartInitDataPC.AppendFormat("IsShowSql: \"{0}\"", Configs.SysConfigs.ConfigsControl.Instance.IsOpenSql ? "1" : "0");

                    sbStartInitDataMobile.Append("};");
                    
                    Core.FSO.FObject.WriteFileUtf8(HttpContext.Current.Server.MapPath(string.Concat(IISPath, "js/mobile/init.js")),sbStartInitDataMobile.ToString());
               }
               catch (Exception e)
               {
                    Log.Factory.GetInstance().ErrorLog(string.Format("初始init.js文件发生错误,当前站点ID:{0},站点名称:{1},站点皮肤：{2}", GetSiteID,
                       CurrentSite.SiteName, e.Message));
                    //throw new Exception(string.Format("初始init.js文件发生错误,当前站点ID:{0},站点名称:{1},站点皮肤：{2}", GetSiteID,
                    //   CurrentSite.SiteName, e.Message));
               }

           }
           else
           {
               throw new Exception(string.Format("获取当前站点出错,当前站点ID:{0}", GetSiteID));
           }
         

          
          
       }
        
       private static int GetSiteID
       {
           get
           {
               if (HttpContext.Current != null)
               {
                   if (!string.IsNullOrEmpty(HttpContext.Current.Request["site"]))
                   {
                       return int.Parse(HttpContext.Current.Request["site"]);
                   }
                   return 1;
               }
               else
               {
                   return 1;
               }
           }
       }


       public static void LoadPlugins()
       {


           #region 载入插件
           /*添加新插件类型后要在以下创建列表，及修改相应的
             Collectors.cs
            * ProviderLoader.cs
             * 最后修改 EbSite.BLL.Plugins.Plugin下的 GetPlugins
             */

           EbSite.Base.Plugin.Collectors.FileNames = new System.Collections.Generic.Dictionary<string, string>(11);
           //创建插件容器-正在运行的
           EbSite.Base.Plugin.Collectors.UseIEmailManagerCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IEmailManager>();
           EbSite.Base.Plugin.Collectors.UseIMobileSendCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IMobileSend>();
           EbSite.Base.Plugin.Collectors.UseITimerTaskCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.ITimerTask>();
           EbSite.Base.Plugin.Collectors.UseIPaymentCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IPayment>();
           EbSite.Base.Plugin.Collectors.UseIDeliveryCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IDelivery>();
           EbSite.Base.Plugin.Collectors.UseIUserLoginApiCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IUserLoginApi>();
           EbSite.Base.Plugin.Collectors.UseIDataExportCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IDataExport>();
           EbSite.Base.Plugin.Collectors.UseIDataImportCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IDataImport>();
           EbSite.Base.Plugin.Collectors.UseISearchEngineCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.ISearchEngine>();

           EbSite.Base.Plugin.Collectors.UseIIPToAreaCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IIPToArea>();

           EbSite.Base.Plugin.Collectors.UseICacheCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.ICache>();



           //创建插件容器-已经关闭的
           EbSite.Base.Plugin.Collectors.DisabledIEmailManagerCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IEmailManager>();
           EbSite.Base.Plugin.Collectors.DisabledIMobileSendCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IMobileSend>();
           EbSite.Base.Plugin.Collectors.DisabledITimerTaskCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.ITimerTask>();
           EbSite.Base.Plugin.Collectors.DisabledIPaymentCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IPayment>();
           EbSite.Base.Plugin.Collectors.DisabledIDeliveryCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IDelivery>();
           EbSite.Base.Plugin.Collectors.DisabledIUserLoginApiCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IUserLoginApi>();
           EbSite.Base.Plugin.Collectors.DisabledIDataExportCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IDataExport>();
           EbSite.Base.Plugin.Collectors.DisabledIDataImportCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IDataImport>();
           EbSite.Base.Plugin.Collectors.DisabledISearchEngineCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.ISearchEngine>();

           EbSite.Base.Plugin.Collectors.DisabledIIPToAreaCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.IIPToArea>();

           EbSite.Base.Plugin.Collectors.DisabledICacheCollector = new EbSite.Base.Plugin.ProviderCollector<EbSite.Base.Plugin.ICache>();



           EbSite.Base.Plugin.ProviderLoader.LoadAll();
           #endregion

           #region 载入一些初始事件

           EbSite.Base.EBSiteEvents.UserActivated += new EventHandler<EbSite.Base.EBSiteEventArgs.UserActivatedEventArgs>(On_UserActivated);

           #endregion


       }

       /**/
       /// <summary>
       /// Handles the Post.Serving event to take care of logging IP.
       /// </summary>
       private static void On_UserActivated(object sender, EbSite.Base.EBSiteEventArgs.UserActivatedEventArgs e)
       {
           if (e.UserID > 0) //用户ID>0
           {
               // e.UserID 用户ID
               // e.UserName 用户名称
               //e.Email 用户email
               //执行一些处理操作

               #region 邀请注册相关处理
               //如果邀请人的ID大于0,将进入积分等相关处理
               if (e.VUserID > 0)
               {
                   EbSite.Base.EntityAPI.MembershipUserEb umd = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(e.VUserID);

                   //给邀请人加积分 要获得积分
                   int score = int.Parse(ConfigsControl.Instance.InviteRegInCredit.ToString());
                   umd.Credits += score;
                   EbSite.BLL.User.MembershipUserEb.Instance.Update(umd);
                   EbSite.Entity.Invite md = new EbSite.Entity.Invite();
                   md.AddDate = DateTime.Now;
                   md.InviteInviteNiName = e.UserName;
                   md.InviteUserID = e.UserID;
                   md.UserID = e.VUserID.ToString();
                   md.Save();

                   //if (!umd.IsHaveAvatar)
                   //{
                   //    //给邀请人加积分 要获得积分
                   //    int score = int.Parse(ConfigsControl.Instance.InviteRegInCredit.ToString());
                   //    umd.Credits += score;
                   //    EbSite.BLL.User.MembershipUserEb.Instance.Update(umd);
                   //    EbSite.Entity.Invite md = new EbSite.Entity.Invite();
                   //    md.AddDate = DateTime.Now;
                   //    md.InviteInviteNiName = e.UserName;
                   //    md.InviteUserID = e.UserID;
                   //    md.UserID = e.VUserID.ToString();
                   //    md.Save();
                   //}
               }
               #endregion

               #region cookie写入操作
               string sUserName = e.UserName;//txtUserName.Text.Trim();
               string sPass = e.Pass;//已经加过密码

               EbSite.BLL.User.UserIdentity.WriteUserIdentity(e.UserID.ToString(), sUserName, sUserName, sPass,e.RoleID.ToString());
               #endregion



           }
       }
        
    }
}
