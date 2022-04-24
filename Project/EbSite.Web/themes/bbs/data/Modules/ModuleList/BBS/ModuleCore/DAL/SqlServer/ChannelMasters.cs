using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.BBS.ModuleCore.DAL.SqlServer
{
	/// <summary>
	/// 数据访问类BBS。
	/// </summary>
	public partial class BBS
	{
		private string sFieldChannelMasters = "id,ChannelID,ChannelName,UserID,UserName,CreatedTime,CompanyID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int ChannelMasters_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}ChannelMasters",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ChannelMasters_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}ChannelMasters",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int ChannelMasters_Add(Entity.ChannelMasters model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}ChannelMasters(",sPre);
			strSql.Append("ChannelID,ChannelName,UserID,UserName,CreatedTime,CompanyID)");
			strSql.Append(" values (");
			strSql.Append("@ChannelID,@ChannelName,@UserID,@UserName,@CreatedTime,@CompanyID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@ChannelName", SqlDbType.VarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			
			parameters[0].Value = model.ChannelID;
			parameters[1].Value = model.ChannelName;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.CreatedTime;
			parameters[5].Value = model.CompanyID;

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
		public void ChannelMasters_Update(Entity.ChannelMasters model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}ChannelMasters set ",sPre);
			strSql.Append("ChannelID=@ChannelID,");
			strSql.Append("ChannelName=@ChannelName,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("CreatedTime=@CreatedTime,");
			strSql.Append("CompanyID=@CompanyID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@ChannelName", SqlDbType.VarChar,200),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ChannelID;
			parameters[2].Value = model.ChannelName;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.UserName;
			parameters[5].Value = model.CreatedTime;
			parameters[6].Value = model.CompanyID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void ChannelMasters_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}ChannelMasters ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.ChannelMasters ChannelMasters_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldChannelMasters +"  from {0}ChannelMasters ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.ChannelMasters model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= ChannelMasters_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int ChannelMasters_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}ChannelMasters ",sPre);
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
		public DataSet ChannelMasters_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldChannelMasters );
			strSql.AppendFormat(" FROM {0}ChannelMasters ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.ChannelMasters> ChannelMasters_GetListArray(string strWhere)
		{
			return ChannelMasters_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.ChannelMasters> ChannelMasters_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldChannelMasters );
			strSql.AppendFormat(" FROM {0}ChannelMasters ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.ChannelMasters> list = new List<Entity.ChannelMasters>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ChannelMasters_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.ChannelMasters> ChannelMasters_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.ChannelMasters> list = new List<Entity.ChannelMasters>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"ChannelMasters", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(ChannelMasters_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.ChannelMasters ChannelMasters_ReaderBind(IDataReader dataReader)
		{
			Entity.ChannelMasters model=new Entity.ChannelMasters();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ChannelID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ChannelID=(int)ojb;
			}
			model.ChannelName=dataReader["ChannelName"].ToString();
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			ojb = dataReader["CreatedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreatedTime=(DateTime)ojb;
			}
			ojb = dataReader["CompanyID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CompanyID=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

