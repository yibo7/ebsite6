//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Web;
//using System.Web.Profile;
//using System.Web.Routing;
//using System.Web.Security;
//using System.Web.UI.WebControls;
//using EbSite.Base;
//using EbSite.Base.Configs.SysConfigs;
//using EbSite.Base.DataProfile;
//using EbSite.Base.EBSiteEventArgs;
//using EbSite.Base.Modules;
//using EbSite.BLL.GetLink;
//using EbSite.Control;
//using EbSite.Modules.BBS.ModuleCore;
//using EbSite.Modules.BBS.ModuleCore.BLL;
//using Repeater = System.Web.UI.WebControls.Repeater;

////using EbSite.Modules.BBS.ModuleCore.Cart;

//namespace EbSite.Modules.BBS
//{
//    public class ModuleGlobal : ModuleGlobalBase
//    {
//        private static string StartupOK = null;
//        private static object _SyncRoot = new object();
//        static private int SiteID = 0;
//        public ModuleGlobal()
//        {
//            //获取当前模块所在的站点Id,这样做可以防止别的站点下事件执行到这里搂
//            //也就是说，如果当前访问非当前站点时，可以不处理事件(在下面会用到)
//            SiteID = SettingInfo.Instance.GetSysConfig.Instance.GetSiteID;
//        }

//        override public void Application_Start(object sender, EventArgs e)
//        {

//        }

//        override public void Application_BeginRequest(object sender, EventArgs e)
//        {
//            if (StartupOK == null)
//            {
//                lock (_SyncRoot)
//                {
//                    if (StartupOK == null)
//                    {
//                        EbSite.Base.EBSiteEvents.HttpModuleRuning += new EventHandler<HttpModuleRuningEventArgs>(On_HttpModuleRuning);
//                        //分类页面事件处理
//                        //EbSite.Base.EBSiteEvents.ClassItemBound += new EventHandler<RepeaterItemEventArgs>(onrpIndexList_ItemBound);
//                        EbSite.Base.EBSiteEvents.ClassPageLoadingEvent += new EventHandler<ClassPageLoadingEventArgs>(On_ClassPageLoadingEvent);
//                        EbSite.Base.EBSiteEvents.ClassPageLoadEvent += new EventHandler<ClassPageLoadEventArgs>(On_ClassPageLoadEvent);
//                        //内容页面事件处理
//                        EbSite.Base.EBSiteEvents.ContentPageLoadEvent += new EventHandler<ContentPageLoadEventArgs>(On_ContentPageLoadEvent);

//                        EbSite.Base.EBSiteEvents.ClassAdded += new EventHandler<AddedClassEventArgs>(On_ClassAddedEvent);
//                        EbSite.Base.EBSiteEvents.ClassUpdated += new EventHandler<UpdatedClassEventArgs>(On_ClassUpdatedEvent);

//                        StartupOK = "OK";
//                    }
//                }
//            }


//        }
//        /// <summary>
//        /// 更新分类时，如果不存在表，也会生成，如果存在不处理
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private static void On_ClassUpdatedEvent(object sender, UpdatedClassEventArgs e)
//        {
//            if (e.ID > 0 && e.Entity.SiteID == SiteID)
//            {
//                string tablename = Comm.GetPostTableNamePre(e.ID);//表名称

//                int isok = TopicReplies.Instance.TopicReplies_Copy(tablename);

//            }
//        }

//        private static void On_ClassAddedEvent(object sender, AddedClassEventArgs e)
//        {
//            if (e.ID > 0 && e.Entity.SiteID == SiteID)
//            {
//                string tablename = Comm.GetPostTableNamePre(e.ID);//表名称

//                int isok = TopicReplies.Instance.TopicReplies_Copy(tablename);

//            }
//        }

//        //private static void On_ContentPageLoading(object sender, ContentPageLoadingEventArgs e)
//        //{
//        //    if (e.ContentID > 0)
//        //    {
//        //        Entity.NewsClass Model = BLL.NewsClass.GetModelByCache(e.ClassID);
//        //        if (!Equals(Model, null))
//        //        {
//        //            if (Convert.ToInt32(Model.Annex9) > 0)
//        //            {
//        //                if (Convert.ToInt32(Model.Annex9) != Host.Instance.CurrentFirstGroupID)
//        //                {
//        //                    Host.Instance.Tips("出错了", "你没有访问当前版块的权限", "");
//        //                }
//        //            }

