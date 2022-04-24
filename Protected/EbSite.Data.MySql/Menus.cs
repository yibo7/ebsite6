using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using EbSite.Base.DataProfile;

namespace EbSite.Data.MySql
{
    /// <summary>
    /// 数据访问类Menus。
    /// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
    {
        private string sFieldMenus = "id,MenuName,ImageUrl,OrderID,ParentID,PermissionID,Target,CtrPath,PageUrl,AddTime,IsLeftParent,ModulesID,help,SiteID";

        #region 读

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Menus_Exists(Guid id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}menus", sPre);
            strSql.Append(" where id=?id ");

            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.VarChar,36)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>

        public Entity.Menus Menus_GetEntity(Guid id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldMenus + "  from {0}menus ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.VarChar,36)};
            parameters[0].Value = id;
            Entity.Menus model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = Menus_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int Menus_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}menus ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            int iCount = 0;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    iCount = int.Parse(dataReader[0].ToString());
                }
            }
            return iCount;
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet Menus_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldMenus);
            strSql.AppendFormat(" FROM {0}menus ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            return DbHelperCms.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Entity.Menus> Menus_GetListArray(string strWhere)
        {
            return Menus_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.Menus> Menus_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");



            strSql.Append(" " + sFieldMenus);



            strSql.AppendFormat(" FROM {0}menus  ", sPre);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }



            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by  " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
            List<Entity.Menus> list = new List<Entity.Menus>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(Menus_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.Menus> Menus_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.Menus> list = new List<Entity.Menus>();
            RecordCount = Menus_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "menus", PageSize, PageIndex, "", "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(Menus_ReaderBind(dataReader));
                }
            }
            return list;
        }
        public List<Entity.Menus> Menus_GetListByParentID(Guid ParentID, int SiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldMenus + "  from {0}menus ", sPre);
            strSql.Append(" where ParentID=?ParentID and(SiteID=0 or SiteID=?SiteID) order by orderid asc");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ParentID", MySqlDbType.VarChar,36),
                    new MySqlParameter("?SiteID", MySqlDbType.Int32,4)
                                          };
            parameters[0].Value = ParentID;
            parameters[1].Value = SiteID;

            List<Entity.Menus> list = new List<Entity.Menus>();

            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                while (dataReader.Read())
                {
                    list.Add(Menus_ReaderBind(dataReader));
                }
            }
            return list;
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.Menus Menus_ReaderBind(IDataReader dataReader)
        {
            Entity.Menus model = new Entity.Menus();
            object ojb;
            model.id = new Guid(dataReader["id"].ToString());

            model.MenuName = dataReader["MenuName"].ToString();
            model.ImageUrl = dataReader["ImageUrl"].ToString();
            ojb = dataReader["OrderID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrderID = (int)ojb;
            }
            model.ParentID = new Guid(dataReader["ParentID"].ToString());

            model.PermissionID = dataReader["PermissionID"].ToString();
            model.Target = dataReader["Target"].ToString();
            model.CtrPath = dataReader["CtrPath"].ToString();
            model.PageUrl = dataReader["PageUrl"].ToString();

            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = (DateTime)ojb;
            }

            ojb = dataReader["IsLeftParent"];
            if (dataReader["IsLeftParent"].ToString() == "1")
            {
                ojb = true;
            }

            if (dataReader["IsLeftParent"].ToString() == "0")
            {
                ojb = false;
            }

            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsLeftParent = (bool)ojb;
            }

            model.ModulesID = new Guid(dataReader["ModulesID"].ToString());
            model.help = dataReader["help"].ToString();

            ojb = dataReader["SiteID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SiteID = (int)ojb;
            }
            return model;
        }




        public int Menus_GetMaxOrderID(Guid ParentID)
        {
            string sSql = string.Concat("select Max(orderid)  from  ", sPre, "menus where Parentid='", ParentID, "'");
            object MaxID = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, sSql);
            if (MaxID != null && !string.IsNullOrEmpty(MaxID.ToString()))
            {
                return int.Parse(MaxID.ToString());
            }
            else
            {
                return 0;
            }
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Menus_Add(Entity.Menus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}menus(", sPre);
            strSql.Append("id,MenuName,ImageUrl,OrderID,ParentID,PermissionID,Target,CtrPath,PageUrl,AddTime,IsLeftParent,ModulesID,help,SiteID)");
            strSql.Append(" values (");
            strSql.Append("?id,?MenuName,?ImageUrl,?OrderID,?ParentID,?PermissionID,?Target,?CtrPath,?PageUrl,?AddTime,?IsLeftParent,?ModulesID,?help,?SiteID)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.VarChar,36),
					new MySqlParameter("?MenuName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID", MySqlDbType.VarChar,36),
					new MySqlParameter("?PermissionID", MySqlDbType.VarChar,10),
					new MySqlParameter("?Target", MySqlDbType.VarChar,300),
					new MySqlParameter("?CtrPath", MySqlDbType.VarChar,50),
					new MySqlParameter("?PageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?AddTime", MySqlDbType.Datetime),
				    new MySqlParameter("?IsLeftParent", MySqlDbType.Int16,1),
					new MySqlParameter("?ModulesID", MySqlDbType.VarChar,36),
					new MySqlParameter("?help", MySqlDbType.Text),
                    new MySqlParameter("?SiteID",MySqlDbType.Int32,4) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.MenuName;
            parameters[2].Value = model.ImageUrl;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.ParentID;
            parameters[5].Value = model.PermissionID;
            parameters[6].Value = model.Target;
            parameters[7].Value = model.CtrPath;
            parameters[8].Value = model.PageUrl;
            parameters[9].Value = model.AddTime;
            parameters[10].Value = model.IsLeftParent;
            parameters[11].Value = model.ModulesID;
            parameters[12].Value = model.help;
            parameters[13].Value = model.SiteID;

            DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Menus_Update(Entity.Menus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}menus set ", sPre);
            strSql.Append("MenuName=?MenuName,");
            strSql.Append("ImageUrl=?ImageUrl,");
            strSql.Append("OrderID=?OrderID,");
            strSql.Append("ParentID=?ParentID,");
            strSql.Append("PermissionID=?PermissionID,");
            strSql.Append("Target=?Target,");
            strSql.Append("CtrPath=?CtrPath,");
            strSql.Append("PageUrl=?PageUrl,");
            strSql.Append("AddTime=?AddTime,");
            strSql.Append("IsLeftParent=?IsLeftParent,");
            strSql.Append("ModulesID=?ModulesID,");
            strSql.Append("help=?help,");
            strSql.Append(" SiteID=?SiteID");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.VarChar,36),
					new MySqlParameter("?MenuName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID", MySqlDbType.VarChar,36),
					new MySqlParameter("?PermissionID", MySqlDbType.VarChar,10),
					new MySqlParameter("?Target", MySqlDbType.VarChar,300),
					new MySqlParameter("?CtrPath", MySqlDbType.VarChar,50),
					new MySqlParameter("?PageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?AddTime", MySqlDbType.Datetime),
					new MySqlParameter("?IsLeftParent", MySqlDbType.Int16,1),
					new MySqlParameter("?ModulesID", MySqlDbType.VarChar,36),
					new MySqlParameter("?help", MySqlDbType.Text),
                    new MySqlParameter("?SiteID",MySqlDbType.Int32,4) };
            parameters[0].Value = model.id;
            parameters[1].Value = model.MenuName;
            parameters[2].Value = model.ImageUrl;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.ParentID;
            parameters[5].Value = model.PermissionID;
            parameters[6].Value = model.Target;
            parameters[7].Value = model.CtrPath;
            parameters[8].Value = model.PageUrl;
            parameters[9].Value = model.AddTime;
            parameters[10].Value = model.IsLeftParent;
            parameters[11].Value = model.ModulesID;
            parameters[12].Value = model.help;
            parameters[13].Value = model.SiteID;
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Menus_Delete(Guid id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}menus ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.VarChar,36)};
            parameters[0].Value = id;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="SoureClassID"></param>
        /// <param name="TargetClassID"></param>
        /// <param name="IsAsChildnode"></param>
        public void Menus_Move(Guid SoureClassID, Guid TargetClassID, bool IsAsChildnode)
        {

            string sqlStr;

            //将与源分类同级的分类，并且orderid大于源分类orderid的分类，-1补位

            //  sqlStr = string.Format("UPDATE [{0}Menus] SET [orderid]=[orderid]-1 WHERE [ParentID]=(select [parentid] from  {0}Menus where id='{1}') and [orderid]>(select orderid from  {0}Menus where id='{1}')", sPre, SoureClassID);


            sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}menus where id='{1}';", sPre, SoureClassID);
            sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}menus where id='{1}';", sPre, SoureClassID);
            sqlStr += string.Format(" UPDATE {0}menus SET orderid=orderid-1 WHERE   ParentID=(select col1 from tmp1) and orderid>(select col1 from tmp2);", sPre);
            sqlStr += string.Format("drop table tmp1;  drop table tmp2;");



            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);

            if (IsAsChildnode) //作为目标分类的子分类
            {

                //让目标分类下子分类的ID都加1，让位
                sqlStr = string.Format("UPDATE {0}menus SET orderid=orderid+1 WHERE ParentID='{1}'", sPre, TargetClassID);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);


                //先移到目标分类下并将orderid置为1
                sqlStr = string.Format("UPDATE {0}menus SET parentid='{1}' ,orderid=1 WHERE id='{2}'", sPre, TargetClassID, SoureClassID);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);



            }
            else  //调整到某个分类前面
            {


                //首先将与目标分类同级，并且orderid大于目标分类orderid 增加1,给源分类让位

                //  sqlStr = string.Format("UPDATE [{0}Menus] SET [orderid]=[orderid]+1  WHERE [parentid]=(select [Parentid] from  {0}Menus where id='{1}') and [orderid]>=(select orderid from  {0}Menus where id='{1}') ", sPre, TargetClassID);
                sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}menus where id='{1}';", sPre, TargetClassID);
                sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}menus where id='{1}';", sPre, TargetClassID);
                sqlStr += string.Format(" UPDATE {0}menus SET orderid=orderid+1 WHERE ParentID=(select col1 from tmp1) and orderid>=(select col1 from tmp2);", sPre);
                sqlStr += string.Format("drop table tmp1;  drop table tmp2;");
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);




                //将源分类更新到与目标分类同一父级下的分类,并将其orderid置为当前目标分类的orderid ，由于上面已经将目标分类加1，所以这里要减去1

                // sqlStr = string.Format("UPDATE [{0}Menus] SET [parentid]=(select [Parentid] from  {0}Menus where id='{1}'),[orderid]=(select orderid from  {0}Menus where id='{1}')-1  WHERE [id]='{2}'", sPre, TargetClassID, SoureClassID);
                sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}menus where id='{1}';", sPre, TargetClassID);
                sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}menus where id='{1}';", sPre, TargetClassID);
                sqlStr += string.Format(" UPDATE {0}Menus SET parentid=(select col1 from tmp1 ) ,orderid=(select col1 from tmp2)-1 WHERE id='{1}';", sPre, SoureClassID);
                sqlStr += string.Format("drop table tmp1;  drop table tmp2;");
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);


            }
        }
        public void Menus_DeleteByModuleID(Guid ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}menus ", sPre);
            strSql.Append(" where ModulesID=?ModulesID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ModulesID", MySqlDbType.VarChar,36)};
            parameters[0].Value = ModuleID;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

        #endregion 写

    }
}
