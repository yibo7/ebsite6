using System;
using System.Data;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;

namespace EbSite.Data.MySql
{

    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        
        /// <summary>
        /// 创建权限
        /// </summary>
        /// <param name="categoryID">权限分类ID</param>
        /// <param name="description">权限名称</param>
        /// <returns></returns>
        public void AdminUser_CreatePermission(int categoryID, string description)
        {
            int num;
            MySqlParameter[] parameters = new MySqlParameter[]
                                            {
                                                new MySqlParameter("?p_CategoryID", MySqlDbType.Int32 , 8), 
                                                new MySqlParameter("?p_Description",MySqlDbType.VarChar, 50)
                                                //new MySqlParameter("?menuid", MySqlDbType.Int32 , 16)

                                            };
            parameters[0].Value = categoryID;
            parameters[1].Value = description;
            //parameters[2].Value = iMemuid;

             DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}CreatePermission",sPre), parameters);
        }
        /// <summary>
        /// 删除权限-同时删除关联角色权限
        /// </summary>
        /// <param name="id">权限ID</param>
        /// <returns></returns>
        public bool AdminUser_DeletePermission(int id)
        {
            int num;
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_PermissionID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = id;
            num = DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}DeletePermission", sPre), parameters);
            return (num == 1);
        }
        /// <summary>
        /// 获取不属于此角色对应的权限与其分类 dataset里两个表
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public DataSet AdminUser_GetNoPermissionList(int roleId)
        {
            string sql =
                         string.Format(
                             "SELECT PermissionID, Description, CategoryID FROM {0}Admin_Permissions where PermissionID not in(select PermissionID from {0}Admin_RolesPermissions WHERE RoleID = ?RoleID ) ORDER BY Description", sPre);
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?RoleID", MySqlDbType.VarChar, 4) };
            parameters[0].Value = roleId;
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text,sql, parameters);

            //MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?RoleID", MySqlDbType.VarChar, 4) };
            //parameters[0].Value = roleId;
            //using (DataSet set = DbHelperCms.Instance.ExecuteDataset(CommandType.StoredProcedure, string.Format("{0}GetPermissionCategories", sPre), null))//, "Categories" 默认表名称为Result
            //{
            //    DbHelperCms.Instance.ExecuteDataset(set, CommandType.StoredProcedure, string.Format("{0}GetNoPermissionList", sPre), parameters);
            //    DataRelation relation = new DataRelation("PermissionCategories", set.Tables[0].Columns["CategoryID"], set.Tables[1].Columns["CategoryID"], true);
            //    set.Relations.Add(relation);
            //    DataColumn[] columnArray = new DataColumn[] { set.Tables[0].Columns["CategoryID"] };
            //    DataColumn[] columnArray2 = new DataColumn[] { set.Tables[1].Columns["PermissionID"] };
            //    set.Tables[0].PrimaryKey = columnArray;
            //    set.Tables[1].PrimaryKey = columnArray2;
            //    return set;
            //}
        }
        /// <summary>
        /// 获取所有权限，包括权限分类
        /// </summary>
        /// <returns></returns>
        public DataSet AdminUser_GetPermissionList()
        {
            string sql = string.Format("SELECT PermissionID, Description, CategoryID FROM {0}Admin_Permissions ORDER BY PermissionID ", sPre);
            return DbHelperCms.Instance.ExecuteDataset(sql);

            //MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?RoleID", MySqlDbType.VarChar, 4) };
            //using (DataSet set = DbHelperCms.Instance.ExecuteDataset(CommandType.StoredProcedure, string.Format("{0}GetPermissionCategories", sPre), null))
            //{
            //    DbHelperCms.Instance.ExecuteDataset(set, CommandType.StoredProcedure, string.Format("{0}GetPermissionList", sPre), parameters);
            //    DataRelation relation = new DataRelation("PermissionCategories", set.Tables[0].Columns["CategoryID"], set.Tables[1].Columns["CategoryID"], true);
            //    set.Relations.Add(relation);
            //    DataColumn[] columnArray = new DataColumn[] { set.Tables[0].Columns["CategoryID"] };
            //    DataColumn[] columnArray2 = new DataColumn[] { set.Tables[1].Columns["PermissionID"] };
            //    set.Tables[0].PrimaryKey = columnArray;
            //    set.Tables[1].PrimaryKey = columnArray2;
            //    return set;
            //}
        }
        /// <summary>
        /// 获取角色对应的权限与其分类 dataset里两个表 
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public DataSet AdminUser_GetPermissionList(int roleId)
        {


            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_RoleID", MySqlDbType.VarChar, 4) };
            parameters[0].Value = roleId;

            return DbHelperCms.Instance.ExecuteDataset( CommandType.StoredProcedure, string.Format("{0}GetPermissionList", sPre), parameters);

            //using (DataSet set = DbHelperCms.Instance.ExecuteDataset(CommandType.StoredProcedure, string.Format("{0}GetPermissionCategories", sPre), null))//, "Categories"
            //{
            //    DbHelperCms.Instance.ExecuteDataset(set, "Permissions", CommandType.StoredProcedure, string.Format("{0}GetPermissionList", sPre), parameters);

            //    DataRelation relation = new DataRelation("PermissionCategories", set.Tables[0].Columns["CategoryID"], set.Tables["Permissions"].Columns["CategoryID"], true);

            //    set.Relations.Add(relation);
            //    DataColumn[] columnArray = new DataColumn[] { set.Tables[0].Columns["CategoryID"] };
            //    DataColumn[] columnArray2 = new DataColumn[] { set.Tables[1].Columns["PermissionID"] };
            //    set.Tables[0].PrimaryKey = columnArray;
            //    set.Tables[1].PrimaryKey = columnArray2;
            //    return set;
            //}
        }

        public DataRow AdminUser_RetrievePermission(int permissionId)
        {
            MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?p_PermissionID", MySqlDbType.Int32 , 4) };
            parameters[0].Value = permissionId;
            using (DataSet set = DbHelperCms.Instance.ExecuteDataset(CommandType.StoredProcedure, string.Format("{0}GetPermissionDetails", sPre), parameters))//"Permissions"
            {
                if (set.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("找不到权限 （" + permissionId + "）");
                }
                return set.Tables[0].Rows[0];
            }
        }

        public bool AdminUser_UpdatePermission(int PermissionID, int ParentID, string description)
        {
            string sql = string.Format("UPDATE {0}Admin_Permissions SET Description = ?Description,CategoryID = ?CategoryID WHERE PermissionID = ?PermissionID", sPre);
            int num;
            MySqlParameter[] parameters = new MySqlParameter[]
                                              {
                                                  new MySqlParameter("?Description", MySqlDbType.VarChar, 50),
                                                  new MySqlParameter("?PermissionID", MySqlDbType.Int32 , 8),
                                                  new MySqlParameter("?CategoryID", MySqlDbType.Int32 , 8)
                                                  
                                              };
            parameters[0].Value = description;
            parameters[1].Value = PermissionID;
            parameters[2].Value = ParentID;
            num = DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, sql, parameters);
            return (num == 1);

            //int num;
            //MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("?PermissionID", MySqlDbType.Int32 , 8), new MySqlParameter("?Description", MySqlDbType.VarChar, 50) };
            //parameters[0].Value = PermissionID;
            //parameters[1].Value = description;
            //num = DbHelperCms.Instance.ExecuteNonQuery(CommandType.StoredProcedure, string.Format("{0}UpdatePermission", sPre), parameters);
            //return (num == 1);
        }
    }
}

