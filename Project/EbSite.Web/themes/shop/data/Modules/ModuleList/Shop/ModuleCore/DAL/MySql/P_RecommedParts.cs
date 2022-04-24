using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
using MySql.Data.MySqlClient;
namespace EbSite.Modules.Shop.ModuleCore.DAL.MySql
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
    public partial class Shop
	{
		private string sFieldP_RecommedParts = "id,ProductID,PartsID,OrderiD,PartsAvatarSmall,PartsName";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int P_RecommedParts_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}P_RecommedParts",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool P_RecommedParts_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}P_RecommedParts",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int P_RecommedParts_Add(Entity.P_RecommedParts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}P_RecommedParts(",sPre);
			strSql.Append("ProductID,PartsID,OrderiD,PartsAvatarSmall,PartsName)");
			strSql.Append(" values (");
			strSql.Append("?ProductID,?PartsID,?OrderiD,?PartsAvatarSmall,?PartsName)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
				
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
					new MySqlParameter("?PartsID", MySqlDbType.VarChar,10),
					new MySqlParameter("?OrderiD", MySqlDbType.VarChar,10),
					new MySqlParameter("?PartsAvatarSmall", MySqlDbType.VarChar,200),
					new MySqlParameter("?PartsName", MySqlDbType.VarChar,200)};
		
			parameters[0].Value = model.ProductID;
			parameters[1].Value = model.PartsID;
			parameters[2].Value = model.OrderiD;
			parameters[3].Value = model.PartsAvatarSmall;
			parameters[4].Value = model.PartsName;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
			return 0;		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void P_RecommedParts_Update(Entity.P_RecommedParts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}P_RecommedParts set ",sPre);
			strSql.Append("ProductID=?ProductID,");
			strSql.Append("PartsID=?PartsID,");
			strSql.Append("OrderiD=?OrderiD,");
			strSql.Append("PartsAvatarSmall=?PartsAvatarSmall,");
			strSql.Append("PartsName=?PartsName");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,4),
					new MySqlParameter("?PartsID", MySqlDbType.VarChar,10),
					new MySqlParameter("?OrderiD", MySqlDbType.VarChar,10),
					new MySqlParameter("?PartsAvatarSmall", MySqlDbType.VarChar,200),
					new MySqlParameter("?PartsName", MySqlDbType.VarChar,200)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductID;
			parameters[2].Value = model.PartsID;
			parameters[3].Value = model.OrderiD;
			parameters[4].Value = model.PartsAvatarSmall;
			parameters[5].Value = model.PartsName;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void P_RecommedParts_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}P_RecommedParts ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.P_RecommedParts P_RecommedParts_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldP_RecommedParts +"  from {0}P_RecommedParts ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;
			Entity.P_RecommedParts model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= P_RecommedParts_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int P_RecommedParts_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}P_RecommedParts ",sPre);
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
		public DataSet P_RecommedParts_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldP_RecommedParts );
			strSql.AppendFormat(" FROM {0}P_RecommedParts ",sPre);
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
		public List<Entity.P_RecommedParts> P_RecommedParts_GetListArray(string strWhere)
		{
			return P_RecommedParts_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.P_RecommedParts> P_RecommedParts_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldP_RecommedParts );
			strSql.AppendFormat(" FROM {0}P_RecommedParts ",sPre);
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
			List<Entity.P_RecommedParts> list = new List<Entity.P_RecommedParts>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(P_RecommedParts_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.P_RecommedParts> P_RecommedParts_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            StringBuilder sbSql = new StringBuilder();
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" where ");
                sbSql.AppendFormat(strWhere);
            }
            RecordCount = P_RecommedParts_GetCount(sbSql.ToString());
            List<Entity.P_RecommedParts> list = new List<Entity.P_RecommedParts>();
            string strSql = SplitPages.GetSplitPagesMySql(DB, "P_RecommedParts", PageSize, PageIndex, Fileds, "id", oderby, sbSql.ToString(), sPre);
            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(P_RecommedParts_ReaderBind(dataReader));
                }
            }
            return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.P_RecommedParts P_RecommedParts_ReaderBind(IDataReader dataReader)
		{
			Entity.P_RecommedParts model=new Entity.P_RecommedParts();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
			}
			model.PartsID=dataReader["PartsID"].ToString();
			model.OrderiD=dataReader["OrderiD"].ToString();
			model.PartsAvatarSmall=dataReader["PartsAvatarSmall"].ToString();
			model.PartsName=dataReader["PartsName"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

