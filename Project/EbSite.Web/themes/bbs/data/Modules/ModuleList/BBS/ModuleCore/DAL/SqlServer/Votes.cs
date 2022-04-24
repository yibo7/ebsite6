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
		private string sFieldVotes = "id,VoteName,UserID,UserName,UserHeadImageUrl,VoteDescription,VoteConclusion,OptionCount,OptionFlag,VoteCount,CreatedTime,CreatedIP,UpdatedTime,ExpiredTime,LockFlag,BBSTopicID,CompanyID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int Votes_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}Votes",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Votes_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Votes",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Votes_Add(Entity.Votes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Votes(",sPre);
			strSql.Append("id,VoteName,UserID,UserName,UserHeadImageUrl,VoteDescription,VoteConclusion,OptionCount,OptionFlag,VoteCount,CreatedTime,CreatedIP,UpdatedTime,ExpiredTime,LockFlag,BBSTopicID,CompanyID)");
			strSql.Append(" values (");
			strSql.Append("@id,@VoteName,@UserID,@UserName,@UserHeadImageUrl,@VoteDescription,@VoteConclusion,@OptionCount,@OptionFlag,@VoteCount,@CreatedTime,@CreatedIP,@UpdatedTime,@ExpiredTime,@LockFlag,@BBSTopicID,@CompanyID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@VoteName", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@UserHeadImageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@VoteDescription", SqlDbType.VarChar,5000),
					new SqlParameter("@VoteConclusion", SqlDbType.VarChar,5000),
					new SqlParameter("@OptionCount", SqlDbType.Int,4),
					new SqlParameter("@OptionFlag", SqlDbType.Int,4),
					new SqlParameter("@VoteCount", SqlDbType.Int,4),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CreatedIP", SqlDbType.VarChar,50),
					new SqlParameter("@UpdatedTime", SqlDbType.DateTime),
					new SqlParameter("@ExpiredTime", SqlDbType.DateTime),
					new SqlParameter("@LockFlag", SqlDbType.Int,4),
					new SqlParameter("@BBSTopicID", SqlDbType.BigInt,8),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.VoteName;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.UserHeadImageUrl;
			parameters[5].Value = model.VoteDescription;
			parameters[6].Value = model.VoteConclusion;
			parameters[7].Value = model.OptionCount;
			parameters[8].Value = model.OptionFlag;
			parameters[9].Value = model.VoteCount;
			parameters[10].Value = model.CreatedTime;
			parameters[11].Value = model.CreatedIP;
			parameters[12].Value = model.UpdatedTime;
			parameters[13].Value = model.ExpiredTime;
			parameters[14].Value = model.LockFlag;
			parameters[15].Value = model.BBSTopicID;
			parameters[16].Value = model.CompanyID;

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
		public void Votes_Update(Entity.Votes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Votes set ",sPre);
			strSql.Append("VoteName=@VoteName,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserHeadImageUrl=@UserHeadImageUrl,");
			strSql.Append("VoteDescription=@VoteDescription,");
			strSql.Append("VoteConclusion=@VoteConclusion,");
			strSql.Append("OptionCount=@OptionCount,");
			strSql.Append("OptionFlag=@OptionFlag,");
			strSql.Append("VoteCount=@VoteCount,");
			strSql.Append("CreatedTime=@CreatedTime,");
			strSql.Append("CreatedIP=@CreatedIP,");
			strSql.Append("UpdatedTime=@UpdatedTime,");
			strSql.Append("ExpiredTime=@ExpiredTime,");
			strSql.Append("LockFlag=@LockFlag,");
			strSql.Append("BBSTopicID=@BBSTopicID,");
			strSql.Append("CompanyID=@CompanyID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@VoteName", SqlDbType.VarChar,50),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@UserHeadImageUrl", SqlDbType.VarChar,500),
					new SqlParameter("@VoteDescription", SqlDbType.VarChar,5000),
					new SqlParameter("@VoteConclusion", SqlDbType.VarChar,5000),
					new SqlParameter("@OptionCount", SqlDbType.Int,4),
					new SqlParameter("@OptionFlag", SqlDbType.Int,4),
					new SqlParameter("@VoteCount", SqlDbType.Int,4),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CreatedIP", SqlDbType.VarChar,50),
					new SqlParameter("@UpdatedTime", SqlDbType.DateTime),
					new SqlParameter("@ExpiredTime", SqlDbType.DateTime),
					new SqlParameter("@LockFlag", SqlDbType.Int,4),
					new SqlParameter("@BBSTopicID", SqlDbType.BigInt,8),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.VoteName;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.UserHeadImageUrl;
			parameters[5].Value = model.VoteDescription;
			parameters[6].Value = model.VoteConclusion;
			parameters[7].Value = model.OptionCount;
			parameters[8].Value = model.OptionFlag;
			parameters[9].Value = model.VoteCount;
			parameters[10].Value = model.CreatedTime;
			parameters[11].Value = model.CreatedIP;
			parameters[12].Value = model.UpdatedTime;
			parameters[13].Value = model.ExpiredTime;
			parameters[14].Value = model.LockFlag;
			parameters[15].Value = model.BBSTopicID;
			parameters[16].Value = model.CompanyID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Votes_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Votes ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Votes Votes_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldVotes +"  from {0}Votes ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.Votes model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Votes_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Votes_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Votes ",sPre);
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
		public DataSet Votes_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldVotes );
			strSql.AppendFormat(" FROM {0}Votes ",sPre);
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
		public List<Entity.Votes> Votes_GetListArray(string strWhere)
		{
			return Votes_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Votes> Votes_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldVotes );
			strSql.AppendFormat(" FROM {0}Votes ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.Votes> list = new List<Entity.Votes>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Votes_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Votes> Votes_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.Votes> list = new List<Entity.Votes>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"Votes", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(Votes_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Votes Votes_ReaderBind(IDataReader dataReader)
		{
			Entity.Votes model=new Entity.Votes();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.VoteName=dataReader["VoteName"].ToString();
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			model.UserHeadImageUrl=dataReader["UserHeadImageUrl"].ToString();
			model.VoteDescription=dataReader["VoteDescription"].ToString();
			model.VoteConclusion=dataReader["VoteConclusion"].ToString();
			ojb = dataReader["OptionCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OptionCount=(int)ojb;
			}
			ojb = dataReader["OptionFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OptionFlag=(int)ojb;
			}
			ojb = dataReader["VoteCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VoteCount=(int)ojb;
			}
			ojb = dataReader["CreatedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreatedTime=(DateTime)ojb;
			}
			model.CreatedIP=dataReader["CreatedIP"].ToString();
			ojb = dataReader["UpdatedTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UpdatedTime=(DateTime)ojb;
			}
			ojb = dataReader["ExpiredTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ExpiredTime=(DateTime)ojb;
			}
			ojb = dataReader["LockFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LockFlag=(int)ojb;
			}
			ojb = dataReader["BBSTopicID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BBSTopicID=(long)ojb;
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

