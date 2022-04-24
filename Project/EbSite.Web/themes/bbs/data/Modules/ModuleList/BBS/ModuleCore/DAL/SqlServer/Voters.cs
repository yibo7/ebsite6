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
		private string sFieldVoters = "id,VoteID,VoteContent,UserID,UserName,UserHeadImageUrl,CreatedTime,CreatedIP,CompanyID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int Voters_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}Voters",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Voters_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Voters",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Voters_Add(Entity.Voters model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Voters(",sPre);
			strSql.Append("id,VoteID,VoteContent,UserID,UserName,UserHeadImageUrl,CreatedTime,CreatedIP,CompanyID)");
			strSql.Append(" values (");
			strSql.Append("@id,@VoteID,@VoteContent,@UserID,@UserName,@UserHeadImageUrl,@CreatedTime,@CreatedIP,@CompanyID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@VoteID", SqlDbType.Int,4),
					new SqlParameter("@VoteContent", SqlDbType.VarChar,5000),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@UserHeadImageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CreatedIP", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.VoteID;
			parameters[2].Value = model.VoteContent;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.UserName;
			parameters[5].Value = model.UserHeadImageUrl;
			parameters[6].Value = model.CreatedTime;
			parameters[7].Value = model.CreatedIP;
			parameters[8].Value = model.CompanyID;

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
		public void Voters_Update(Entity.Voters model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Voters set ",sPre);
			strSql.Append("VoteID=@VoteID,");
			strSql.Append("VoteContent=@VoteContent,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserHeadImageUrl=@UserHeadImageUrl,");
			strSql.Append("CreatedTime=@CreatedTime,");
			strSql.Append("CreatedIP=@CreatedIP,");
			strSql.Append("CompanyID=@CompanyID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@VoteID", SqlDbType.Int,4),
					new SqlParameter("@VoteContent", SqlDbType.VarChar,5000),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@UserHeadImageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CreatedIP", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.VoteID;
			parameters[2].Value = model.VoteContent;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.UserName;
			parameters[5].Value = model.UserHeadImageUrl;
			parameters[6].Value = model.CreatedTime;
			parameters[7].Value = model.CreatedIP;
			parameters[8].Value = model.CompanyID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Voters_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Voters ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Voters Voters_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldVoters +"  from {0}Voters ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.Voters model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Voters_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Voters_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Voters ",sPre);
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
		public DataSet Voters_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldVoters );
			strSql.AppendFormat(" FROM {0}Voters ",sPre);
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
		public List<Entity.Voters> Voters_GetListArray(string strWhere)
		{
			return Voters_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Voters> Voters_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldVoters );
			strSql.AppendFormat(" FROM {0}Voters ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.Voters> list = new List<Entity.Voters>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Voters_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Voters> Voters_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.Voters> list = new List<Entity.Voters>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"Voters", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(Voters_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Voters Voters_ReaderBind(IDataReader dataReader)
		{
			Entity.Voters model=new Entity.Voters();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["VoteID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteID=(int)ojb;
			}
			model.VoteContent=dataReader["VoteContent"].ToString();
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.UserHeadImageUrl=dataReader["UserHeadImageUrl"].ToString();
			ojb = dataReader["CreatedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreatedTime=(DateTime)ojb;
			}
			model.CreatedIP=dataReader["CreatedIP"].ToString();
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

