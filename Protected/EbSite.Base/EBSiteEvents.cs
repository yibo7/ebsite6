using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Profile;
using System.Web.UI.WebControls;
using EbSite.Base.EBSiteEventArgs;

namespace EbSite.Base
{
    /// <summary>
    /// EBSite所有的对外开发事件将定义到这里来
    /// </summary>
    public class EBSiteEvents
    {
        #region MvcRouteHandlerEventArgs事件
        static public event EventHandler<MvcRouteHandlerEventArgs> EbMvcRouteHandler;
        /// <summary>
        /// 在MVC执行RouteHandler后执行，可扩展IHttpHandler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        static public void OnEbMvcRouteHandler(object sender, MvcRouteHandlerEventArgs arg)
        {
            if (!Equals(EbMvcRouteHandler, null))
            {
                EbMvcRouteHandler(sender, arg);
            }
        }
        #endregion

        #region WCF下的事件
        //public static event EventHandler<GetVersionEventArgs> GetVersion;
        //public static void OnGetVersion(object sender, GetVersionEventArgs arg)
        //{
        //    if (GetVersion != null)
        //    {
        //        GetVersion(sender, arg);
        //    }
        //}
        #endregion

        #region Profiles事件
        static public event EventHandler<DeleteProfilesArgs> EDeleteProfilesArgs;
        /// <summary>
        /// 删除Profiles数据时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        static public void OnDeleteProfilesArgs(object sender, DeleteProfilesArgs arg)
        {
            if (!Equals(EDeleteProfilesArgs, null))
            {
                EDeleteProfilesArgs(sender, arg);
            }
        }
        #endregion

        #region CMS分类处理事件

        public static event EventHandler<AddingClassEventArgs> ClassAdding;
        /// <summary>
        /// 添加一个分类之前触发事件
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnClassAdding(EbSite.Entity.NewsClass model, AddingClassEventArgs arg)
        {
            if (ClassAdding != null)
            {
               
                ClassAdding(model, arg);
            }
        }


        public static event EventHandler<UpdatedClassEventArgs> ClassUpdated;
        /// <summary>
        /// 添加一个分类之前触发事件
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnClassUpdated(EbSite.Entity.NewsClass model, UpdatedClassEventArgs arg)
        {
            if (ClassUpdated != null)
            {
                ClassUpdated(model, arg);
            }
        }

        public static event EventHandler<AddedClassEventArgs> ClassAdded;
        /// <summary>
        /// 添加一个分类之后触发事件
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnClassAdded(EbSite.Entity.NewsClass model, AddedClassEventArgs arg)
        {
            if (ClassAdded != null)
            {
                ClassAdded(model, arg);
            }
        }

        public static event EventHandler<DeletedClassEventArgs> ClassDeleted;
        /// <summary>
        /// 删除一条记录后触发
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnClassDeleted(EbSite.Entity.NewsClass model, DeletedClassEventArgs arg)
        {
            if (ClassDeleted != null)
            {
                ClassDeleted(model, arg);
            }
        }

        public static event EventHandler<DeleteingClassEventArgs> ClassDeleteing;
        /// <summary>
        /// 删除一条记录后触发
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnClassDeleteing(EbSite.Entity.NewsClass model, DeleteingClassEventArgs arg)
        {
            if (ClassDeleteing != null)
            {
                ClassDeleteing(model, arg);
            }
        }

        public static event EventHandler<GetClassEntityEventArgs> GetClassEntityed;
        /// <summary>
        /// 获取一个记录前触发
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnGetClassEntityed(EbSite.Entity.NewsClass model, GetClassEntityEventArgs arg)
        {
            if (GetClassEntityed != null)
            {
                GetClassEntityed(model, arg);
            }
        }
        public static event EventHandler<ClassListLaodingEventArgs> ClassListLoading;
        /// <summary>
        /// 当分类列表载入前处理事件
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnClassListLoading(object sender, ClassListLaodingEventArgs arg)
        {
            if (ClassListLoading != null)
            {
                ClassListLoading(sender, arg);
            }
        }
        #endregion


        #region CMS内容处理事件

        public static event EventHandler<AddedContentEventArgs> ContentAdded;
        /// <summary>
        /// 内容添加后触发
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnContentAdded(EbSite.Entity.NewsContent model, AddedContentEventArgs arg)
        {
            if (ContentAdded != null)
            {
                ContentAdded(model, arg);
            }
        }

