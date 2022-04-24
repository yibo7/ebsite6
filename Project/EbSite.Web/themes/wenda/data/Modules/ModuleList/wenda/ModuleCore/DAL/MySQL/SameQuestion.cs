using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Wenda.ModuleCore.DAL.MySQL
{
	/// <summary>
	/// 数据访问类bb。
	/// </summary>
    public partial class Ask
	{
		private string sFieldSameQuestion = "id,UserId,Cid,TDate";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int SameQuestion_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}SameQuestion",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool SameQuestion_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}SameQuestion",sPre);
			strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int SameQuestion_Add(Entity.SameQuestion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}SameQuestion(",sPre);
			strSql.Append("UserId,Cid,TDate)");
			strSql.Append(" values (");
			strSql.Append("?UserId,?Cid,?TDate)");
            strSql.Append(";SELECT @@session.identity");
            MySqlParameter[] parameters = {
					
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Cid", MySqlDbType.Int32,4),
					new MySqlParameter("?TDate", MySqlDbType.Datetime)};
			
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.Cid;
			parameters[2].Value = model.TDate;

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
		public void SameQuestion_Update(Entity.SameQuestion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}SameQuestion set ",sPre);
			strSql.Append("UserId=?UserId,");
			strSql.Append("Cid=?Cid,");
			strSql.Append("TDate=?TDate");
			strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?Cid", MySqlDbType.Int32,4),
					new MySqlParameter("?TDate", MySqlDbType.Datetime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.UserId;
			parameters[2].Value = model.Cid;
			parameters[3].Value = model.TDate;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void SameQuestion_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}SameQuestion ",sPre);
			strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.SameQuestion SameQuestion_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldSameQuestion +"  from {0}SameQuestion ",sPre);
			strSql.Append(" where id=?id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?id",  MySqlDbType.Int32,4)};
			parameters[0].Value = id;
			Entity.SameQuestion model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= SameQuestion_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int SameQuestion_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}SameQuestion ",sPre);
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
		public DataSet SameQuestion_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldSameQuestion );
			strSql.AppendFormat(" FROM {0}SameQuestion ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.SameQuestion> SameQuestion_GetListArray(string strWhere)
		{
			return SameQuestion_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.SameQuestion> SameQuestion_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldSameQuestion );
			strSql.AppendFormat(" FROM {0}SameQuestion ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
			List<Entity.SameQuestion> list = new List<Entity.SameQuestion>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(SameQuestion_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.SameQuestion> SameQuestion_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.SameQuestion> list = new List<Entity.SameQuestion>();
            RecordCount = Answers_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DB, "SameQuestion", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(SameQuestion_ReaderBind(dataReader));
                }
            }
            return list;
          
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.SameQuestion SameQuestion_ReaderBind(IDataReader dataReader)
		{
			Entity.SameQuestion model=new Entity.SameQuestion();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["UserId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserId=(int)ojb;
			}
			ojb = dataReader["Cid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Cid=(int)ojb;
			}
			ojb = dataReader["TDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.TDate = (DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

