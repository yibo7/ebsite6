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
        private string sFieldUserHelp = "id,UserID,QCount,ACount,AdoptionCount,LikeAskClass,TotalScore";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int UserHelp_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}UserHelp",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool UserHelp_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}UserHelp",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int UserHelp_Add(Entity.UserHelp model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}UserHelp(", sPre);
            strSql.Append("UserID,QCount,ACount,AdoptionCount,LikeAskClass,TotalScore)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@QCount,@ACount,@AdoptionCount,@LikeAskClass,@TotalScore)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@QCount", SqlDbType.Int,4),
					new SqlParameter("@ACount", SqlDbType.Int,4),
					new SqlParameter("@AdoptionCount", SqlDbType.Int,4),
					new SqlParameter("@LikeAskClass", SqlDbType.NVarChar,1000),
					new SqlParameter("@TotalScore", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.QCount;
            parameters[2].Value = model.ACount;
            parameters[3].Value = model.AdoptionCount;
            parameters[4].Value = model.LikeAskClass;
            parameters[5].Value = model.TotalScore;

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
        public void UserHelp_Update(Entity.UserHelp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update {0}UserHelp set ", sPre);
            strSql.Append("UserID=@UserID,");
            strSql.Append("QCount=@QCount,");
            strSql.Append("ACount=@ACount,");
            strSql.Append("AdoptionCount=@AdoptionCount,");
            strSql.Append("LikeAskClass=@LikeAskClass,");
            strSql.Append("TotalScore=@TotalScore");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@QCount", SqlDbType.Int,4),
					new SqlParameter("@ACount", SqlDbType.Int,4),
					new SqlParameter("@AdoptionCount", SqlDbType.Int,4),
					new SqlParameter("@LikeAskClass", SqlDbType.NVarChar,1000),
					new SqlParameter("@TotalScore", SqlDbType.BigInt,8)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.QCount;
            parameters[3].Value = model.ACount;
            parameters[4].Value = model.AdoptionCount;
            parameters[5].Value = model.LikeAskClass;
            parameters[6].Value = model.TotalScore;

            DB.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void UserHelp_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}UserHelp ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.UserHelp UserHelp_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldUserHelp +"  from {0}UserHelp ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.UserHelp model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= UserHelp_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int UserHelp_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}UserHelp ",sPre);
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
		public DataSet UserHelp_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldUserHelp );
			strSql.AppendFormat(" FROM {0}UserHelp ",sPre);
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
		public List<Entity.UserHelp> UserHelp_GetListArray(string strWhere)
		{
			return UserHelp_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.UserHelp> UserHelp_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldUserHelp );
			strSql.AppendFormat(" FROM {0}UserHelp ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.UserHelp> list = new List<Entity.UserHelp>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(UserHelp_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.UserHelp> UserHelp_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.UserHelp> list = new List<Entity.UserHelp>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"UserHelp", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(UserHelp_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.UserHelp UserHelp_ReaderBind(IDataReader dataReader)
		{
			Entity.UserHelp model=new Entity.UserHelp();
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
			ojb = dataReader["QCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.QCount=(int)ojb;
			}
			ojb = dataReader["ACount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ACount=(int)ojb;
			}
			ojb = dataReader["AdoptionCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AdoptionCount=(int)ojb;
			}
			model.LikeAskClass=dataReader["LikeAskClass"].ToString();
            ojb = dataReader["TotalScore"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TotalScore = (long)ojb;
            }
			return model;
		}

		#endregion  成员方法
	}
}

