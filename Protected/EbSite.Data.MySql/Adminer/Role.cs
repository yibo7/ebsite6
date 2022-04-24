using System.Data;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;

namespace EbSite.Data.MySql
{



    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        
        /// <summary>
        /// 给角色添加对应的权限
        /// </summary>
        /// <param name="roleId">用户组ID</param>
        /// <param name="permissionId">权限ID</param>
        public void AdminUser_AddPermission(int roleId, int permissionId)
        {
            int num;
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_RoleID", MySqlDbType.Int32, 4), new MySqlParameter("?p_PermissionID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = roleId;
            parameters[1].Value = permissionId;
            DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}AddPermissionToRole",sPre), parameters);
        }
        /// <summary>
        /// 全部清除此角色的权限
        /// </summary>
        /// <param name="roleId">角色ID</param>
        //public void AdminUser_ClearPermissions(int roleId)
        //{
        //    int num;
        //    MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?RoleID", MySqlDbType.Int32 , 4) };
        //    parameters[0].Value = roleId;
        //    DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}ClearPermissionsFromRole",sPre), parameters);
        //}
        /// <summary>
        /// 创建用户组(角色)
        /// </summary>
        /// <param name="description">用户组(角色)名称</param>
        /// <returns></returns>
        public int AdminUser_CreateRole(string description)
        {
            int num;
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_Description", MySqlDbType.VarChar, 50) };
            parameters[0].Value = description;
            return DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}CreateRole",sPre), parameters);
        }
        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="roleId">用户组ID</param>
        /// <returns></returns>
        public bool AdminUser_DeleteRole(int roleId)
        {
            int num;
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_RoleID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = roleId;
            num = DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}DeleteRole",sPre), parameters);
            return (num == 1);
        }

        public DataSet AdminUser_GetRoleList()
        {
            using (DataSet set = DbHelperCms.Instance.ExecuteDataset(CommandType.StoredProcedure, string.Format("{0}GetAllRoles",sPre), null))
            {
                return set;
            }
        }
        /// <summary>
        /// 移除此用户组对应的权限
        /// </summary>
        /// <param name="roleId">用户组ID</param>
        /// <param name="permissionId">权限ID</param>
        public void AdminUser_RemovePermission(int roleId, int permissionId)
        {
            int num;
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_RoleID", MySqlDbType.Int32 , 4), new MySqlParameter("?p_PermissionID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = roleId;
            parameters[1].Value = permissionId;
            DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}RemovePermissionFromRole",sPre), parameters);
        }

        public DataRow AdminUser_RetrieveRole(int roleId)
        {
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_RoleID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = roleId;
            using (DataSet set = DbHelperCms.Instance.ExecuteDataset(CommandType.StoredProcedure, string.Format("{0}GetRoleDetails",sPre), parameters))
            {
                return set.Tables[0].Rows[0];
            }
        }
        /// <summary>
        /// 更新用户组名称
        /// </summary>
        /// <param name="roleId">用户组ID</param>
        /// <param name="description">用户组名称</param>
        /// <returns></returns>
        public bool AdminUser_UpdateRole(int roleId, string description)
        {
            int num;
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_RoleID", MySqlDbType.Int32 , 4), new MySqlParameter("?p_Description", MySqlDbType.VarChar, 50) };
            parameters[0].Value = roleId;
            parameters[1].Value = description;
            num = DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}UpdateRole",sPre), parameters);
            return (num == 1);
        }
    }
}

