using System.Data;
using System.Data.SqlClient;


namespace EbSite.Data.Interface
{



    public partial interface IDataProviderCms
    {

        /// <summary>
        /// 给角色添加对应的权限
        /// </summary>
        /// <param name="roleId">用户组ID</param>
        /// <param name="permissionId">权限ID</param>
        void AdminUser_AddPermission(int roleId, int permissionId);

        /// <summary>
        /// 全部清除此角色的权限
        /// </summary>
        /// <param name="roleId">角色ID</param>
        //void AdminUser_ClearPermissions(int roleId);

        /// <summary>
        /// 创建用户组(角色)
        /// </summary>
        /// <param name="description">用户组(角色)名称</param>
        /// <returns></returns>
        int AdminUser_CreateRole(string description);

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="roleId">用户组ID</param>
        /// <returns></returns>
        bool AdminUser_DeleteRole(int roleId);

        DataSet AdminUser_GetRoleList();

        /// <summary>
        /// 移除此用户组对应的权限
        /// </summary>
        /// <param name="roleId">用户组ID</param>
        /// <param name="permissionId">权限ID</param>
        void AdminUser_RemovePermission(int roleId, int permissionId);

        DataRow AdminUser_RetrieveRole(int roleId);

        /// <summary>
        /// 更新用户组名称
        /// </summary>
        /// <param name="roleId">用户组ID</param>
        /// <param name="description">用户组名称</param>
        /// <returns></returns>
        bool AdminUser_UpdateRole(int roleId, string description);
    }
}

