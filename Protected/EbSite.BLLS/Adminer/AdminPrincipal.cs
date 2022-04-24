
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using EbSite.BLL.User;
using EbSite.Base;
using EbSite.Base.Static;
using EbSite.Core;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
    
    /// <summary>
    /// 管理员登录后得到此实例(identity 包括用户精确必要信息 )
    /// </summary>
    public class AdminPrincipal : EBPrincipal
    {

        const double cachetime = 1000;//1000秒
        private const string CacheAdminPrintcipal= "aacounts"; //private static readonly string[] MasterCacheKeyArray = { "AdminAccounts" };
        //private static CacheManager bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);

        //protected IIdentity identity;
        protected ArrayList permissionList;
        protected ArrayList permissionListid;
        protected List<string> roleList = new List<string>();
        private List<int> roleIDs = new List<int>();
        protected List<EbSite.Base.EntityAPI.AdminRoleInfo> roleListMds;
        public AdminPrincipal(int userID)
            : base(userID)
        {
           
            this.permissionList = DbProviderCms.GetInstance().AdminUser_GetEffectivePermissionListAdmin(userID);
            this.permissionListid = DbProviderCms.GetInstance().AdminUser_GetEffectivePermissionListIDAdmin(userID);
            this.roleListMds = DbProviderCms.GetInstance().AdminUser_GetUserRolesAdmin(userID);
            
            foreach (EbSite.Base.EntityAPI.AdminRoleInfo role in this.roleListMds)
            {
                roleList.Add(role.RoleName);
                roleIDs.Add(role.id);
            }
            CurrentSiteID = AdminUser.GetCurrentSiteID(userID);
        }

        public AdminPrincipal(string userName)
            : base(userName)
        {
            this.identity = new SiteIdentity(userName);
            this.permissionList = DbProviderCms.GetInstance().AdminUser_GetEffectivePermissionListAdmin(((SiteIdentity)this.identity).UserID);
            this.permissionListid = DbProviderCms.GetInstance().AdminUser_GetEffectivePermissionListIDAdmin(((SiteIdentity)this.identity).UserID);
            this.roleListMds = DbProviderCms.GetInstance().AdminUser_GetUserRolesAdmin(((SiteIdentity)this.identity).UserID);
           
            foreach (EbSite.Base.EntityAPI.AdminRoleInfo role in this.roleListMds)
            {
                roleList.Add(role.RoleName);
                roleIDs.Add(role.id);
            }
            CurrentSiteID = AdminUser.GetCurrentSiteID(userName);
        }



        /// <summary>
        /// 返回加密后的密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static byte[] EncryptPassword(string password)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(bytes);
        }
        /// <summary>
        /// 判断是否包含某权限名称的权限
        /// </summary>
        /// <param name="permission">权限名称</param>
        /// <returns></returns>
        public bool HasPermission(string permission)
        {
            return this.permissionList.Contains(permission);
        }
        /// <summary>
        /// 判断是否包含某权限ID的权限
        /// </summary>
        /// <param name="permissionid">权限ID</param>
        /// <returns></returns>
        public bool HasPermissionID(int permissionid)
        {
            return this.permissionListid.Contains(permissionid);
        }

        public static bool IsHaveLimit(string LimitID, string UserName)
        {
            
            AdminPrincipal user = ValidateLogin(UserName);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(LimitID) && user.HasPermissionID(int.Parse(LimitID)))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 判断当前用户是否存在于某用户组(角色)--名称
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
       override public bool IsInRole(string role)
        {
            return this.roleList.Contains(role);
        }
        /// <summary>
        /// 用户登录验证,使用频率多，做缓存
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="password">用户密码</param>
        /// <returns></returns>
       public static AdminPrincipal ValidateLogin(string userName)
        {


            string CacheKey = string.Concat("Validate-", userName);
            AdminPrincipal model = Host.CacheRawApp.GetCacheItem<AdminPrincipal>(CacheKey, CacheAdminPrintcipal);//bllCache.GetCacheItem(CacheKey) as AdminPrincipal;
                if (Equals(model,null))
                {
                    int userID = DbProviderCms.GetInstance().AdminUser_ValidateLoginAdmin(userName);
                    if (userID > 0)
                    {
                        model = new AdminPrincipal(userID);
                        Host.CacheRawApp.AddCacheItem(CacheKey, model, cachetime, ETimeSpanModel.M, CacheAdminPrintcipal); //bllCache.AddCacheItem(CacheKey, model);
                    }
                   
                }
                return model;
            
        }

        /// <summary>
        /// 当前用户身份标识
        /// </summary>
      override  public IIdentity Identity
        {
            get
            {
                return this.identity;
            }
            set
            {
                this.identity = value;
            }
        }
        /// <summary>
        /// 属于当前用户权限名称列表
        /// </summary>
        public ArrayList Permissions
        {
            get
            {
                return this.permissionList;
            }
        }
        /// <summary>
        /// 属于当前用户权限ID列表
        /// </summary>
        public ArrayList PermissionsID
        {
            get
            {
                return this.permissionListid;
            }
        }
        /// <summary>
        /// 属于当前用户角色名称列表 角色ID，用字符串保存
        /// </summary>
        public List<string> Roles
        {
            get
            {
                return this.roleList;
            }
        }
        public List<int> RoleIDs
        {
            get
            {
                return this.roleIDs;
            }
        }
        public int _CurrentSiteID = 1;
        public int CurrentSiteID
        {
            get
            {
                return _CurrentSiteID;
            }
            set
            {
                _CurrentSiteID = value;
            }
        }
        
    }
}

