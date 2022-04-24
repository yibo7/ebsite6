using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web;
using System.Web.Security;
using EbSite.BLL;
using EbSite.Base;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.EntityAPI;
using EbSite.Base.Json;
using EbSite.BLL.ModulesBll;
using EbSite.Core;
using EbSite.Core.Strings;
using EbSite.ServiceAPI.CusttomClass;
using Favorite = EbSite.Entity.Favorite;
using SpecialNews = EbSite.Entity.SpecialNews;

namespace EbSite.ServiceAPI
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        public bool IsMobile()
        {
            bool flag = false;
            string str = (HttpContext.Current.Request.UserAgent ?? "").ToLower().Trim();
            if (!string.IsNullOrEmpty(str) && (str.IndexOf("mobile") > -1))
            {
                flag = true;
            }
            return flag;
        }
        public JsonResponse UserName()
        {
            return new JsonResponse() { Success = true, Message = Base.Host.Instance.UserName };
            //return Base.Host.Instance.UserName;
        }

        public int UserID()
        {
            return Base.Host.Instance.UserID;
        }
        public Base.EntityAPI.MembershipUserEb CurrentUser()
        {
            return Base.Host.Instance.CurrentUser;

        }

        public JsonResponse HelloString(string str)
        {
            return new JsonResponse() { Data = "", Message = "您请求了HelloString:" + str, Success = true };
        }

        #region RSS订阅

        private Uri GetRootUri()
        {
            Uri uri = OperationContext.Current.Channel.LocalAddress.Uri;
            UriBuilder builder = new UriBuilder(uri);

            StringBuilder pathBuilder = new StringBuilder(builder.Path);
            int indexOfSlash = builder.Path.LastIndexOf('/');
            pathBuilder.Remove(indexOfSlash + 1, builder.Path.Length - indexOfSlash - 1);

            builder.Path = pathBuilder.ToString();
            return builder.Uri;
        }
        public SyndicationFeedFormatter GetRss(int itop, int itype, int iclassid, int SiteID,string key)
        {
            Entity.Sites mdSite = EbSite.BLL.Sites.Instance.GetEntity(SiteID);
            Uri uri = GetRootUri();
            SyndicationFeed feed = new SyndicationFeed(
                mdSite.SiteName,
                mdSite.SiteName,
                uri
                );

            RssArgs Args = new RssArgs(itop, itype, iclassid, SiteID, feed,key);
            Base.EBSiteEvents.OnRssGetting(null, Args);

            if(Args.Feed.Items.Count()==0)
            {
                NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(iclassid);//2014-2-11 YHL

                List<EbSite.Entity.NewsContent> lstContent = new List<Entity.NewsContent>();

                if (itype == 0) //排行
                {
                    lstContent = NewsContentInst.GetListHot(iclassid, itop, "id", false, false, "id,newstitle,contentinfo,HtmlName", SiteID);
                }
                else if (itype == 1)//推荐
                {
                    lstContent = NewsContentInst.GetGoodList(itop, iclassid, SiteID);
                }
                else if (itype == 2)//最新
                {
                    lstContent = NewsContentInst.GetListNewOfNewsClass(iclassid, itop, false, false, "id,newstitle,contentinfo,HtmlName", SiteID);
                }
                Collection<SyndicationItem> items = new Collection<SyndicationItem>();
                foreach (Entity.NewsContent newsContent in lstContent)
                {
                    SyndicationItem item = new SyndicationItem();
                    item.Title = new TextSyndicationContent(newsContent.NewsTitle);
                    item.Content = new TextSyndicationContent(GetString.GetSubString(newsContent.ContentInfo, 100, "..."));
                    item.Summary = new TextSyndicationContent(GetString.GetSubString(newsContent.ContentInfo, 100, "..."));
                    item.Links.Add(new SyndicationLink(new Uri(string.Concat(Base.Host.Instance.Domain, Base.Host.Instance.GetContentLink(newsContent.ID, newsContent.HtmlName, SiteID)))));

                    item.Authors.Add(new SyndicationPerson("cqs@ebsite.net", "EbSite", "http://www.ebsite.net"));
                    item.PublishDate = newsContent.AddTime;
                    item.Id = newsContent.ID.ToString();
                    items.Add(item);
                }
                feed.Items = items.Take(10);
                feed.Items = items;
                return new Rss20FeedFormatter(feed);
            }
            else
            {
                return new Rss20FeedFormatter(feed);
            }

            

        }

        #endregion

        #region IServiceAPI Members


        #endregion

        #region IServiceAPI Members




        public string IISPath()
        {
            return Base.Host.Instance.IISPath;
        }

        public string Domain()
        {
            return Base.Host.Instance.Domain;
        }

        public string MapPath()
        {
            return Base.Host.Instance.sMapPath;
        }

        public string GetAvatarPath(int UserID)
        {
            return Base.Host.Instance.GetAvatarPath(UserID);
        }

        public string UserSiteUrl()
        {
            return Base.Host.Instance.CurrentSiteUrl;
        }

        //public string UserGroupNames()
        //{
        //    return Base.Host.Instance.UserGroupNames;
        //}

        public void SendEmail(string email, string title, string body)
        {
            Base.Host.Instance.SendEmailPool(email, title, body);
        }

        public void InsertLog(string Title, string Msg)
        {
            Base.Host.Instance.InsertLog(Title, Msg);
        }

        public string GetClassHref(object iID, object HtmlPath, int pIndex)
        {
            return Base.Host.Instance.GetClassHref(iID, HtmlPath, pIndex);
        }

        public string GetClassHref(object iID, object HtmlPath, int pIndex, string OutLink)
        {
            return Base.Host.Instance.GetClassHref(iID, HtmlPath, pIndex, OutLink);
        }

        public string GetClassHref(int iID, int Index)
        {
            return Base.Host.Instance.GetClassHref(iID, Index);
        }

        //public string GetContentLink(object iID, object HtmlPath)
        //{
        //    return Base.Host.Instance.GetContentLink(iID, HtmlPath);
        //}

        //public string GetContentLink(object iID)
        //{
        //    return Base.Host.Instance.GetContentLink(iID);
        //}

        public string GetClassHref_OrderBy(int iID, int Index, int OrderBy)
        {
            return Base.Host.Instance.GetClassHref_OrderBy(iID, Index, OrderBy);
        }

        public string GetSpecialHref(int iID, int Index)
        {
            return Base.Host.Instance.GetSpecialHref(iID, Index);
        }

        public string TagsList(int p)
        {
            return Base.Host.Instance.TagsList(p);
        }

        public string TagsSearchList(object id, int p)
        {
            return Base.Host.Instance.TagsSearchList(id, p);
        }

        public string GetUserHomePage(string sUserName)
        {
            return Base.Host.Instance.GetUserHomePage(sUserName);
        }

        public string GetUserHomePage()
        {
            return Base.Host.Instance.GetUserHomePage();
        }

        //public string GetUserHomePageHref(string sUserName, string sUserNiName, string target)
        //{
        //    return Base.Host.Instance.GetUserHomePageHref(sUserNiName, sUserNiName, target);
        //}

        public string GetUserHomePageHref(string target)
        {
            return Base.Host.Instance.GetUserHomePage(target);
        }

        //public string IsOnlineImg(string UserName)
        //{
        //    return Base.Host.Instance.IsOnlineImg(UserName);
        //}

        public int GetProfileUniqueID(string userName, bool isAuthenticated, bool ignoreAuthenticationType, string appName)
        {
            return Base.Host.Instance.GetProfileUniqueID(userName, isAuthenticated, ignoreAuthenticationType, appName);
        }

        public int CreateProfileForUser(string userName, bool isAuthenticated, string appName)
        {
            return Base.Host.Instance.CreateProfileForUser(userName, isAuthenticated, appName);
        }

        //public IList<Entity.CustomProfileInfo> GetProfileInfo(int authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, string appName, out int totalRecords)
        //{
        //    return Base.Host.Instance.GetProfileInfo(authenticationOption, usernameToMatch, userInactiveSinceDate,
        //                                             appName, out totalRecords);
        //}

        public bool DeleteProfile(int iUid)
        {
            return Base.Host.Instance.DeleteProfile(iUid);
        }

        public IList<string> GetInactiveProfiles(int authenticationOption, DateTime userInactiveSinceDate, string appName)
        {
            return Base.Host.Instance.GetInactiveProfiles(authenticationOption, userInactiveSinceDate, appName);
        }

        public void UpdateActivityDates(string userName, bool activityOnly, string appName)
        {
            Base.Host.Instance.UpdateActivityDates(userName, activityOnly, appName);
        }

        #endregion

        #region
        //是否登录成功
        public JsonResponse Login(string u, string p)
        {
            string err = "ok";

            EbSite.BLL.User.MembershipUserEb.Instance.ValidateUser(u, p, -1, out err);
            return new JsonResponse() { Success = true, Message = err };
        }
        #endregion
        public JsonResponse GetModulePath(string mid, int siteid)
        {
            //EbSite.BLL.ModulesBll.Modules modulesBll = new Modules(siteid);
            string sPath = EbSite.BLL.ModulesBll.Modules.Instance.GetModelPath(new Guid(mid));
            return new JsonResponse() { Success = true, Message = sPath };
        }

        public List<TreeItem> GetAlear(int pid)
        {
            List<Entity.AreaInfo> lst = EbSite.BLL.AreaInfo.Instance.GetListByParentID(pid);

            List<TreeItem> lstOK = new List<TreeItem>();

            foreach (Entity.AreaInfo info in lst)
            {

                lstOK.Add(new TreeItem(info.id, info.Name, info.Level));
            }

            return lstOK;
        }

        //public List<TreeItem> GetNewClassList(int pid)
        //{
        //    List<Entity.NewsClass> lst = EbSite.BLL.NewsClass.GetListArr("parentid="+ pid, 1);

        //    List<TreeItem> lstOK = new List<TreeItem>();

        //    foreach (Entity.NewsClass info in lst)
        //    {
        //        //lstOK.Add(new TreeItem(info.ID, info.ClassName,int.Parse( info.Annex9)));
        //        lstOK.Add(new TreeItem(info.ID, info.ClassName, info.Annex9));
        //    }

        //    return lstOK;
        //}



        public TreeItem GetAlearInfo(int id)
        {
            Entity.AreaInfo info = EbSite.BLL.AreaInfo.Instance.GetEntity(id);
            return new TreeItem(info.id, info.Name, info.Level);
        }

        public Entity.VersionInfo GetVersion(string ip, string dm)
        {
            Entity.VersionInfo md = new Entity.VersionInfo();
            string sVersion = Core.Utils.GetAssemblyVersion();
            md.Version = sVersion;
            md.PathUrl = "http://www.ebsite.net/update2.0.zip";
            md.WebUrl = "http://www.ebsite.net";
            md.UpdateTime = DateTime.Now;
            //为了方便官方做统计，对外开发事件
            EBSiteEvents.OnGetVersion(null, new GetVersionEventArgs(md.Version, md.WebUrl, md.PathUrl, md.UpdateTime));

            return md;
        }
        public string ServerInfo()
        {
            return "<a target=_blank href='http://www.ebsite.net'>官方电子平台上线啦</a>";
        }
        public string GetModuleUrl(Guid pid, Guid sid)
        {
            return EbSite.Base.Host.Instance.GetModuleUrl(pid, sid);
        }
        /// <summary>
        /// 返回当前登录的用户ID,没有登录为-1
        /// </summary>
        /// <returns></returns>
        public int GetUserID()
        {
            if (EbSite.Base.Host.Instance.UserID > 0)
            {
                return EbSite.Base.Host.Instance.UserID;
            }
            return -1;
        }
        /// <summary>
        /// 调个人的收藏分类
        /// </summary>
        /// <returns></returns>
        public string GetFavClassList()
        {
            string str = "";
            List<EbSite.Entity.FavoriteClass> ls = EbSite.BLL.FavoriteClass.GetListByUserID(EbSite.Base.Host.Instance.UserID);// GetListArr(0, "UserID=" + EbSite.Base.Host.Instance.UserID + "", "id asc");
            foreach (EbSite.Entity.FavoriteClass li in ls)
            {
                str += li.ClassName + "," + li.ID + "|";
            }
            if (str.Length > 0)
            {
                str = str.Remove(str.Length - 1, 1);
            }
            return str;
        }

        #region 添加喜爱收藏的分类
        /// <summary>
        /// 添加喜爱收藏的分类
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddFavClass(string name)
        {
            bool k = false;
            if (EbSite.Base.Host.Instance.UserID > 0)
            {

                EbSite.Entity.FavoriteClass md = new EbSite.Entity.FavoriteClass();
                md.ClassName = name;

                md.Adddatetime = DateTime.Now;
                EbSite.BLL.FavoriteClass.Add(md);
                k = true;

            }
            return k;
        }

        #endregion

        #region  添加喜爱收藏
        /// <summary>
        /// 添加喜爱收藏
        /// </summary>
        /// <param name="contentId">内容id</param>
        /// <param name="classId">收藏分类ID</param>
        /// <param name="favType">收藏类别，0为内容，1为分类</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public bool AddFavorite(int contentId, int classId, int favType, int userId,int CID)
        {
            bool key = false;
            Entity.Favorite md = new Favorite();
            md.ContentID = contentId;
            md.ContentClassId = CID;
            md.ClassID = classId;
            md.FavType = favType;
            md.UserID = userId;
            NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(CID);//YHL 2014-2-11
            md.Title = NewsContentInst.GetModel(contentId, 1).NewsTitle;
            md.UserName = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(userId).UserName;
            md.UserNiName = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(userId).NiName;
            md.AddDateTime = DateTime.Now;
            int i = BLL.Favorite.Add(md);
            if (i > 0)
            {
                key = true;
            }
            return key;
        }
        #endregion

        #region 判断是否已添加喜爱收藏
        /// <summary>
        /// 判断是否已添加喜爱收藏
        /// </summary>
        /// <param name="contentId">内容id</param>
        /// <param name="classId">收藏分类ID</param>
        /// <param name="favType">收藏类别，0为内容，1为分类</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public bool IfAddFavorite(int contentId, int classId, int favType, int userId)
        {
            bool key = false;
            string strsql = "ContentID =" + contentId + " and ClassID=" + classId + " and FavType=" + favType + " and userId=" + userId;
            List<Entity.Favorite> ls = BLL.Favorite.GetListArr(0, strsql, "id asc");
            if (ls.Count == 0)
            {
                key = true;
            }
            return key;
        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="uname">用户名</param>
        /// <param name="upwd">明名密码</param>
        /// <returns></returns>

        public int LoginClick(string sUserName, string sPass)
        {

            int key = 0;
            string sErr = "";
            EbSite.Base.EntityAPI.MembershipUserEb ucf = BLL.User.MembershipUserEb.Instance.ValidateUser(sUserName, sPass, -1, out sErr);
            if (!Equals(ucf, null) && string.IsNullOrEmpty(sErr)) //登录成功
            {

                key = ucf.id;
            }
            return key;
        }
        #endregion

        #region 删除喜爱收藏的分类
        public void DelFavClass(int id)
        {
            EbSite.BLL.FavoriteClass.Delete(id, EbSite.Base.Host.Instance.UserName);
            //同时删除 对应分类下的收藏内容
            EbSite.BLL.Favorite.DeleteOfClass(id, EbSite.Base.Host.Instance.UserName);
        }
        #endregion

        #region  修改喜爱收藏分类
        public void UpdateFavClass(string name, int id)
        {
            EbSite.Entity.FavoriteClass md = EbSite.BLL.FavoriteClass.GetModel(id);
            md.ClassName = name;
            EbSite.BLL.FavoriteClass.Update(md);

        }
        #endregion

        #region 调收藏的分类
        public List<ClassInfo> GetFavClass(int uid)
        {
            List<Entity.FavoriteClass> ls = EbSite.BLL.FavoriteClass.GetListArr(0, " UserName='" + EbSite.Base.Host.Instance.UserName + "' and UserID=" + uid, "id desc");
            List<ClassInfo> lstOK = new List<ClassInfo>();
            foreach (Entity.FavoriteClass newsClass in ls)
            {
                lstOK.Add(new ClassInfo(newsClass.ID, newsClass.ClassName));
            }

            return lstOK;
        }
        #endregion

        #region 调主站的分类
        public List<ClassInfo> GetClassTree(int siteid)
        {
            List<Entity.NewsClass> ls = EbSite.BLL.NewsClass.GetContentClassesTree(siteid);
            List<ClassInfo> lstOK = new List<ClassInfo>();
            foreach (Entity.NewsClass newsClass in ls)
            {
                lstOK.Add(new ClassInfo(newsClass.ID, newsClass.ClassName));
            }

            return lstOK;
        }

        #endregion

        #region  喜欢某个内容

        public JsonResponse LikeOrNo(int id,int CID)
        {
            NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(CID);
            NewsContentInst.LikeOrNo(id, 1);
            return new JsonResponse() { Success = true, Message = id.ToString() };
        }
        #endregion

        #region 调当前站点下主站的专题分类
        public List<TreeItem> GetSpecialClass(int pid, int sid)
        {
            string lst = EbSite.BLL.SpecialClass.GetSubIDs(pid, sid);
            string[] arry = lst.Split(',');
            List<TreeItem> lstOK = new List<TreeItem>();
            for (int i = 0; i < arry.Length; i++)
            {
                int level = 1;
                if (!string.IsNullOrEmpty(arry[i]))
                {
                    Entity.SpecialClass md = BLL.SpecialClass.GetModel(int.Parse(arry[i]));
                    GetSubItem_channels(md.id, pid, ref level);
                    lstOK.Add(new TreeItem(md.id, md.SpecialName, level));
                }

            }
            return lstOK;
        }
        private void GetSubItem_channels(int id, int pid, ref int level)
        {
            Entity.SpecialClass md = BLL.SpecialClass.GetModel(id);
            if (md.ParentID != pid)
            {
                level += 1;
                GetSubItem_channels(md.ParentID, pid, ref level);
            }
        }
        #endregion

        #region 添加专题内容
        /// <summary>
        /// 添加专题内容
        /// </summary>
        /// <param name="newsId">内容ID</param>
        /// <param name="specialClassId">分类ID</param>
        /// <returns></returns>
        public bool AddSpecialNews(int newsId, int specialClassId)
        {
            bool key = false;
            Entity.SpecialNews md = new SpecialNews();
            md.NewsID = newsId;
            md.SpecialClassID = specialClassId;
            md.orderid = 1;
            md.ClassID = 0;
            int idd = BLL.SpecialNews.Add(md);
            if (idd > 0)
            {
                key = true;
            }
            return key;
        }
        #endregion

        #region 决断是否已添加到专题
        public bool IfSpecialNews(int newsId, string specialClassId)
        {
            int it = 0;
            bool key = true;
            if (!int.TryParse(specialClassId, out it))
            {
                key = false;
            }
            else
            {
                List<Entity.SpecialNews> ls =
                    BLL.SpecialNews.GetListArry("newsid=" + newsId + " and SpecialClassID=" + specialClassId);
                if (ls.Count > 0)
                {
                    key = false;
                }
            }
            return key;
        }
        #endregion

        #region  评价 暂同
        /// <summary>
        /// 评价 暂同 反对
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key">1：暂同 2 ：反对</param>
        /// <returns></returns>
        public int RemarkSupport(int id, int key)
        {
            EbSite.Entity.Remark md = BLL.Remark.GetModel(id);
            if (key == 1)
            {
                md.Support += 1;
            }
            if (key == 2)
            {
                md.Discourage += 1;
            }
            BLL.Remark.Update(md);
            if (key == 1)
            {
                return md.Support;
            }
            if (key == 2)
            {
                return md.Discourage;
            }
            return 0;
        }
        #endregion


        //public List<ShortUserInfo> GetUsers(int gid, string k)
        //{
        //    string swhere = "";
        //    List<ShortUserInfo> ulst = new List<ShortUserInfo>();
        //    int iCount = 0;
        //    if (!string.IsNullOrEmpty(k))
        //    {
        //        swhere = string.Format(" NiName like '%{0}%'", k);
        //    }
        //    List<Base.EntityAPI.MembershipUserEb> lst = EbSite.BLL.User.MembershipUserEb.Instance.GetListPages(1, 300, true, out iCount, gid, swhere);
        //    foreach (MembershipUserEb userEb in lst)
        //    {
        //        ulst.Add(new ShortUserInfo(userEb.id, userEb.UserName, userEb.NiName, gid, userEb.Password));
        //    }
        //    return ulst;
        //}
        #region  添加评价
        /// <summary>
        /// 添加评价
        /// </summary>
      
    
        /// <param name="txtExperience">使用心得</param>
        /// <param name="cid">分类id</param>
        /// <param name="RdScore">评价分数</param>
        /// <returns></returns>
        public bool RemarkOp(string txtExperience, int cid, int classid, int contentid, string RdScore)
        {
            EbSite.Entity.Remark Model = new EbSite.Entity.Remark();
           
            if (!string.IsNullOrEmpty(Model.Body))
            {
                Model.DateAndTime = DateTime.Now;
                Model.Discourage = 0;
                Model.Information = 0;
                Model.Ip = EbSite.Core.Utils.GetClientIP();

                Model.Quote = txtExperience.Trim();
                Model.Support = 0;
                Model.UserName = AppStartInit.UserName;
                Model.UserNiName = AppStartInit.UserNiName;
                Model.UserID = AppStartInit.UserID;
                Model.IsNiName = false;
                Model.RemarkClassID = cid;
                Model.EvaluationScore = Core.Utils.StrToInt(RdScore, 0);

                Model.ClassID = classid;
                Model.ContentID = contentid;

                EbSite.BLL.Remark.Add(Model, true);
               
                return true;
            }
            return false;
        }
        #endregion

        #region 回复一个评价
        public bool RemarkHfOp(string body, int parentid)
        {
            EbSite.Entity.RemarkSublist Model = new EbSite.Entity.RemarkSublist();
            Model.Body = body.Trim();
            if (!string.IsNullOrEmpty(Model.Body))
            {
                Model.DateAndTime = DateTime.Now;
                Model.Discourage = 0;
                Model.Information = 0;
                Model.Ip = Utils.GetClientIP();
                Model.Support = 0;
                Model.UserName = AppStartInit.UserName;
                Model.UserNiName = AppStartInit.UserNiName;
                Model.UserID = AppStartInit.UserID;
                Model.IsNiName = false;
                Model.ParentID = parentid;
                EbSite.BLL.RemarkSublist.Add(Model);
                return true;
            }
            return false;
        }
        #endregion


        #region 注册用户
        /// <summary>
        /// 注册用户-将email当作用户帐号使用(用户帐号与email相同)
        /// </summary>
        /// <param name="reg_email">email</param>
        /// <param name="reg_pwd">密码</param>
        /// <param name="reg_yzm">验证码</param>
        /// <param name="reg_glkey">用户组加密标记</param>
        /// <param name="reg_vuid">邀请用户ID</param>
        /// <param name="reg_formurl">来源地址</param>
      /// <param name="Mobile">手机号</param>
      /// <param name="RegType">注册类别，0为email 1为帐号 2为手机号</param>
      /// <returns></returns>
        public JsonResponse RegUser(string reg_username,string reg_email, string reg_pwd, string reg_yzm, string reg_glkey, int reg_vuid, string reg_formurl, string reg_mobile, int reg_type)
        {

            JsonResponse jr = new JsonResponse();
            RegStatus ms;
            string sReturnUrl = string.Empty;
            string Ip = EbSite.Core.Utils.GetClientIP();
            EbSite.Base.Host.Instance.RegUserByGroupKey(reg_username, reg_pwd, reg_email, out ms, false, reg_glkey, out sReturnUrl, reg_vuid, reg_formurl, reg_mobile, reg_type, Ip,"来自wcf接口服务");
            if (RegStatus.注册成功 == ms)
            {
                jr.Message = sReturnUrl;
                jr.Success = true;
            }
            else
            {

                if (RegStatus.已经存在此帐号 == ms)
                {
                    jr.Message = "已经存在此用户名,请换一个用户名再注册!";
                    jr.Success = false;
                }
                else if (RegStatus.已经存在此Email == ms)
                {
                    jr.Message = "已经存在此Email,请换一个Email再注册!";
                    jr.Success = false;
                }
                else if (RegStatus.已经存在此手机号码 == ms)
                {
                    jr.Message = "已经存在此手机号码!";
                    jr.Success = false;
                }
                else if (RegStatus.帐号不能为空 == ms)
                {
                    jr.Message = "帐号不能为空!";
                    jr.Success = false;
                }
                else
                {
                    jr.Message = "注册失败，原因不明!";
                    jr.Success = false;
                }
            }
            
            return jr;
        }

        

        #endregion

        #region 用户登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login_username">用户帐号，或用户email或手机号码，视login_type 而定，0为帐号登录，1为email登录，2为手机号登录</param>
        /// <param name="login_pwd">密码,未加密</param>
        /// <param name="login_yzm">验证码</param>
        /// <param name="iscookie">是否记住</param>
        /// <param name="login_type">0为帐号登录，1为email登录，2为手机号登录</param>
        /// <param name="reg_formurl">请求来源地址，用户返回</param>
        /// <returns></returns>
        public JsonResponse LoginUser(string login_username, string login_pwd, string login_yzm, bool isremember, int login_type, string login_formurl)
        {
            JsonResponse jr = new JsonResponse();
            LoginStatus ls;
            string sReturnUrl;
            EbSite.Base.Host.Instance.Login(login_username, login_pwd, login_yzm, isremember, login_type, out ls, out sReturnUrl, login_formurl);

            if (LoginStatus.登录成功 == ls)
            {
                jr.Message = sReturnUrl;
                jr.Success = true;
            }
            else
            {
                if (LoginStatus.IP禁止登录 == ls)
                {
                    jr.Message = "IP禁止登录";
                    jr.Success = false;
                }
                else if (LoginStatus.不存在此Email或密码错误 == ls)
                {
                    jr.Message = "不存在此Email或密码错误";
                    jr.Success = false;
                }
                else if (LoginStatus.不存在此手机号码或密码错误 == ls)
                {
                    jr.Message = "不存在此手机号码或密码错误";
                    jr.Success = false;
                }
                else if (LoginStatus.不存在此帐号或密码错误 == ls)
                {
                    jr.Message = "不存在此帐号或密码错误";
                    jr.Success = false;
                }
                else if (LoginStatus.错误登录次数超出规定 == ls)
                {
                    jr.Message = "对不起，你错误登录了" + Base.Configs.SysConfigs.ConfigsControl.Instance.ErrLoginNum + "次，系统登录锁定！!";
                    jr.Success = false;
                }

                else if (LoginStatus.验证码不正确 == ls)
                {
                    jr.Message = "验证码不正确或已经过期";
                    jr.Success = false;
                }
                else if (LoginStatus.帐号没有激活 == ls)
                {
                    jr.Message = "帐号没有激活";
                    jr.Success = false;
                }
                else
                {
                    jr.Message = "登录失败";
                    jr.Success = false;
                }
               
                
            }


            return jr;
        }

        #endregion

        public JsonResponse test(string u, string p, string sign)
        {
            return new JsonResponse{Data = "abc",Message = "调用成功",Success = true};
        }

    }
}
