using System;
using System.Data;
using System.Text;

using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;

namespace EbSite.Modules.Wenda.ModuleCore.DAL.MySQL
{
	/// <summary>
	/// 数据访问类EbSite.Modules.Wenda。
	/// </summary>
	public partial class Ask
	{
        private string sFieldexpertAsk = "id,Qid,UserID,State,OpTime,Title,AskDate,ClassId";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int expertAsk_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}expertAsk",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool expertAsk_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}expertAsk",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int expertAsk_Add(Entity.expertAsk model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}expertAsk(",sPre);
            strSql.Append("Qid,UserID,State,OpTime,Title,AskDate,ClassId)");
			strSql.Append(" values (");
            strSql.Append("?Qid,?UserID,?State,?OpTime,?Title,?AskDate,?ClassId)");
            strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					
					new MySqlParameter("?Qid", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?State", MySqlDbType.Int32,4),
					new MySqlParameter("?OpTime", MySqlDbType.DateTime),
                    new MySqlParameter("?Title",MySqlDbType.VarChar,255),
					new MySqlParameter("?AskDate", MySqlDbType.DateTime),
                    new MySqlParameter("?ClassId",MySqlDbType.Int32,4) 
                                          };
			
			parameters[0].Value = model.Qid;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.State;
			parameters[3].Value = model.OpTime;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.AskDate;
		    parameters[6].Value = model.ClassID;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}	
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void expertAsk_Update(Entity.expertAsk model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}expertAsk set ",sPre);
			strSql.Append("Qid=?Qid,");
			strSql.Append("UserID=?UserID,");
			strSql.Append("State=?State,");
			strSql.Append("OpTime=?OpTime,");
            strSql.Append("Title=?Title,");
            strSql.Append("AskDate=?AskDate,");
		    strSql.Append("ClassId=?ClassId");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4),
					new MySqlParameter("?Qid", MySqlDbType.Int32,4),
					new MySqlParameter("?UserID", MySqlDbType.Int32,4),
					new MySqlParameter("?State", MySqlDbType.Int32,4),
					new MySqlParameter("?OpTime", MySqlDbType.DateTime),
                    new MySqlParameter("?Title",MySqlDbType.VarChar,255),
					new MySqlParameter("?AskDate", MySqlDbType.DateTime),
                    new MySqlParameter("?ClassId",MySqlDbType.Int32,4) 
 
                                          };
			parameters[0].Value = model.id;
			parameters[1].Value = model.Qid;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.State;
			parameters[4].Value = model.OpTime;
            parameters[5].Value = model.Title;
            parameters[6].Value = model.AskDate;
		    parameters[7].Value = model.ClassID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void expertAsk_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}expertAsk ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.expertAsk expertAsk_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldexpertAsk +"  from {0}expertAsk ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,4)};
			parameters[0].Value = id;
			Entity.expertAsk model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= expertAsk_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int expertAsk_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}expertAsk ",sPre);
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
		public DataSet expertAsk_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldexpertAsk );
			strSql.AppendFormat(" FROM {0}expertAsk ",sPre);
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
		public List<Entity.expertAsk> expertAsk_GetListArray(string strWhere)
		{
			return expertAsk_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.expertAsk> expertAsk_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldexpertAsk );
			strSql.AppendFormat(" FROM {0}expertAsk ",sPre);
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
			List<Entity.expertAsk> list = new List<Entity.expertAsk>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(expertAsk_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.expertAsk> expertAsk_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
            List<Entity.expertAsk> list = new List<Entity.expertAsk>();
            RecordCount = expertAsk_GetCount(strWhere);
            string strSql = SplitPages.GetSplitPagesMySql(DB, "expertAsk", PageSize, PageIndex, Fileds, "id", oderby, strWhere, sPre);

            using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql))
            {
                while (dataReader.Read())
                {
                    list.Add(expertAsk_ReaderBind(dataReader));
                }
            }
            return list;
			
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.expertAsk expertAsk_ReaderBind(IDataReader dataReader)
		{
			Entity.expertAsk model=new Entity.expertAsk();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["Qid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Qid=(int)ojb;
			}
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			ojb = dataReader["State"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.State=(int)ojb;
			}
			ojb = dataReader["OpTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OpTime=(DateTime)ojb;
			}
            model.Title  = dataReader["Title"].ToString();
            
            ojb = dataReader["AskDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AskDate = (DateTime)ojb;
            }

            ojb = dataReader["ClassID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ClassID = (int) ojb;
            }
			return model;
		}

		#endregion  成员方法
	}
}

