using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Text;
using System.Web.Security;
using EbSite.Data.Interface;
using EbSite.Base.DataProfile;
using EbSite.Data.User.Interface;

namespace EbSite.Data.MySql
{
    /// <summary>
    /// Generic Db Role Provider 已经放弃使用
    /// </summary>
    public class DbRoleProvider : RoleProvider
    {
        private string tablePrefix;
        private string applicationName;


        /// <summary>
        /// Initializes the provider
        /// </summary>
        /// <param name="name">Configuration name</param>
        /// <param name="config">Configuration settings</param>
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            if (String.IsNullOrEmpty(name))
            {
                name = "DbMembershipProvider";
            }

            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Generic Database Membership Provider");
            }

            base.Initialize(name, config);

            if (config["connectionStringName"] == null)
            {
                
                // default to BlogEngine
                //connString = EbSite.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms;
                //provider = DbProviderFactories.GetFactory("System.Data.SqlClient");
            }
            else
            {
                

                
                //connStringName = config["connectionStringName"];
                config.Remove("connectionStringName");

                //connString = ConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
                //string providerName = ConfigurationManager.ConnectionStrings[connStringName].ProviderName;
                // provider = DbProviderFactories.GetFactory(providerName);
            }
            

            if (config["tablePrefix"] == null)
            {
                // default
                config["tablePrefix"] = Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;
            }
            tablePrefix = config["tablePrefix"];
            config.Remove("tablePrefix");

            if (config["parmPrefix"] == null)
            {
                // default
                config["parmPrefix"] = "?";
            }
            //parmPrefix = config["parmPrefix"];
            config.Remove("parmPrefix");

            if (config["applicationName"] == null)
            {
                // default to BlogEngine
                config["applicationName"] = "SwordWeb";
            }
            applicationName = config["applicationName"];
            config.Remove("applicationName");

