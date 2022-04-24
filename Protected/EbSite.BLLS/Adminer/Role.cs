
using System;
using System.Collections.Generic;
using System.Data;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
    /// <summary>
    /// 用户组（角色）管理类
    /// </summary>
    public class AdminRole
    {
        private string description;
        private DataSet nopermissions;
        private DataSet permissions;
        private int roleId;
        const double cachetime = 60.0;
        private const string CacheAdminRole = "adminrole"; //private static readonly string[] MasterCacheKeyArray = { "AdminRole" };
        //private static CacheManager bllCache;
        public AdminRole()
        {
        }
        static public void ClearCache()
        {
            //if (!Equals(bllCache,null))
            //    bllCache.InvalidateCache();
            Host.CacheApp.InvalidateCache(CacheAdminRole);
        }
        public static AdminRole AdminRoleInstace(int iRoleID)
        {
            

            string CacheKey = string.Concat("AdminRoleInstace-", iRoleID);
            AdminRole model = Base.Host.CacheRawApp.GetCacheItem<AdminRole>(CacheKey,"ar");// as AdminRole;
            if (Equals(model, null))
            {
                model = new AdminRole(iRoleID);
                Base.Host.CacheRawApp.AddCacheItem(CacheKey, model,5,ETimeSpanModel.XS,"ar");

            }
            return model;

        }
        /// <summary>
        /// 构造函数-初始化当前用户组
        /// </summary>
        /// <param name="currentRoleId">当前用户组ID</param>
        public AdminRole(int currentRoleId)
        {
            //bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
            //初始角色
            DataRow row = DbProviderCms.GetInstance().AdminUser_RetrieveRole(currentRoleId);
            this.roleId = currentRoleId;
            this.description = (string) row["Description"];

          //  Permission permission = new Permission(PubConstant.ConnectionString);
            //获取角色对应的权限与其分类 dataset里两个表 
            this.permissions = DbProviderCms.GetInstance().AdminUser_GetPermissionList(currentRoleId);
            //获取不属于此角色对应的权限与其分类 dataset里两个表
            this.nopermissions = DbProviderCms.GetInstance().AdminUser_GetNoPermissionList(currentRoleId);


        }
        /// <summary>
        /// 给角色添加对应的权限
        /// </summary>
        /// <param name="permissionId">权限ID</param>
        public void AddPermission(int permissionId)
        {
            Host.CacheApp.InvalidateCache(CacheAdminRole); //bllCache.InvalidateCache();
            DbProviderCms.GetInstance().AdminUser_AddPermission(this.roleId, permissionId);
        }
        /// <summary>
        /// 全部清除此角色的权限
        /// </summary>
        //public void ClearPermissions()
        //{
        //    DbProviderCms.GetInstance().AdminUser_ClearPermissions(this.roleId);
        //}
        /// <summary>
        /// 创建用户组(角色)
        /// </summary>
        /// <returns></returns>
        public int Create()
        {
            this.roleId = DbProviderCms.GetInstance().AdminUser_CreateRole(this.description);
            Host.CacheApp.InvalidateCache(CacheAdminRole);// bllCache.InvalidateCache();
            return this.roleId;
        }
        /// <summary>
        /// 删除用户组(角色)
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
           // XsAccounts.Data.Role role = new XsAccounts.Data.Role(PubConstant.ConnectionString);
            Host.CacheApp.InvalidateCache(CacheAdminRole);// bllCache.InvalidateCache();
            return DbProviderCms.GetInstance().AdminUser_DeleteRole(this.roleId);
        }
        /// <summary>
        /// 移除此用户组对应的权限
        /// </summary>
        /// <param name="permissionId">权限ID</param>
        public void RemovePermission(int permissionId)
        {
            DbProviderCms.GetInstance().AdminUser_RemovePermission(this.roleId, permissionId);
            Host.CacheApp.InvalidateCache(CacheAdminRole); //bllCache.InvalidateCache();
        }
        /// <summary>
        /// 更新用户组名称
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            Host.CacheApp.InvalidateCache(CacheAdminRole);// bllCache.InvalidateCache();
            return DbProviderCms.GetInstance().AdminUser_UpdateRole(this.roleId, this.description);
        }
        /// <summary>
        /// 用户组名称
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        /// <summary>
        /// 不属于此用户组的权限列表
        /// </summary>
        public DataSet NoPermissions
        {
            get
            {
                return this.nopermissions;
            }
        }
        /// <summary>
        /// 属于此用户组的权限列表
        /// </summary>
        public DataSet Permissions
        {
            get
            {
                return this.permissions;
            }
        }
        public List<Permissions>  PermissionsList
        {
            get
            {
                List<Permissions> lst = new List<Permissions>();
                foreach (DataRow dr in Permissions.Tables[0].Rows)
                {
                    Permissions md = new Permissions();
                    md.PermissionID = int.Parse(dr["PermissionID"].ToString());
                    md.ParentID = int.Parse(dr["CategoryID"].ToString());
                    md.PermissionName = dr["Description"].ToString();
                    lst.Add(md);
                }
                return lst;
            }
        }
        public List<string> PermissionsIDList
        {
            get
            {

                string CacheKey = "PermissionsIDList" + this.roleId;
                List<string> lst = Host.CacheApp.GetCacheItem<List<string>>(CacheKey, CacheAdminRole);// bllCache.GetCacheItem(CacheKey) as List<string>;
                if (lst == null)
                {
                    lst = new List<string>();
                    foreach (DataRow dr in Permissions.Tables[0].Rows)
                    {

                        lst.Add(dr["PermissionID"].ToString());
                    }
                    Host.CacheApp.AddCacheItem(CacheKey, lst, cachetime, ETimeSpanModel.M, CacheAdminRole);//bllCache.AddCacheItem(CacheKey, lst);
                }

                return lst;

            }
        }
        /// <summary>
        /// 用户组ID
        /// </summary>
        public int RoleID
        {
            get
            {
                return this.roleId;
            }
        }
    }
}

