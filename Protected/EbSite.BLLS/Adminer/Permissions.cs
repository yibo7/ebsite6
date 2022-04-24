
using System;
using System.Collections.Generic;
using System.Data;
using EbSite.Data.Interface;

namespace EbSite.BLL
{
   
   
    /// <summary>
    /// 权限管理类
    /// </summary>
    public class Permissions
    {
        #region 属性
        private int _PermissionID;
        public int PermissionID
        {
            get
            {
                return _PermissionID;
            }
            set
            {
                _PermissionID = value;
            }
        }
        private int _ParentID;
        public int ParentID
        {
            get
            {
                return _ParentID;
            }
            set
            {
                _ParentID = value;
            }
        }
        private string _PermissionName;
        public string PermissionName
        {
            get
            {
                return _PermissionName;
            }
            set
            {
                _PermissionName = value;
            }
        }
        #endregion

        /// <summary>
        /// 创建权限
        /// </summary>
        /// <param name="pcID">权限分类ID</param>
        /// <param name="description">权限名称</param>
        public static void Create(int pcID, string description)
        {
           
             DbProviderCms.GetInstance().AdminUser_CreatePermission(pcID, description);
        }
        /// <summary>
        /// 删除权限-同时删除关联角色权限
        /// </summary>
        /// <param name="pID">权限ID</param>
        /// <returns></returns>
        public static bool Delete(int pID)
        {
           
            return DbProviderCms.GetInstance().AdminUser_DeletePermission(pID);
        }
        /// <summary>
        /// 获取权限名称
        /// </summary>
        /// <param name="pID">权限ID</param>
        /// <returns></returns>
        public static string GetPermissionName(int pID)
        {
          
            return DbProviderCms.GetInstance().AdminUser_RetrievePermission(pID)["Description"].ToString();
        }
        /// <summary>
        /// 更新权限名称
        /// </summary>
        /// <param name="pcID">权限ID</param>
        /// <param name="description">权限名称</param>
        /// <returns></returns>
        public static bool Update(int PermissionID,int ParentID, string description)
        {

            return DbProviderCms.GetInstance().AdminUser_UpdatePermission(PermissionID, ParentID, description);
        }
        /// <summary>
        /// 获取所有权限，包括权限分类
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllPermissions()
        {
            return DbProviderCms.GetInstance().AdminUser_GetPermissionList();
        }
        public static Permissions GetPermissionsByID(int ID)
        {
            DataRow dr =  DbProviderCms.GetInstance().AdminUser_RetrievePermission(ID);

            Permissions md = new Permissions();
            md.PermissionID = int.Parse(dr["PermissionID"].ToString());
            md.ParentID = int.Parse(dr["CategoryID"].ToString());
            md.PermissionName = dr["Description"].ToString();
            return md;
        }

        public static List<Permissions> GetAllPermissionsList()
        {
            DataSet ds =  DbProviderCms.GetInstance().AdminUser_GetPermissionList();
            List<Permissions> lst = new List<Permissions>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Permissions md = new Permissions();
                md.PermissionID = int.Parse(dr["PermissionID"].ToString());
                md.ParentID = int.Parse(dr["CategoryID"].ToString());
                md.PermissionName = dr["Description"].ToString();
                lst.Add(md);
            }
            return lst;
        }
        public static List<Permissions> GetPermissionsListByName(string sName)
        {
            DataSet ds = DbProviderCms.GetInstance().AdminUser_GetPermissionList();
            List<Permissions> lst = new List<Permissions>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Permissions md = new Permissions();
                md.PermissionID = int.Parse(dr["PermissionID"].ToString());
                md.ParentID = int.Parse(dr["CategoryID"].ToString());
                md.PermissionName = dr["Description"].ToString();
                if (md.PermissionName.IndexOf(sName)>-1)
                    lst.Add(md);
            }
            return lst;
        }
        #region 树形处理
        

        public static List<Permissions> GetTree_pic()
        {
            List<Permissions> dsAllPermissionsList = GetAllPermissionsList();
            List<Permissions> getTree = new List<Permissions>();


            string sPatch = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (Permissions tree in dsAllPermissionsList)
            {
                //Entity.Menus mdTem = tree.Clone();
                if (tree.ParentID == 0)
                {

                    tree.PermissionName = sPatch + string.Format("<b><font color=red>{0}</font></b><a name=\"a{1}\"></a>", tree.PermissionName, tree.PermissionID);
                    getTree.Add(tree);
                    GetSubItem_pic(tree.PermissionID, ref getTree, "", dsAllPermissionsList);
                }

            }
            return getTree;
        }
        /// <summary>
        /// 获取某个记录下的子记录，从而构建树形(递归调用)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="GetTree"></param>
        /// <param name="blank"></param>
        private static void GetSubItem_pic(int id, ref List<Permissions> NewClass, string blank, List<Permissions> OldClass)
        {
            string sW3 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w3.gif\" align=absmiddle>");
            string sW1 = string.Concat("<img src=\"", Base.AppStartInit.IISPath, "Images/tree/w1.gif\" align=absmiddle>");
            foreach (Permissions mdModel in OldClass)
            {
                //Entity.Menus mdTem = mdModel.Clone();
                if (mdModel.ParentID == id)
                {
                    string str = blank;
                    str = string.Concat(str, sW3);
                    mdModel.PermissionName = str + sW1 + mdModel.PermissionName;
                    NewClass.Add(mdModel);
                    GetSubItem_pic(mdModel.PermissionID, ref NewClass, str, OldClass);
                }
            }
        }

        public static List<Permissions> GetTree()
        {

            List<Permissions> dsAllPermissionsList = GetAllPermissionsList();
            List<Permissions> getTree = new List<Permissions>();

            foreach (Permissions tree in dsAllPermissionsList)
            {
                if (tree.ParentID == 0)
                {
                    tree.PermissionName = "╋" + tree.PermissionName;
                    getTree.Add(tree);
                    GetSubItem(tree.PermissionID, ref getTree, "├", dsAllPermissionsList);
                }

            }
            return getTree;
        }
        /// <summary>
        /// 获取某个记录下的子记录，从而构建树形(递归调用)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="GetTree"></param>
        /// <param name="blank"></param>
        private static void GetSubItem(int id, ref List<Permissions> NewClass, string blank, List<Permissions> OldClass)
        {
            foreach (Permissions mdModel in OldClass)
            {
                if (mdModel.ParentID == id)
                {

                    string str = blank + "─";
                    mdModel.PermissionName = str + "『" + mdModel.PermissionName + "』";
                    NewClass.Add(mdModel);
                    GetSubItem(mdModel.PermissionID, ref NewClass, str, OldClass);
                }
            }
        }

        #endregion
    }
}

