using System;
using System.Data;
using System.Data.SqlClient;


namespace EbSite.Data.Interface
{

    public partial interface IDataProviderCms
    {

        /// <summary>
        /// 创建权限
        /// </summaryAdminUser_CreatePermission
        /// <param name="categoryID">权限分类ID</param>
        /// <param name="description">权限名称</param>
        /// <returns></returns>
        void AdminUser_CreatePermission(int categoryID, string description);

        /// <summary>
        /// 删除权限-同时删除关联角色权限
        /// </summary>
        /// <param name="id">权限ID</param>
        /// <returns></returns>
        bool AdminUser_DeletePermission(int id);

        /// <summary>
        /// 获取不属于此角色对应的权限与其分类 dataset里两个表
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        DataSet AdminUser_GetNoPermissionList(int roleId);

        /// <summary>
        /// 获取所有权限，包括权限分类
        /// </summary>
        /// <returns></returns>
        DataSet AdminUser_GetPermissionList();

        /// <summary>
        /// 获取角色对应的权限与其分类 dataset里两个表 
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        DataSet AdminUser_GetPermissionList(int roleId);

        DataRow AdminUser_RetrievePermission(int permissionId);
        bool AdminUser_UpdatePermission(int PermissionID, int ParentID, string description);
    }
}

