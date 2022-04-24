
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using EbSite.Base;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.EBSiteEventArgs;
using EbSite.BLL.GetLink;
using EbSite.Core.HttpModules;

namespace EbSite.Core
{
    public class HttpModule : EbSite.Core.URLRewriterBase.BaseModuleRewriter
    {
        private bool IsMatchClassUrlReWritPage(string requestedPath,ref string sRulePage, ref string sPathName,ref int iClassId)
        {
            
            foreach (var classRuleHtmlName in UrlRules.ClassRuleHtmlNames)
            {
                string rulePage = string.Concat(classRuleHtmlName.Key, "([0-9]+)/");
                if (IsMatchReWrite(requestedPath, rulePage))
                {
                    sPathName = classRuleHtmlName.Key;
                    iClassId = classRuleHtmlName.Value;
                    sRulePage = rulePage;
                    return true;
                }

            }

            return false;

        }
        private bool IsMatchSpecalUrlReWritPage(string requestedPath, ref string sRulePage, ref string sPathName, ref int iSpecialId)
        {

            foreach (var specialRuleHtmlName in UrlRules.SpecialRuleHtmlNames)
            {
                string rulePage = string.Concat(specialRuleHtmlName.Key, "([0-9]+)/");
                if (IsMatchReWrite(requestedPath, rulePage))
                {
                    sPathName = specialRuleHtmlName.Key;
                    iSpecialId = specialRuleHtmlName.Value;
                    sRulePage = rulePage;
                    return true;
                }

            }

            return false;

        }