//        //        }
//        //        else
//        //        {
//        //            Host.Instance.GetLinkOrErr("当前版块不存在！");
//        //        }
//        //    }
//        //    else
//        //    {
//        //        Host.Instance.GetLinkOrErr("当前版块不存在！");
//        //    }
//        //}

//        public override void Session_Start(object sender, EventArgs e)
//        {
//            BBSClass.ClearToDayCount();
//        }


//        private static void On_ClassPageLoadingEvent(object sender, ClassPageLoadingEventArgs e)
//        {
//            if (e.SiteID == SiteID)
//            {
//                //验证分类访问权限
//                if (e.ClassID > 0)
//                {
//                    Entity.NewsClass Model = BLL.NewsClass.GetModelByCache(e.ClassID);
//                    if (!Equals(Model, null))
//                    {
//                        if (Convert.ToInt32(Model.Annex9) > 0)
//                        {
//                            //if (Convert.ToInt32(Model.Annex9) != Host.Instance.CurrentFirstGroupID)
//                            if (Convert.ToInt32(Model.Annex9) != EbSite.Base.AppStartInit.RoleID)
//                            {
//                                //e.Context.Response.StatusCode = 403;
//                                Host.Instance.Tips("出错了", "你没有访问当前版块的权限", "");
//                            }
//                        }

//                    }
//                    else
//                    {
//                        //e.Context.Response.StatusCode = 403;
//                        Host.Instance.GetTips("当前版块不存在！");
//                    }
//                }
//                else
//                {
//                    //e.Context.Response.StatusCode = 403;
//                    Host.Instance.GetTips("当前版块不存在！");
//                }
//            }

//        }
//        private static void On_ClassPageLoadEvent(object sender, ClassPageLoadEventArgs e)
//        {
//            if (e.SiteID == SiteID)
//            {

//                Control.Repeater rpTopicReplies = e.Page.FindControl("rpTops") as Control.Repeater;
//                if (!Equals(rpTopicReplies, null))
//                {

//                    string sWhere = string.Format("Annex15=1 or (ClassID={0} and IsGood=1) ", e.ClassID);
//                    rpTopicReplies.DataSource = EbSite.Base.AppStartInit.GetNewsContentInst(e.ClassID).GetListArray(sWhere, 0, "NumberTime desc", "", e.SiteID);
//                    rpTopicReplies.DataBind();

//                }
//            }

//        }

//        private static void On_ContentPageLoadEvent(object sender, ContentPageLoadEventArgs e)
//        {
//            //Log.Factory.GetInstance().InfoLog(string.Format("转入ID:{0} 站点Id:{1}", e.SiteID, SiteID));
//            if (e.SiteID == SiteID)
//            {

//                //对访问权限验证
//                if (e.ContentID > 0)
//                {
//                    Entity.NewsClass Model = BLL.NewsClass.GetModelByCache(e.ContentModel.ClassID);
//                    if (!Equals(Model, null))
//                    {
//                        if (Convert.ToInt32(Model.Annex9) > 0)
//                        {
//                            //if (Convert.ToInt32(Model.Annex9) != Host.Instance.CurrentFirstGroupID)
//                            if (Convert.ToInt32(Model.Annex9) != Base.AppStartInit.RoleID)
//                            {
//                                e.Context.Response.StatusCode = 403;
//                                Host.Instance.Tips("出错了", "你没有访问当前版块的权限", "");

//                                return;
//                            }
//                        }

//                    }
//                    else
//                    {
//                        e.Context.Response.StatusCode = 403;
//                        Host.Instance.Tips("出错了", "当前版块不存在！");
//                        return;
//                    }
//                }
//                else
//                {
//                    e.Context.Response.StatusCode = 403;
//                    Host.Instance.Tips("出错了", "当前版块不存在！");
//                    return;
//                }

//                //加载回帖
//                Control.Repeater rpTopicReplies = e.Page.FindControl("rpTopicReplies") as Control.Repeater;
//                PagesContrl pc1 = e.Page.FindControl("pgCtr1") as Control.PagesContrl;
//                if (!Equals(rpTopicReplies, null) && !Equals(pc1, null))
//                {