            // Throw an exception if unrecognized attributes remain
            if (config.Count > 0)
            {
                string attr = config.GetKey(0);
                if (!String.IsNullOrEmpty(attr))
                    throw new ProviderException("Unrecognized attribute: " + attr);
            }
        }
        private int GetRoleId(string roleName)
        {
            
            string sql = string.Format("SELECT RoleId FROM {0}roles WHERE Role = ?RoleName", tablePrefix);
            MySqlParameter[] parameters = {
            new MySqlParameter("?RoleName", MySqlDbType.VarChar,100)};

            parameters[0].Value = roleName;

            object result =  DbHelperCms.Instance.ExecuteScalar(CommandType.Text, sql, parameters);

            if(!Equals(result,null))
            {
                return (int) result;
            }
            return -1;

        }

        /// <summary>
        /// Check to see if user is in a role
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override bool IsUserInRole(string username, string roleName)
        {
            //bool roleFound = false;


            //int iUserID = Base.Host.Instance.EBMembershipInstance.GetUserIDByUserName(username);

            //int iRoleID = GetRoleId(roleName);

            //string sql = string.Format("SELECT UserId FROM {0}UserRoles WHERE UserId = ?UserId AND RoleId = ?RoleId", tablePrefix);

                    
            //MySqlParameter[] parameters = {
            //new MySqlParameter("?UserId", MySqlDbType.Int32 ),
            //new MySqlParameter("?RoleId", MySqlDbType.Int32 )};

            //parameters[0].Value = iUserID;

            //parameters[1].Value = iRoleID;
            ////object result = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql, parameters);
            ////if (result == null || !(result is int) || ((int)result) != iUserID)
            ////    return false;
            ////return true;

            //using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql, parameters))
            //{
            //    if (dataReader.Read())
            //    {
            //       //int tUserID =  dataReader.GetInt32(0);
            //        roleFound = true;

            //    }
            //}

            ////using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, sql, parameters))
            ////{
            ////    if (dataReader.Read())
            ////    {
            ////        roleFound = true;
                    
            ////    }
            ////}

            //return roleFound;
            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Return an array of roles that user is in
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public override string[] GetRolesForUser(string username)
        {
            int iGroupID = Base.Host.Instance.EBMembershipInstance.GetUserGroupId(username);

            List<string> roles = new List<string>();

            string sql = string.Format("SELECT GroupName FROM  {0}usergroupprofile r WHERE r.GroupID = {1} ", tablePrefix, iGroupID);


             using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql, null))
             {
                 while (dataReader.Read())
                 {
                     roles.Add(dataReader.GetString(0));
                 }
             }
           
            return roles.ToArray();


            //int iUserID = Base.Host.Instance.EBMembershipInstance.GetUserIDByUserName(username);

            //List<string> roles = new List<string>();

            //string sql = string.Format("SELECT Role FROM {0}UserRoles ur, {0}Roles r WHERE ur.UserId = ?UserId AND ur.RoleId = r.RoleId ORDER BY Role", tablePrefix);

            //MySqlParameter[] parameters = {
            //new MySqlParameter("?UserId", MySqlDbType.Int32 )};

            //parameters[0].Value = iUserID;

            //using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql, parameters))
            //{
            //    while (dataReader.Read())
            //    {
            //        roles.Add(dataReader.GetString(0));
            //    }
            //}
            //return roles.ToArray();
            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Adds a new role to the database
        /// </summary>
        /// <param name="roleName"></param>
        public override void CreateRole(string roleName)
        {
            //string sql = string.Format("INSERT INTO {0}Roles (role) VALUES (?role)", tablePrefix);

            // MySqlParameter[] parameters = {
            //new MySqlParameter("?role", MySqlDbType.VarChar,100)};

            //parameters[0].Value = roleName;

            //DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, sql, parameters);
           
        }

        /// <summary>
        /// Removes a role from database
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="throwOnPopulatedRole"></param>
        /// <returns></returns>
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            bool success = false;

            //string sql = string.Format("DELETE FROM {0}Roles WHERE Role = ?role", tablePrefix);

            //MySqlParameter[] parameters = {
            //new MySqlParameter("?role", MySqlDbType.VarChar,100)};

            //parameters[0].Value = roleName;

            //DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, sql, parameters);


            return success;
        }

        /// <summary>
        /// Checks to see if role exists
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override bool RoleExists(string roleName)
        {
            bool roleFound = false;

            //string sql = string.Format("SELECT roleID FROM {0}Roles WHERE role = ?role", tablePrefix);

            //MySqlParameter[] parameters = {
            //new MySqlParameter("?role", MySqlDbType.VarChar,100)};

            //parameters[0].Value = roleName;

            //using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql, parameters))
            //{
            //    if (dataReader.Read())
            //    {
            //        roleFound = true;
            //    }
            //}
            return roleFound;
        }

        /// <summary>
        /// Adds all users in user array to all roles in role array
        /// </summary>
        /// <param name="usernames"></param>
        /// <param name="roleNames"></param>
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            //foreach (string user in usernames)
            //{

            //    //string sql = string.Format("SELECT UserID FROM {0}Users WHERE UserName = ?user", Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefixUser);
            //    //MySqlParameter[] parameters = {
            //    //new MySqlParameter("?user", MySqlDbType.VarChar,100)};
            //    //parameters[0].Value = user;
            //    //object ouid = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sql, parameters);
            //    //if(Equals(ouid,null))continue;
            //    ////获取用户ID
            //    //int userID = Int32.Parse(ouid.ToString());

            //    int userID = Base.Host.Instance.EBMembershipInstance.GetUserIDByUserName(user);

            //    foreach (string role in roleNames)
            //    {

            //       // sql = string.Format("SELECT RoleID FROM {0}Roles WHERE Role = ?role", tablePrefix);
            //       // MySqlParameter[]  parameters2 = {
            //       //new MySqlParameter("?role", MySqlDbType.VarChar,100)};
            //       // parameters2[0].Value = role;
            //       // object oroleid = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sql, parameters2);
            //       // if (Equals(oroleid, null)) continue;
            //       // //获取用户组ID
            //       // int roleID = Int32.Parse(oroleid.ToString());

            //        int roleID = GetRoleId(role);

            //       string sql = string.Format("INSERT INTO {0}UserRoles (UserID, RoleID) VALUES (?uID, ?rID)", tablePrefix);


            //        MySqlParameter[] parameters3 = {
            //        new MySqlParameter("?uID",  MySqlDbType.Int32,4),
            //        new MySqlParameter("?rID",  MySqlDbType.Int32,4)};

            //        parameters3[0].Value = userID;
            //        parameters3[1].Value = roleID;

            //        DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, sql, parameters3);

            //    }
          //  }

        }

        /// <summary>
        /// Removes all users in user array from all roles in role array
        /// </summary>
        /// <param name="usernames"></param>
        /// <param name="roleNames"></param>
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            //foreach (string user in usernames)
            //{
            //    //string sql = string.Format("SELECT UserID FROM {0}Users WHERE UserName = ?user", tablePrefix);
            //    //MySqlParameter[] parameters = {
            //    //new MySqlParameter("?user", MySqlDbType.VarChar,100)};
            //    //parameters[0].Value = user;
            //    //object ouid = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sql, parameters);
            //    //if (Equals(ouid, null)) continue;
            //    ////获取用户ID
            //    //int userID = Int32.Parse(ouid.ToString());

            //    int userID = Base.Host.Instance.EBMembershipInstance.GetUserIDByUserName(user);
            //    foreach (string role in roleNames)
            //    {
            //       // sql = string.Format("SELECT RoleID FROM {0}Roles WHERE Role = ?role", tablePrefix);
            //       // MySqlParameter[] parameters2 = {
            //       //new MySqlParameter("?role", MySqlDbType.VarChar,100)};
            //       // parameters2[0].Value = role;
            //       // object oroleid = DbHelperUser.Instance.ExecuteScalar(CommandType.Text, sql, parameters2);
            //       // if (Equals(oroleid, null)) continue;
            //       // //获取用户组ID
            //       // int roleID = Int32.Parse(oroleid.ToString());
            //        int roleID = GetRoleId(role);
            //        //执行删除
            //       string sql = string.Format("DELETE FROM {0}UserRoles WHERE UserID = ?uID AND RoleID = ?rID", tablePrefix);


            //        MySqlParameter[] parameters3 = {
            //        new MySqlParameter("?uID",  MySqlDbType.Int32,4),
            //        new MySqlParameter("?rID",  MySqlDbType.Int32,4)};

            //        parameters3[0].Value = userID;
            //        parameters3[1].Value = roleID;

            //        DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, sql, parameters3);
            //    }
            //}

        }

        /// <summary>
        /// Returns array of users in selected role
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public override string[] GetUsersInRole(string roleName)
        {
           // List<string> users = new List<string>();

            //string sql = string.Format("SELECT u.UserName FROM {0}Users u INNER JOIN {0}UserRoles ur ON u.UserID = ur.UserID INNER JOIN {0}Roles r ON ur.RoleID = r.RoleID WHERE r.Role  = ?role", tablePrefix);


            //MySqlParameter[] parameters = {
            //new MySqlParameter("?role", MySqlDbType.VarChar,100)};

            //parameters[0].Value = roleName;

            //using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql, parameters))
            //{
            //    while (dataReader.Read())
            //    {
            //        users.Add(dataReader.GetString(0));
            //    }
            //}
            throw new NotImplementedException(); 
            
        }

        /// <summary>
        /// Returns array of all roles in database
        /// </summary>
        /// <returns></returns>
        public override string[] GetAllRoles()
        {
            List<string> roles = new List<string>();

            string sql = string.Format("SELECT GroupName FROM {0}usergroupprofile", tablePrefix);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql))
            {
                while (dataReader.Read())
                {
                    roles.Add(dataReader.GetString(0));
                }
            }

            //string sql = string.Format("SELECT role FROM {0}Roles", tablePrefix);

            //using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql))
            //{
            //    while (dataReader.Read())
            //    {
            //        roles.Add(dataReader.GetString(0));
            //    }
            //}
            return roles.ToArray();
        }

        /// <summary>
        /// Returns all users in selected role with names that match usernameToMatch
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="usernameToMatch"></param>
        /// <returns></returns>
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            //List<string> users = new List<string>();

            //string sql = string.Format("SELECT u.UserName FROM {0}Users u INNER JOIN {0}UserRoles ur ON u.UserID = ur.UserID INNER JOIN {0}Roles r ON ur.RoleID = r.RoleID WHERE r.Role  = ?role AND u.UserName LIKE ?name", tablePrefix);

            //MySqlParameter[] parameters = {
            //new MySqlParameter("?name", MySqlDbType.VarChar,100),
            //new MySqlParameter("?role", MySqlDbType.VarChar,100)};

            //parameters[0].Value = usernameToMatch + "%";

            //parameters[1].Value = roleName;


            //using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql, parameters))
            //{
            //    while (dataReader.Read())
            //    {
            //        users.Add(dataReader.GetString(0));
            //    }
            //}
            //return users.ToArray();

            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Returns the application name as set in the web.config
        /// otherwise returns BlogEngine.  Set will throw an error.
        /// </summary>
        public override string ApplicationName
        {
            get { return applicationName; }
            set { throw new NotImplementedException(); }
        }
    }
}