        public static event EventHandler<AddingContentEventArgs> ContentAdding;
        /// <summary>
        /// 内容添加前触发
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnContentAdding(EbSite.Entity.NewsContent model, AddingContentEventArgs arg)
        {
            if (ContentAdding != null)
            {
                ContentAdding(model, arg);
            }
        }
        public static event EventHandler<UpdateingContentEventArgs> ContentUpdateing;
        /// <summary>
        /// 内容更新前触发
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnContentUpdateing(EbSite.Entity.NewsContent model, UpdateingContentEventArgs arg)
        {
            if (ContentUpdateing != null)
            {
                ContentUpdateing(model, arg);
            }
        }
        public static event EventHandler<DeleteingContentEventArgs> ContentDeleteing;
        /// <summary>
        /// 删除一条记录后触发
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnContentDeleteing(EbSite.Entity.NewsContent model, DeleteingContentEventArgs arg)
        {
            if (ContentDeleteing != null)
            {
                ContentDeleteing(model, arg);
            }
        }

        public static event EventHandler<GetContentEntityEventArgs> GetContentEntityed;
        /// <summary>
        /// 获取一个记录后触发
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnGetContentEntityed(EbSite.Entity.NewsContent model, GetContentEntityEventArgs arg)
        {
            if (GetContentEntityed != null)
            {
                GetContentEntityed(model, arg);
            }
        }

        #endregion

        #region 静态页生成

        public static event EventHandler<MakedEventArgs> IndexMaked;
        /// <summary>
        /// 生成首页时触发,id 为站点ID
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnIndexMaked(object sender, MakedEventArgs arg)
        {
            if (IndexMaked != null)
            {
                IndexMaked(sender, arg);
            }
        }

        public static event EventHandler<MakeingEventArgs> HTMLMakeing;
        /// <summary>
        /// 所有静态页生成时触发 ID为0
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnHTMLMakeing(object sender, MakeingEventArgs arg)
        {
            if (HTMLMakeing != null)
            {
                HTMLMakeing(sender, arg);
            }
        }

        public static event EventHandler<MakedEventArgs> ContentMaked;
        /// <summary>
        /// 生成内容页面生成成功后调用，ID为内容ID
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnContentMaked(object sender, MakedEventArgs arg)
        {
            if (ContentMaked != null)
            {
                ContentMaked(sender, arg);
            }
        }



        public static event EventHandler<MakedEventArgs> ClassMaked;
        /// <summary>
        /// 生成分类页面生成成功后调用，ID为分类ID
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnClassMaked(object sender, MakedEventArgs arg)
        {
            if (ClassMaked != null)
            {
                ClassMaked(sender, arg);
            }
        }



        public static event EventHandler<MakedEventArgs> SpecialMaked;
        /// <summary>
        /// 生成专题页面生成成功后调用，ID为专题ID
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnSpecialMaked(object sender, MakedEventArgs arg)
        {
            if (SpecialMaked != null)
            {
                SpecialMaked(sender, arg);
            }
        }

        public static event EventHandler<MakedEventArgs> TagListMaked;
        /// <summary>
        /// 生成专题页面生成成功后调用，ID为0
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnTagListMaked(object sender, MakedEventArgs arg)
        {
            
            if (TagListMaked != null)
            {
                TagListMaked(sender, arg);
            }
        }

        public static event EventHandler<MakedEventArgs> TagSearchListMaked;
        /// <summary>
        /// 生成标签搜索页面生成成功后调用，ID为标签ID
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnTagSearchListMaked(object sender, MakedEventArgs arg)
        {

            if (TagListMaked != null)
            {
                TagListMaked(sender, arg);
            }
        }


        public static event EventHandler<EventArgs> MakeHtmlErred;
        /// <summary>
        /// 生成每个页面发生错误触发
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnMakeHtmlErred(EbSite.Entity.Logs log, EventArgs arg)
        {
            if (MakeHtmlErred != null)
            {
                MakeHtmlErred(log, arg);
            }
        }

        #endregion

        #region 支付回馈事件

        public static event EventHandler<PayedEventArgs> Payed;
        /// <summary>
        /// 生成首页时触发,id 为站点ID
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnPayed(object sender, PayedEventArgs arg)
        {
            if (Payed != null)
            {
                Payed(sender, arg);
            }
        }

        #endregion

        #region 搜索事件

        public static event EventHandler<SearchEventArgs> Searching;
        /// <summary>
        /// 生成首页时触发,id 为站点ID
        /// </summary>
        /// <param name="log"></param>
        /// <param name="arg"></param>
        public static void OnSearching(object sender, SearchEventArgs arg)
        {
            if (Searching != null)
            {
                Searching(sender, arg);
            }
        }

        #endregion


        #region 审核扩展事件

        public static event EventHandler<AllowContentEventArgs> AllowContentEvent;

        public static void OnAllowContent(object sender, AllowContentEventArgs arg)
        {
            if (AllowContentEvent != null)
            {
                AllowContentEvent(sender, arg);
            }
        }
        #endregion


        #region 用户后台扩展事件

