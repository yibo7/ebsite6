
using System;
using System.Collections.Generic;
using System.Data;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
   
    public sealed class AdminUser
    {
        private int userID;
        private string userName;
        private bool isLock = false;
        private DateTime lastLoginTime = DateTime.Now;
        private int _CurrentSiteID = 1;
        public int CurrentSiteID
        {
            get
            {
                return this._CurrentSiteID;
            }
            set
            {
                this._CurrentSiteID = value;
            }
        }
        public DateTime LastLoginTime
        {
            get
            {
                return this.lastLoginTime;
            }
            set
            {
                this.lastLoginTime = value;
            }
        }

        public bool IsLock
        {
            get
            {
                return this.isLock;
            }
            set
            {
                this.isLock = value;
            }
        }

        public int UserID
        {
            get
            {
                return this.userID;
            }
            set
            {
                this.userID = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        public AdminUser()
        {
            //this.departmentID = "-1";
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="existingPrincipal">登录后得到的实例</param>
        //public AdminUser(AccountsPrincipal existingPrincipal)
        //{
            
        //    this.userID = ((SiteIdentity) existingPrincipal.Identity).UserID;
        //    this.LoadFromID();
        //}

        public AdminUser(int existingUserID)
        {
            
            this.userID = existingUserID;
            this.LoadFromID();
        }

        public AdminUser(string UserName)
        {
            //this.departmentID = "-1";
            //获取用户注册名称，查找用户记录
            DataRow row = DbProviderCms.GetInstance().AdminUser_RetrieveAdmin(UserName);
            if (row != null)
            {
                this.userID = (int) row["UserID"];
                this.userName = (string)row["UserName"];

                this.IsLock = (bool)Core.Utils.ConvertBool(row["IsLock"].ToString());
                this.LastLoginTime = (DateTime)row["LastLoginTime"];
                this.CurrentSiteID = (int)row["CurrentSiteID"];
            }
        }
        /// <summary>
        /// 添加用户到对应的用户组(角色)
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool AddToRole(int roleId)
        {
            return DbProviderCms.GetInstance().AdminUser_AddRoleAdmin(this.userID, roleId);
        }
        /// <summary>
        /// 添加一个管理员
        /// </summary>
        /// <returns></returns>
        public int Create()
        {
            this.userID = DbProviderCms.GetInstance().AdminUser_CreateAdmin(this.userName,this.userID);
            return this.userID;
        }
        /// <summary>
        /// 删除一个用户
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            //应该还同时移除与此管理员相关的角色
            return DbProviderCms.GetInstance().AdminUser_DeleteAdmin(this.userID);
        }
        /// <summary>
        /// 获取用户-根据真实姓名
        /// </summary>
        /// <param name="key">真实姓名</param>
        /// <returns></returns>
        //public IDataReader GetAllUsers(string key)
        //{
        //    return DbProviderCms.GetInstance().AdminUser_GetAllUsersAdmin(key);
        //}
        public List<EbSite.BLL.AdminUser> GetAllUsers(string key)
        {
            return DbProviderCms.GetInstance().AdminUser_GetAllUsersAdmin(key);
        }
        public List<EbSite.BLL.AdminUser> GetAllUsers(int RoleID)
        {
            return DbProviderCms.GetInstance().AdminUser_GetAllUsersAdmin(RoleID);
        }

        /// <summary>
        /// 获取用户-根据真实姓名
        /// </summary>
        /// <param name="key">真实姓名</param>
        /// <returns></returns>
        static public int GetManagerID(string sUserName)
        {
            return DbProviderCms.GetInstance().AdminUser_GetManagerID(sUserName);
        }
        /// <summary>
        /// 获取某个部门的所有用户
        /// </summary>
        /// <param name="DepartmentID">部门ID</param>
        /// <returns></returns>
        //public IDataReader GetUsers(string DepartmentID)
        //{
        //    return DbProviderCms.GetInstance().AdminUser_GetUsersAdmin(DepartmentID);
        //}
        /// <summary>
        /// 查房某个用户类型下的用户
        /// </summary>
        /// <param name="usertype">用户类型</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        //public IDataReader GetUsersByType(string usertype, string key)
        //{
        //    //XsAccounts.Data.User user = new XsAccounts.Data.User(PubConstant.ConnectionString);
        //    return DbProviderCms.GetInstance().AdminUser_GetUsersByTypeAdmin(usertype, key);
        //}
        /// <summary>
        /// 是否存在某个用户名称的用户
        /// </summary>
        /// <param name="userName">用户注册账号</param>
        /// <returns></returns>
        public static bool HasUser(string userName)
        {
            //XsAccounts.Data.User user = new XsAccounts.Data.User(PubConstant.ConnectionString);
            return DbProviderCms.GetInstance().AdminUser_HasUserAdmin(userName);
        }
        public static int GetCurrentSiteID(string userName)
        {
            return DbProviderCms.GetInstance().AdminUser_GetCurrentSiteID(userName);
        }
        public static int GetCurrentSiteID(int UserID)
        {
            return DbProviderCms.GetInstance().AdminUser_GetCurrentSiteID(UserID);
        }
        /// <summary>
        /// 获取某个用户记录-根据用户ID
        /// </summary>
        private void LoadFromID()
        {
            DataRow row = DbProviderCms.GetInstance().AdminUser_RetrieveAdmin(this.userID);
            if (row != null)
            {
                //this.userName = (string) row["UserName"];
                //this.IsLock = (bool)row["IsLock"];
                //this.LastLoginTime = (DateTime) row["LastLoginTime"];   
                this.userID = (int)row["UserID"];
                this.userName = (string)row["UserName"];
              
                this.IsLock = (bool)Core.Utils.ConvertBool(row["IsLock"].ToString());
                this.LastLoginTime = (DateTime)row["LastLoginTime"];
                this.CurrentSiteID = (int)row["CurrentSiteID"];
            }
        }
        /// <summary>
        /// 除去某个用户所属的用户组
        /// </summary>
        /// <param name="roleId">用户组ID</param>
        /// <returns></returns>
        public bool RemoveRole(int roleId)
        {
            //XsAccounts.Data.User user = new XsAccounts.Data.User(PubConstant.ConnectionString);
            return DbProviderCms.GetInstance().AdminUser_RemoveRoleAdmin(this.userID, roleId);
        }
        /// <summary>
        /// 根据用户账号更新某个用户的密码
        /// </summary>
        /// <param name="UserName">用户账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        //public bool SetPassword(string UserName, string password)
        //{
        //    byte[] encPassword = AccountsPrincipal.EncryptPassword(password);

        //    return DbProviderCms.GetInstance().AdminUser_SetPasswordAdmin(UserName, encPassword);
        //}
        /// <summary>
        /// 更新用户资料
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {

            return DbProviderCms.GetInstance().AdminUser_UpdateAdmin(this.userID, this.userName, this.IsLock, this.LastLoginTime, this.CurrentSiteID);
        }

    }
}