//                    string CurrentUrl = EbSite.BLL.GetLink.LinkContent.Instance.GetReWriteInstance(e.SiteID).GetContentLink(e.ContentID, e.ContentModel.ClassID, 0);

//                    PagesContrl pc2 = e.Page.FindControl("pgCtr2") as Control.PagesContrl;
//                    int PageIndex = EbSite.Core.Utils.StrToInt(e.Context.Request["p"], 1);
//                    int RecordCount = 0;
//                    int iPageSize = 2;
//                    if (pc1.PageSize > 0)
//                        iPageSize = pc1.PageSize;

//                    rpTopicReplies.DataSource = ModuleCore.BLL.TopicReplies.Instance.GetListPagesByPostID(PageIndex, iPageSize, out RecordCount, e.ContentModel.ID, e.ContentModel.ClassID);
//                    rpTopicReplies.DataBind();
//                    // /bbs/12551a1044b0c.html
//                    string PageRule = GetLinks.ContentPageRule(e.ContentID, e.SiteID, e.ClassID);
//                    pc1.Linktype = LinkType.AspxRewrite;
//                    pc1.AllCount = RecordCount;
//                    pc1.PageSize = iPageSize;
//                    pc1.CurrentClass = "CurrentPageCoder";
//                    pc1.ParentClass = "PagesClass";
//                    pc1.ReWritePatchUrl = PageRule;// string.Concat(e.ContentID, "-{0}-", e.SiteID, EbSite.Base.Host.Instance.ContentLinkRw(e.SiteID)); //{0} 页码
//                    pc1.FirstPageUrl = CurrentUrl;

//                    if (!Equals(pc2, null))
//                    {
//                        pc2.Linktype = LinkType.AspxRewrite;
//                        pc2.AllCount = RecordCount;
//                        pc2.PageSize = iPageSize;
//                        pc2.CurrentClass = "CurrentPageCoder";
//                        pc2.ParentClass = "PagesClass";
//                        pc2.ReWritePatchUrl = PageRule;// string.Concat(e.ContentID, "-{0}-", e.SiteID, EbSite.Base.Host.Instance.ContentLinkRw(e.SiteID)); //{0} 页码
//                        pc2.FirstPageUrl = CurrentUrl;
//                    }
//                    if (PageIndex > 1)  //分页后，主题应该隐藏
//                    {
//                        PlaceHolder phMainModel = e.Page.FindControl("phMainModel") as PlaceHolder;
//                        if (!Equals(phMainModel, null))
//                        {
//                            phMainModel.Visible = false;
//                        }
//                    }

//                }
//            }

//        }

//        private static void On_HttpModuleRuning(object sender, HttpModuleRuningEventArgs e)
//        {
//            HttpContext httpContext = e.App.Context;
//            string requestPath = httpContext.Request.Path.ToLower();

//            #region

//            string strRulesavepost = "savepost-([0-9]+)-([0-9]+).html";
//            string strReplyt = "reply-([0-9]+)-([0-9]+).html";
//            //string strContent = string.Concat("([0-9]+)-([0-9]+)-([0-9]+)-([0-9]+)", EbSite.Base.Host.Instance.ContentLinkRw(1));
//            string sContentRule = Base.Configs.ContentSet.ConfigsControl.Instance.ContentPathRw.Replace("{分类ID}", "([0-9]+)");

//            string strContent = string.Concat("/", Base.Configs.ContentSet.ConfigsControl.Instance.ContentPathRw.Replace("{分类ID}", "([0-9]+)").Replace("{页码}", "([0-9]+)").Replace("{内容ID}", "([0-9]+)").Replace(".", "p([0-9]+)."));
//            string strRuleOperation = "operation-([0-9]+)-([0-9]+).html";

//            string strRulesavepostM = "savepostm-([0-9]+)-([0-9]+).html";

