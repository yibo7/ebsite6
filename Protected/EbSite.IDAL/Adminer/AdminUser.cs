
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EbSite.Data.Interface
{
    public partial interface IDataProviderCms
    {

        /// <summary>
        /// 添加用户到对应的用户组(角色)
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">用户组ID</param>
        /// <returns></returns>
        bool AdminUser_AddRoleAdmin(int userId, int roleId);

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userName">用户名称</param>
         /// <param name="userID">用户ID 是EB_users 的用户ID</param> //杨欢乐添加
        /// <returns></returns>
        int AdminUser_CreateAdmin(string userName,int userID);

        bool AdminUser_DeleteAdmin(int userID);

        /// <summary>
        /// 获取用户-根据真实姓名
        /// </summary>
        /// <param name="key">真实姓名</param>
        /// <returns></returns>
        List<EbSite.BLL.AdminUser> AdminUser_GetAllUsersAdmin(string key);

        /// <summary>
        /// 通过 角色 获得用户列表
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        List<EbSite.BLL.AdminUser> AdminUser_GetAllUsersAdmin(int RoleID);
        /// <summary>
        /// 获取当前用户的权限名称列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        ArrayList AdminUser_GetEffectivePermissionListAdmin(int userID);

        /// <summary>
        /// 获取用户的权限ID列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        ArrayList AdminUser_GetEffectivePermissionListIDAdmin(int userID);

        //IDataReader AdminUser_GetUserListAdmin();
        List<EbSite.Base.EntityAPI.AdminRoleInfo> AdminUser_GetUserRolesAdmin(int userID);

        //IDataReader AdminUser_GetUsersAdmin(string DepartmentID);

        /// <summary>
        /// 查房某个用户类型下的用户
        /// </summary>
        /// <param name="usertype">用户类型</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        //IDataReader AdminUser_GetUsersByTypeAdmin(string usertype, string key);

        /// <summary>
        /// 是否存在某个用户名称的用户
        /// </summary>
        /// <param name="userName">用户注册名</param>
        /// <returns></returns>
        bool AdminUser_HasUserAdmin(string userName);

        /// <summary>
        /// 除去某个用户所属的用户组
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">用户组ID</param>
        /// <returns></returns>
        bool AdminUser_RemoveRoleAdmin(int userId, int roleId);

        /// <summary>
        /// 获取某个用户记录-根据用户ID
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        DataRow AdminUser_RetrieveAdmin(int userID);

        /// <summary>
        /// 获取用户注册名称，查找用户记录
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <returns></returns>
        DataRow AdminUser_RetrieveAdmin(string userName);

        /// <summary>
        /// 根据用户账号更新某个用户的密码
        /// </summary>
        /// <param name="UserName">用户账号</param>
        /// <param name="encPassword">密码</param>
        /// <returns></returns>
        //bool AdminUser_SetPasswordAdmin(string UserName, byte[] encPassword);

        /// <summary>
        /// 验证某个用户输入的密码是否正确
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="encPassword">加密后的密码</param>
        /// <returns></returns>
        //int AdminUser_TestPasswordAdmin(int userID, byte[] encPassword);

        bool AdminUser_UpdateAdmin(int userID, string userName, bool isLock, DateTime LastLoginTime, int CurrentSiteID);
        int AdminUser_ValidateLoginAdmin(string userName);
        /// <summary>
        /// 获取某个用户的管理员ID，不是管理员返回0
        /// </summary>
        /// <param name="sUserName"></param>
        /// <returns></returns>
       int AdminUser_GetManagerID(string sUserName);

        int AdminUser_GetCurrentSiteID(string userName);
        int AdminUser_GetCurrentSiteID(int UserID);
    }
}

