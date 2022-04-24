using System;
using System.Data;
using System.Text;
using EbSite.Base;
using MySql.Data.MySqlClient;
using EbSite.Base.DataProfile;//请先添加引用
using System.Collections.Generic;
namespace EbSite.Data.MySql
{
	/// <summary>
	/// 数据访问类MenusForUser。
	/// </summary>
    public partial class DataProviderCms : Interface.IDataProviderCms
	{
        private string sFieldMenusForUser = "id,MenuName,ImageUrl,OrderID,ParentID,Target,ModuleMenuID,PageUrl,IsLeftParent,ModulesID,AddTime,MenuType";

        #region 读

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool MenusForUser_Exists(Guid id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from {0}menusforuser", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.VarChar,36)};
            parameters[0].Value = id;

            return DbHelperCms.Instance.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.MenusForUser MenusForUser_GetEntity(Guid id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldMenusForUser + "  from {0}menusforuser ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.VarChar,36)};
            parameters[0].Value = id;
            Entity.MenusForUser model = null;
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = MenusForUser_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获取统计
        /// </summary>
        public int MenusForUser_GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(*)  from {0}menusforuser ", sPre);
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
        public DataSet MenusForUser_GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldMenusForUser);
            strSql.AppendFormat(" FROM {0}menusforuser ", sPre);
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
        public List<Entity.MenusForUser> MenusForUser_GetListArray(string strWhere)
        {
            return MenusForUser_GetListArray(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<Entity.MenusForUser> MenusForUser_GetListArray(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");

            strSql.Append(sFieldMenusForUser);
            strSql.AppendFormat(" FROM {0}menusforuser  ", sPre);
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
            List<Entity.MenusForUser> list = new List<Entity.MenusForUser>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(MenusForUser_ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 获得分页数据
        /// </summary>
        public List<Entity.MenusForUser> MenusForUser_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby, out int RecordCount)
        {
            List<Entity.MenusForUser> list = new List<Entity.MenusForUser>();
            RecordCount = MenusForUser_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "MenusForUser", PageSize, PageIndex, "", "id", oderby, strWhere, sPre);
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(MenusForUser_ReaderBind(dataReader));
                }
            }
            return list;
        }


        public int MenusForUser_GetMaxOrderID(Guid ParentID)
        {
            string sSql = string.Concat("select Max(orderid)  from  ", sPre, "MenusForUser where Parentid='", ParentID, "'");
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

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Entity.MenusForUser MenusForUser_ReaderBind(IDataReader dataReader)
        {
            Entity.MenusForUser model = new Entity.MenusForUser();
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

            model.Target = dataReader["Target"].ToString();
            model.ModuleMenuID = new Guid(dataReader["ModuleMenuID"].ToString());
            model.PageUrl = dataReader["PageUrl"].ToString();
            ojb = dataReader["IsLeftParent"];
            if (ojb != null && ojb != DBNull.Value)
            {
                if ((ojb.ToString() == "1") || (ojb.ToString().ToLower() == "true"))
                {
                    model.IsLeftParent = true;
                }
                else
                {
                    model.IsLeftParent = false;
                }
                //model.IsLeftParent=(bool)ojb;
            }
            model.ModulesID = new Guid(dataReader["ModulesID"].ToString());

            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = (DateTime)ojb;
            }
            ojb = dataReader["MenuType"];

            if (ojb != null && ojb != DBNull.Value)
            {
                if ((ojb.ToString() == "1"))
                {
                    model.MenuType = ThemeType.PC;
                }
                else
                {
                    model.MenuType = ThemeType.MOBILE;
                }

            }

            model.MarkOld();
            return model;
        }

        #endregion 读

        #region 写

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void MenusForUser_Add(Entity.MenusForUser model)
        {
            MenusForUser_Add(model, null);
        }
        /// <summary>
        /// 增加一条数据(事务处理)
        /// </summary>
        public void MenusForUser_Add(Entity.MenusForUser model, MySqlTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}menusforuser(", sPre);
            strSql.Append("id,MenuName,ImageUrl,OrderID,ParentID,Target,ModuleMenuID,PageUrl,IsLeftParent,ModulesID,AddTime,MenuType)");
            strSql.Append(" values (");
            strSql.Append("?id,?MenuName,?ImageUrl,?OrderID,?ParentID,?Target,?ModuleMenuID,?PageUrl,?IsLeftParent,?ModulesID,?AddTime,?MenuType)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.VarChar,36),
					new MySqlParameter("?MenuName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID", MySqlDbType.VarChar,36),
					new MySqlParameter("?Target", MySqlDbType.VarChar,300),
					new MySqlParameter("?ModuleMenuID", MySqlDbType.VarChar,36),
					new MySqlParameter("?PageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?IsLeftParent", MySqlDbType.Int16,1),
					new MySqlParameter("?ModulesID", MySqlDbType.VarChar,36),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?MenuType", MySqlDbType.Int16,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.MenuName;
            parameters[2].Value = model.ImageUrl;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.ParentID;
            parameters[5].Value = model.Target;
            parameters[6].Value = model.ModuleMenuID;
            parameters[7].Value = model.PageUrl;
            parameters[8].Value = model.IsLeftParent;
            parameters[9].Value = model.ModulesID;
            parameters[10].Value = model.AddTime;
            parameters[11].Value = model.MenuType;
            if (Trans == null)
            {
                DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DbHelperCmsWrite.Instance.ExecuteScalar(Trans, CommandType.Text, strSql.ToString(), parameters);
            }
            //return "";
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void MenusForUser_Update(Entity.MenusForUser model)
        {
            MenusForUser_Update(model, null);
        }

        /// <summary>
        /// 更新一条数据(事务处理)
        /// </summary>
        public void MenusForUser_Update(Entity.MenusForUser model, MySqlTransaction Trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}menusforuser set ", sPre);
            strSql.Append("MenuName=?MenuName,");
            strSql.Append("ImageUrl=?ImageUrl,");
            strSql.Append("OrderID=?OrderID,");
            strSql.Append("ParentID=?ParentID,");
            strSql.Append("Target=?Target,");
            strSql.Append("ModuleMenuID=?ModuleMenuID,");
            strSql.Append("PageUrl=?PageUrl,");
            strSql.Append("IsLeftParent=?IsLeftParent,");
            strSql.Append("ModulesID=?ModulesID,");
            strSql.Append("AddTime=?AddTime,");
            strSql.Append("MenuType=?MenuType");
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.VarChar,36),
					new MySqlParameter("?MenuName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ImageUrl", MySqlDbType.VarChar,50),
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ParentID", MySqlDbType.VarChar,36),
					new MySqlParameter("?Target", MySqlDbType.VarChar,300),
					new MySqlParameter("?ModuleMenuID", MySqlDbType.VarChar,36),
					new MySqlParameter("?PageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?IsLeftParent", MySqlDbType.Int16,1),
					new MySqlParameter("?ModulesID", MySqlDbType.VarChar,36),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?MenuType", MySqlDbType.Int16,1)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.MenuName;
            parameters[2].Value = model.ImageUrl;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.ParentID;
            parameters[5].Value = model.Target;
            parameters[6].Value = model.ModuleMenuID;
            parameters[7].Value = model.PageUrl;
            parameters[8].Value = model.IsLeftParent;
            parameters[9].Value = model.ModulesID;
            parameters[10].Value = model.AddTime;
            parameters[11].Value = model.MenuType;

            if (Trans == null)
            {
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DbHelperCmsWrite.Instance.ExecuteNonQuery(Trans, CommandType.Text, strSql.ToString(), parameters);
            }
        }
        public void MenusForUser_DeleteByModulID(Guid mid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}menusforuser ", sPre);
            strSql.Append(" where ModulesID=?ModulesID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ModulesID", MySqlDbType.VarChar,36)};
            parameters[0].Value = mid;

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void MenusForUser_Delete(Guid id)
        {
            MenusForUser_Delete(id, null);
        }

