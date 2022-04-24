using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using EbSite.Base;
using EbSite.Base.Configs.UserSetConfigs;
using EbSite.Base.EBSiteEventArgs;
using EbSite.BLL.Email;
using EbSite.Base.Static;
using EbSite.Core;

namespace EbSite.BLL.User
{
    public class MembershipUserEb : Base.BLL.BllBase<EbSite.Base.EntityAPI.MembershipUserEb, int>
    {
        public static readonly MembershipUserEb Instance = new MembershipUserEb();
//        public string GetUserPass(string sUserName,out bool isHave)
//        {
//            return Base.Host.Instance.EBMembershipInstance.Users_GetPass(sUserName, out isHave);
//        }
        public string GetEmailByUserID(int UserID)
        {
            return Base.Host.Instance.EBMembershipInstance.Users_GetEmail(UserID);
        }
        public string GetMobileNumber(int UserID)
        {
            return Base.Host.Instance.EBMembershipInstance.User_GetMobileNumber(UserID);
        }
        public string GetMobileNumber(string UserName)
        {
            return Base.Host.Instance.EBMembershipInstance.User_GetMobileNumber(UserName);
        }
        public Base.EntityAPI.ShortUserInfo GetShortUserInfo(string UserName)
        {
            return Base.Host.Instance.EBMembershipInstance.GetShortUserInfo(UserName);
        }
        public Base.EntityAPI.ShortUserInfo GetShortUserInfo(int UserID)
        {
            return Base.Host.Instance.EBMembershipInstance.GetShortUserInfo(UserID);
        }

