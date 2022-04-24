using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using EbSite.Base.EntityAPI;
using EbSite.Base.Modules;
using EbSite.BLL;
using EbSite.BLL.Email;
using EbSite.BLL.GetLink;
using EbSite.BLL.ModulesBll;
using EbSite.BLL.User;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Core.Strings;
using EbSite.Data.User.Interface;
using EbSite.Entity;
using EbSite.Entity.Module;
using Sites = EbSite.Entity.Sites;

namespace EbSite.Base
{
    /// <summary>
    /// 为插件提供系统常用的信息
    /// </summary>
    public partial class Host
    {
        public   string RoleName
        {
            get { return AppStartInit.RoleName; }

        }
        /// <summary>
        /// 获取某个用户是否在线
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool IsOnline(int UserID)
        {
            return EbSite.BLL.User.UserOnline.IsOnline(UserID);
        }
        /// <summary>
        /// 获取系统管理员ID，如果为0,表示不是管理员
        /// </summary>
        public string GetManagerID
        {
            get
            {
                string ManagerID =  HttpContext.Current.Session["ManagerID"] as string;

                if (string.IsNullOrEmpty(ManagerID) && !string.IsNullOrEmpty(UserName))
                {
                    ManagerID = AdminUser.GetManagerID(UserName).ToString();
                    HttpContext.Current.Session["ManagerID"] = ManagerID;
                }
                return ManagerID;

                //if (!string.IsNullOrEmpty(Host.Instance.UserName))
                //{
                //    string CacheKey = string.Concat("ManagerID", Host.Instance.UserName);
                //    ManagerID = Host.CacheRawApp.GetCacheItem<string>(CacheKey, "ManagerID");// as string;
                //    if (string.IsNullOrEmpty(ManagerID))
                //    {
                //        ManagerID = EbSite.BLL.AdminUser.GetManagerID(Host.Instance.UserName).ToString();
                //        if (!string.IsNullOrEmpty(ManagerID))
                //            CacheRawApp.AddCacheItem(CacheKey, ManagerID, 1, ETimeSpanModel.天, "ManagerID");
                //    }
                //}
                //return ManagerID;
            }


        }
        /// <summary>
        /// 获取当前用户的在线ID 
        /// </summary>
        public int OnlineID  
        {
            get
            {
                string sOlid = EbSite.BLL.User.UserIdentity.GetUserOnlineID();
                if (!string.IsNullOrEmpty(sOlid))
                {
                    return int.Parse(sOlid);
                }
                return 0;
            }
        }
        /// <summary>
        /// 获取游客名称,所以的用户注册时，用户名称前缘不得是 游客-,以免出现游客与注册用户名称相同的现象
        /// </summary>
        /// <param name="golineid"></param>
        /// <returns></returns>
        public string GetGuestName(int golineid)
        {
            return string.Concat("游客-", golineid);
        }

        /// <summary>
        /// 当前用户的 级别ID
        /// </summary>
        public int UserLevel
        {
            get
            {
                if (UserID > 0)
                {
                    if (!Equals(HttpContext.Current, null) && !Equals(HttpContext.Current.Session,null))
                    {
                        string UserLevel = HttpContext.Current.Session["UserLevel"] as string;
                        if (string.IsNullOrEmpty(UserLevel))
                        {
                            UserLevel = CurrentUser.UserLevel.ToString();
                            HttpContext.Current.Session["UserLevel"] = UserLevel;
                        }
                        return Core.Utils.StrToInt(UserLevel, 0);
                    }
                   
                }
                return 0;
                ////为了性能，以后考虑写到cookie里
                //return CurrentUser.UserLevel;
            }
        }
        /// <summary>
        /// 获取当前用户昵称
        /// </summary>
        public   string UserNiName
        {
            get
            {
                return AppStartInit.UserNiName;

            }
        }
        /// <summary>
        /// 获取当前用户登录的帐号
        /// </summary>
        public string UserName
        {
            get
            {
                return AppStartInit.UserName;
            }
        }
        /// <summary>
        /// 获取当前登录的用户ID
        /// </summary>
        public int UserID
        {
            get
            {
                return AppStartInit.UserID;
            }
        }


        /// <summary>
        /// 获取当前登录的用户的积分
        /// </summary>
        public int UserCredits
        {
            get
            {
                int iCredits = GetUserCreditsByID(UserID);
                return iCredits;
            }
        }

