
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using EbSite.BLL;
using MySql.Data.MySqlClient;
using System.Text;
using EbSite.Base.DataProfile;
using EbSite.Base.EntityAPI;

namespace EbSite.Data.MySql 
{
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        
        /// <summary>
        /// 添加用户到对应的用户组(角色)
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">用户组ID</param>
        /// <returns></returns>
        public bool AdminUser_AddRoleAdmin(int userId, int roleId)
        {
           
            int num;
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_UserID", MySqlDbType.Int32 , 4), new MySqlParameter("?p_RoleID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = userId;
            parameters[1].Value = roleId;
            //base.RunProcedure("SP_AddUserToRole", parameters, out num);
            num = DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}AddUserToRole",sPre), parameters);
            return (num == 1);
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="userID">用户ID 是EB_users 的用户ID</param> //杨欢乐添加
        /// <returns></returns>
        public int AdminUser_CreateAdmin(string userName, int userID)
        {

            MySqlParameter[] parameters = new MySqlParameter[]
                                            {
                                                new MySqlParameter("?p_UserName", MySqlDbType.VarChar, 100), 
                                                new MySqlParameter("?p_UserID", MySqlDbType.Int32 )
                                            };
            parameters[0].Value = userName;
          //  parameters[1].Direction = ParameterDirection.Output;
            parameters[1].Value = userID;
            try
            {
                int num;
                num = DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure,string.Format("{0}CreateUser",sPre), parameters);
            }
            catch (MySqlException exception)
            {
                if (exception.Number == 0xa29)
                {
                    return -100;
                }
            }