        /// <summary>
        /// 获取用户ID-从用户帐号
        /// </summary>
        /// <param name="sUserName"></param>
        /// <returns></returns>
        public int GetUserIDByUserName(string sUserName)
        {
            string CacheKey = string.Concat("GetUserIDByUserName-", sUserName);
            string str = base.GetCacheItem<string>(CacheKey);
            if (str == null)
            {
                str = EbSite.Base.Host.Instance.EBMembershipInstance.GetUserIDByUserName(sUserName).ToString();

                if (!string.IsNullOrEmpty(str))
                    base.AddCacheItem(CacheKey, str);
            }
            return Core.Utils.StrToInt(str, 0);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Base.EntityAPI.MembershipUserEb GetEntity(string sUserName)
        {
            string CacheKey = string.Concat("GetEntity-", sUserName);
            Base.EntityAPI.MembershipUserEb md = GetCacheItem<Base.EntityAPI.MembershipUserEb>(CacheKey);
            if (md == null)
            {
                md = EbSite.Base.Host.Instance.EBMembershipInstance.Users_GetEntity(sUserName);
                if (!Equals(md, null))
                    base.AddCacheItem(CacheKey, md);
            }
            return md;
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Pass"></param>
        /// <returns></returns>
        public bool ChangeUserPass(string UserName, string Pass)
        {
            return EbSite.Base.Host.Instance.EBMembershipInstance.ChangeUserPass(UserName, Pass);
        }
        /// <summary>
        /// 获取头像的路径包括文件名
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="iSize"></param>
        /// <returns></returns>
        public string GetAvatarFileName(int UserID, int iSize)
        {

            return EbSite.Base.Host.Instance.EBMembershipInstance.GetAvatarFileName(UserID, iSize);
        }
        /// <summary>
        /// 保存一个远程图片为用户头像
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="AvatarUrl">远程图片地址</param>
        public void UpdateAvatar(int UserID, string AvatarUrl)
        {
            string sPath = GetAvatarFileName(UserID, 1);
            sPath = HttpContext.Current.Server.MapPath(sPath);
            Core.WebUtility.WebClientGetFile(AvatarUrl, sPath);

            sPath = GetAvatarFileName(UserID, 2);
            sPath = HttpContext.Current.Server.MapPath(sPath);
            Core.WebUtility.WebClientGetFile(AvatarUrl, sPath);

            sPath = GetAvatarFileName(UserID, 3);
            sPath = HttpContext.Current.Server.MapPath(sPath);
            Core.WebUtility.WebClientGetFile(AvatarUrl, sPath);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        override public int Add(Base.EntityAPI.MembershipUserEb model)
        {
            base.InvalidateCache();
            return EbSite.Base.Host.Instance.EBMembershipInstance.Users_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        override public void Update(Base.EntityAPI.MembershipUserEb model)
        {
            base.InvalidateCache();
            Base.Host.Instance.EBMembershipInstance.Users_Update(model);
        }

        public void Update(Base.EntityAPI.MembershipUserEb model, DbTransaction tran)
        {
            base.InvalidateCache();
            Base.Host.Instance.EBMembershipInstance.Users_Update(model, tran);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        override public void Delete(int UserID)
        {
            base.InvalidateCache();

            Base.Host.Instance.EBMembershipInstance.Users_Delete(UserID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string sUserName)
        {
            base.InvalidateCache();
            Base.Host.Instance.EBMembershipInstance.Users_Delete(sUserName);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        override public Base.EntityAPI.MembershipUserEb GetEntity(int UserID)
        {

            string rawKey = string.Concat("GetEntity-", UserID);
            Base.EntityAPI.MembershipUserEb etEntity = base.GetCacheItem<Base.EntityAPI.MembershipUserEb>(rawKey);
            if (Equals(etEntity, null))
            {
                etEntity = Base.Host.Instance.EBMembershipInstance.Users_GetEntity(UserID);
                if (!Equals(etEntity, null))
                    base.AddCacheItem(rawKey, etEntity);
            }
            return etEntity;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Base.EntityAPI.MembershipUserEb> GetListArray(int Top, string strWhere, string filedOrder)
        {
            return Base.Host.Instance.EBMembershipInstance.Users_GetListArray(Top, strWhere, filedOrder);
        }
        public List<Base.EntityAPI.MembershipUserEb> GetListArrayOrderCredits(int Top, string strWhere)
        {
            return Base.Host.Instance.EBMembershipInstance.Users_GetListArray(Top, strWhere, "-Credits");
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        override public List<Base.EntityAPI.MembershipUserEb> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            return Base.Host.Instance.EBMembershipInstance.Users_GetListPages(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
        }

        public bool ExistsUserID(int iUserID)
        {
            return Base.Host.Instance.EBMembershipInstance.Users_Exists(iUserID);
        }
        public bool ExistsUserName(string sUserName)
        {
            int iUserID = Base.Host.Instance.EBMembershipInstance.GetUserIDByUserName(sUserName);
            return iUserID > 0;
        }
        public bool ExistsEmail(string sEmail)
        {
            return Base.Host.Instance.EBMembershipInstance.ExistEmail(sEmail);
            //string sUserName =  Base.Host.Instance.EBMembershipInstance.GetUserNameByEmail(sEmail);
            //return !string.IsNullOrEmpty(sUserName);
        }
        public bool ExistsMobile(string sMobile)
        {
            return Base.Host.Instance.EBMembershipInstance.ExistMobile(sMobile);
            //string sUserName =  Base.Host.Instance.EBMembershipInstance.GetUserNameByEmail(sEmail);
            //return !string.IsNullOrEmpty(sUserName);
        }
        /// <summary>
        /// 通过手机得到 用户实体
        /// </summary>
        public Base.EntityAPI.MembershipUserEb GetUserMobile(string sMobileNumber)
        {
            return Base.Host.Instance.EBMembershipInstance.GetUserMobile(sMobileNumber);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Base.EntityAPI.MembershipUserEb> GetListArrayCache(int Top, string strWhere, string filedOrder)
        {
            string rawKey = string.Concat("GetListArray-", strWhere, Top, filedOrder);
            List<Base.EntityAPI.MembershipUserEb> lstData = base.GetCacheItem<List<Base.EntityAPI.MembershipUserEb>>(rawKey);
            if (Equals(lstData, null))
            {
                //从基类调用，激活事件
                lstData = base.GetListArrayEv(Top, strWhere, filedOrder);
                if (!Equals(lstData, null))
                    base.AddCacheItem(rawKey, lstData);
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Base.EntityAPI.MembershipUserEb> GetListArray(int Top, string filedOrder)
        {
            return GetListArrayCache(Top, "", filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Base.EntityAPI.MembershipUserEb> GetListArray(string strWhere)
        {
            return GetListArrayCache(0, strWhere, "");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCountCache(string strWhere)
        {
            string rawKey = string.Concat("GetCount-", strWhere);
            string sCount = base.GetCacheItem<string>(rawKey);
            if (string.IsNullOrEmpty(sCount))
            {
                sCount = Base.Host.Instance.EBMembershipInstance.User_GetCount(strWhere).ToString();
                if (!string.IsNullOrEmpty(sCount))
                    base.AddCacheItem(rawKey, sCount);
            }
            if (!string.IsNullOrEmpty(sCount))
            {
                return int.Parse(sCount);
            }
            return 0;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Base.EntityAPI.MembershipUserEb> GetListPagesCache(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            string rawKey = string.Concat("GlPages-", PageIndex, PageSize, strWhere, Fileds, oderby);
            string rawKeyCount = string.Concat("C-", rawKey);
            List<Base.EntityAPI.MembershipUserEb> lstData = base.GetCacheItem<List<Base.EntityAPI.MembershipUserEb>>(rawKey);
            int iRecordCount = -1;
            if (Equals(lstData, null))
            {
                //从基类调用，激活事件
                lstData = base.GetListPagesEv(PageIndex, PageSize, strWhere, Fileds, oderby, out  RecordCount);
                if (!Equals(lstData, null))
                {
                    base.AddCacheItem(rawKey, lstData);
                    base.AddCacheItem(rawKeyCount, RecordCount.ToString());
                }
            }
            if (iRecordCount == -1)
            {
                string sCount = base.GetCacheItem<string>(rawKeyCount);
                if (!string.IsNullOrEmpty(sCount))
                {
                    RecordCount = int.Parse(sCount);
                }
                else
                {
                    RecordCount = GetCountCache(strWhere);
                }
            }
            else
            {
                RecordCount = iRecordCount;
            }
            return lstData;
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Base.EntityAPI.MembershipUserEb> GetListPages(int PageIndex, int PageSize, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, "", "", "", out  RecordCount);
        }
        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Base.EntityAPI.MembershipUserEb> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }

        /// <summary>
        /// 获得数据列表-分页
        /// </summary>
        public List<Base.EntityAPI.MembershipUserEb> GetListPages(int PageIndex, int PageSize, string strWhere, string oderby)
        {
            int iCount = 0;
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out iCount);
        }
        /// <summary>
        /// 搜索-分页
        /// </summary>
        public List<Base.EntityAPI.MembershipUserEb> SearchLike(int PageIndex, int PageSize, string oderby, out int RecordCount, string sKeyWord, string ColumnName)
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(sKeyWord)) strWhere = string.Format("{0} like '%{1}%'", ColumnName, sKeyWord);
            if (string.IsNullOrEmpty(strWhere))
            {
                RecordCount = 0;
                return null;
            }
            return GetListPagesCache(PageIndex, PageSize, strWhere, "", oderby, out  RecordCount);
        }

        /// <summary>
        /// 验证用户是否合法
        /// </summary>
        /// <param name="sUserName">用户名</param>
        /// <param name="Pass">密码</param>
        /// <param name="CookieExpiresTime">验证成功的话，cookie保存时长,单位分钟,如果此值为小于1,将使用系统默认配置</param>
        /// <param name="IsMD5Pass">是否已经加密过的密码</param>
        /// <returns></returns>
        public EbSite.Base.EntityAPI.MembershipUserEb ValidateUser(string sUserName, string Pass, int CookieExpiresTime, out string err, bool IsMD5Pass)
        {
            Base.EntityAPI.MembershipUserEb ucf = null;
            //验证是否禁止登录IP

            bool isAllowIP = IP.IsAllowIP(Utils.GetClientIP(), Base.Configs.UserSetConfigs.ConfigsControl.Instance.StarIP,
 Base.Configs.UserSetConfigs.ConfigsControl.Instance.EndIP, Base.Configs.UserSetConfigs.ConfigsControl.Instance.IPSetDateTime);

            if (!isAllowIP)
            {
                err = "您被禁止登录,可能IP已经列入黑名单!";
                return ucf;
            }

            string sPass = (IsMD5Pass) ? Pass : UserIdentity.PassWordEncode(Pass);

            err = "";

            bool HaveUser = EbSite.Base.Host.Instance.EBMembershipInstance.IsHaveUser(sUserName, (IsMD5Pass) ? Pass : sPass);//Membership.ValidateUser(sUserName, Pass);

            if (HaveUser)
            {
                ucf = GetEntity(sUserName);
                if (ucf.IsApproved)
                {

                    #region  一天内第一次登录可获得积分 yhl 2012-01-04  添加
                    //最后登录时间不是今天说明是今天的第一次登录
                    if (DateTime.Now.Day == DateTime.Parse(ucf.LastLoginDate.ToString()).Day && DateTime.Now.Month == DateTime.Parse(ucf.LastLoginDate.ToString()).Month && DateTime.Now.Year == DateTime.Parse(ucf.LastLoginDate.ToString()).Year)
                    {
                        #region  登录成功后，更新用户的等级 yhl
                        ucf.UserLevel = UpdateUserLevel(ucf.Credits);
                        EbSite.BLL.User.MembershipUserEb.Instance.Update(ucf);
                        #endregion
                    }
                    else
                    {
                        int score = int.Parse(ConfigsControl.Instance.LoginInCredit.ToString());
                        ucf.Credits += score;
                        ucf.LastLoginDate = DateTime.Now;

                        #region  登录成功后，更新用户的等级 yhl
                        ucf.UserLevel = UpdateUserLevel(ucf.Credits);
                        #endregion

                        EbSite.BLL.User.MembershipUserEb.Instance.Update(ucf);
                    }

                    #endregion


                    if (CookieExpiresTime < 1)
                        CookieExpiresTime = Base.Configs.SysConfigs.ConfigsControl.Instance.LoginExpires;

                    BLL.User.UserIdentity.WriteUserIdentity(ucf.id.ToString(), sUserName, ucf.NiName, sPass, CookieExpiresTime, ucf.GroupID.ToString());

                    //与membership登录同步
                    //EBPrincipal newUser = new EBPrincipal(ucf.id, sUserName, ucf.LastLoginDate, ucf.IsLockedOut);
                    //HttpContext.Current.User = newUser;
                    //FormsAuthentication.SetAuthCookie(sUserName, false);
                }
                else
                {
                    err = "帐号还没有激活,请在24小时内激活帐号!";
                }


            }
            else
            {
                err = "不存在用户或密码错误!";
            }

            return ucf;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login_username">用户帐号，或用户email或手机号码，视login_type 而定，0为帐号登录，1为email登录，2为手机号登录</param>
        /// <param name="login_pwd">密码</param>
        /// <param name="login_yzm">验证码</param>
        /// <param name="iscookie">是否记住</param>
        /// <param name="login_type">0为帐号登录，1为email登录，2为手机号登录</param>
        /// <param name="ls">登录状态</param>
        /// <param name="sReturnUrl">登录成功后返回地址</param>
        /// <param name="IsMD5Pass">密码是否经过加密的</param>
        /// <param name="sFromUrl">请求来源地址，用户返回</param>
        /// <returns></returns>
        public EbSite.Base.EntityAPI.MembershipUserEb Login(string login_username, string login_pwd, string login_yzm, bool iscookie, int login_type, out LoginStatus ls, out string sReturnUrl, bool IsMD5Pass, string sFromUrl)
        {

            sReturnUrl = string.Empty;
            if (BLL.User.UserIdentity.IsOverErrLoginNum())
            {
                ls = LoginStatus.错误登录次数超出规定;
                return null;
            }
            //如果开验证码
            if (BLL.User.UserIdentity.GetErrNum > 0 || Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpenSafeCoder)
            {
                if (!BLL.User.UserIdentity.ValidateSafeCode(login_yzm))
                {
                    ls = LoginStatus.验证码不正确;
                    return null;
                }
            }

            Base.EntityAPI.MembershipUserEb ucf = null;
            //验证是否禁止登录IP

            bool isAllowIP = IP.IsAllowIP(Utils.GetClientIP(), Base.Configs.UserSetConfigs.ConfigsControl.Instance.StarIP,
 Base.Configs.UserSetConfigs.ConfigsControl.Instance.EndIP, Base.Configs.UserSetConfigs.ConfigsControl.Instance.IPSetDateTime);

            if (!isAllowIP)
            {
                ls = LoginStatus.IP禁止登录;
                return null;
            }

            string sPass = (IsMD5Pass) ? login_pwd : UserIdentity.PassWordEncode(login_pwd);

            bool HaveUser = false;
            if (login_type == 0)
            {
                HaveUser = EbSite.Base.Host.Instance.EBMembershipInstance.IsHaveUser(login_username, sPass);//(IsMD5Pass) ? login_pwd : sPass
                if (HaveUser)
                    ucf = GetEntity(login_username);
            }
            else if (login_type == 1)
            {
                ucf = EbSite.Base.Host.Instance.EBMembershipInstance.GetUserByEmail(login_username, sPass);
                if (!Equals(ucf, null))
                    HaveUser = true;
            }
            else if (login_type == 2)
            {
                ucf = EbSite.Base.Host.Instance.EBMembershipInstance.GetUserByEmail(login_username, sPass);
                if (!Equals(ucf, null))
                    HaveUser = true;
            }


            if (HaveUser)
            {

                if (ucf.IsApproved)
                {
                    ucf.LoginCount = ucf.LoginCount + 1;//统计登录次数
                    #region  一天内第一次登录可获得积分 yhl 2012-01-04  添加
                    //最后登录时间不是今天说明是今天的第一次登录
                    if (DateTime.Now.Day == DateTime.Parse(ucf.LastLoginDate.ToString()).Day && DateTime.Now.Month == DateTime.Parse(ucf.LastLoginDate.ToString()).Month && DateTime.Now.Year == DateTime.Parse(ucf.LastLoginDate.ToString()).Year)
                    {
                        #region  登录成功后，更新用户的等级 yhl

                        ucf.UserLevel = UpdateUserLevel(ucf.Credits);
                        ucf.LastLoginDate = DateTime.Now;
                        EbSite.BLL.User.MembershipUserEb.Instance.Update(ucf);
                        #endregion
                    }
                    else
                    {
                        int score = int.Parse(ConfigsControl.Instance.LoginInCredit.ToString());
                        ucf.Credits += score;
                        ucf.LastLoginDate = DateTime.Now;
                        #region  登录成功后，更新用户的等级 yhl
                        ucf.UserLevel = UpdateUserLevel(ucf.Credits);
                        #endregion
                        EbSite.BLL.User.MembershipUserEb.Instance.Update(ucf);
                    }

                    #endregion

                    int CookieExpiresTime = 1440; //1440分钟后过期 一天时间24小时
                    if (iscookie)
                        CookieExpiresTime = Base.Configs.SysConfigs.ConfigsControl.Instance.LoginExpires;

                    BLL.User.UserIdentity.WriteUserIdentity(ucf.id.ToString(), login_username, ucf.NiName, sPass, CookieExpiresTime, ucf.GroupID.ToString());

                    ////与membership登录同步 移到 WriteUserIdentity
                    //EBPrincipal newUser = new EBPrincipal(ucf.id, login_username, ucf.LastLoginDate, ucf.IsLockedOut);
                    //HttpContext.Current.User = newUser;
                    //FormsAuthentication.SetAuthCookie(login_username, false);
                }
                else
                {
                    //err = "帐号还没有激活,请在24小时内激活帐号!";
                    ls = LoginStatus.帐号没有激活;
                    return null;
                }


            }
            else
            {
                BLL.User.UserIdentity.AddErrLoginNum();
                //err = "不存在用户或密码错误!";
                ls = LoginStatus.不存在此帐号或密码错误;
                return null;
            }


            ls = LoginStatus.登录成功;

            UserLoginedEventArgs Args = new UserLoginedEventArgs(ucf.id, ucf.UserName, ucf.emailAddress, ucf.Password, ucf.MobileNumber);
            Base.EBSiteEvents.OnUserLogined(ucf, Args);
            if (!string.IsNullOrEmpty(Args.ReturnUrl))
            {
                sReturnUrl = Args.ReturnUrl;
            }
            else
            {
                if (string.IsNullOrEmpty(sFromUrl))
                {
                    sReturnUrl = Base.Host.Instance.UccUrl;
                }
                else
                {
                    sReturnUrl = sFromUrl;
                }

            }
            return ucf;

        }

        /// <summary>
        /// 没有密码时，用随机码来登录 YHL2014-5-25
        /// </summary>
        /// <param name="login_username"></param>
        /// <param name="login_yzm"></param>
        /// <param name="ls"></param>
        /// <returns></returns>
        public EbSite.Base.EntityAPI.MembershipUserEb LoginNoPass(string login_username, string login_yzm, out LoginStatus ls)
        {
            if (!string.IsNullOrEmpty(login_username) && !string.IsNullOrEmpty(login_yzm))
            {
                if (!BLL.User.UserIdentity.ValidateSafeCode(login_yzm))
                {
                    ls = LoginStatus.验证码不正确;
                    return null;
                }
                EbSite.Base.EntityAPI.MembershipUserEb m = EbSite.BLL.User.MembershipUserEb.Instance.GetUserMobile(login_username);
                if (m != null)
                {
                    if (string.IsNullOrEmpty(m.Password))
                    {
                        ls = LoginStatus.登录成功;
                    }
                    else
                    {
                        ls = LoginStatus.登录失败;
                    }
                }
                else
                {
                    ls = LoginStatus.不存在此帐号或密码错误;
                }    
                return m;
            }
            else
            {
                 ls = LoginStatus.帐号不能为空;
                 return null;
            }
        }


        /// <summary>
        /// 验证用户是否合法
        /// </summary>
        /// <param name="sUserName">用户名</param>
        /// <param name="Pass">密码</param>
        /// <param name="CookieExpiresTime">验证成功的话，cookie保存时长,单位分钟,如果此值为小于1,将使用系统默认配置</param>
        /// <returns></returns>
        public EbSite.Base.EntityAPI.MembershipUserEb ValidateUser(string sUserName, string Pass, int CookieExpiresTime, out string err)
        {
            return ValidateUser(sUserName, Pass, CookieExpiresTime, out err, false);


        }


        /// <summary>
        /// 更新用户的等级，返回用户新的级别ID
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        private int UpdateUserLevel(int score)
        {
            int newLeval = 1;
            List<Entity.UserLevel> ls = EbSite.BLL.UserLevel.Instance.GetListArray("");
            List<Entity.UserLevel> nls = (from li in ls
                                          orderby li.id //descending
                                          select li).ToList();
            foreach (Entity.UserLevel userLevel in nls)
            {
                if (score < userLevel.MaxCredit)
                {
                    newLeval = userLevel.id;
                    break;

                }
            }
            return newLeval;
        }
        /// <summary>
        /// 验证用户是否合法-简单验证，只用menbership
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="Pass">已经加过密的密码</param>
        /// <returns></returns>
        public bool ValidateUserSimple(string sUserName, string Pass)
        {


            bool vlIsOK = false;
            string CacheKey = string.Concat("vl-", sUserName, Pass);
            string sIsOK = base.GetCacheItem<string>(CacheKey);
            if (string.IsNullOrEmpty(sIsOK))
            {
                string sPass = Pass;

                //if (IsEncodePassWord) sPass = UserIdentity.PassWordEncode(Pass);

                //vlIsOK = Membership.ValidateUser(sUserName, sPass);
                vlIsOK = EbSite.Base.Host.Instance.EBMembershipInstance.IsHaveUser(sUserName, sPass);
                base.AddCacheItem(CacheKey, vlIsOK.ToString());
            }
            else
            {
                vlIsOK = bool.Parse(sIsOK);
            }

            return vlIsOK;

        }
        /// <summary>
        /// 获取最新注册用户列表
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Base.EntityAPI.MembershipUserEb> GetListOfNews(int top)
        {
            return GetListArray(top, "CreateDate desc");
        }
        /// <summary>
        /// 获取积分达人用户列表
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Base.EntityAPI.MembershipUserEb> GetListOfCrdits(int top)
        {

            return GetListArray(top, "credits desc");
        }
        /// <summary>
        /// 验证激活码
        /// </summary>
        /// <param name="strActivateEncode">激活码</param>
        /// <param name="Pass">加过密的密码</param>
        /// <returns>是否通过，验证规则，目前规定为24小时内</returns>
        public bool IsActivateOK(string strActivateEncode, out int UserGroupID)
        {
            bool isok = false;
            string str = Core.DES.Decode(strActivateEncode, Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);

            string[] aStr = str.Split('|');
            //UserGroupName = "";
            UserGroupID = 0;
            if (aStr.Length == 4)
            {
                int iUserID = int.Parse(aStr[0]);
                int vUserID = Core.Utils.StrToInt(aStr[2], 0);
                UserGroupID = Utils.StrToInt(aStr[3], 0);

                EbSite.Base.EntityAPI.MembershipUserEb ucf = GetEntity(iUserID);
                if (ucf != null)
                {
                    DateTime dtStart = ucf.CreateDate;

                    long iHours = Core.Strings.cConvert.DateDiff("h", dtStart, DateTime.Now);
                    if (iHours < 24)
                    {
                        isok = true;
                        ActivateUser(ucf, vUserID, ucf.Password);
                    }
                    //else 用不用锁定用户
                    //{
                    //    ucf.IsLockedOut = true;
                    //    ucf.Save();
                    //}
                }
            }

            return isok;

        }
        /// <summary>
        /// 将用户置为通过(激活)
        /// </summary>
        /// <param name="ucf"></param>
        /// <param name="VUserID">邀请用户ID</param>
        /// <param name="Pass">加过密码的密码</param>
        public void ActivateUser(Base.EntityAPI.MembershipUserEb ucf, int VUserID, string Pass)
        {

            ucf.IsApproved = true;
            ucf.Save();

            //UserActivatedEventArgs Args = new UserActivatedEventArgs(ucf.id, ucf.UserName, ucf.emailAddress, ucf.GetColumNames[0], VUserID, Pass, ucf.GroupID);
            //Base.EBSiteEvents.OnUserActivated(null, Args);
            UserActivatedEventArgs Args = new UserActivatedEventArgs(ucf.id, ucf.UserName, ucf.emailAddress, VUserID, Pass, ucf.GroupID);
            Base.EBSiteEvents.OnUserActivated(null, Args);
        }
        public List<Base.EntityAPI.MembershipUserEb> GetListPages(int PageIndex, int PageSize, bool IsAuditing, out int RecordCount, int RoleID)
        {
            return Base.Host.Instance.EBMembershipInstance.GetListPages(PageIndex, PageSize, "", "UserID desc", IsAuditing,
                                                                        out RecordCount, RoleID);
        }

        public List<Base.EntityAPI.MembershipUserEb> GetListPages(int PageIndex, int PageSize, bool IsAuditing, out int RecordCount, int RoleID, string sWhere)
        {
            return Base.Host.Instance.EBMembershipInstance.GetListPages(PageIndex, PageSize, sWhere, "", IsAuditing,
                                                                       out RecordCount, RoleID);
        }

        public bool IsPassValiOK(string strAEncode, out string sChangeUserName, out string sChangePass)
        {
            bool isok = false;
            string str = Core.DES.Decode(strAEncode, Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);

            string[] aStr = str.Split('|');
            sChangeUserName = "";
            sChangePass = "";
            if (aStr.Length == 4)
            {
                sChangeUserName = aStr[0];
                sChangePass = aStr[1];
                bool vluser = Base.Host.Instance.EBMembershipInstance.IsHaveUser(sChangeUserName, sChangePass);
                //bool vluser = Membership.ValidateUser(sChangeUserName, sChangePass);
                if (vluser)
                {
                    MembershipUser mu = Membership.GetUser(sChangeUserName);
                    if (mu != null)
                    {
                        DateTime dtStart = mu.LastActivityDate; //目前用这个时间来记录密码申请更改时间

                        long iHours = Core.Strings.cConvert.DateDiff("h", dtStart, DateTime.Now);
                        if (iHours < 1) //1小时内修改完成
                        {
                            isok = true;

                        }
                    }
                }

            }

            return isok;
        }

        /// <param name="iUserKey">用户ID</param>
        /// <param name="ATag">注册时间</param>
        /// <param name="vUserID">邀请用户ID</param>
        /// <returns>激活码</returns>
        public string GetActivateEncode(string iUserKey, string ATag, int vUserID, int UserGroupID)
        {

            string str = Core.DES.Encode(string.Concat(iUserKey, "|", ATag, "|", vUserID, "|", UserGroupID), Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
            if (string.IsNullOrEmpty(str))
                return str;
            return HttpContext.Current.Server.UrlEncode(str);

        }

        /// <summary>
        /// 调某个用户来管理员
        /// </summary>
        /// <param name="username"></param>
        public void SetForManager(string username)
        {

            //向管理员表添加一个记录
            AdminUser userAdmin = new AdminUser();
            userAdmin.IsLock = false;
            userAdmin.LastLoginTime = DateTime.Now;
            userAdmin.UserName = username;
            userAdmin.UserID = Base.Host.Instance.EBMembershipInstance.GetUserIDByUserName(username);//杨欢乐添加 2011-12-10
            userAdmin.CurrentSiteID = 1;//默认站群 杨欢乐2011-12-31 添加
            userAdmin.Create();

            //更新为是否为管理员id
            //DbProviderUser.GetInstance().UserCustomField_UpdateUserForManagerOrNo(username, Managerid);


            base.InvalidateCache();
        }
        /// <summary>
        /// 取消某个用户的管理员资格
        /// </summary>
        /// <param name="username"></param>
        public void RemoveForManager(string username)
        {
            //更新为是否为管理员标记为false
            //DbProviderUser.GetInstance().UserCustomField_UpdateUserForManagerOrNo(username, 0);
            //同时将此用户的管理员表里的记录删除
            AdminUser userAdmin = new AdminUser(username);
            userAdmin.Delete();

            base.InvalidateCache();
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

        public int RegUserByGroupKey(string username, string password, string email, out RegStatus ms, bool IsManager, string GroupKey, out string RetunUrl, int YQUserID, string FromUrl, string Mobile, int RegType, string UserNiName, string IP, string RegRemark)
        {
            return RegUserByGroupKey(username, password, email, out ms, IsManager, GroupKey, out RetunUrl, YQUserID,
                                     FromUrl, Mobile, RegType, UserNiName, false, IP, RegRemark);
        }

        public int RegUserByGroupKey(string username, string password, string email, out RegStatus ms, bool IsManager, string GroupKey, out string RetunUrl, int YQUserID, string FromUrl, string Mobile, int RegType, string UserNiName, bool IsHt, string IP, string RegRemark)
        {

            int GroupID = string.IsNullOrEmpty(GroupKey) ? 0 : BLL.User.UserGroupProfile.GroupIDDecode(GroupKey);
            //string GroupName = string.Empty;

            //if (GroupID > 0)
            //{
            //    GroupName = BLL.User.UserGroupProfile.GetUserGroupProfile(GroupID).GroupName;
            //}
            //else
            //{
            //    //分配给一个默认用户组
            //    GroupName = Base.Configs.UserSetConfigs.ConfigsControl.Instance.UserGroup;
            //}
            return RegUser(username, password, email, out ms, IsManager, GroupID, out RetunUrl, YQUserID, FromUrl, Mobile, RegType, UserNiName, IsHt, IP, RegRemark);
        }

        //public int RegUser(string username, string password, string email, out RegStatus ms, bool IsManager, int GroupID, out string RetunUrl, int YQUserID, string FromUrl, string Mobile, int RegType, string UserNiName, bool IsHt, string IP, string RegRemark)
        //{

        //    string GroupName = string.Empty;

        //    if (GroupID > 0)
        //    {
        //        GroupName = BLL.User.UserGroupProfile.GetUserGroupProfile(GroupID).GroupName;
        //    }
        //    else
        //    {
        //        //分配给一个默认用户组
        //        GroupName = Base.Configs.UserSetConfigs.ConfigsControl.Instance.UserGroup;
        //    }
        //    return RegUser(username, password, email, out ms, IsManager, GroupName, out RetunUrl, YQUserID, FromUrl, Mobile, RegType, UserNiName, IsHt,IP,RegRemark);
        //}

        /// <summary>
        /// 注册一个用户,//同时写入UserCustomField表，以记录用户的一些共同可扩展属性,而UserGroupProfile表是不同用户属性的，高级版中将由用户模型生成不同的表
        /// </summary>
        /// <param name="username">用户帐号，如果为空，将取email用为用户帐号</param>
        /// <param name="password">密码未加密</param>
        /// <param name="email">Email</param>
        /// <param name="ms">返回的注册状态</param>
        /// <param name="IsManager">是否为管理员</param>
        /// <param name="GroupName">用户组名称</param>
        /// <param name="YQUserID">邀请用户的ID</param>
        ///<param name="FromUrl">请求页面的来源，ebsite默认以参数为 HttpContext.Current.Request["ru"];</param>
        /// <param name="Mobile">手机号</param>
        /// <param name="RegType">注册类型，0email注册，1用户名称注册，2手机号码注册</param>
        /// <param name="IsHt"> IsHt 是否从后台注册的  不用定向到当前注册用户的后台。</param>
        /// <param name="IP">注册用户的IP</param>
        /// <param name="RegRemark">注册标记</param>
        /// <returns></returns>
        public int RegUser(string username, string password, string email, out RegStatus ms, bool IsManager, int RegRoleID, out string RetunUrl,
            int YQUserID, string FromUrl, string Mobile, int RegType, string UserNiName, bool IsHt, string IP, string RegRemark)
        {

            string iNiName = username;
            RetunUrl = "";
            bool isok = false;
            if (RegType == 0) //email注册 
            {
                username = email;
                iNiName = email.Split('@')[0];// YHL 2013-06-06
                isok = ExistsEmail(email);
                if (isok)
                {
                    ms = RegStatus.已经存在此Email;//已经存在
                    return 0;
                }
            }
            else if (RegType == 2) //手机号注册
            {
                username = Mobile;
                iNiName = EbSite.Core.Strings.GetString.GetHidePhoneUName(Mobile);
                isok = ExistsMobile(Mobile);
                if (isok)
                {
                    ms = RegStatus.已经存在此手机号码;//已经存在
                    return 0;
                }
            }



            if (string.IsNullOrEmpty(username))
            {

                ms = RegStatus.帐号不能为空;//已经存在
                return 0;
            }


            //验证用户帐号是否存在
            isok = ExistsUserName(username);
            if (isok)
            {

                ms = RegStatus.已经存在此帐号;//已经存在
                return 0;
            }




            //是否激用户

            bool isApproved = (Base.Configs.UserSetConfigs.ConfigsControl.Instance.AllowUserType == 0);

            //!EbSite.Configs.UserSetConfigs.ConfigsControl.Instance.IsAuditingNewUser;
            //Membership.CreateUser(username, password, email, null, null, isApproved, null, out ms);
            //if (MembershipCreateStatus.Success != ms) return -1;



            //分配给一个默认用户组
            //string sUserG = string.Empty;

            //if (!string.IsNullOrEmpty(GroupName))
            //{
            //    sUserG = GroupName;
            //}
            //else
            //{
            //    //分配给一个默认用户组
            //    sUserG = Base.Configs.UserSetConfigs.ConfigsControl.Instance.UserGroup;
            //}

            int RoleID = 0;

            if (RegRoleID > 0)
            {
                RoleID = RegRoleID;
            }
            else
            {
                RoleID = ConfigsControl.Instance.UserGroupID;
            }

            //同时注册UserCustomField表，以记录用户的一些共同可扩展属性
            EbSite.Base.EntityAPI.MembershipUserEb UCF = new Base.EntityAPI.MembershipUserEb();

            UCF.UserName = username;
            UCF.Credits = Base.Configs.UserSetConfigs.ConfigsControl.Instance.DefaultCredits;
            UCF.UserLevel = ConfigsControl.Instance.DefaultLevel;//设置一个默认用户级别
            UCF.MobileNumber = Mobile;
            if (!string.IsNullOrEmpty(password))
            {
                UCF.Password = UserIdentity.PassWordEncode(password);
            }
            UCF.emailAddress = email;
            UCF.IsLockedOut = false;//不锁定
            UCF.IsApproved = isApproved; //是否注册时激活用户
            UCF.LastActivityDate = DateTime.Now;
            UCF.NiName = string.IsNullOrEmpty(UserNiName) ? iNiName : UserNiName;
            UCF.CreateDate = DateTime.Now;
            UCF.IP = IP;
            UCF.RegRemark = RegRemark;
            UCF.GroupID = RoleID;// EbSite.BLL.User.UserGroupProfile.GetRoleIDByUserName(sUserG);
            int iNewUserID = UCF.Add();


            //杨欢乐2011-12-09 22：50修改 原因 以前先添加 管理员表 再添加用户表 两个都是自动增长id.这样用户ID不一致。
            //如果创建的是管理员,还要写入与管理员相关的表
            if (IsManager)
            {
                AdminUser userAdmin = new AdminUser();
                userAdmin.UserName = username;
                userAdmin.UserID = iNewUserID;//杨欢乐添加
                userAdmin.Create();
            }


            if (iNewUserID > 0)
            {
                //#region 邀请注册相关处理
                ////如果邀请人的ID大于0,将进入积分等相关处理
                //if (YQUserID > 0)
                //{
                //    EbSite.Base.EntityAPI.MembershipUserEb umd = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(YQUserID);
                //    if (!umd.IsHaveAvatar)
                //    {
                //        //给邀请人加积分 要获得积分
                //        int score = int.Parse(ConfigsControl.Instance.InviteRegInCredit.ToString());
                //        umd.Credits += score;
                //        EbSite.BLL.User.MembershipUserEb.Instance.Update(umd);

                //    }
                //}
                //#endregion


                #region 发送激活信
                if (Base.Configs.UserSetConfigs.ConfigsControl.Instance.AllowUserType == 2)
                {

                    string sWebName = Base.Host.Instance.MainSite.SiteName;
                    string sWebUrl = Base.Configs.SysConfigs.ConfigsControl.Instance.DomainName;
                    string iisPath = Base.Configs.SysConfigs.ConfigsControl.Instance.IISPath;
                    string ActivateCorde = GetActivateEncode(iNewUserID.ToString(), UCF.CreateDate.ToString(), YQUserID, RoleID);

                    string sContent = string.Format("感谢您加入[{0}],请在24小时内点击此连接来激活您的帐号 <a href='{1}{2}activate.aspx?act={3}'>{1}{2}activate.aspx?act={3}</a>！",
                        sWebName, sWebUrl, iisPath, ActivateCorde
                        );
                    EmailBLL.SendEmail(email.Trim(), "请激活您的帐号", sContent);
                }
                #endregion

                //else if() //如果手机激活，发送激活码到手机
                //{

                //}

                //关联一个默认会员组 
                //2014-3-19 YHL 一个用户 现只属于一个组 
                //if (!string.IsNullOrEmpty(sUserG))
                //{
                //    Roles.AddUserToRole(username, sUserG);
                //}

                ms = RegStatus.注册成功;
                if (!IsHt)
                {

                    UserActivatedEventArgs Args = new UserActivatedEventArgs(iNewUserID, UCF.UserName, UCF.emailAddress, YQUserID, UCF.Password, UCF.GroupID);
                    if (isApproved) //自动激时激活触发事件
                    {
                        Base.EBSiteEvents.OnUserActivated(UCF, Args);

                    }
                    Base.EBSiteEvents.OnUserUserReged(UCF, Args);




                    #region 获取注册成本并且在自动激活的情况下的定向地址

                    if (string.IsNullOrEmpty(Args.ReturnUrl))
                    {

                        if (Base.Configs.UserSetConfigs.ConfigsControl.Instance.AllowUserType == 0)
                        {

                            //Host.Instance.InsertLog("测试", "在1这里!");
                            RetunUrl = GetActivatedReturnUrl(RoleID, FromUrl);

                            //Host.Instance.InsertLog("测试", "在4这里!");
                        }
                        else if (Base.Configs.UserSetConfigs.ConfigsControl.Instance.AllowUserType == 1) //管理员激活
                        {

                            RetunUrl = Host.Instance.GetTipsUrl(4);
                            //Response.Redirect(GetTipsUrl(4));
                        }
                        else if (Base.Configs.UserSetConfigs.ConfigsControl.Instance.AllowUserType == 2) //email激活
                        {

                            RetunUrl = Host.Instance.GetTipsUrl(5);
                            //Response.Redirect(GetTipsUrl(5));
                        }
                    }
                    else
                    {

                        RetunUrl = Args.ReturnUrl;
                    }
                    #endregion
                }

            }
            else
            {
                ms = RegStatus.注册失败;
            }


            return iNewUserID;

        }

        public string GetActivatedReturnUrl(int GroupId, string FromUrl)
        {
            string RetunUrl = string.Empty;
            ////注册成功后的定向
            //if (GroupId > 0) //指定会员组d
            //{

            //    RetunUrl = BLL.User.UserGroupProfile.GroupShortByUserID(GroupId).ManageIndex;

            //}
            //else //获取默认会员组
            //{
            //    RetunUrl = Base.PageLink.GetBaseLinks.GetDefault.UccIndexRw;
            //    //RetunUrl = BLL.User.UserGroupProfile.GetUserGroupProfile(Base.Configs.UserSetConfigs.ConfigsControl.Instance.UserGroupID).ManageIndex;

            //}



            //if (string.IsNullOrEmpty(RetunUrl))
            //{
            //    //EbSite.Base.AppStartInit.LoginToReurl();
            //    if (!string.IsNullOrEmpty(FromUrl))
            //    {
            //        RetunUrl = FromUrl;
            //    }
            //    else
            //    {
            //        RetunUrl = Base.Host.Instance.UccUrl;
            //    }

            //}

            if (!string.IsNullOrEmpty(FromUrl))
            {
                RetunUrl = FromUrl;
            }
            else
            {
                RetunUrl = Base.Host.Instance.UccUrl;
            }
            return RetunUrl;
        }

        /// <summary>
        /// 获取今天注册会员数
        /// </summary>
        public int GetCountByToday
        {
            get
            {
                return Base.Host.Instance.EBMembershipInstance.User_GetCount("d");
            }

        }
        /// <summary>
        /// 获取本周注册会员数
        /// </summary>
        public int GetCountByWeek
        {
            get
            {
                return Base.Host.Instance.EBMembershipInstance.User_GetCount("w");
            }

        }
        /// <summary>
        /// 获取本月注册会员数
        /// </summary>
        public int GetCountByMonth
        {
            get
            {
                return Base.Host.Instance.EBMembershipInstance.User_GetCount("m");
            }

        }
        /// <summary>
        /// 获取本季注册会员数
        /// </summary>
        public int GetCountByQuarter
        {
            get
            {
                return Base.Host.Instance.EBMembershipInstance.User_GetCount("q");
            }

        }
        /// <summary>
        /// 获取本年注册会员数
        /// </summary>
        public int GetCountByYear
        {
            get
            {
                return Base.Host.Instance.EBMembershipInstance.User_GetCount("y");
            }

        }
        /// <summary>
        /// 获取本年注册会员数
        /// </summary>
        public int GetCountAll
        {
            get
            {
                return Base.Host.Instance.EBMembershipInstance.User_GetCount("");
            }

        }


        //后台管理会员-更改用户组
        public bool UpdateUserGroupId(string UserName, int GroupId)
        {
            return EbSite.Base.Host.Instance.EBMembershipInstance.UpdateUserGroupId(UserName, GroupId);
        }
        //后台管理会员-得到用户组Id
        public int GetUserGroupId(string UserName)
        {
            return EbSite.Base.Host.Instance.EBMembershipInstance.GetUserGroupId(UserName);
        }
    }
}