        public static event EventHandler<UserInfoEventArgs> UserInfoEvent;
        public static void OnUserInfo(object sender, UserInfoEventArgs args)
        {
            if (UserInfoEvent != null)
            {
                UserInfoEvent(sender,args);
            }
        }
        #endregion


        #region 用户注册操作相关的事件

        //用户注册注册成功时触发
        public static event EventHandler<UserActivatedEventArgs> UserReged;
        /// <summary>
        /// 用户注册注册成功时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public static void OnUserUserReged(object sender, UserActivatedEventArgs arg)
        {
            if (UserReged != null)
            {
                UserReged(sender, arg);
            }
        }

        //用户注册审核成功时触发(包括:自动通过,email验证通过,人工通过,手机号码通过)

        public static event EventHandler<UserActivatedEventArgs> UserActivated;
        /// <summary>
        /// 用户注册审核成功时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public static void OnUserActivated(object sender, UserActivatedEventArgs arg)
        {
            if (UserActivated != null)
            {
                UserActivated(sender, arg);
            }
        }

        #endregion

        #region HttpModule扩展
        //在HttpModule开始执行前触发
        public static event EventHandler<HttpModuleRuningEventArgs> HttpModuleRuning;
        /// <summary>
        /// 在HttpModule开始执行前触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public static void OnHttpModuleRuning(object sender, HttpModuleRuningEventArgs arg)
        {
            if (HttpModuleRuning != null)
            {
                HttpModuleRuning(sender, arg);
            }
        }
        #endregion

        #region 第三方登录插件登录后返回事件扩展
        //采用第三方登录接口登录成功后回调页面时触发
        public static event EventHandler<LoginApiBackEventArgs> LoginApiBacked;
       
        public static void OnLoginApiBacked(object sender, LoginApiBackEventArgs arg)
        {
            if (LoginApiBacked != null)
            {
                LoginApiBacked(sender, arg);
            }
        }
        #endregion

        #region 评价系统数据载入前
      
        public static event EventHandler<RemarkEventArgs> RemarkLoading;

        public static void OnRemarkLoading(object sender, RemarkEventArgs arg)
        {
            if (RemarkLoading != null)
            {
                RemarkLoading(sender, arg);
            }
        }
        #endregion

        #region 分类列表控件绑定时触发

        public static event EventHandler<ClassRepeaterItemEventArgs> ClassItemBound;

        public static void OnClassItemBound(object sender, ClassRepeaterItemEventArgs arg)
        {
            if (ClassItemBound != null)
            {
                ClassItemBound(sender, arg);
            }
        }
       
        #endregion

        #region 首页列表控件绑定时触发

        public static event EventHandler<RepeaterItemEventArgs> IndexItemBound;

        public static void OnIndexItemBound(object sender, RepeaterItemEventArgs arg)
        {
            if (IndexItemBound != null)
            {
                IndexItemBound(sender, arg);
            }
        }

        #endregion

        #region 用户登录成功后触发

        public static event EventHandler<UserLoginedEventArgs> UserLogined;

        public static void OnUserLogined(object sender, UserLoginedEventArgs arg)
        {
            if (UserLogined != null)
            {
                UserLogined(sender, arg);
            }
        }
        #endregion

        #region 订单宝导购模式提交

        public static event EventHandler<OrderBoxEventArgs> OrderBoxAdding;

        public static void OnOrderBoxAdding(object sender, OrderBoxEventArgs arg)
        {
            if (OrderBoxAdding != null)
            {
                OrderBoxAdding(sender, arg);
            }
        }
        #endregion

        #region  Wcf中的Rss调用前事件触发 可自定义rss数据源

        public static event EventHandler<RssArgs> RssGetting;

        public static void OnRssGetting(object sender, RssArgs arg)
        {
            if (RssGetting != null)
            {
                RssGetting(sender, arg);
            }
        }
        #endregion

        #region 分类头部 Title keywords description
        public static event EventHandler<ClassMetaEventArgs> ClassMeta;
    
        public static void OnClassMeta(object sender, ClassMetaEventArgs arg)
        {
            if (ClassMeta != null)
            {
                ClassMeta(sender, arg);
            }
        }
        #endregion

        #region 在跳转到付款平台之前 Title keywords description
        public static event EventHandler<GotoPayEventArgs> GotoPay;

        public static void OnGotoPay(object sender, GotoPayEventArgs arg)
        {
            if (GotoPay != null)
            {
                GotoPay(sender, arg);
            }
        }
        #endregion

        #region 内容页面PageLoad事件
        public static event EventHandler<ContentPageLoadEventArgs> ContentPageLoadEvent;
        public static void OnContentPageLoadEvent(object sender, ContentPageLoadEventArgs arg)
        {
            if (ContentPageLoadEvent != null)
            {
                ContentPageLoadEvent(sender, arg);
            }
        }
        #endregion

