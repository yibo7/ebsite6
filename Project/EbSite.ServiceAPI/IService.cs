using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;
using EbSite.Base.EntityAPI;
using EbSite.Base.Json;
using EbSite.Entity;
using EbSite.ServiceAPI.CusttomClass;

namespace EbSite.ServiceAPI
{
    [ServiceContract(Namespace = "http://www.ebsite.net")] 
    public interface IService
    {
        
        //#region 获取常用数据
        /// <summary>
        /// 获取当前登录的用户名称
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        JsonResponse UserName();

        [OperationContract]
        [WebGet]
        [ServiceKnownType(typeof(Rss20FeedFormatter))]
        SyndicationFeedFormatter GetRss(int itop, int itype, int iclassid, int SiteID,string  key);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        Base.EntityAPI.MembershipUserEb CurrentUser();

        #region 参数操作

        /// <summary>
        /// 获取当前登录的用户ID
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int UserID();

        /// <summary>
        /// 是否用户用手机访问
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool IsMobile();

        /// <summary>
        /// 获取当前网站安装目录
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string IISPath();
        /// <summary>
        /// 获取当前网站的域名
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string Domain();
        /// <summary>
        /// 获取当前网站安装的绝对路径
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string MapPath();
        /// <summary>
        /// 获取某个个用户的头像
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string GetAvatarPath(int UserID);
        /// <summary>
        /// 获取当前用户的个人主页网址
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string UserSiteUrl();
        ///// <summary>
        ///// 获取当前登录用户的用户组名称，多个用逗号分开
        ///// </summary>
        ///// <returns></returns>
        //[OperationContract]
        //[WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //[ServiceKnownType(typeof(string))]
        //string UserGroupNames();
        #endregion

        #region 执行常用操作
        /// <summary>
        /// 发送一份邮件
        /// </summary>
        /// <param name="email">邮件地址</param>
        /// <param name="title">标题</param>
        /// <param name="body">正文</param>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void SendEmail(string email, string title, string body);
        /// <summary>
        /// 写入一条日志
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Msg">正文</param>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void InsertLog(string Title, string Msg);
        #endregion

        #region 获取连接

        /// <summary>
        /// 获取分类连接地址
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="HtmlPath">html生成名称</param>
        /// <param name="pIndex">页码</param>
        /// <returns></returns>
        [OperationContract(Name = "GetClassHrefThree")]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string GetClassHref(object iID, object HtmlPath, int pIndex);

        /// <summary>
        /// 获取分类连接地址
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="HtmlPath">html生成名称</param>
        /// <param name="pIndex">页码</param>
        /// <param name="OutLink">外部连接</param>
        /// <returns></returns>
        [OperationContract(Name = "GetClassHrefFour")]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string GetClassHref(object iID, object HtmlPath, int pIndex, string OutLink);

        /// <summary>
        /// 获取分类连接地址
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="Index">页码</param>
        /// <returns></returns>
        [OperationContract(Name = "GetClassHrefTwo")]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string GetClassHref(int iID, int Index);


        ///// <summary>
        ///// 获取内容页面连接地址
        ///// </summary>
        ///// <param name="HtmlPath">内容html命名</param>
        ///// <returns></returns>
        //[OperationContract(Name = "GetContentLinkTwo")]
        //[WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //[ServiceKnownType(typeof(string))]
        //string GetContentLink(object iID, object HtmlPath);

        ///// <summary>
        ///// 获取内容页面连接地址
        ///// </summary>
        ///// <param name="iID">内容ID</param>
        ///// <returns></returns>
        //[OperationContract(Name = "GetContentLinkOne")]
        //[WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //[ServiceKnownType(typeof(string))]
        //string GetContentLink(object iID);

        /// <summary>
        /// 获取列表-按排序号
        /// </summary>
        /// <param name="iID">分类ID</param>
        /// <param name="Index">页码</param>
        /// <param name="OrderBy">排序，0默认按ID排序，1按点击率排序，2按收藏排序，3按评论数排序，4好评或星级或顶一下排序，5按发布日期排序</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string GetClassHref_OrderBy(int iID, int Index, int OrderBy);

        /// <summary>
        /// 获取专题连接
        /// </summary>
        /// <param name="iID">专题ID</param>
        /// <param name="Index">分页码</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string GetSpecialHref(int iID, int Index);

        /// <summary>
        /// 获取标签列表地址-用来获取分类，生成静态面页用
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string TagsList(int p);

        /// <summary>
        /// 获取标签搜索结果列表地址
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <param name="p">页码</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string TagsSearchList(object id, int p);

        /// <summary>
        /// 获取某个用户的管理主页
        /// </summary>
        /// <param name="sUserName"></param>
        /// <returns></returns>
        string GetUserHomePage(string sUserName);

        /// <summary>
        /// 获取当前登录用户的主页
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string GetUserHomePage();

        ///// <summary>
        ///// 获取某个用户的管理主页
        ///// </summary>
        ///// <param name="sUserName"></param>
        ///// <returns></returns>
        //[OperationContract(Name = "GetUserHomePageHrefThree")]
        //[WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //[ServiceKnownType(typeof(string))]
        //string GetUserHomePageHref(string sUserName, string sUserNiName, string target);

