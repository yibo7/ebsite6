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
		private string sFieldTopicReplies = "id,TopicID,UserID,UserName,IsGoodCount,IsBadCount,DeleteFlag,AuditFlag,ReplyContent,ReferenceFlag,ReferenceContent,CreatedTime,CreatedIP,UpdatedTime,CompanyID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public long TopicReplies_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}TopicReplies",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool TopicReplies_Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}TopicReplies",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public long TopicReplies_Add(Entity.TopicReplies model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}TopicReplies(",sPre);
			strSql.Append("TopicID,UserID,UserName,IsGoodCount,IsBadCount,DeleteFlag,AuditFlag,ReplyContent,ReferenceFlag,ReferenceContent,CreatedTime,CreatedIP,UpdatedTime,CompanyID)");
			strSql.Append(" values (");
			strSql.Append("@TopicID,@UserID,@UserName,@IsGoodCount,@IsBadCount,@DeleteFlag,@AuditFlag,@ReplyContent,@ReferenceFlag,@ReferenceContent,@CreatedTime,@CreatedIP,@UpdatedTime,@CompanyID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@TopicID", SqlDbType.BigInt,8),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@IsGoodCount", SqlDbType.Int,4),
					new SqlParameter("@IsBadCount", SqlDbType.Int,4),
					new SqlParameter("@DeleteFlag", SqlDbType.Int,4),
					new SqlParameter("@AuditFlag", SqlDbType.Int,4),
					new SqlParameter("@ReplyContent", SqlDbType.NText),
					new SqlParameter("@ReferenceFlag", SqlDbType.Int,4),
					new SqlParameter("@ReferenceContent", SqlDbType.NText),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CreatedIP", SqlDbType.VarChar,50),
					new SqlParameter("@UpdatedTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			
			parameters[0].Value = model.TopicID;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.IsGoodCount;
			parameters[4].Value = model.IsBadCount;
			parameters[5].Value = model.DeleteFlag;
			parameters[6].Value = model.AuditFlag;
			parameters[7].Value = model.ReplyContent;
			parameters[8].Value = model.ReferenceFlag;
			parameters[9].Value = model.ReferenceContent;
			parameters[10].Value = model.CreatedTime;
			parameters[11].Value = model.CreatedIP;
			parameters[12].Value = model.UpdatedTime;

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
		public void TopicReplies_Update(Entity.TopicReplies model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}TopicReplies set ",sPre);
			strSql.Append("TopicID=@TopicID,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("IsGoodCount=@IsGoodCount,");
			strSql.Append("IsBadCount=@IsBadCount,");
			strSql.Append("DeleteFlag=@DeleteFlag,");
			strSql.Append("AuditFlag=@AuditFlag,");
			strSql.Append("ReplyContent=@ReplyContent,");
			strSql.Append("ReferenceFlag=@ReferenceFlag,");
			strSql.Append("ReferenceContent=@ReferenceContent,");
			strSql.Append("CreatedTime=@CreatedTime,");
			strSql.Append("CreatedIP=@CreatedIP,");
			strSql.Append("UpdatedTime=@UpdatedTime,");
			strSql.Append("CompanyID=@CompanyID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@TopicID", SqlDbType.BigInt,8),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@IsGoodCount", SqlDbType.Int,4),
					new SqlParameter("@IsBadCount", SqlDbType.Int,4),
					new SqlParameter("@DeleteFlag", SqlDbType.Int,4),
					new SqlParameter("@AuditFlag", SqlDbType.Int,4),
					new SqlParameter("@ReplyContent", SqlDbType.NText),
					new SqlParameter("@ReferenceFlag", SqlDbType.Int,4),
					new SqlParameter("@ReferenceContent", SqlDbType.NText),
					new SqlParameter("@CreatedTime", SqlDbType.DateTime),
					new SqlParameter("@CreatedIP", SqlDbType.VarChar,50),
					new SqlParameter("@UpdatedTime", SqlDbType.DateTime),
					new SqlParameter("@CompanyID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.TopicID;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.IsGoodCount;
			parameters[5].Value = model.IsBadCount;
			parameters[6].Value = model.DeleteFlag;
			parameters[7].Value = model.AuditFlag;
			parameters[8].Value = model.ReplyContent;
			parameters[9].Value = model.ReferenceFlag;
			parameters[10].Value = model.ReferenceContent;
			parameters[11].Value = model.CreatedTime;
			parameters[12].Value = model.CreatedIP;
			parameters[13].Value = model.UpdatedTime;
            //parameters[14].Value = model.CompanyID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public void TopicReplies_Delete(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}TopicReplies ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Entity.TopicReplies TopicReplies_GetEntity(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldTopicReplies +"  from {0}TopicReplies ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8)};
			parameters[0].Value = id;
			Entity.TopicReplies model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= TopicReplies_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int TopicReplies_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}TopicReplies ",sPre);
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
		public DataSet TopicReplies_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldTopicReplies );
			strSql.AppendFormat(" FROM {0}TopicReplies ",sPre);
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
		public List<Entity.TopicReplies> TopicReplies_GetListArray(string strWhere)
		{
			return TopicReplies_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.TopicReplies> TopicReplies_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldTopicReplies );
			strSql.AppendFormat(" FROM {0}TopicReplies ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.TopicReplies> list = new List<Entity.TopicReplies>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(TopicReplies_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.TopicReplies> TopicReplies_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.TopicReplies> list = new List<Entity.TopicReplies>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"TopicReplies", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(TopicReplies_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.TopicReplies TopicReplies_ReaderBind(IDataReader dataReader)
		{
			Entity.TopicReplies model=new Entity.TopicReplies();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
                model.id = (long)ojb;
			}
			ojb = dataReader["TopicID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TopicID=(long)ojb;
			}
			ojb = dataReader["UserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UserID=(int)ojb;
			}
			model.UserName=dataReader["UserName"].ToString();
			ojb = dataReader["IsGoodCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsGoodCount=(int)ojb;
			}
			ojb = dataReader["IsBadCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsBadCount=(int)ojb;
			}
			ojb = dataReader["DeleteFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DeleteFlag=(int)ojb;
			}
			ojb = dataReader["AuditFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AuditFlag=(int)ojb;
			}
			model.ReplyContent=dataReader["ReplyContent"].ToString();
			ojb = dataReader["ReferenceFlag"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ReferenceFlag=(int)ojb;
			}
			model.ReferenceContent=dataReader["ReferenceContent"].ToString();
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

