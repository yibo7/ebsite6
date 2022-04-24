using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Data.User.SqlServer
{
	/// <summary>
	/// 数据访问类FSDFSF。
	/// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
		private string sFieldWithdrawList = "id,UserId,UserName,RequestTime,Amount,AccountName,BankName,CardNumber,Remark";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int WithdrawList_GetMaxId()
		{
			return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}WithdrawList",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool WithdrawList_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}WithdrawList",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperUser.Instance.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int WithdrawList_Add(Entity.WithdrawList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}WithdrawList(",sPre);
			strSql.Append("UserId,UserName,RequestTime,Amount,AccountName,BankName,CardNumber,Remark)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@UserName,@RequestTime,@Amount,@AccountName,@BankName,@CardNumber,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@RequestTime", SqlDbType.DateTime),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@AccountName", SqlDbType.VarChar,50),
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,500)};
		
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.RequestTime;
			parameters[3].Value = model.Amount;
			parameters[4].Value = model.AccountName;
			parameters[5].Value = model.BankName;
			parameters[6].Value = model.CardNumber;
			parameters[7].Value = model.Remark;

			object obj = DbHelperUser.Instance.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
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
		public void WithdrawList_Update(Entity.WithdrawList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}WithdrawList set ",sPre);
			strSql.Append("UserId=@UserId,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("RequestTime=@RequestTime,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("AccountName=@AccountName,");
			strSql.Append("BankName=@BankName,");
			strSql.Append("CardNumber=@CardNumber,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@RequestTime", SqlDbType.DateTime),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@AccountName", SqlDbType.VarChar,50),
					new SqlParameter("@BankName", SqlDbType.VarChar,50),
					new SqlParameter("@CardNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.UserId;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.RequestTime;
			parameters[4].Value = model.Amount;
			parameters[5].Value = model.AccountName;
			parameters[6].Value = model.BankName;
			parameters[7].Value = model.CardNumber;
			parameters[8].Value = model.Remark;

			DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void WithdrawList_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}WithdrawList ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.WithdrawList WithdrawList_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldWithdrawList +"  from {0}WithdrawList ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.WithdrawList model=null;
			using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= WithdrawList_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int WithdrawList_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}WithdrawList ",sPre);
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			int iCount = 0;
			using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text,strSql.ToString()))
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
		public DataSet WithdrawList_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldWithdrawList );
			strSql.AppendFormat(" FROM {0}WithdrawList ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			return DbHelperUser.Instance.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.WithdrawList> WithdrawList_GetListArray(string strWhere)
		{
			return WithdrawList_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.WithdrawList> WithdrawList_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldWithdrawList );
			strSql.AppendFormat(" FROM {0}WithdrawList ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.WithdrawList> list = new List<Entity.WithdrawList>();
			using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(WithdrawList_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.WithdrawList> WithdrawList_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.WithdrawList> list = new List<Entity.WithdrawList>();
            using (IDataReader dataReader = SplitPages.GetListPages_SP(DbHelperUser.Instance, "WithdrawList", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount, sPre))
			{
				while (dataReader.Read())
				{
					list.Add(WithdrawList_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.WithdrawList WithdrawList_ReaderBind(IDataReader dataReader)
		{
			Entity.WithdrawList model=new Entity.WithdrawList();
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
			model.UserName=dataReader["UserName"].ToString();
			ojb = dataReader["RequestTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RequestTime=(DateTime)ojb;
			}
			ojb = dataReader["Amount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Amount=(decimal)ojb;
			}
			model.AccountName=dataReader["AccountName"].ToString();
			model.BankName=dataReader["BankName"].ToString();
			model.CardNumber=dataReader["CardNumber"].ToString();
			model.Remark=dataReader["Remark"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

