using EbSite.Entity;

namespace EbSite.Data.User.Interface
{
    public partial interface IDataProviderUser
    {
        /// <summary>
        /// 当用户登录后，写入用户的cookie
        void WriteUserIdentity(string UserID, string UserName, string UserNiName, string UserPass, int ExpiresTime,string RoleID);
        /// <summary>
        /// 用户退出后，清除用户已经登录的coolie
        /// </summary>
        void SignOutUser();
        /// <summary>
        /// 获取当前登录用户的用户帐号
        /// </summary>
        /// <returns></returns>
        string GetUserName();
        /// <summary>
        /// 获取当前登录用户的昵称
        /// </summary>
        string GetUserNiName();

        /// <summary>
        /// 获取当前登录的用户密码(已解密),未登录为空
        /// </summary>
         string GetUserPass();

         /// <summary>
         /// 获取当前登录的用户的id,未登录等于-1
         /// </summary>
         int GetUserId();
          int GetRoleID();
        /// <summary>
        /// 实现密码的加密办法
        /// </summary>
        /// <returns></returns>
         string PassWordEncode(string Pass);
        ///// <summary>
        ///// 获取管理员ID
        ///// </summary>
        ///// <returns></returns>
        //int GetManagerID();


    }
}