using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Ask.ModuleCore.DAL.SqlServer
{
	/// <summary>
	/// 数据访问类Ask。
	/// </summary>
	public partial class Ask
	{
		private string sFieldAnswers = "id,QID,QUserID,AnswerUserID,AnswerContent,IsAdoption,AnswerTime,IsDel,AnswerIP,ReferBook,IsAnonymity,AnswerUpdateTime,Score";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int Answers_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}Answers",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Answers_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Answers",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Answers_Add(Entity.Answers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Answers(",sPre);
			strSql.Append("QID,QUserID,AnswerUserID,AnswerContent,IsAdoption,AnswerTime,IsDel,AnswerIP,ReferBook,IsAnonymity,AnswerUpdateTime,Score)");
			strSql.Append(" values (");
			strSql.Append("@QID,@QUserID,@AnswerUserID,@AnswerContent,@IsAdoption,@AnswerTime,@IsDel,@AnswerIP,@ReferBook,@IsAnonymity,@AnswerUpdateTime,@Score)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@QID", SqlDbType.Int,4),
					new SqlParameter("@QUserID", SqlDbType.Int,4),
					new SqlParameter("@AnswerUserID", SqlDbType.Int,4),
					new SqlParameter("@AnswerContent", SqlDbType.Text),
					new SqlParameter("@IsAdoption", SqlDbType.Bit,1),
					new SqlParameter("@AnswerTime", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@AnswerIP", SqlDbType.NVarChar,50),
					new SqlParameter("@ReferBook", SqlDbType.NVarChar,1000),
					new SqlParameter("@IsAnonymity", SqlDbType.Bit,1),
					new SqlParameter("@AnswerUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Score", SqlDbType.Int,4)};
			
			parameters[0].Value = model.QID;
			parameters[1].Value = model.QUserID;
			parameters[2].Value = model.AnswerUserID;
			parameters[3].Value = model.AnswerContent;
			parameters[4].Value = model.IsAdoption;
			parameters[5].Value = model.AnswerTime;
			parameters[6].Value = model.IsDel;
			parameters[7].Value = model.AnswerIP;
			parameters[8].Value = model.ReferBook;
			parameters[9].Value = model.IsAnonymity;
			parameters[10].Value = model.AnswerUpdateTime;
			parameters[11].Value = model.Score;

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
		public void Answers_Update(Entity.Answers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Answers set ",sPre);
			strSql.Append("QID=@QID,");
			strSql.Append("QUserID=@QUserID,");
			strSql.Append("AnswerUserID=@AnswerUserID,");
			strSql.Append("AnswerContent=@AnswerContent,");
			strSql.Append("IsAdoption=@IsAdoption,");
			strSql.Append("AnswerTime=@AnswerTime,");
			strSql.Append("IsDel=@IsDel,");
			strSql.Append("AnswerIP=@AnswerIP,");
			strSql.Append("ReferBook=@ReferBook,");
			strSql.Append("IsAnonymity=@IsAnonymity,");
			strSql.Append("AnswerUpdateTime=@AnswerUpdateTime,");
			strSql.Append("Score=@Score");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@QID", SqlDbType.Int,4),
					new SqlParameter("@QUserID", SqlDbType.Int,4),
					new SqlParameter("@AnswerUserID", SqlDbType.Int,4),
					new SqlParameter("@AnswerContent", SqlDbType.Text),
					new SqlParameter("@IsAdoption", SqlDbType.Bit,1),
					new SqlParameter("@AnswerTime", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@AnswerIP", SqlDbType.NVarChar,50),
					new SqlParameter("@ReferBook", SqlDbType.NVarChar,1000),
					new SqlParameter("@IsAnonymity", SqlDbType.Bit,1),
					new SqlParameter("@AnswerUpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Score", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.QID;
			parameters[2].Value = model.QUserID;
			parameters[3].Value = model.AnswerUserID;
			parameters[4].Value = model.AnswerContent;
			parameters[5].Value = model.IsAdoption;
			parameters[6].Value = model.AnswerTime;
			parameters[7].Value = model.IsDel;
			parameters[8].Value = model.AnswerIP;
			parameters[9].Value = model.ReferBook;
			parameters[10].Value = model.IsAnonymity;
			parameters[11].Value = model.AnswerUpdateTime;
			parameters[12].Value = model.Score;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Answers_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Answers ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Answers Answers_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldAnswers +"  from {0}Answers ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.Answers model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Answers_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Answers_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Answers ",sPre);
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
		public DataSet Answers_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldAnswers );
			strSql.AppendFormat(" FROM {0}Answers ",sPre);
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
		public List<Entity.Answers> Answers_GetListArray(string strWhere)
		{
			return Answers_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Answers> Answers_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldAnswers );
			strSql.AppendFormat(" FROM {0}Answers ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.Answers> list = new List<Entity.Answers>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Answers_ReaderBind(dataReader));
				}
			}
            
			return list;
		}

        


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Answers> Answers_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.Answers> list = new List<Entity.Answers>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"Answers", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(Answers_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Answers Answers_ReaderBind(IDataReader dataReader)
		{
			Entity.Answers model=new Entity.Answers();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["QID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.QID=(int)ojb;
			}
			ojb = dataReader["QUserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.QUserID=(int)ojb;
			}
			ojb = dataReader["AnswerUserID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AnswerUserID=(int)ojb;
			}
			model.AnswerContent=dataReader["AnswerContent"].ToString();
			ojb = dataReader["IsAdoption"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsAdoption=(bool)ojb;
			}
			ojb = dataReader["AnswerTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AnswerTime=(DateTime)ojb;
			}
			ojb = dataReader["IsDel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsDel=(bool)ojb;
			}
			model.AnswerIP=dataReader["AnswerIP"].ToString();
			model.ReferBook=dataReader["ReferBook"].ToString();
			ojb = dataReader["IsAnonymity"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsAnonymity=(bool)ojb;
			}
			ojb = dataReader["AnswerUpdateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AnswerUpdateTime=(DateTime)ojb;
			}
			ojb = dataReader["Score"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Score=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