        protected override void Rewrite(string requestedPath, System.Web.HttpApplication app)
        {
            requestedPath = requestedPath.ToLower();
            HttpContext httpContext = app.Context;
            //if (requestedPath.EndsWith(".svc"))
            //{
            //    httpContext.Response.StatusCode = 404;
            //    httpContext.Response.End();
            //    return;
            //}

            //对外播放事件
            HttpModuleRuningEventArgs Args = new HttpModuleRuningEventArgs(requestedPath, app);
            Base.EBSiteEvents.OnHttpModuleRuning(null,Args);
           
            string sRealUrl = Args.RealUrl;
            
            if(!Args.IsStop)  //接受处来事件参数
            {
                #region 防盗处理

                if (Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpenPickproofLinkOfPic) //是否开启图片防盗
                {
                    
                    string sFileType = Core.Strings.GetString.getFileType(requestedPath);
                    if (!string.IsNullOrEmpty(sFileType))
                    {
                        string[] pics = Base.Configs.SysConfigs.ConfigsControl.Instance.PickproofLinkPreOfPic.Split(',');
                        if (pics.Length > 0)
                        {
                            if (Core.Strings.Validate.InArray(sFileType.Trim().ToLower(), pics))
                            {
                                if (!Equals(httpContext, null) && !Equals(httpContext.Request.UrlReferrer, null))
                                {
                                    if (Utils.IsCrossSitePost(httpContext.Request.UrlReferrer.ToString(), Utils.GetHost())) //站外连接
                                    {

                                        string path = HttpContext.Current.Request.RawUrl;
                                        string hostIP = HttpContext.Current.Request.UserHostAddress;
                                        string referer = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
                                        string useragent = HttpContext.Current.Request.ServerVariables["http_user_agent"];
                                        
                                        Entity.Logs mdLogs = new Entity.Logs();
                                        mdLogs.Title = string.Concat("图片盗链请求:", path, " 来路:", referer);
                                        mdLogs.Description = string.Concat(path, "UserAgent:", useragent);
                                        mdLogs.IP = hostIP;
                                        mdLogs.AddDate = DateTime.Now;
                                        BLL.AppErrLog.InsertLogs(mdLogs);

                                        httpContext.Response.ContentType = "image/JPEG";
                                        httpContext.RewritePath(string.Concat(EbSite.Base.AppStartInit.IISPath, "images/outlink.gif"));
                                        //httpContext.Response.WriteFile(string.Concat(EbSite.Base.AppStartInit.IISPath, "images/outlink.gif"));//被替换图片
                                        //httpContext.Response.End();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                   
                    
                }

                #endregion

                string sRuleModule = string.Concat(EbSite.Base.AppStartInit.IISPath, Base.Configs.SysConfigs.ConfigsControl.Instance.UserPath, "([A-Za-z0-9]+).ashx");
                    if (IsMatchReWrite(requestedPath, sRuleModule))  //请求的是不是用户模块页面
                    {

                        Match mc = Regex.Match(requestedPath, sRuleModule);
                        if (mc.Success)
                        {
                            string sReWritePath = mc.Groups[1].Value;
                             sRealUrl = BLL.MenusForUser.Instance.GetLinkFormReWritePath(sReWritePath);
                            
                            if(!string.IsNullOrEmpty(sRealUrl))
                            {
                                httpContext.RewritePath(sRealUrl);
                                //ToRewritePath(sRealUrl, httpContext);
                                return;
                            }
                                
                        }
                
                    }
                    else
                    {
                        if (EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.SiteModule == 2)
                        {
                            if (Equals(requestedPath, "/")||Equals(requestedPath, "/index.aspx"))
                            {

                                ToRewritePath("~/indexmobile.aspx", httpContext);
                                return;
                            }
                        }

                    if (IsGoToReWrite(requestedPath))//过滤一些没必要的页面
                        {

                            if (requestedPath.EndsWith("/ebcss.ashx")) //目录文件样式
                            {
                                sRealUrl = string.Concat(EbSite.Base.AppStartInit.IISPath, "jscss.ashx?t=css&p=", requestedPath.Replace("/ebcss.ashx", "/"));
                            }
                            else if (requestedPath.EndsWith(".ebcss.ashx")) //目录文件样式
                            {
                                sRealUrl = string.Concat(AppStartInit.IISPath, "jscss.ashx?t=css&p=", requestedPath.Replace(".ebcss.ashx", ""));
                            }
                            else
                            {
                                int SiteID = Core.Utils.StrToInt(httpContext.Request["site"], 1);

                                string sRwRulePage = string.Empty;

                                string sRwPathName = string.Empty;
                                int iRwClassId = 0;

                                

                                if (EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.SiteModule != 2)
                                    {
                                        #region PC版地址重写

                                if (UrlRules.ClassRuleHtmlNames.ContainsKey(requestedPath))//分类目录自定义重写
                                {
                                    int ClassId = UrlRules.ClassRuleHtmlNames[requestedPath];
                                    int PageIndex = 1;
                                    int Odb = 0;
                                    sRealUrl = LinkClass.Instance.GetAspxInstance(SiteID).GetClassHref_OrderBy(ClassId, PageIndex, Odb);
                                }
                                else if (IsMatchClassUrlReWritPage(requestedPath, ref sRwRulePage, ref sRwPathName, ref iRwClassId)) //分类目录自定义重写-分页
                                {
                                    Match mc = Regex.Match(requestedPath, sRwRulePage);
                                    int PageIndex = 1;
                                    int Odb = 0;
                                    if (mc.Success)
                                    {
                                        PageIndex = int.Parse(mc.Groups[1].Value);
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.ClassRule);
                                        sRealUrl = LinkClass.Instance.GetAspxInstance(SiteID).GetClassHref_OrderBy(iRwClassId, PageIndex, Odb);
                                    }


                                }

                                else if (IsMatchReWrite(requestedPath, UrlRules.ClassRule)) //分类页
                                {
                                    int ClassId = 0;
                                    int PageIndex = 1;
                                    int Odb = 0;

                                    Match mc = Regex.Match(requestedPath, UrlRules.ClassRule);
                                    if (mc.Success)
                                    {
                                        ClassId = int.Parse(mc.Groups[1].Value);
                                        Odb = int.Parse(mc.Groups[2].Value);
                                        PageIndex = int.Parse(mc.Groups[3].Value);
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.ClassRule);

                                    }
                                    sRealUrl = LinkClass.Instance.GetAspxInstance(SiteID)
                                        .GetClassHref_OrderBy(ClassId, PageIndex, Odb);

                                }
                                else if (IsMatchReWrite(requestedPath, UrlRules.ContentRule)) //内容面页
                                {
                                    string ContentId = string.Empty;
                                    int ClassID = 0;
                                    string iPageIndex = "0";
                                    Match mc = Regex.Match(requestedPath, UrlRules.ContentRule);
                                    if (mc.Success)
                                    {
                                        string url = mc.Groups[0].Value;


                                        if (Equals(requestedPath, url))
                                        {
                                            ClassID = Core.Utils.StrToInt(mc.Groups[1].Value, 0);
                                            ContentId = mc.Groups[2].Value;
                                            iPageIndex = mc.Groups[3].Value;
                                            //SiteID = GetSiteFolder(requestedPath, UrlRules.ContentRule);
                                        }
                                        else //这种情况是可能出现的二级路重写，如abc/******.html
                                        {
                                            SiteID = GetSiteFolder(requestedPath, UrlRules.ContentRule);
                                            if (SiteID > 1)
                                            {
                                                ClassID = Core.Utils.StrToInt(mc.Groups[1].Value, 0);
                                                ContentId = mc.Groups[2].Value;
                                                iPageIndex = mc.Groups[3].Value;
                                            }
                                            else
                                            {
                                                Match mc2 = Regex.Match(requestedPath, UrlRules.ContentCusttomRule);
                                                if (mc2.Success)
                                                {
                                                    ClassID = Core.Utils.StrToInt(mc.Groups[1].Value, 0);
                                                    ContentId = mc.Groups[2].Value;
                                                    iPageIndex = mc.Groups[3].Value;
                                                    SiteID = GetSiteFolder(requestedPath, UrlRules.ContentCusttomRule);
                                                    if (UrlRules.ClassRuleHtmlNameForContentPre2.ContainsKey(ClassID))
                                                    {
                                                        string rename = UrlRules.ClassRuleHtmlNameForContentPre2[ClassID];
                                                        if (requestedPath.IndexOf(rename) > -1)
                                                            sRealUrl =
                                                                LinkContent.Instance.GetAspxInstance(SiteID)
                                                                    .GetContentLink(ContentId, ClassID, iPageIndex);
                                                    }
                                                    else
                                                    {
                                                        ContentId = ""; //不让在下面的时候进去
                                                    }

                                                }
                                            }

                                        }



                                    }
                                    if (!string.IsNullOrEmpty(ContentId) &&
                                        !UrlRules.ClassRuleHtmlNameForContentPre2.ContainsKey(ClassID) &&
                                        string.IsNullOrEmpty(sRealUrl)) //如果包含，不能走这个规则
                                    {
                                        sRealUrl = LinkContent.Instance.GetAspxInstance(SiteID)
                                            .GetContentLink(ContentId, ClassID, iPageIndex);
                                    }


                                }
                                else if (IsMatchReWrite(requestedPath, UrlRules.ContentCusttomRule))
                                //来自分类自定义内容面页url前缀，一级前缀重写，如abc-***.html
                                {


                                    string ContentId = "0";
                                    int ClassID = 0;
                                    string iPageIndex = "0";
                                    Match mc = Regex.Match(requestedPath, UrlRules.ContentCusttomRule);
                                    if (mc.Success)
                                    {
                                        ClassID = Core.Utils.StrToInt(mc.Groups[1].Value, 0);
                                        ContentId = mc.Groups[2].Value;
                                        iPageIndex = mc.Groups[3].Value;
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.ContentCusttomRule);
                                        if (UrlRules.ClassRuleHtmlNameForContentPre2.ContainsKey(ClassID))
                                        {
                                            string rename = UrlRules.ClassRuleHtmlNameForContentPre2[ClassID];
                                            if (requestedPath.IndexOf(rename) > -1)
                                                sRealUrl =
                                                    LinkContent.Instance.GetAspxInstance(SiteID)
                                                        .GetContentLink(ContentId, ClassID, iPageIndex);
                                        }

                                    }

                                }
                                //else if (IsMatchReWrite(requestedPath, UrlRules.ContentRuleDefault)) //内容面页默认
                                //{
                                //    string ContentId = "0";

                                //    Match mc = Regex.Match(requestedPath, UrlRules.ContentRuleDefault);
                                //    if (mc.Success)
                                //    {
                                //        ContentId = mc.Groups[1].Value;
                                //        SiteID = GetSiteFolder(requestedPath, UrlRules.ContentRuleDefault);
                                //    }
                                //    sRealUrl = LinkContent.Instance.GetAspxInstance(SiteID).GetContentLink(ContentId);
                                //}

                                else if (UrlRules.SpecialRuleHtmlNames.ContainsKey(requestedPath))//分类目录自定义重写
                                {
                                    int ClassId = UrlRules.SpecialRuleHtmlNames[requestedPath];
                                    int PageIndex = 1;
                                    sRealUrl = LinkSpecial.Instance.GetAspxInstance(SiteID).GetSpecialHref(ClassId, PageIndex);
                                }
                                else if (IsMatchSpecalUrlReWritPage(requestedPath, ref sRwRulePage, ref sRwPathName, ref iRwClassId)) //分类目录自定义重写-分页
                                {
                                    Match mc = Regex.Match(requestedPath, sRwRulePage);
                                    int PageIndex = 1;
                                    if (mc.Success)
                                    {
                                        PageIndex = int.Parse(mc.Groups[1].Value);
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.SpecialRule);
                                        sRealUrl = LinkSpecial.Instance.GetAspxInstance(SiteID).GetSpecialHref(iRwClassId, PageIndex);
                                    }


                                }

                                //专题页
                                else if (IsMatchReWrite(requestedPath, UrlRules.SpecialRule))
                                {
                                    int ClassId = 0;
                                    int PageIndex = 0;
                                    Match mc = Regex.Match(requestedPath, UrlRules.SpecialRule);
                                    if (mc.Success)
                                    {
                                        ClassId = int.Parse(mc.Groups[1].Value);
                                        PageIndex = int.Parse(mc.Groups[2].Value);
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.SpecialRule);
                                    }
                                    sRealUrl = LinkSpecial.Instance.GetAspxInstance(SiteID)
                                        .GetSpecialHref(ClassId, PageIndex);
                                } //表单
                                else if (IsMatchReWrite(requestedPath, UrlRules.CustomFormRule))
                                {

                                    string ModelID = "";
                                    Match mc = Regex.Match(requestedPath, UrlRules.CustomFormRule);
                                    if (mc.Success)
                                    {
                                        ModelID = mc.Groups[1].Value;
                                        SiteID = int.Parse(mc.Groups[2].Value);
                                        //SiteID = GetSiteFolder(requestPath, SpecialRule);
                                    }
                                    sRealUrl = LinkOrther.Instance.GetAspxInstance(SiteID).GetFormUrl(ModelID);
                                }
                                //所有标签列表页面
                                else if (IsMatchReWrite(requestedPath, UrlRules.TagsRule))
                                {
                                    int TagPageIndex = 0;
                                    Match mc = Regex.Match(requestedPath, UrlRules.TagsRule);
                                    if (mc.Success)
                                    {
                                        TagPageIndex = int.Parse(mc.Groups[1].Value);
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.TagsRule);
                                    }
                                     

                                    string tgvRealUrl = LinkTags.Instance.GetAspxInstance(SiteID).TagsList(TagPageIndex);

                                    if (EbSite.BLL.Sites.Instance.GetLinkTypeTags(SiteID) == LinkType.AutoHtml)
                                    {
                                        string CacheUrl = string.Concat(AppStartInit.IISPath, AppStartInit.CacheFolder,
                                            "tags/p", TagPageIndex, "s", SiteID, ".htm");
                                        sRealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, tgvRealUrl);
                                    }
                                    else
                                    {
                                        sRealUrl = tgvRealUrl;
                                    }

                                }
                                //标签搜索页--关键词
                                else if (requestedPath.Equals(string.Concat(EbSite.Base.AppStartInit.IISPath,
                                        Base.PageLink.GetBaseLinks.Get(SiteID).TagsSearchListLinkRw.ToLower())))
                                {
                                    sRealUrl = Base.PageLink.GetBaseLinks.Get(SiteID).TagsSearchListLink;

                                } //标签搜索页--标签ID
                                else if (IsMatchReWrite(requestedPath, UrlRules.TagsSearchRuleByID))
                                {
                                    int TagId = 0;
                                    int PageIndex = 0;
                                    Match mc = Regex.Match(requestedPath, UrlRules.TagsSearchRuleByID);
                                    if (mc.Success)
                                    {
                                        TagId = int.Parse(mc.Groups[1].Value);
                                        PageIndex = int.Parse(mc.Groups[2].Value);
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.TagsSearchRuleByID);
                                    }
                                    string tgvRealUrl = LinkTags.Instance.GetAspxInstance(SiteID).TagsSearchList(TagId, PageIndex);

                                    if (EbSite.BLL.Sites.Instance.GetLinkTypeTags(SiteID) == LinkType.AutoHtml)
                                    {
                                        string CacheUrl = string.Concat(AppStartInit.IISPath, AppStartInit.CacheFolder,
                                            "tagv/id", TagId, "p", PageIndex, "s", SiteID, ".htm");
                                        sRealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, tgvRealUrl);
                                    }
                                    else
                                    {
                                        sRealUrl = tgvRealUrl;
                                    }

                                }
                                else if (
                                    requestedPath.Equals(
                                        Base.PageLink.GetBaseLinks.Get(SiteID).LoginRw.ToLower())) //登录
                                {
                                    sRealUrl = Base.PageLink.GetBaseLinks.Get(SiteID).Login;
                                }
                                else if (
                                    requestedPath.Equals(
                                        Base.PageLink.GetBaseLinks.Get(SiteID).LostpasswordRw.ToLower()))
                                //找加密
                                {
                                    sRealUrl = Base.PageLink.GetBaseLinks.Get(SiteID).Lostpassword;
                                }
                                else if (
                                    requestedPath.Equals(
                                        Base.PageLink.GetBaseLinks.Get(SiteID).RegRw.ToLower()))
                                //注册
                                {
                                    sRealUrl = Base.PageLink.GetBaseLinks.Get(SiteID).Reg;
                                }
                                else if (
                                    requestedPath.Equals(
                                        Base.PageLink.GetBaseLinks.Get(SiteID)
                                            .SearchRw.ToLower())) //搜索
                                {
                                    sRealUrl = Base.PageLink.GetBaseLinks.Get(SiteID).Search;
                                }
                                else if (
                                    requestedPath.Equals(
                                        Base.PageLink.GetBaseLinks.Get(SiteID)
                                            .UhomeRw.ToLower())) //用户自助主页
                                {
                                    int sUserID = 0;

                                    if (
                                        !string.IsNullOrEmpty(
                                            httpContext.Request.QueryString["uid"]))
                                    {
                                        sUserID =
                                            int.Parse(httpContext.Request.QueryString["uid"]);
                                    }
                                    else
                                    {
                                        sUserID = EbSite.Base.AppStartInit.UserID;
                                        // EbSite.Base.AppStartInit.UserID;
                                    }
                                    EbSite.Base.EntityAPI.MembershipUserEb mdUser =
                                        EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(
                                            sUserID);
                                    if (!string.IsNullOrEmpty(mdUser.SpaceThemePath))
                                    {
                                        sRealUrl =
                                            string.Concat(EbSite.Base.AppStartInit.IISPath,
                                                "Home/themes/", mdUser.SpaceThemePath,
                                                "/uhome.aspx");
                                    }
                                    else
                                    {
                                        if (IsMyPlace(app)) //自己访问的自己
                                        {
                                            //如果不存在空间,指定到创建空间页面
                                            httpContext.Response.Redirect(
                                                EbSite.BLL.MenusForUser.Instance
                                                    .GetSpaceSettingUrl);
                                        }
                                        else //访问别人空间
                                        {
                                            EbSite.Base.AppStartInit.TipsPageRender(
                                                "空间没开通", "当前用户还没有创建空间",
                                                EbSite.Base.Host.Instance.Domain);
                                        }

                                        httpContext.Response.End();
                                    }

                                    //sRealUrl = GetLink.HrefFactory.GetInstance().Uhome;
                                }
                                else if (
                                    requestedPath.Equals(
                                        Base.PageLink.GetBaseLinks.Get(SiteID)
                                            .UccIndexRw.ToLower())) //用户控制面板
                                {
                                    sRealUrl =
                                        Base.PageLink.GetBaseLinks.Get(SiteID).UccIndex;

                                }
                                else if (IsMatchReWrite(requestedPath, UrlRules.errPage))
                                {
                                    string iId = "0";

                                    Match mc = Regex.Match(requestedPath,
                                        UrlRules.errPage);
                                    if (mc.Success)
                                    {
                                        iId = mc.Groups[1].Value;
                                    }
                                    sRealUrl =
                                        Base.PageLink.GetBaseLinks.Get(SiteID)
                                            .GetErrPage(iId);
                                }
                                else if (
                                    requestedPath.Equals(
                                        Base.PageLink.GetBaseLinks.Get(SiteID)
                                            .CustomSearchRw.ToLower())) //自定义搜索页
                                {
                                    sRealUrl =
                                        Base.PageLink.GetBaseLinks.Get(SiteID)
                                            .CustomSearch;
                                }
                                else if (IsMatchReWrite(requestedPath,
                                    UrlRules.IndexRule)) //首页分页列表情况
                                {
                                    int PageIndex = 0;
                                    Match mc = Regex.Match(requestedPath,
                                        UrlRules.IndexRule);
                                    if (mc.Success)
                                    {
                                        PageIndex = int.Parse(mc.Groups[1].Value);
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.IndexRule);
                                    }
                                    sRealUrl = LinkOrther.Instance.GetAspxInstance(SiteID).IndexForPage(PageIndex);
                                }
                                else if (IsMatchReWrite(requestedPath,
                                    UrlRules.sLoginBackBind))
                                //第三方登录回调地址
                                {
                                    string AppType = "";
                                    Match mc = Regex.Match(requestedPath, UrlRules.sLoginBackBind);
                                    if (mc.Success)
                                    {
                                        AppType = mc.Groups[1].Value;
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.SpecialRule);
                                    }
                                    sRealUrl = LinkOrther.Instance.GetAspxInstance(SiteID).GetLoginApiBackUrl(AppType);
                                }
                                else if (requestedPath.Equals(Base.PageLink.GetBaseLinks.Get(SiteID).PaymentRw.ToLower()))
                                //支付方式
                                {
                                    sRealUrl = Base.PageLink.GetBaseLinks.Get(SiteID).Payment;
                                }
                                else if (requestedPath.Equals(Base.PageLink.GetBaseLinks.Get(SiteID).DeliveryRw.ToLower()))
                                //配送方式
                                {
                                    sRealUrl = Base.PageLink.GetBaseLinks.Get(SiteID).Delivery;
                                }
                                else if (requestedPath.Equals(Base.PageLink.GetBaseLinks.Get(SiteID).FrdlinkRw.ToLower()))
                                //友情连接展示页
                                {
                                    sRealUrl = Base.PageLink.GetBaseLinks.Get(SiteID).Frdlink;
                                }
                                else if (requestedPath.Equals(Base.PageLink.GetBaseLinks.Get(SiteID).FrdlinkPostRw.ToLower()))
                                //友情连接展示页
                                {
                                    sRealUrl = Base.PageLink.GetBaseLinks.Get(SiteID).FrdlinkPost;
                                }
                                else if (requestedPath.Equals(Base.PageLink.GetBaseLinks.Get(SiteID).UserOnlineRw.ToLower()))//在线用户页
                                {
                                    sRealUrl = Base.PageLink.GetBaseLinks.Get(SiteID).UserOnline;
                                }
                                else if (IsMatchReWrite(requestedPath, UrlRules.uinfoRule))
                                //默认用户信息展示页，如果您还没有开通个人空间，点击用户连接时会连接到这个模板页面
                                {
                                    string UserID = "";
                                    Match mc = Regex.Match(requestedPath, UrlRules.uinfoRule);
                                    if (mc.Success)
                                    {
                                        UserID = mc.Groups[1].Value;
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.uinfoRule);

                                    }
                                    sRealUrl = LinkOrther.Instance.GetAspxInstance(SiteID).GetUserInfo(UserID);

                                }
                                else if (IsMatchReWrite(requestedPath, UrlRules.voteviewRule))
                                //投票展示页
                                {
                                    string voteid = "";
                                    Match mc = Regex.Match(requestedPath, UrlRules.voteviewRule);
                                    if (mc.Success)
                                    {
                                        voteid = mc.Groups[1].Value;
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.voteviewRule);

                                    }
                                    sRealUrl = LinkOrther.Instance.GetAspxInstance(SiteID).GetVoteView(voteid);

                                }
                                else if (IsMatchReWrite(requestedPath, UrlRules.votepostRule))
                                //投票提交页
                                {
                                    string voteid = "";
                                    Match mc = Regex.Match(requestedPath, UrlRules.votepostRule);
                                    if (mc.Success)
                                    {
                                        voteid = mc.Groups[1].Value;
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.votepostRule);

                                    }
                                    sRealUrl = LinkOrther.Instance.GetAspxInstance(SiteID).GetVotePost(voteid);

                                }

                                else if (IsMatchReWrite(requestedPath, UrlRules.topRule))
                                //数据排行榜页
                                {
                                    int toptype = 0;
                                    int pageindex = 1;
                                    Match mc = Regex.Match(requestedPath, UrlRules.topRule);
                                    if (mc.Success)
                                    {
                                        toptype = int.Parse(mc.Groups[1].Value);
                                        pageindex = int.Parse(mc.Groups[2].Value);
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.topRule);

                                    }
                                    sRealUrl = LinkOrther.Instance.GetAspxInstance(SiteID).GetTop(toptype, pageindex);

                                }
                                else if (IsMatchReWrite(requestedPath, UrlRules.sUserAlbum))
                                //个人收藏专辑
                                {


                                    int ClassId = 0;
                                    int PageIndex = 0;
                                    int uid = 0;
                                    Match mc = Regex.Match(requestedPath, UrlRules.sUserAlbum);
                                    if (mc.Success)
                                    {
                                        uid = int.Parse(mc.Groups[1].Value);
                                        ClassId = int.Parse(mc.Groups[2].Value);
                                        PageIndex = int.Parse(mc.Groups[3].Value);
                                        SiteID = GetSiteFolder(requestedPath, UrlRules.sUserAlbum);
                                    }
                                    sRealUrl = LinkOrther.Instance.GetAspxInstance(SiteID).UserAlbumHref(ClassId, PageIndex, uid);
                                }
                                else if (requestedPath.EndsWith(UrlRules.AllClassRule))
                                //所有分类页
                                {
                                    SiteID = GetSiteFolder(requestedPath, UrlRules.AllClassRule);
                                    sRealUrl = LinkClass.Instance.GetAspxInstance(SiteID).GetAllClassHref();
                                }
                                else if (IsMatchReWrite(requestedPath, UrlRules.discussRule))
                                //评论
                                {
                                    //连接规则:评论类别ID-系统分类ID-内容ID-展示模板ID-站点ID-分内或内容标记-dc.aspx
                                    Match mc = Regex.Match(requestedPath, UrlRules.discussRule);
                                    if (mc.Success)
                                    {
                                        int sClassDataID = int.Parse(mc.Groups[1].Value);
                                        int ClassID = int.Parse(mc.Groups[2].Value);
                                        int ContentID = int.Parse(mc.Groups[3].Value);
                                        int iDiscuzType = int.Parse(mc.Groups[4].Value);
                                        SiteID = int.Parse(mc.Groups[5].Value);
                                        int iPage = int.Parse(mc.Groups[6].Value);

                                        //string sMark = mc.Groups[2].Value;


                                        string temprule = "ask_";
                                        if (iDiscuzType == 1)
                                        //盖楼式评论
                                        {
                                            temprule = "discuss_";
                                        }
                                        else if (iDiscuzType == 2)
                                        //好评系统
                                        {
                                            temprule = "pj_";
                                        }
                                        else if (iDiscuzType == 3)
                                        //一问一答
                                        {
                                            temprule = "ask_";
                                        }
                                        EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(SiteID);
                                        temprule = string.Concat(temprule, string.Format("{0}.aspx?cid={0}&classid={1}&site={2}&ipage={3}&contentid={4}", sClassDataID,
                                                            ClassID,
                                                            SiteID,
                                                            iPage,
                                                            ContentID));
                                        sRealUrl = string.Concat(EbSite.Base.AppStartInit.IISPath, "themes/", mdSite.PageTheme, "/pages/", temprule);


                                    }

                                }

                                #endregion
                                    }

                                if (EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.SiteModule!=1&&string.IsNullOrEmpty(sRealUrl))
                                    {
                                        #region 手机版

                                        if(requestedPath.Equals(UrlRules.sMIndexNoPram))
                                            //手机版首页
                                        {
                                            sRealUrl=LinkMobile.InstanceAspx(SiteID).MIndexLink;

                                        }
                                        else if(IsMatchReWrite(requestedPath,UrlRules.sMIndex))
                                            //手机版首页
                                        {
                                            Match mc=Regex.Match(requestedPath,UrlRules.sMIndex);
                                            if(mc.Success)
                                            {
                                                SiteID=int.Parse(mc.Groups[1].Value);
                                            }
                                            sRealUrl=LinkMobile.InstanceAspx(SiteID).GetIndexHref();
                                        }
                                        else if(IsMatchReWrite(requestedPath,UrlRules.sMClassRule))
                                            //手机版分类列表页
                                        {
                                            int ClassId=0;
                                            int PageIndex=0;
                                            int Odb=0;

                                            Match mc=Regex.Match(requestedPath,UrlRules.sMClassRule);
                                            if(mc.Success)
                                            {
                                                ClassId=int.Parse(mc.Groups[1].Value);
                                                PageIndex=int.Parse(mc.Groups[2].Value);
                                                Odb=int.Parse(mc.Groups[3].Value);
                                                SiteID=int.Parse(mc.Groups[4].Value);

                                            }
                                            sRealUrl=LinkMobile.InstanceAspx(SiteID).GetClassHref(ClassId,PageIndex,Odb);
                                        }
                                        else if(IsMatchReWrite(requestedPath,UrlRules.sMClassIndexRule))
                                            //默认所有分类页
                                        {
                                            Match mc=Regex.Match(requestedPath,UrlRules.sMClassIndexRule);
                                            if(mc.Success)
                                            {
                                                SiteID=int.Parse(mc.Groups[1].Value);
                                            }
                                        sRealUrl=LinkMobile.InstanceAspx(SiteID).GetClassHref();
                                        }

                                        else if(IsMatchReWrite(requestedPath,UrlRules.sMContentRule))
                                            //手机版内容页
                                        {
                                            string ContentId="0";
                                            string ClassID="0";
                                            string PageIndex="0";
                                            Match mc=Regex.Match(requestedPath,UrlRules.sMContentRule);
                                            if(mc.Success)
                                            {
                                                ClassID=mc.Groups[1].Value;
                                                ContentId=mc.Groups[2].Value;
                                                SiteID=int.Parse(mc.Groups[3].Value);
                                                PageIndex=mc.Groups[4].Value;
                                            }
                                            sRealUrl=LinkMobile.InstanceAspx(SiteID).GetContentLink(ContentId,ClassID,PageIndex);
                                        }
                                        //else if(IsMatchReWrite(requestedPath,UrlRules.sMContentRuleDefault))
                                        //    //手机版内容面页默认
                                        //{
                                        //    string ContentId="0";
                                        //    Match mc=Regex.Match(requestedPath,UrlRules.sMContentRuleDefault);
                                        //    if(mc.Success)
                                        //    {
                                        //        ContentId=mc.Groups[1].Value;
                                        //        SiteID=int.Parse(mc.Groups[2].Value);
                                        //    }
                                        //    sRealUrl=LinkMobile.InstanceAspx(SiteID).GetContentLink(ContentId);
                                        //}
                                        else if(IsMatchReWrite(requestedPath,UrlRules.sMSpecial))
                                            //专题列表页
                                        {
                                            Match mc=Regex.Match(requestedPath,UrlRules.sMSpecial);
                                            int ClassId=0;
                                            int PageIndex=0;
                                            if(mc.Success)
                                            {
                                                ClassId=int.Parse(mc.Groups[1].Value);
                                                PageIndex=int.Parse(mc.Groups[2].Value);
                                                SiteID=int.Parse(mc.Groups[3].Value);
                                            }
                                            sRealUrl=LinkMobile.InstanceAspx(SiteID).GetSpecialHref(ClassId,PageIndex);
                                        }
                                        else if(IsMatchReWrite(requestedPath,UrlRules.sMSpecialIndex))
                                            //专题首页
                                        {
                                            Match mc=Regex.Match(requestedPath,UrlRules.sMSpecialIndex);
                                            if(mc.Success)
                                            {
                                                SiteID=int.Parse(mc.Groups[1].Value);
                                            }
                                            sRealUrl=LinkMobile.InstanceAspx(SiteID).GetSpecialHref();
                                        }
                                        else if(IsMatchReWrite(requestedPath,UrlRules.sMTagsRule))
                                            //标签列表
                                        {

                                            int TagPageIndex=0;
                                            Match mc=Regex.Match(requestedPath,UrlRules.sMTagsRule);
                                            if(mc.Success)
                                            {
                                                SiteID=int.Parse(mc.Groups[1].Value);
                                                TagPageIndex=int.Parse(mc.Groups[2].Value);
                                            }
                                            //sRealUrl=LinkMobile.InstanceAspx(SiteID).GetTagsHref(TagPageIndex);
                                            string tgvRealUrl = LinkMobile.InstanceAspx(SiteID).GetTagsHref(TagPageIndex);

                                            if (EbSite.BLL.Sites.Instance.GetLinkTypeTags(SiteID) == LinkType.AutoHtml)
                                            {
                                                string CacheUrl = string.Concat(AppStartInit.IISPath, AppStartInit.CacheFolder,"tagsm/p", TagPageIndex, "s", SiteID, ".htm");
                                                sRealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, tgvRealUrl);
                                            }
                                            else
                                            {
                                                sRealUrl = tgvRealUrl;
                                            }

                                        }
                                        else if(IsMatchReWrite(requestedPath,UrlRules.sMTagsSearchRuleByID))
                                            //标签内容
                                        {

                                            int PageIndex=0;
                                            string stid=string.Empty;
                                            Match mc=Regex.Match(requestedPath,UrlRules.sMTagsSearchRuleByID);
                                            if(mc.Success)
                                            {
                                                SiteID=int.Parse(mc.Groups[1].Value);
                                                stid=mc.Groups[2].Value;
                                                PageIndex=int.Parse(mc.Groups[3].Value);
                                            }
                                            //sRealUrl=LinkMobile.InstanceAspx(SiteID).GetTagvHref(stid,PageIndex);

                                            string tgvRealUrl = LinkMobile.InstanceAspx(SiteID).GetTagvHref(stid, PageIndex);

                                            if (EbSite.BLL.Sites.Instance.GetLinkTypeTags(SiteID) == LinkType.AutoHtml)
                                            {
                                                string CacheUrl = string.Concat(AppStartInit.IISPath, AppStartInit.CacheFolder,"tagvm/id", stid, "p", PageIndex, "s", SiteID, ".htm");
                                                sRealUrl = EbSite.Base.Static.HtmlPool.GetCacheUrl(CacheUrl, tgvRealUrl);
                                            }
                                            else
                                            {
                                                sRealUrl = tgvRealUrl;
                                            }

                                        }
                                        else if(requestedPath.Equals(Base.PageLink.GetBaseLinks.Get(SiteID).MLoginRw.ToLower()))
                                            //登录
                                        {
                                            sRealUrl=Base.PageLink.GetBaseLinks.Get(SiteID).MLogin;
                                        }
                                        else if(requestedPath.Equals(Base.PageLink.GetBaseLinks.Get(SiteID).MLostpasswordRw.ToLower()))
                                            //找加密
                                        {
                                            sRealUrl=Base.PageLink.GetBaseLinks.Get(SiteID).MLostpassword;
                                        }
                                        else if(requestedPath.Equals(Base.PageLink.GetBaseLinks.Get(SiteID).MRegRw.ToLower()))
                                            //注册
                                        {
                                            sRealUrl=Base.PageLink.GetBaseLinks.Get(SiteID).MReg;
                                        }
                                        else if(requestedPath.Equals(Base.PageLink.GetBaseLinks.Get(SiteID).MSearchRw.ToLower()))
                                            //搜索
                                        {
                                            sRealUrl=Base.PageLink.GetBaseLinks.Get(SiteID).MSearch;
                                        }
                                        else if(requestedPath.Equals(Base.PageLink.GetBaseLinks.Get(SiteID).MUccIndexRw.ToLower()))
                                            //用户控制面板
                                        {
                                            sRealUrl=Base.PageLink.GetBaseLinks.Get(SiteID).MUccIndex;
                                        }
                                        else if(requestedPath.Equals(Base.PageLink.GetBaseLinks.Get(SiteID).MUccUserInfoRw.ToLower()))
                                            //用户信息详细页
                                        {
                                            sRealUrl=Base.PageLink.GetBaseLinks.Get(SiteID).MUccUserInfo;
                                        }

                                        #endregion
                                    }


                               
                            }
                        }
                      
                       
                    }

            }
           
            //定向到真实页面
            ToRewritePath(sRealUrl, httpContext);
           

        }
        //private bool IsMobile(string requestedPath)
        //{
        //    if (requestedPath.ToLower().StartsWith(AppStartInit.MPathUrl))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        private bool IsGoToReWrite(string requestedPath)
        {
           
            string rqTolower = requestedPath.ToLower();
            //if ((rqTolower.IndexOf(".aspx") != -1 || rqTolower.EndsWith("/")  || rqTolower.IndexOf(".ashx") != -1 || rqTolower.IndexOf(".htm") != -1 || rqTolower.IndexOf(".html") != -1 || rqTolower.IndexOf(".do") != -1) || rqTolower.IndexOf(".dll") != -1 && IsRootPath(requestedPath))
            //{
            if ((rqTolower.EndsWith(".aspx") || rqTolower.EndsWith("/") || rqTolower.EndsWith(".ashx") || rqTolower.EndsWith(".htm") || rqTolower.EndsWith(".html") || rqTolower.EndsWith(".do") || rqTolower.EndsWith(".dll")))//&& IsRootPath(requestedPath)
            {
                if (!(rqTolower.StartsWith("/index.aspx") || rqTolower.StartsWith("/ajaxget/") || rqTolower.StartsWith("/count.ashx") || rqTolower.StartsWith("/custompages/") || rqTolower.StartsWith("/paycallback/") || rqTolower.StartsWith("/dialog/")))
                {
                    if ((rqTolower.StartsWith("/themes/") || rqTolower.StartsWith("/themesm/") || rqTolower.StartsWith("/js/")))
                    {
                        if(rqTolower.EndsWith("ebcss.ashx"))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                   
                }
            }
            
            return false;
        }

        private void ToRewritePath(string sRealUrl, HttpContext httpContext)
        {
            if (!string.IsNullOrEmpty(sRealUrl))
            {
                //对静态页面进行gzip
                if (sRealUrl.EndsWith(".html") || sRealUrl.EndsWith(".htm"))
                {
                    //httpContext.RewritePath(sRealUrl);
                    
                    string sPath = httpContext.Server.MapPath(sRealUrl);
                    httpContext.Response.ContentType = "text/html";//如果不加这个在google浏览器或360极速浏览器下直接显示源码
                    httpContext.Response.TransmitFile(sPath);
                    if (EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.EnableHttpCompression)
                    {
                        if (IsEncodingAccepted("gzip"))
                        {
                            httpContext.Response.Filter = new GZipStream(httpContext.Response.Filter, CompressionMode.Compress);
                            SetEncoding("gzip");
                        }
                        else if (IsEncodingAccepted("deflate"))
                        {
                            httpContext.Response.Filter = new DeflateStream(httpContext.Response.Filter, CompressionMode.Compress);
                            SetEncoding("deflate");
                        }
                    }
                    httpContext.Response.End();
                    return;
                }
                else
                {
                    string sQueStr = httpContext.Request.QueryString.ToString();

                    if (!string.IsNullOrEmpty(sQueStr))
                    {
                        if (sRealUrl.IndexOf(".aspx?") > 1 || sRealUrl.IndexOf(".ashx?") > -1)
                        {
                            sRealUrl = string.Concat(sRealUrl, "&", sQueStr);
                        }
                        else
                        {
                            sRealUrl = string.Concat(sRealUrl, "?", sQueStr);
                        }
                    }
                    httpContext.RewritePath(sRealUrl);
                }
                
                
                
            }
        }

        /// <summary>
        /// 当前访问是不是自己
        /// </summary>
        protected bool IsMyPlace(System.Web.HttpApplication context)
        {
            if (context.Request.QueryString["v"] == "1") //一览模式
                    return false;
            return context.Request.QueryString["uid"] == EbSite.Base.Host.Instance.UserID.ToString();
            
        }
        /// <summary>
        /// 是否一级目录 只对一级地址处理
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        private bool IsRootPath(string Url)
        {
            bool IsPPath = false;
            if(!string.IsNullOrEmpty(Url))
            {
                if (!string.IsNullOrEmpty(EbSite.Base.AppStartInit.IISPath))
                    Url = Url.Replace(EbSite.Base.AppStartInit.IISPath, "");
                IsPPath =  (Url.IndexOf("/") == -1) ;
            }
            return IsPPath;
        }

       
        private int GetSiteFolder(string sUrl,string rg)
        {
            string sRegexRule = string.Concat("/([\\w]+)", rg);
            string Folder = "";
            Match mc = Regex.Match(sUrl, sRegexRule);
            if (mc.Success)
            {
                Folder = mc.Groups[1].Value;
              
            }
           
            return EbSite.BLL.Sites.Instance.GetSiteIDBySiteFolder(Folder);
        }

        private bool IsMatchReWrite(string sUrl,string rg)
        {
            Match mc = Regex.Match(sUrl, rg);
            return mc.Success;
        }

        private static void SetEncoding(string encoding)
        {
            HttpContext.Current.Response.AppendHeader("Content-encoding", encoding);
        }
        private static bool IsEncodingAccepted(string encoding)
        {
            var context = HttpContext.Current;
            return context.Request.Headers["Accept-encoding"] != null &&
                   context.Request.Headers["Accept-encoding"].Contains(encoding);
        }
       
    }
}