//            if (Core.Utils.IsMatchReWrite(requestPath, strRulesavepost)) //发表帖子
//            {
//                Match mc = Regex.Match(requestPath, strRulesavepost);
//                if (mc.Success)
//                {
//                    int iSiteID = int.Parse(mc.Groups[1].Value);
//                    string classid = mc.Groups[2].Value;
//                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
//                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("msavepost.aspx"), "?cid=", classid, "&site=", iSiteID);
//                    e.IsStop = true;
//                }
//            }
//            else if (Core.Utils.IsMatchReWrite(requestPath, strContent))
//            {
//                Match mc = Regex.Match(requestPath, strContent);
//                if (mc.Success)
//                {
//                    int ClassID = int.Parse(mc.Groups[1].Value);
//                    int iContentID = int.Parse(mc.Groups[2].Value);
//                    string PageIndex = mc.Groups[4].Value;
//                    //int SiteID = int.Parse(mc.Groups[3].Value);
//                    int SiteID = GetSiteFolder(requestPath, strContent);
//                    //int PI = int.Parse(mc.Groups[1].Value);


//                    //ClassID = Core.Utils.StrToInt(mc.Groups[1].Value, 0);
//                    //ContentId = mc.Groups[2].Value;
//                    //iPageIndex = mc.Groups[3].Value;

//                    e.RealUrl = string.Concat(LinkContent.Instance.GetAspxInstance(SiteID).GetContentLink(iContentID, ClassID, 0), "&p=", PageIndex);
//                    e.IsStop = true;
//                }
//            }
//            else if (Core.Utils.IsMatchReWrite(requestPath, strReplyt))
//            {
//                Match mc = Regex.Match(requestPath, strReplyt);
//                if (mc.Success)
//                {
//                    int iSiteID = int.Parse(mc.Groups[1].Value);
//                    string postid = mc.Groups[2].Value;
//                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
//                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("mreply.aspx"), "?postid=", postid, "&site=", iSiteID);
//                    e.IsStop = true;
//                }
//            }
//            else if (Core.Utils.IsMatchReWrite(requestPath, strRuleOperation))
//            {
//                Match mc = Regex.Match(requestPath, strRuleOperation);
//                if (mc.Success)
//                {
//                    int iSiteID = int.Parse(mc.Groups[1].Value);
//                    string classid = mc.Groups[2].Value;
//                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
//                    e.RealUrl = string.Concat(mdSite.GetCurrentPageUrl("moperation.aspx"), "?site=", iSiteID, "&cid=", classid);
//                    e.IsStop = true;
//                }
//            }
//            else if (Core.Utils.IsMatchReWrite(requestPath, strRulesavepostM)) //发表帖子
//            {
//                Match mc = Regex.Match(requestPath, strRulesavepostM);
//                if (mc.Success)
//                {
//                    int iSiteID = int.Parse(mc.Groups[1].Value);
//                    string classid = mc.Groups[2].Value;
//                    EbSite.Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntityCache(iSiteID);
//                    e.RealUrl = string.Concat(mdSite.MGetCurrentPageUrl("msavepost.aspx"), "?cid=", classid, "&site=", iSiteID);

//                    e.IsStop = true;
//                }
//            }
//            #endregion

//        }

//        static private int GetSiteFolder(string sUrl, string rg)
//        {
//            string sRegexRule = string.Concat("/([\\w]+)", rg);
//            string Folder = "";
//            Match mc = Regex.Match(sUrl, sRegexRule);
//            if (mc.Success)
//            {
//                Folder = mc.Groups[1].Value;

//            }

//            return EbSite.BLL.Sites.Instance.GetSiteIDBySiteFolder(Folder);
//        }
//        //public void onrpIndexList_ItemBound(object sender, RepeaterItemEventArgs e)
//        //{

//        //    if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
//        //    {
//        //        Repeater rpSub = e.Item.FindControl("rpSubBBS") as Repeater;
//        //        if (!Equals(rpSub, null))
//        //        {
//        //            EbSite.Entity.NewsClass md = e.Item.DataItem as EbSite.Entity.NewsClass;
//        //            if (!Equals(md, null))
//        //            {
//        //                rpSub.DataSource = EbSite.BLL.NewsClass.GetSubClass(md.ID, 0, EbSite.Base.Host.Instance.GetSiteID);
//        //                rpSub.DataBind();
//        //            }

//        //        }
//        //    }

//        //}


//    }
//}