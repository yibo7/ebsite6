using System;
using System.Collections.Generic;
using System.Data;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
    public class AccountsTool
    {
        
        ///// <summary>
        ///// 获取所有权限分类列表
        ///// </summary>
        ///// <returns></returns>
        //public static DataSet GetAllCategories()
        //{
        //    return DbProviderCms.GetInstance().AdminUser_GetCategoryList();
        //}
        
        ///// <summary>
        ///// 获取权限-根据权限分类ID
        ///// </summary>
        ///// <param name="categoryID">权限分类ID</param>
        ///// <returns></returns>
        //public static DataSet GetPermissionsByCategory(int categoryID)
        //{
        //    return DbProviderCms.GetInstance().AdminUser_GetPermissionsInCategory(categoryID);
        //}
        /// <summary>
        /// 获取所有角色列表
        /// </summary>
        /// <returns></returns>
        public static DataSet GetRoleList()
        {
            //XsAccounts.Data.Role role = new XsAccounts.Data.Role(PubConstant.ConnectionString);
            return DbProviderCms.GetInstance().AdminUser_GetRoleList();
        }
        
    }
}

