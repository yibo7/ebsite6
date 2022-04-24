using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.BBS.ModuleCore.DAL.MySql
{
	/// <summary>
	/// 数据访问类BBS。
	/// </summary>
	public partial class BBS
	{
        private string sFieldimitateuser = "id,UserID,ImitateUserID,ImitateUserName,ImitateUserRealName,UserNiName";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int imitateuser_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}imitateuser",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool imitateuser_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}imitateuser",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int imitateuser_Add(Entity.imitateuser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}imitateuser(",sPre);
            strSql.Append("UserID,ImitateUserID,ImitateUserName,ImitateUserRealName,UserNiName)");
			strSql.Append(" values (");
            strSql.Append("?UserID,?ImitateUserID,?ImitateUserName,?ImitateUserRealName,?UserNiName)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?ImitateUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?ImitateUserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ImitateUserRealName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50)
                                          };
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.ImitateUserID;
			parameters[2].Value = model.ImitateUserName;
			parameters[3].Value = model.ImitateUserRealName;

            parameters[4].Value = model.UserNiName;
			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return imitateuser_GetMaxId();
			}
			return 0;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void imitateuser_Update(Entity.imitateuser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}imitateuser set ",sPre);
			strSql.Append("UserID=?UserID,");
			strSql.Append("ImitateUserID=?ImitateUserID,");
			strSql.Append("ImitateUserName=?ImitateUserName,");
			strSql.Append("ImitateUserRealName=?ImitateUserRealName,");

            strSql.Append("UserNiName=?UserNiName");

			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?ImitateUserID", MySqlDbType.Int32,11),
					new MySqlParameter("?ImitateUserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ImitateUserRealName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?UserNiName", MySqlDbType.VarChar,50)
                                          
                                          };
			parameters[0].Value = model.id;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.ImitateUserID;
			parameters[3].Value = model.ImitateUserName;
			parameters[4].Value = model.ImitateUserRealName;

            parameters[5].Value = model.UserNiName;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void imitateuser_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}imitateuser ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.imitateuser imitateuser_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldimitateuser +"  from {0}imitateuser ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.imitateuser model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= imitateuser_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int imitateuser_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}imitateuser ",sPre);
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			int iCount = 0;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text,strSql.ToString()))
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
		public DataSet imitateuser_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldimitateuser );
			strSql.AppendFormat(" FROM {0}imitateuser ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			if(Top>0)
			{
				strSql.Append(" limit "+Top.ToString());
			}
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.imitateuser> imitateuser_GetListArray(string strWhere)
		{
			return imitateuser_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.imitateuser> imitateuser_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldimitateuser );
			strSql.AppendFormat(" FROM {0}imitateuser ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			if(Top>0)
			{
				strSql.Append(" limit "+Top.ToString());
			}
			List<Entity.imitateuser> list = new List<Entity.imitateuser>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(imitateuser_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.imitateuser> imitateuser_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.imitateuser> list = new List<Entity.imitateuser>();
			RecordCount = imitateuser_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "imitateuser", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(imitateuser_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.imitateuser imitateuser_ReaderBind(IDataReader dataReader)
		{
			Entity.imitateuser model=new Entity.imitateuser();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			ojb = dataReader["ImitateUserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ImitateUserID=(int)ojb;
			}
			model.ImitateUserName=dataReader["ImitateUserName"].ToString();
			model.ImitateUserRealName=dataReader["ImitateUserRealName"].ToString();

            model.UserNiName = dataReader["UserNiName"].ToString();

        

			return model;
		}

		#endregion  成员方法


        public Entity.imitateuser GetRandByUserID(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select " + sFieldimitateuser + "  from {0}imitateuser ", sPre);
            strSql.Append(" where UserID=?UserID ORDER BY RAND() LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32)
                                          };
            parameters[0].Value = UserID;
            Entity.imitateuser model = null;
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(), parameters))
            {
                if (dataReader.Read())
                {
                    model = imitateuser_ReaderBind(dataReader);
                }
            }
            return model;
        }

	}
}