            return (int) parameters[1].Value;
        }

        public bool AdminUser_DeleteAdmin(int userID)
        {
            int num;
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_UserID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = userID;
            num = DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}DeleteUser",sPre), parameters);
            return (num == 1);
        }
        /// <summary>
        /// 获取用户-根据真实姓名
        /// </summary>
        /// <param name="key">真实姓名</param>
        /// <returns></returns>
        public List<EbSite.BLL.AdminUser> AdminUser_GetAllUsersAdmin(string key)
        {
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_key", MySqlDbType.VarChar, 50) };
            parameters[0].Value = key;
             //DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}GetUsers", sPre), parameters);
            List<EbSite.BLL.AdminUser>  lst = new List<AdminUser>();
            using (IDataReader reader = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}GetUsers", sPre), parameters))
            {
                while (reader.Read())
                {
                    EbSite.BLL.AdminUser md = new AdminUser();
                    md.UserName = reader["UserName"].ToString();
                    //md.IsLock =  reader["IsLock"].ToString();
                    if (!string.IsNullOrEmpty(reader["IsLock"].ToString()))
                        md.IsLock = bool.Parse(reader["IsLock"].ToString());
                    if (!string.IsNullOrEmpty(reader["UserID"].ToString()))
                        md.UserID = int.Parse(reader["UserID"].ToString());
                    if (!string.IsNullOrEmpty(reader["LastLoginTime"].ToString()))
                        md.LastLoginTime = DateTime.Parse(reader["LastLoginTime"].ToString());


                    lst.Add(md);
                }
            }

            return lst;
        }
        /// <summary>
        /// 查询 角色下的管理员用户
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public List<EbSite.BLL.AdminUser> AdminUser_GetAllUsersAdmin(int RoleID)
        {
            List<EbSite.BLL.AdminUser> lst = new List<AdminUser>();

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT * from {0}admin_user where UserId in( SELECT userid from {0}admin_userroles where RoleID={1} ) ", sPre, RoleID);
            using (IDataReader reader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (reader.Read())
                {
                    EbSite.BLL.AdminUser md = new AdminUser();
                    md.UserName = reader["UserName"].ToString();
                    //md.IsLock =  reader["IsLock"].ToString();
                    if (!string.IsNullOrEmpty(reader["IsLock"].ToString()))
                        md.IsLock = bool.Parse(reader["IsLock"].ToString());
                    if (!string.IsNullOrEmpty(reader["UserID"].ToString()))
                        md.UserID = int.Parse(reader["UserID"].ToString());
                    if (!string.IsNullOrEmpty(reader["LastLoginTime"].ToString()))
                        md.LastLoginTime = DateTime.Parse(reader["LastLoginTime"].ToString());


                    lst.Add(md);
                }
            }
            return lst; 
        }

        /// <summary>
        /// 获取当前用户的权限名称列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public ArrayList AdminUser_GetEffectivePermissionListAdmin(int userID)
        {
            ArrayList list = new ArrayList();
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_UserID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = userID;
            //IDataReader reader = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure,string.Format("{0}GetEffectivePermissionList",sPre), parameters);

            using (IDataReader reader = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}GetEffectivePermissionList", sPre), parameters))
            {
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
            }


            //base.Connection.Close();
            return list;
        }
       /// <summary>
       /// 获取用户的权限ID列表
       /// </summary>
       /// <param name="userID">用户ID</param>
       /// <returns></returns>
        public ArrayList AdminUser_GetEffectivePermissionListIDAdmin(int userID)
        {
            ArrayList list = new ArrayList();
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_UserID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = userID;
            //IDataReader reader = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}GetEffectivePermissionListID",sPre), parameters);
            using (IDataReader reader = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}GetEffectivePermissionListID", sPre), parameters))
            {
                while (reader.Read())
                {
                    list.Add(reader.GetInt32(0));
                }
            }

           
            //base.Connection.Close();
            return list;
        }

        //public IDataReader AdminUser_GetUserListAdmin()
        //{
        //    //return base.RunProcedure("SP_GetUsers", new IDataParameter[0], "Users");
        //    return DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}GetUsers",sPre),null);

        //}

        public List<EbSite.Base.EntityAPI.AdminRoleInfo> AdminUser_GetUserRolesAdmin(int userID)
        {
            List<EbSite.Base.EntityAPI.AdminRoleInfo> list = new List<EbSite.Base.EntityAPI.AdminRoleInfo>();
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_UserID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = userID;
            //IDataReader reader = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}GetUserRoles",sPre), parameters);
            using (IDataReader reader = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}GetUserRoles", sPre), parameters))
            {
                while (reader.Read())
                {
                    Base.EntityAPI.AdminRoleInfo md = new AdminRoleInfo();
                    md.id = reader.GetInt32(0);
                    md.RoleName = reader.GetString(1);
                    list.Add(md);
                }
            }
            
            return list;
        }

        //public IDataReader AdminUser_GetUsersAdmin(string DepartmentID)
        //{
        //    MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?DepartmentID", MySqlDbType.VarChar, 15) };
        //    parameters[0].Value = DepartmentID;
        //    //return base.RunProcedure("SP_GetUsersByDepart", parameters, "Users");
        //    return DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}GetUsersByDepart",sPre), parameters);
        //}
        ///// <summary>
        ///// 查房某个用户类型下的用户
        ///// </summary>
        ///// <param name="usertype">用户类型</param>
        ///// <param name="key">关键字</param>
        ///// <returns></returns>
        //public IDataReader AdminUser_GetUsersByTypeAdmin(string usertype, string key)
        //{
        //    MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?UserType", MySqlDbType.VarChar, 2), new MySqlParameter("?key", MySqlDbType.VarChar, 50) };
        //    parameters[0].Value = usertype;
        //    parameters[1].Value = key;
        //    return DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}GetUsersByType",sPre), parameters);//, "Users"
        //}
        /// <summary>
        /// 是否存在某个用户名称的用户
        /// </summary>
        /// <param name="userName">用户注册名</param>
        /// <returns></returns>
        public bool AdminUser_HasUserAdmin(string userName)
        {
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_UserName", MySqlDbType.VarChar, 50) };
            parameters[0].Value = userName;
            using (IDataReader dr = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Format("{0}GetUserDetailsByUserName",sPre), parameters))//, "Users"
            {
                if (dr.Read())
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// 除去某个用户所属的用户组
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">用户组ID</param>
        /// <returns></returns>
        public bool AdminUser_RemoveRoleAdmin(int userId, int roleId)
        {
            int num;
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_UserID", MySqlDbType.Int32 , 4), new MySqlParameter("?p_RoleID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = userId;
            parameters[1].Value = roleId;
            num = DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}RemoveUserFromRole",sPre), parameters);
            return (num == 1);
        }
        /// <summary>
        /// 获取某个用户记录-根据用户ID
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public DataRow AdminUser_RetrieveAdmin(int userID)
        {
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_UserID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = userID;
            using (DataSet ds = DbHelperCms.Instance.ExecuteDataset(CommandType.StoredProcedure, string.Format("{0}GetUserDetails",sPre), parameters))//, "Users"
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0];
                }
                return null;
            }
        }
        /// <summary>
        /// 获取用户注册名称，查找用户记录
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <returns></returns>
        public DataRow AdminUser_RetrieveAdmin(string userName)
        {
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_UserName", MySqlDbType.VarChar, 50) };
            parameters[0].Value = userName;
            using (DataSet ds = DbHelperCms.Instance.ExecuteDataset(CommandType.StoredProcedure, string.Format("{0}GetUserDetailsByUserName",sPre), parameters))//, "Users"
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("无此用户或用户已过期：" + userName);
                }
                return ds.Tables[0].Rows[0];
            }
        }
        /// <summary>
        /// 根据用户账号更新某个用户的密码
        /// </summary>
        /// <param name="UserName">用户账号</param>
        /// <param name="encPassword">密码</param>
        /// <returns></returns>
        //public bool AdminUser_SetPasswordAdmin(string UserName, byte[] encPassword)
        //{
        //    int num;
        //    MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?UserName", MySqlDbType.VarChar), new MySqlParameter("?EncryptedPassword", MySqlDbType.Binary, 20) };
        //    parameters[0].Value = UserName;
        //    parameters[1].Value = encPassword;
        //    num = DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}SetPassword",sPre), parameters);
        //    return (num == 1);
        //}
        /// <summary>
        /// 验证某个用户输入的密码是否正确
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="encPassword">加密后的密码</param>
        /// <returns></returns>
        //public int AdminUser_TestPasswordAdmin(int userID, byte[] encPassword)
        //{
        //    int num;
        //    MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?UserID", MySqlDbType.Int32 , 4), new MySqlParameter("?EncryptedPassword", MySqlDbType.Binary, 20) };
        //    parameters[0].Value = userID;
        //    parameters[1].Value = encPassword;
        //    return DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}TestPassword",sPre), parameters);
        //}

        public bool AdminUser_UpdateAdmin(int userID, string userName, bool isLock, DateTime LastLoginTime,int CurrentSiteID)
        {
            int num;
            MySqlParameter[] parameters = new MySqlParameter[]
                                            {
                                                new MySqlParameter("?p_UserName", MySqlDbType.VarChar, 100),
                                                new MySqlParameter("?p_IsLock", MySqlDbType.Bit),
                                                new MySqlParameter("?p_LastLoginTime", MySqlDbType.Datetime),
                                                new MySqlParameter("?p_userID", MySqlDbType.Int32 ),
                                                new MySqlParameter("?p_CurrentSiteID", MySqlDbType.Int32 )
                                            };
            parameters[0].Value = userName;
            parameters[1].Value = isLock;
            parameters[2].Value = LastLoginTime;
            parameters[3].Value = userID;
            parameters[4].Value = CurrentSiteID;
            //CurrentSiteID
            num = DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}UpdateUser",sPre), parameters);
            return (num == 1);
        }

        public int AdminUser_ValidateLoginAdmin(string userName)
        {
           // int num;
            //MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?UserName", MySqlDbType.VarChar, 50), new MySqlParameter("?EncryptedPassword", MySqlDbType.Binary, 20) };
            //parameters[0].Value = userName;
            //parameters[1].Value = encPassword;
            //return DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, "SP_ValidateLogin", parameters);

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select UserId from {0}Admin_User", sPre);
            strSql.Append(" where UserName=?UserName ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100)};
            parameters[0].Value = userName;

            object oID =  DbHelperCms.Instance.ExecuteScalar(CommandType.Text,strSql.ToString(), parameters);

            if(!Equals(oID,null))
            {
                return int.Parse(oID.ToString());
            }
            return -1;
        }

        public int AdminUser_GetCurrentSiteID(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select CurrentSiteID from {0}Admin_User", sPre);
            strSql.Append(" where UserName=?UserName ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100)};
            parameters[0].Value = userName;

            object oID = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

            if (!Equals(oID, null))
            {
                return int.Parse(oID.ToString());
            }
            return 1;
        }
        public int AdminUser_GetCurrentSiteID(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select CurrentSiteID from {0}Admin_User", sPre);
            strSql.Append(" where UserId=?UserId ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserId",  MySqlDbType.Int32,4)};
            parameters[0].Value = UserID;

            object oID = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

            if (!Equals(oID, null))
            {
                return int.Parse(oID.ToString());
            }
            return 1;
        }

       public int AdminUser_GetManagerID(string sUserName)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select UserId");
           strSql.AppendFormat(" FROM {0}Admin_User where UserName=?UserName limit 1", sPre);

           MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,100)};
           parameters[0].Value = sUserName;

          object ob =  DbHelperCms.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

           if(!Equals(ob,null))
           {
               return Int32.Parse(ob.ToString());
           }
           else
           {
               return 0;
           }

       }
    }
}