        #region 内容页面PageLoad事件
        public static event EventHandler<ContentShowEventArgs> ContentShowEvent;
        public static void OnContentShowEvent(object sender, ContentShowEventArgs arg)
        {
            if (ContentShowEvent != null)
            {
                ContentShowEvent(sender, arg);
            }
        }
        #endregion

        

        #region 分类页面PageLoad事件
        public static event EventHandler<ClassPageLoadEventArgs> ClassPageLoadEvent;
        public static void OnClassPageLoadEvent(object sender, ClassPageLoadEventArgs arg)
        {
            if (ClassPageLoadEvent != null)
            {
                ClassPageLoadEvent(sender, arg);
            }
        }

        public static event EventHandler<ClassPageLoadingEventArgs> ClassPageLoadingEvent;
        public static void OnClassPageLoadingEvent(object sender, ClassPageLoadingEventArgs arg)
        {
            if (ClassPageLoadingEvent != null)
            {
                ClassPageLoadingEvent(sender, arg);
            }
        }
        #endregion

        #region 内容页面PageLoad事件
        public static event EventHandler<SubClassBindingEventArgs> SubClassBinding;
        public static void OnSubClassBinding(object sender, SubClassBindingEventArgs arg)
        {
            if (SubClassBinding != null)
            {
                SubClassBinding(sender, arg);
            }
        }
        #endregion
        #region 内容页面PageLoad事件 在页面数据读取之前
        public static event EventHandler<ContentPageLoadingEventArgs> ContentPageLoading;
        public static void OnContentPageLoading(object sender, ContentPageLoadingEventArgs arg)
        {
            if (ContentPageLoading != null)
            {
                ContentPageLoading(sender, arg);
            }
        }
        #endregion
        #region 首页PageLoad事件
        public static event EventHandler<IndexPageLoadEventArgs> IndexPageLoadEvent;
        public static void OnIndexPageLoadEvent(object sender, IndexPageLoadEventArgs arg)
        {
            if (IndexPageLoadEvent != null)
            {
                IndexPageLoadEvent(sender, arg);
            }
        }
        #endregion

        #region 个人后台 主页PageLoad事件
        public static event EventHandler<UccIndexPageLoadEventArgs> UccIndexPageLoadEvent;
        public static void OnUccIndexPageLoadEvent(object sender, UccIndexPageLoadEventArgs arg)
        {
            if (UccIndexPageLoadEvent != null)
            {
                UccIndexPageLoadEvent(sender, arg);
            }
        }
        #endregion


        #region Global事件扩展
        static public event EventHandler<ProfileMigrateEventArgs> ProfileMigrateAnonymous;
        /// <summary>
        /// 用户迁移事件
        /// </summary>
        static public void OnProfile_MigrateAnonymousStarting(object sender, ProfileMigrateEventArgs e)
        {
            if (!Equals(ProfileMigrateAnonymous, null))
            {
                ProfileMigrateAnonymous(sender, e);
            }
        }

        static public event EventHandler<EventArgs> ApplicationStart;
        static public void OnApplicationStart(object sender, EventArgs e)
        {
            if (!Equals(ApplicationStart, null))
            {
                ApplicationStart(sender, e);
            }
        }

        static public event EventHandler<EventArgs> ApplicationEnd;
        static public void OnApplicationEnd(object sender, EventArgs e)
        {
            if (!Equals(ApplicationEnd, null))
            {
                ApplicationEnd(sender, e);
            }
        }
        static public event EventHandler<EventArgs> ApplicationError;
        static public void OnApplicationError(object sender, EventArgs e)
        {
            if (!Equals(ApplicationError, null))
            {
                ApplicationError(sender, e);
            }
        }
        static public event EventHandler<EventArgs> ApplicationBeginRequest;
        static public void OnApplicationBeginRequest(object sender, EventArgs e)
        {
            if (!Equals(ApplicationBeginRequest, null))
            {
                ApplicationBeginRequest(sender, e);
            }
        }
        static public event EventHandler<EventArgs> SessionStart;
        static public void OnSessionStart(object sender, EventArgs e)
        {
            if (!Equals(SessionStart, null))
            {
                SessionStart(sender, e);
            }
        }
        static public event EventHandler<EventArgs> SessionEnd;
        static public void OnSessionEnd(object sender, EventArgs e)
        {
            if (!Equals(SessionEnd, null))
            {
                SessionEnd(sender, e);
            }
        }
        #endregion

        static public event EventHandler<TemCacheingEventArgs> TemCacheing;
        static public void OnTemCacheing(object sender, TemCacheingEventArgs e)
        {
            if (!Equals(TemCacheing, null))
            {
                TemCacheing(sender, e);
            }
        }
    }
}
