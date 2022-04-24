using System;
using System.Collections;
using System.Collections.Generic;
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
using EbSite.Core;
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

        /// <summary>
        /// 获取一个profile用户ID
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="isAuthenticated">是否认证</param>
        /// <param name="ignoreAuthenticationType"></param>
        /// <param name="appName"></param>
        /// <returns></returns>
        public int GetProfileUniqueID(string userName, bool isAuthenticated, bool ignoreAuthenticationType, string appName)
        {
            return EbSite.BLL.User.ProfileProvider.GetUniqueID(userName, isAuthenticated, ignoreAuthenticationType, appName);
        }
        /// <summary>
        /// 创建一个profile用户ID
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="isAuthenticated">是否认证</param>
        /// <param name="appName">系统名称</param>
        /// <returns></returns>
        public int CreateProfileForUser(string userName, bool isAuthenticated, string appName)
        {
            return EbSite.BLL.User.ProfileProvider.CreateProfileForUser(userName, isAuthenticated, appName);
        }
        /// <summary>
        /// 获取profile数据集合
        /// </summary>
        /// <param name="authenticationOption"></param>
        /// <param name="usernameToMatch"></param>
        /// <param name="userInactiveSinceDate"></param>
        /// <param name="appName"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public IList<CustomProfileInfo> GetProfileInfo(int authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, string appName, out int totalRecords)
        {
            return EbSite.BLL.User.ProfileProvider.GetProfileInfo(authenticationOption, usernameToMatch, userInactiveSinceDate, appName, out  totalRecords);
        }
        /// <summary>
        /// 删除一个profile
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="appName"></param>
        /// <returns></returns>
        public bool DeleteProfile(int iUid)
        {
            return EbSite.BLL.User.ProfileProvider.DeleteProfile(iUid);
        }
        public IList<string> GetInactiveProfiles(int authenticationOption, DateTime userInactiveSinceDate, string appName)
        {
            return EbSite.BLL.User.ProfileProvider.GetInactiveProfiles(authenticationOption, userInactiveSinceDate, appName);
        }

        public void UpdateActivityDates(string userName, bool activityOnly, string appName)
        {
            EbSite.BLL.User.ProfileProvider.UpdateActivityDates(userName, activityOnly, appName);
        }

    }
}