        /// <summary>
        /// 获取当前登录用户的主页
        /// </summary>
        /// <param name="sUserName"></param>
        /// <returns></returns>
        [OperationContract(Name = "GetUserHomePageHrefOne")]
        [WebGet]
        [ServiceKnownType(typeof(string))]
        string GetUserHomePageHref(string target);

        ///// <summary>
        ///// 查看某个用户是否在线
        ///// </summary>
        ///// <param name="UserName"></param>
        ///// <returns></returns>
        //[OperationContract]
        //[WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //[ServiceKnownType(typeof(string))]
        //string IsOnlineImg(string UserName);
        #endregion

        #region profile

        /// <summary>
        /// 获取一个profile用户ID
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="isAuthenticated">是否认证</param>
        /// <param name="ignoreAuthenticationType"></param>
        /// <param name="appName"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(int))]
        int GetProfileUniqueID(string userName, bool isAuthenticated, bool ignoreAuthenticationType, string appName);

        /// <summary>
        /// 创建一个profile用户ID
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="isAuthenticated">是否认证</param>
        /// <param name="appName">系统名称</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(int))]
        int CreateProfileForUser(string userName, bool isAuthenticated, string appName);

        /// <summary>
        /// 获取profile数据集合
        /// </summary>
        /// <param name="authenticationOption"></param>
        /// <param name="usernameToMatch"></param>
        /// <param name="userInactiveSinceDate"></param>
        /// <param name="appName"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebGet]
        //[ServiceKnownType(typeof(CustomProfileInfo))]
        //IList<CustomProfileInfo> GetProfileInfo(int authenticationOption, string usernameToMatch,
        //                                        DateTime userInactiveSinceDate, string appName, out int totalRecords);

        /// <summary>
        /// 删除一个profile
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="appName"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(int))]
        bool DeleteProfile(int iUid);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        IList<string> GetInactiveProfiles(int authenticationOption, DateTime userInactiveSinceDate, string appName);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void UpdateActivityDates(string userName, bool activityOnly, string appName);
        #endregion


        #region 登录
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        JsonResponse Login(string u,string p);
        #endregion

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        JsonResponse GetModulePath(string mid,int siteid);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        JsonResponse HelloString(string str);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<TreeItem> GetAlear(int pid);
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        TreeItem GetAlearInfo(int id);

        
        //[OperationContract]
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //List<TreeItem> GetNewClassList(int pid);
        

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        VersionInfo GetVersion(string ip, string dm);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string ServerInfo();
      
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [ServiceKnownType(typeof(string))]
        string GetModuleUrl(Guid pid, Guid sid);

        #region 返回当前登录的用户ID
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int GetUserID();
        #endregion

        #region 调个人的收藏分类
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string GetFavClassList();
        #endregion

        #region 添加喜爱收藏的分类
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool AddFavClass(string name);
        #endregion

        #region 修改喜爱收藏的分类
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void UpdateFavClass( string name,int id);
        #endregion

        #region 删除喜爱收藏的分类
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void DelFavClass(int id);
        #endregion

        #region 添加喜爱收藏
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool AddFavorite(int contentId,int classId,int favType,int userId,int CID);
        #endregion

        #region 判断是否已添加喜爱收藏
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool IfAddFavorite(int contentId, int classId, int favType, int userId);
        #endregion

        #region 用户登录
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int LoginClick(string sUserName, string sPass);
        #endregion

        #region  调收藏的分类
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<ClassInfo> GetFavClass(int uid);
        #endregion


        #region  调主站的分类
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<ClassInfo> GetClassTree(int siteid);
        #endregion
        #region  喜欢某个内容
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        JsonResponse LikeOrNo(int id,int CID);
        #endregion

        #region  调当前站点下主站的专题分类
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<TreeItem> GetSpecialClass(int pid,int sid);
        #endregion

        #region 添加专题内容
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool AddSpecialNews(int newsId,int specialClassId);
        #endregion


        #region 决断是否已添加到专题
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool IfSpecialNews(int newsId,string specialClassId);
        #endregion

        #region 评价 暂同 反对
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        int RemarkSupport(int id, int key);
        #endregion

        //[OperationContract]
        //[WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //List<ShortUserInfo> GetUsers(int gid, string k);

        #region 添加评价

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool RemarkOp(string txtExperience, int cid, int classid, int contentid, string RdScore);
        #endregion


        #region 回复评价
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool RemarkHfOp(string body, int parentid);
        #endregion

        #region 注册用户

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        JsonResponse RegUser(string reg_username,string reg_email, string reg_pwd, string reg_yzm, string reg_glkey, int reg_vuid, string reg_formurl, string reg_mobile, int reg_type);
       
        #endregion

        #region 用户登录

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        JsonResponse LoginUser(string login_username, string login_pwd, string login_yzm, bool isremember, int login_type, string login_formurl);

        #endregion
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        JsonResponse test(string u, string p,string sign);

    }
}
