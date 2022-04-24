using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Shop.ModuleCore.DAL.SqlServer
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
	public partial class Shop
	{
		private string sFieldPayment = "id,PaymentApi,PaymentName,UseMoney,IsPercent,IsUseInpour,IsClose,OrderNumber,Demo";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int Payment_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}Payment",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Payment_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Payment",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Payment_Add(Entity.Payment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Payment(",sPre);
			strSql.Append("PaymentApi,PaymentName,UseMoney,IsPercent,IsUseInpour,IsClose,OrderNumber,Demo)");
			strSql.Append(" values (");
			strSql.Append("@PaymentApi,@PaymentName,@UseMoney,@IsPercent,@IsUseInpour,@IsClose,@OrderNumber,@Demo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@PaymentApi", SqlDbType.VarChar,50),
					new SqlParameter("@PaymentName", SqlDbType.VarChar,50),
					new SqlParameter("@UseMoney", SqlDbType.Decimal,9),
					new SqlParameter("@IsPercent", SqlDbType.Bit,1),
					new SqlParameter("@IsUseInpour", SqlDbType.Bit,1),
					new SqlParameter("@IsClose", SqlDbType.Bit,1),
					new SqlParameter("@OrderNumber", SqlDbType.Int,4),
					new SqlParameter("@Demo", SqlDbType.VarChar)};
		
			parameters[0].Value = model.PaymentApi;
			parameters[1].Value = model.PaymentName;
			parameters[2].Value = model.UseMoney;
			parameters[3].Value = model.IsPercent;
			parameters[4].Value = model.IsUseInpour;
			parameters[5].Value = model.IsClose;
			parameters[6].Value = model.OrderNumber;
			parameters[7].Value = model.Demo;

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
		public void Payment_Update(Entity.Payment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Payment set ",sPre);
			strSql.Append("PaymentApi=@PaymentApi,");
			strSql.Append("PaymentName=@PaymentName,");
			strSql.Append("UseMoney=@UseMoney,");
			strSql.Append("IsPercent=@IsPercent,");
			strSql.Append("IsUseInpour=@IsUseInpour,");
			strSql.Append("IsClose=@IsClose,");
			strSql.Append("OrderNumber=@OrderNumber,");
			strSql.Append("Demo=@Demo");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@PaymentApi", SqlDbType.VarChar,50),
					new SqlParameter("@PaymentName", SqlDbType.VarChar,50),
					new SqlParameter("@UseMoney", SqlDbType.Decimal,9),
					new SqlParameter("@IsPercent", SqlDbType.Bit,1),
					new SqlParameter("@IsUseInpour", SqlDbType.Bit,1),
					new SqlParameter("@IsClose", SqlDbType.Bit,1),
					new SqlParameter("@OrderNumber", SqlDbType.Int,4),
					new SqlParameter("@Demo", SqlDbType.VarChar)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.PaymentApi;
			parameters[2].Value = model.PaymentName;
			parameters[3].Value = model.UseMoney;
			parameters[4].Value = model.IsPercent;
			parameters[5].Value = model.IsUseInpour;
			parameters[6].Value = model.IsClose;
			parameters[7].Value = model.OrderNumber;
			parameters[8].Value = model.Demo;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Payment_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Payment ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Payment Payment_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldPayment +"  from {0}Payment ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.Payment model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Payment_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Payment_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Payment ",sPre);
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
		public DataSet Payment_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldPayment );
			strSql.AppendFormat(" FROM {0}Payment ",sPre);
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
		public List<Entity.Payment> Payment_GetListArray(string strWhere)
		{
			return Payment_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Payment> Payment_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldPayment );
			strSql.AppendFormat(" FROM {0}Payment ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.Payment> list = new List<Entity.Payment>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Payment_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Payment> Payment_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.Payment> list = new List<Entity.Payment>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"Payment", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(Payment_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Payment Payment_ReaderBind(IDataReader dataReader)
		{
			Entity.Payment model=new Entity.Payment();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.PaymentApi=dataReader["PaymentApi"].ToString();
			model.PaymentName=dataReader["PaymentName"].ToString();
			ojb = dataReader["UseMoney"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UseMoney=(decimal)ojb;
			}
			ojb = dataReader["IsPercent"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsPercent=(bool)ojb;
			}
			ojb = dataReader["IsUseInpour"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsUseInpour=(bool)ojb;
			}
			ojb = dataReader["IsClose"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsClose=(bool)ojb;
			}
			ojb = dataReader["OrderNumber"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderNumber=(int)ojb;
			}
			model.Demo=dataReader["Demo"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