        /// <summary>
        /// 删除一条数据(事务处理)
        /// </summary>
        public void MenusForUser_Delete(Guid id, MySqlTransaction Trans)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}menusforuser ", sPre);
            strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.VarChar,36)};
            parameters[0].Value = id;

            if (Trans == null)
            {
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
            }
            else
            {
                DbHelperCmsWrite.Instance.ExecuteNonQuery(Trans, CommandType.Text, strSql.ToString(), parameters);
            }
        }
        /// <summary>
        /// 移动分类
        /// </summary>
        /// <param name="SoureClassID"></param>
        /// <param name="TargetClassID"></param>
        /// <param name="IsAsChildnode"></param>
        public void MenusForUser_Move(Guid SoureClassID, Guid TargetClassID, bool IsAsChildnode)
        {

            string sqlStr;

            //将与源分类同级的分类，并且orderid大于源分类orderid的分类，-1补位

            // sqlStr = string.Format("UPDATE [{0}menusforuser] SET [orderid]=[orderid]-1 WHERE [ParentID]=(select [parentid] from  {0}menusforuser where id='{1}') and [orderid]>(select orderid from  {0}menusforuser where id='{1}')", sPre, SoureClassID);
            sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}menusforuser where id='{1}';", sPre, SoureClassID);
            sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}menusforuser where id='{1}';", sPre, SoureClassID);
            sqlStr += string.Format(" UPDATE {0}menusforuser SET orderid=orderid-1 WHERE   ParentID=(select col1 from tmp1) and orderid>(select col1 from tmp2);", sPre);
            sqlStr += string.Format("drop table tmp1;  drop table tmp2;");

            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);

            if (IsAsChildnode) //作为目标分类的子分类
            {

                //让目标分类下子分类的ID都加1，让位
                sqlStr = string.Format("UPDATE {0}menusforuser SET orderid=orderid+1 WHERE ParentID='{1}'", sPre, TargetClassID);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);


                //先移到目标分类下并将orderid置为1
                sqlStr = string.Format("UPDATE {0}menusforuser SET parentid='{1}' ,orderid=1 WHERE id='{2}'", sPre, TargetClassID, SoureClassID);
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);



            }
            else  //调整到某个分类前面
            {


                //首先将与目标分类同级，并且orderid大于目标分类orderid 增加1,给源分类让位

                // sqlStr = string.Format("UPDATE [{0}menusforuser] SET [orderid]=[orderid]+1  WHERE [parentid]=(select [Parentid] from  {0}menusforuser where id='{1}') and [orderid]>=(select orderid from  {0}menusforuser where id='{1}') ", sPre, TargetClassID);
                sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}menusforuser where id='{1}';", sPre, TargetClassID);
                sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}menusforuser where id='{1}';", sPre, TargetClassID);
                sqlStr += string.Format(" UPDATE {0}menusforuser SET orderid=orderid+1 WHERE ParentID=(select col1 from tmp1) and orderid>=(select col1 from tmp2);", sPre);
                sqlStr += string.Format("drop table tmp1;  drop table tmp2;");
                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);




                //将源分类更新到与目标分类同一父级下的分类,并将其orderid置为当前目标分类的orderid ，由于上面已经将目标分类加1，所以这里要减去1

                // sqlStr = string.Format("UPDATE [{0}menusforuser] SET [parentid]=(select [Parentid] from  {0}menusforuser where id='{1}'),[orderid]=(select orderid from  {0}menusforuser where id='{1}')-1  WHERE [id]='{2}'", sPre, TargetClassID, SoureClassID);
                sqlStr = string.Format(" create table tmp1 as select parentid  as col1 from {0}menusforuser where id='{1}';", sPre, TargetClassID);
                sqlStr += string.Format(" create table tmp2 as select orderid as col1 from  {0}menusforuser where id='{1}';", sPre, TargetClassID);
                sqlStr += string.Format(" UPDATE {0}menusforuser SET parentid=(select col1 from tmp1 ) ,orderid=(select col1 from tmp2)-1 WHERE id='{1}';", sPre, SoureClassID);
                sqlStr += string.Format("drop table tmp1;  drop table tmp2;");

                DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, sqlStr);


            }
        }

        #endregion 写
    }
}