        ///// <summary>
        ///// 获取当前登录的用户的用户组ID
        ///// </summary>
        //public int RoleIDs
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(UserName))
        //            return UserGroupProfile.GetRoleIDsByUserName(UserName);
        //        return 0;
        //    }
        ////}
        public int RoleID
        {
            get
            {
                return AppStartInit.RoleID;
            }
        }
        /// <summary>
        /// 前台用户是否有上传图片权限
        /// </summary>
        /// <param name="UserLevaID">用户级别Id</param>
        /// <returns></returns>
        public bool IsAllowUpload(string UserLevaID)
        {
            List<string> lstids = EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.UserlevaUpload;
            return lstids.Contains(UserLevaID);
        }

      /// <summary>
        /// 检测某个用户是否存在某权限-适用于模块-用于系统后台管理
      /// </summary>
      /// <param name="UserID">用户ID</param>
        /// <param name="LimitID">系统后台管理员权限ID</param>
      /// <param name="ModuleID">模块ID</param>
      /// <returns></returns>
        public bool IsHaveLimit(long UserId, int LimitID, Guid ModuleID)
        {
            
            #region

            string CacheKey = string.Concat("IsHaveLimit", UserId, LimitID, ModuleID);
            string sIsHave = Host.CacheApp.GetCacheItem<string>(CacheKey, CacheKey);
            if (string.IsNullOrEmpty(sIsHave))
              {
                  //获取某个用户所在的角色列表
                  AdminPrincipal apAdmin = EbSite.Base.AppStartInit.CheckAdmin();
                  bool IsHave = false;
                  if (apAdmin != null)
                  {
                      List<int> lst = apAdmin.RoleIDs;

                      EbSite.BLL.ModulesBll.LimitRoleForAdminer lr = new LimitRoleForAdminer(ModuleID);

                      foreach (int userRoleID in lst)
                      {
                          List<LimitRoleInfo<int>> lstLimits = lr.GetLimitsByRoleID(userRoleID);

                          foreach (LimitRoleInfo<int> limit in lstLimits)
                          {
                              if (limit.LimitID == LimitID)
                              {
                                  IsHave = true;
                                  goto EndFind;

                              }

                          }
                      }
                  }

                 EndFind:
                  sIsHave = IsHave.ToString();
                  Host.CacheApp.AddCacheItem(CacheKey, IsHave.ToString(), 60, ETimeSpanModel.M, "Limit");
              }

          return Core.Utils.StrToBool(sIsHave, false);

          #endregion

        }
        /// <summary>
        /// 检测某个用户是否存在某权限-适用于模块-用于系统前台非管理员用户
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="LimitID">非管理员用户权限ID</param>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public bool IsHaveLimitForUser(long UserId, int LimitID, Guid ModuleID)
        {
            string CacheKey = string.Concat("IsHaveLimitForUser", UserId, LimitID, ModuleID);
             string isok = Host.CacheApp.GetCacheItem<string>(CacheKey, CacheKey);
             if (string.IsNullOrEmpty(isok))
            {
                isok = "false";
                if (RoleID > 0)
                {

                    EbSite.BLL.ModulesBll.LimitRoleForUser lr = new LimitRoleForUser(ModuleID);
                    List<LimitRoleInfo<int>> lstLimits = lr.GetLimitsByRoleID(RoleID);

                    foreach (LimitRoleInfo<int> limit in lstLimits)
                    {
                        if (limit.LimitID == LimitID)
                        {
                            isok = "true";
                            goto EndFind;

                        }
                    }
                }
                EndFind:
                Host.CacheApp.AddCacheItem(CacheKey, isok, 30, ETimeSpanModel.M, "Limit");
            }
            return Core.Utils.StrToBool(isok, false);

#region

        //    bool IsHave = false;
        //    if (RoleID > 0)
        //    {
        //        EbSite.BLL.ModulesBll.LimitRoleForUser lr = new LimitRoleForUser(ModuleID);
        //        List<LimitRoleInfo<int>> lstLimits = lr.GetLimitsByRoleID(RoleID);

        //        foreach (LimitRoleInfo<int> limit in lstLimits)
        //        {
        //            if (limit.LimitID == LimitID)
        //            {
        //                IsHave = true;
        //                goto EndFind;

        //            }
        //        }
        //    }
        //EndFind:
        //    return IsHave;

#endregion


        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="username">用户账号</param>
        /// <returns></returns>
        public EntityAPI.MembershipUserEb GetUser(string username)
        {
            return EBMembershipInstance.Users_GetEntity(username);
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        public EntityAPI.MembershipUserEb GetUser(int userid)
        {

            return EBMembershipInstance.Users_GetEntity(userid);
        }
        /// <summary>
        /// 获取当前登录的用户
        /// </summary>
        public EntityAPI.MembershipUserEb CurrentUser
        {
            get
            {
                return EBMembershipInstance.Users_GetEntity(UserID);
            }
        }
         

        /// <summary>
        /// 获取某个用户的积分
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        public int GetUserCreditsByID(int uid)
        {
            if (UserID > 0)
            {
                EntityAPI.MembershipUserEb md = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(uid);
                if (!Equals(md, null))
                { return md.Credits; }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// 获取某个用户 的UserName
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <returns></returns>
        public string GetUserUserName(int uid)
        {
            EntityAPI.MembershipUserEb md = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(uid);
            if (!Equals(md, null))
                return md.UserName;
            return "";
        }

        /// <summary>
        /// 获取某个用户 的昵称
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <returns></returns>
        public string GetUserNiName(int uid)
        {
            EntityAPI.MembershipUserEb md = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(uid);
            if (!Equals(md, null))
            {
                return md.NiName;
            }
            return "";
        }
        /// <summary>
        /// 给某个用户追加积分
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="Credits">追加分数</param>
        public void AddUserCreditsByID(int uid, int Credits)
        {
            EntityAPI.MembershipUserEb md = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(uid);
            if (!Equals(md, null))
            {
                md.Credits = md.Credits + Credits;
                md.Save();
            }
        }
        /// <summary>
        /// 给某个用户减去积分
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="Credits">追加分数</param>
        public void MinusUserCreditsByID(int uid, int Credits)
        {
            EntityAPI.MembershipUserEb md = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(uid);
            if (!Equals(md, null))
            {
                if (md.Credits > 0)
                {
                    md.Credits = md.Credits - Credits;
                    if (md.Credits < 0)
                        md.Credits = 0;
                    md.Save();
                }
            }
        }
        /// <summary>
        /// 从一个用户向另一个用转积分
        /// </summary>
        /// <param name="SourceUid">来源 用户ID</param>
        /// <param name="TargetUid">目标 用户ID</param>
        /// <param name="Credits"></param>
        public void FromUserAddCreditsByID(int SourceUid, int TargetUid, int Credits)
        {
            EntityAPI.MembershipUserEb Sourcemd = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(SourceUid);
            Sourcemd.Credits = Sourcemd.Credits - Credits;
            Sourcemd.Save();

            EntityAPI.MembershipUserEb Targetmd = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(TargetUid);
            Targetmd.Credits = Targetmd.Credits + Credits;
            Targetmd.Save();

        }
        /// <summary>
        /// 获取一个用户实例
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <returns></returns>
        public EntityAPI.MembershipUserEb GetUserByID(int uid)
        {
            return EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(uid);
        }
        /// <summary>
        /// 根据手机号 获取用户
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns></returns>
        public EntityAPI.MembershipUserEb GetUserByMobile(string mobile)
        {
            return EbSite.BLL.User.MembershipUserEb.Instance.GetUserMobile(mobile);
        }
        /// <summary>
        /// 删除一个用户
        /// </summary>
        /// <param name="uid">用户ID</param>
        public void DeleteUserByID(int uid)
        {
            EbSite.BLL.User.MembershipUserEb.Instance.Delete(uid);
        }
        /// <summary>
        /// 检查数据库里是否已经存在一个用户ID
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
        public bool ExistsUserUserID(int iUserID)
        {
            return Base.Host.Instance.EBMembershipInstance.Users_Exists(iUserID);
        }
        /// <summary>
        /// 检查数据库里是否已经存在一个用户帐号
        /// </summary>
        /// <param name="sUserName">用户帐号</param>
        /// <returns></returns>
        public bool ExistsUserName(string sUserName)
        {
            int iUserID = Base.Host.Instance.EBMembershipInstance.GetUserIDByUserName(sUserName);
            return iUserID > 0;
        }
        /// <summary>
        /// 检查数据库里是否已经存在一个用户Email
        /// </summary>
        /// <param name="sEmail">用户Email</param>
        /// <returns></returns>
        public bool ExistsUserEmail(string sEmail)
        {
            string sUserName = Base.Host.Instance.EBMembershipInstance.GetUserNameByEmail(sEmail);
            return !string.IsNullOrEmpty(sUserName);
        }
        /// <summary>
        /// 从用户账号获取一个用户的手机号
        /// </summary>
        /// <param name="sUserName">用户账号</param>
        /// <returns></returns>
        public string GetUserMobileNumber(string sUserName)
        {

            return EBMembershipInstance.User_GetMobileNumber(sUserName);
        }
        /// <summary>
        /// 获取本系统扩展的 Membership
        /// </summary>
        public MembershipProviderEb EBMembershipInstance
        {
            get
            {
                return (Membership.Provider as MembershipProviderEb);
                //string CacheKey = "EBMembership";
                //MembershipProviderEb ep = Host.CacheApp.GetCacheItem<MembershipProviderEb>(CacheKey);// as MembershipProviderEb;
                //if (ep == null)
                //{
                //    ep = Membership.Provider as MembershipProviderEb;
                //    if (!Equals(ep, null))
                //        Host.CacheApp.AddCacheItem(CacheKey, ep);
                //}

                //return ep;
            }
        }

        /// <summary>
        /// 获取用户的头像路径(不包含文件名称)
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public string GetAvatarPath(int UserID)
        {
            string UserName = UserID.ToString();
            UserName = Utils.FormatUid(UserName);

            string sPath = string.Format("{0}/avatars/{1}/{2}/{3}/{4}/",
               EbSite.Base.AppStartInit.UserUploadPath, UserName.Substring(0, 3), UserName.Substring(3, 2), UserName.Substring(5, 2), UserName.Substring(7, 2));

            return sPath;
        }
        public string GetAvatarFileName(int iUserID, int isize)
        {
            return string.Concat(Configs.UserSetConfigs.ConfigsControl.Instance.UserCenter, IISPath, "ajaxget/uico.ashx?uid=", iUserID);
            //Configs.UserSetConfigs.ConfigsControl.Instance.UserCenter
            //return EBMembershipInstance.GetAvatarFileName(iUserID, isize);
        }
        /// <summary>
        /// 获取一个用户的头像(小)
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
        public string AvatarSmall(object iUserID)
        {
            return AvatarSmall(int.Parse(iUserID.ToString()));
        }

        /// <summary>
        /// 获取一个用户的头像(小尺寸)
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
        public string AvatarSmall(int iUserID)
        {

            return GetAvatarFileName(iUserID, 3);


        }
        /// <summary>
        /// 获取一个用户的头像(中尺寸)
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
        public string AvatarMid(int iUserID)
        {

            return GetAvatarFileName(iUserID, 2);


        }
        /// <summary>
        /// 获取一个用户的头像(大尺寸)
        /// </summary>
        /// <param name="iUserID">用户ID</param>
        /// <returns></returns>
        public string AvatarBig(int iUserID)
        {

            return GetAvatarFileName(iUserID, 1);


        }

        /// <summary>
        /// 获取当前登录用户后台管理员角色列表
        /// </summary>
        public List<int> UserRolesIds
        {
            get
            {
                AdminPrincipal newUser = new AdminPrincipal(UserName);
                List<int> roleids = newUser.RoleIDs;
                return roleids;
            }
        }


        ///// <summary>
        ///// 获取当前用户所在的用户组
        ///// </summary>
        //public string UserGroupNames
        //{
        //    get
        //    {

        //        string CacheKey = string.Concat("CurrentUMID-", UserName);
        //        string UGroupNames = Host.CacheRawApp.GetCacheItem<string>(CacheKey);// as string;
        //        if (string.IsNullOrEmpty(UGroupNames))
        //        {

        //            UGroupNames = EbSite.BLL.User.UserGroupProfile.GetUserGroupProfile(CurrentFirstGroupID).GroupName;

        //            if (UGroupNames.Length < 0)
        //            {
        //                UGroupNames = "未分配";
        //            }

        //            if (!string.IsNullOrEmpty(UGroupNames)) Host.CacheRawApp.AddCacheItem(CacheKey, UGroupNames);
        //        }


        //        return UGroupNames;
        //    }
        //}
        /// <summary>
        /// 在线用户人数(注册与游客)
        /// </summary>
        public int UserOnlineCount
        {
            get
            {
                return EbSite.BLL.User.UserOnline.GetCountAllUser();
            }
        }
        /// <summary>
        /// 获取在线用户列表(注册与游客)
        /// </summary>
        /// <param name="PageIndex">当前页码</param>
        /// <param name="PageSize">每页显示多少条</param>
        /// <param name="oderby">排序</param>
        /// <returns></returns>
        public List<EbSite.BLL.User.UserOnline> OnlineUsers(int PageIndex, int PageSize, string oderby)
        {
            return DbProviderUser.GetInstance().UserOnline_GetAllUser(PageIndex, PageSize, oderby);
        }
        /// <summary>
        /// 获取游客人数
        /// </summary>
        public int GuestUserCount
        {
            get
            {
                return EbSite.BLL.User.UserOnline.GetCountGuestUser(); ;
            }
        }
        /// <summary>
        /// 获取游客列表
        /// </summary>
        /// <param name="PageIndex">当前页码</param>
        /// <param name="PageSize">每页显示多少条</param>
        /// <param name="oderby">排序</param>
        /// <returns></returns>
        public List<EbSite.BLL.User.UserOnline> GuestUsers(int PageIndex, int PageSize, string oderby)
        {
            return UserOnline.GetGuestUser(PageIndex, PageSize, oderby);
        }
        /// <summary>
        /// 在线注册用户人数
        /// </summary>
        public int RegUserCount
        {
            get
            {
                return EbSite.BLL.User.UserOnline.GetCountRegUser();
            }
        }
        /// <summary>
        /// 获取在线注册用户列表
        /// </summary>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">每页显示多少</param>
        /// <param name="oderby">排序</param>
        /// <returns></returns>
        public List<EbSite.BLL.User.UserOnline> RegUsers(int PageIndex, int PageSize, string oderby)
        {
            return UserOnline.GetRegUser(PageIndex, PageSize, oderby);
        }
         

        /// <summary>
        /// 注册用户，注册完成后直接归组为GroupKey,GroupKey为用户组后台对应的那个串
        /// </summary>
        /// <param name="username">注册账号</param>
        /// <param name="password">注册密码,密码未加密</param>
        /// <param name="email">Email</param>
        /// <param name="ms">返回的状态</param>
        /// <param name="IsManager">是否管理员</param>
        /// <param name="GroupKey">用户组标记,如果为空，将归组到系统后台设置的默认用户组</param>
        /// <param name="RetunUrl">注册完成后返回定向的url</param>
        /// <param name="YQUserID">邀请用户的ID,邀请用户可以得到积分</param>
        /// <param name="FromUrl">请求页面的来源，ebsite默认以参数为 HttpContext.Current.Request["ru"];如果有，注册完成后将会返回这个页面</param>
        /// <param name="Mobile">手机号</param>
        /// <param name="RegType">注册类型，0email注册，1用户名称注册，2手机号码注册</param>
        /// <param name="IP">注册用户的Ip</param>
        /// <param name="RegRemark">注册说明</param>
        /// <returns></returns>
        public int RegUserByGroupKey(string username, string password, string email, out RegStatus ms, bool IsManager, string GroupKey, out string RetunUrl, int YQUserID, string FromUrl, string Mobile, int RegType, string IP, string RegRemark)
        {
            return RegUserByGroupKey(username, password, email, out ms, IsManager, GroupKey, out RetunUrl, YQUserID, FromUrl,
                               Mobile, RegType, "", IP, RegRemark);
        }
        /// <summary>
        /// 注册用户，注册完成后直接归组为GroupKey,GroupKey为用户组后台对应的那个串
        /// </summary>
        /// <param name="username">注册账号</param>
        /// <param name="password">注册密码,密码未加密</param>
        /// <param name="email">Email</param>
        /// <param name="ms">返回的状态</param>
        /// <param name="IsManager">是否管理员</param>
        /// <param name="GroupKey">用户组标记,如果为空，将归组到系统后台设置的默认用户组</param>
        /// <param name="RetunUrl">注册完成后返回定向的</param>
        /// <param name="YQUserID">邀请用户的ID,邀请用户可以得到积分</param>
        /// <param name="FromUrl">请求页面的来源，ebsite默认以参数为 HttpContext.Current.Request["ru"];如果有，注册完成后将会返回这个页面</param>
        /// <param name="Mobile">手机号</param>
        /// <param name="RegType">注册类型，0email注册，1用户名称注册，2手机号码注册</param>
        /// <param name="UserNiName">用户昵称</param>
        /// <param name="IP">注册用户的Ip</param>
        /// <param name="RegRemark">注册说明</param>
        /// <returns></returns>
        public int RegUserByGroupKey(string username, string password, string email, out RegStatus ms, bool IsManager, string GroupKey, out string RetunUrl, int YQUserID, string FromUrl, string Mobile, int RegType, string UserNiName, string IP, string RegRemark)
        {
            return RegUserByGroupKey(username, password, email, out ms, IsManager, GroupKey, out RetunUrl, YQUserID,
                                     FromUrl, Mobile, RegType, UserNiName, false, IP, RegRemark);

        }
        /// <summary>
        /// 注册用户，注册完成后直接归组为GroupKey,GroupKey为用户组后台对应的那个串
        /// </summary>
        /// <param name="username">注册账号</param>
        /// <param name="password">注册密码,密码未加密</param>
        /// <param name="email">Email</param>
        /// <param name="ms">返回的状态</param>
        /// <param name="IsManager">是否管理员</param>
        /// <param name="GroupKey">用户组标记,如果为空，将归组到系统后台设置的默认用户组</param>
        /// <param name="RetunUrl">注册完成后返回定向的</param>
        /// <param name="YQUserID">邀请用户的ID,邀请用户可以得到积分</param>
        /// <param name="FromUrl">请求页面的来源，ebsite默认以参数为 HttpContext.Current.Request["ru"];如果有，注册完成后将会返回这个页面</param>
        /// <param name="Mobile">手机号</param>
        /// <param name="RegType">注册类型，0email注册，1用户名称注册，2手机号码注册</param>
        /// <param name="UserNiName">用户昵称</param>
        /// <param name="IsHt">是否从后台管理添加的注册用户</param>
        /// <param name="IP">注册用户的Ip</param>
        /// <param name="RegRemark">注册说明</param>
        /// <returns></returns>
        public int RegUserByGroupKey(string username, string password, string email, out RegStatus ms, bool IsManager, string GroupKey, out string RetunUrl, int YQUserID, string FromUrl, string Mobile, int RegType, string UserNiName, bool IsHt, string IP, string RegRemark)
        {
            return EbSite.BLL.User.MembershipUserEb.Instance.RegUserByGroupKey(username, password, email, out  ms, IsManager, GroupKey, out  RetunUrl, YQUserID, FromUrl, Mobile, RegType, UserNiName, IsHt, IP, RegRemark);
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="sUserName">注册账号</param>
        /// <param name="Pass">注册密码,密码未加密</param>
        /// <param name="sRpass">确认密码</param>
        /// <param name="sEmail">注册电子邮箱</param>
        /// <param name="IsManager">是否注册完成后生成管理员</param>
        /// <param name="GroupID">用户组ID,注册完成后归到哪个用户组下</param>
        /// <param name="ms">返回的状态</param>
        /// <param name="RetunUrl">注册完成后返回定向的</param>
        /// <param name="vUserID">邀请用户的ID,邀请用户可以得到积分</param>
        /// <param name="FromUrl">请求页面的来源，ebsite默认以参数为 HttpContext.Current.Request["ru"];如果有，注册完成后将会返回这个页面</param>
        /// <param name="Mobile">手机号</param>
        /// <param name="RegType">注册类型，0email注册，1用户名称注册，2手机号码注册</param>
        /// <param name="IP">注册用户的Ip</param>
        /// <param name="RegRemark">注册说明</param>
        /// <returns></returns>
        public int RegUser(string sUserName, string Pass, string sRpass, string sEmail, bool IsManager, int GroupID, out RegStatus ms, out string RetunUrl, int vUserID, string FromUrl, string Mobile, int RegType, string IP, string RegRemark)
        {
            return RegUser(sUserName, Pass, sRpass, sEmail, IsManager, GroupID, out ms, out RetunUrl, vUserID, FromUrl,
                           Mobile, RegType, "", IP, RegRemark);
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="sUserName">注册账号</param>
        /// <param name="Pass">注册密码,密码未加密</param>
        /// <param name="sRpass">确认密码</param>
        /// <param name="sEmail">注册电子邮箱</param>
        /// <param name="IsManager">是否注册完成后生成管理员</param>
        /// <param name="GroupID">用户组ID,注册完成后归到哪个用户组下</param>
        /// <param name="ms">返回的状态</param>
        /// <param name="RetunUrl">注册完成后返回定向的</param>
        /// <param name="vUserID">邀请用户的ID,邀请用户可以得到积分</param>
        /// <param name="FromUrl">请求页面的来源，ebsite默认以参数为 HttpContext.Current.Request["ru"];如果有，注册完成后将会返回这个页面</param>
        /// <param name="Mobile">手机号</param>
        /// <param name="RegType">注册类型，0email注册，1用户名称注册，2手机号码注册</param>
        /// <param name="UserNiName">用户昵称</param>
        /// <param name="IP">注册用户的Ip</param>
        /// <param name="RegRemark">注册说明</param>
        /// <returns></returns>
        public int RegUser(string sUserName, string Pass, string sRpass, string sEmail, bool IsManager, int GroupID, out RegStatus ms, out string RetunUrl, int vUserID, string FromUrl, string Mobile, int RegType, string UserNiName, string IP, string RegRemark)
        {
            return RegUser(sUserName, Pass, sRpass, sEmail, IsManager, GroupID,
                           out ms, out RetunUrl, vUserID, FromUrl, Mobile,
                           RegType, UserNiName, false, IP, RegRemark);

        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="sUserName">注册账号</param>
        /// <param name="Pass">注册密码,密码未加密</param>
        /// <param name="sRpass">确认密码</param>
        /// <param name="sEmail">注册电子邮箱</param>
        /// <param name="IsManager">是否注册完成后生成管理员</param>
        /// <param name="GroupID">用户组ID,注册完成后归到哪个用户组下</param>
        /// <param name="ms">返回的状态</param>
        /// <param name="RetunUrl">注册完成后返回定向的</param>
        /// <param name="vUserID">邀请用户的ID,邀请用户可以得到积分</param>
        /// <param name="FromUrl">请求页面的来源，ebsite默认以参数为 HttpContext.Current.Request["ru"];如果有，注册完成后将会返回这个页面</param>
        /// <param name="Mobile">手机号</param>
        /// <param name="RegType">注册类型，0email注册，1用户名称注册，2手机号码注册</param>
        /// <param name="UserNiName">用户昵称</param>
        /// <param name="IsHt"></param>
        /// <param name="IP">注册用户的Ip</param>
        /// <param name="RegRemark">注册说明</param>
        /// <returns></returns>
        public int RegUser(string sUserName, string Pass, string sRpass, string sEmail, bool IsManager, int GroupID, out RegStatus ms, out string RetunUrl, int vUserID, string FromUrl, string Mobile, int RegType, string UserNiName, bool IsHt, string IP, string RegRemark)
        {
            //MembershipCreateStatus ms;

            ////同时写入UserCustomField表，以记录用户的一些共同可扩展属性,而UserGroupProfile表是不同用户属性的，高级版中将由用户模型生成不同的表

            int UserID = EbSite.BLL.User.MembershipUserEb.Instance.RegUser(sUserName, Pass, sEmail, out ms, IsManager, GroupID, out  RetunUrl, vUserID, FromUrl, Mobile, RegType, UserNiName, IsHt, IP, RegRemark);

            return UserID;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="login_username">用户账号</param>
        /// <param name="login_pwd">用户输入的密码</param>
        /// <param name="login_yzm">用户输入的验证码</param>
        /// <param name="iscookie">是否记住登录状态， 使用系统后台设置的cookie过期时间记录登录状态</param>
        /// <param name="login_type">0为帐号登录，1为email登录，2为手机号登录</param>
        /// <param name="ls">登录状态</param>
        /// <param name="sReturnUrl">登录成功后返回地址</param>
        /// <param name="sFromUrl">请求来源地址，用户返回</param>
        /// <returns></returns>
        public EbSite.Base.EntityAPI.MembershipUserEb Login(string login_username, string login_pwd, string login_yzm, bool iscookie, int login_type, out LoginStatus ls, out string sReturnUrl, string sFromUrl)
        {
            return EbSite.BLL.User.MembershipUserEb.Instance.Login(login_username, login_pwd, login_yzm, iscookie, login_type, out  ls, out sReturnUrl, false, sFromUrl);
        }
        /// <summary>
        /// 用户登录 没有密码用短信码登录
        /// </summary>
        /// <param name="login_username"></param>
        /// <param name="login_yzm"></param>
        /// <param name="ls"></param>
        /// <returns></returns>
        public EbSite.Base.EntityAPI.MembershipUserEb LoginNoPass(string login_username, string login_yzm, out LoginStatus ls)
        {
            return EbSite.BLL.User.MembershipUserEb.Instance.LoginNoPass(login_username,  login_yzm,  out  ls);
        }
     /// <summary>
        /// 添加 重构 因为 在后台 添加 用户或 管理员 时 会定向到 注册人的定向面页。 IsHt 是否从后台来的
     /// </summary>
     /// <param name="sUserName"></param>
     /// <param name="Pass"></param>
     /// <param name="sRpass"></param>
     /// <param name="sEmail"></param>
     /// <param name="IsManager"></param>
     /// <param name="GroupID"></param>
     /// <param name="IP"></param>
     /// <param name="RegRemark"></param>
     /// <returns></returns>
        public int RegUser(string sUserName, string Pass, string sRpass, string sEmail, bool IsManager, int GroupID, string IP, string RegRemark)
        {
            return RegUser(sUserName, Pass, sRpass, sEmail, IsManager, GroupID, false, IP, RegRemark);

        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="sUserName">用户账号</param>
        /// <param name="Pass">密码</param>
        /// <param name="sRpass">确认密码</param>
        /// <param name="sEmail">电子邮箱</param>
        /// <param name="IsManager">是否注册后成为管理员</param>
        /// <param name="GroupID">注册完成后归到的用户组ID</param>
        /// <param name="IsHt">是否后台添加用户</param>
        /// <param name="IP">注册用户ID</param>
        /// <param name="RegRemark">注册说明</param>
        /// <returns></returns>
        public int RegUser(string sUserName, string Pass, string sRpass, string sEmail, bool IsManager, int GroupID, bool IsHt, string IP, string RegRemark)
        {
            string username = sUserName.Trim();
            string password = Pass.Trim();
            string cfpassword = sRpass.Trim();
            string email = sEmail.Trim();
            int UserID = -1;
            if (password != cfpassword)
            {
                cJavascripts.MessageShowBack("两次输入的密码不一样");
            }
            else
            {
                RegStatus ms;

                ////同时写入UserCustomField表，以记录用户的一些共同可扩展属性,而UserGroupProfile表是不同用户属性的，高级版中将由用户模型生成不同的表
                string surl = "";
                UserID = EbSite.BLL.User.MembershipUserEb.Instance.RegUser(username, password, email, out ms, IsManager, GroupID, out surl, 0, "", "", 1, "", IsHt, IP, RegRemark);

                if (RegStatus.已经存在此帐号 == ms)
                {
                    cJavascripts.MessageShowBack("已经存在此用户名,请换一个用户名再注册!");
                }
                if (RegStatus.已经存在此Email == ms)
                {
                    cJavascripts.MessageShowBack("已经存在此Email,请换一个Email再注册!");
                }


            }
            return UserID;
        }

        public void BindLogin(string ApiName, string BackUrl)
        {
            EbSite.Core.Utils.WriteCookie("loginapiback", BackUrl);
            HttpContext.Current.Response.Redirect(GetLoginApiUrl(ApiName));
        }

        public bool GetIsAuditing()
        {
            return GetIsAuditing(UserID);
        }

        /// <summary>
        /// 验证 发表内容免审核的用户级别 是否存在 false== 没有开启 true 开启
        /// </summary>
        /// <returns></returns>
        public bool GetIsAuditing(int iUserID)
        {
            if (iUserID > 0)
            {
                List<string> ls = EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.UserlevaNoCheck;
                if (ls.Count > 0)
                {
                    int icount = (from i in ls where i == UserLevel.ToString() select i).Count();
                    if (icount > 0)
                    {
                        return false;
                    } 
                }
                return true;

            }
            return true;
        }
        /// <summary>
        /// 更新用户头像
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="imgpath">原图片绝对路径</param>
        public void UpdateICO(int userid, string imgpath, HttpContext context)
        {
            imgpath = context.Server.MapPath(imgpath);
            //用户头像保存目录
            string sPath = EbSite.BLL.User.MembershipUserEb.Instance.GetAvatarFileName(userid, 1);
            EbSite.Core.ImagesMake.GenThumbnail(imgpath, context.Server.MapPath(sPath), 200, 200);

            sPath = EbSite.BLL.User.MembershipUserEb.Instance.GetAvatarFileName(userid, 2);
            EbSite.Core.ImagesMake.GenThumbnail(imgpath, context.Server.MapPath(sPath), 120, 120);

            sPath = EbSite.BLL.User.MembershipUserEb.Instance.GetAvatarFileName(userid, 3);
            EbSite.Core.ImagesMake.GenThumbnail(imgpath, context.Server.MapPath(sPath), 80, 80);

            Core.FSO.FObject.Delete(imgpath, FsoMethod.File);

        }
        /// <summary>
        /// 用户是否开启 预付款功能
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool IsOpenBalance(int userid)
        {
            List<EbSite.Entity.PayPass> ls = EbSite.BLL.PayPass.Instance.GetListArray(1, "UserId=" + userid, "");
            if (ls.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
