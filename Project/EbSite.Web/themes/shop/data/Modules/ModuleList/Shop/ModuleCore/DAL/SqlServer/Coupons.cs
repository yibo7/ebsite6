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
		private string sFieldCoupons = "id,CouponName,EndDateTime,Amount,DiscountPrice,Description,SentCount,UsedCount,NeedPoint";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int Coupons_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}Coupons",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Coupons_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}Coupons",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Coupons_Add(Entity.Coupons model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}Coupons(",sPre);
			strSql.Append("CouponName,EndDateTime,Amount,DiscountPrice,Description,SentCount,UsedCount,NeedPoint)");
			strSql.Append(" values (");
			strSql.Append("@CouponName,@EndDateTime,@Amount,@DiscountPrice,@Description,@SentCount,@UsedCount,@NeedPoint)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@CouponName", SqlDbType.VarChar,50),
					new SqlParameter("@EndDateTime", SqlDbType.DateTime),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Description", SqlDbType.VarChar,500),
					new SqlParameter("@SentCount",SqlDbType.Int,4),
					new SqlParameter("@UsedCount",SqlDbType.Int,4),
					new SqlParameter("@NeedPoint",SqlDbType.Int,4)};
			
			parameters[0].Value = model.CouponName;
			parameters[1].Value = model.EndDateTime;
			parameters[2].Value = model.Amount;
			parameters[3].Value = model.DiscountPrice;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.SentCount;
			parameters[6].Value = model.UsedCount;
			parameters[7].Value = model.NeedPoint;

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
		public void Coupons_Update(Entity.Coupons model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}Coupons set ",sPre);
			strSql.Append("CouponName=@CouponName,");
			strSql.Append("EndDateTime=@EndDateTime,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("DiscountPrice=@DiscountPrice,");
			strSql.Append("Description=@Description,");
			strSql.Append("SentCount=@SentCount,");
			strSql.Append("UsedCount=@UsedCount,");
			strSql.Append("NeedPoint=@NeedPoint");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4),
					new SqlParameter("@CouponName", SqlDbType.VarChar,50),
					new SqlParameter("@EndDateTime", SqlDbType.DateTime),
					new SqlParameter("@Amount", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Description", SqlDbType.VarChar,500),
					new SqlParameter("@SentCount",SqlDbType.Int,4),
					new SqlParameter("@UsedCount",SqlDbType.Int,4),
					new SqlParameter("@NeedPoint",SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.CouponName;
			parameters[2].Value = model.EndDateTime;
			parameters[3].Value = model.Amount;
			parameters[4].Value = model.DiscountPrice;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.SentCount;
			parameters[7].Value = model.UsedCount;
			parameters[8].Value = model.NeedPoint;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Coupons_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}Coupons ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.Coupons Coupons_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldCoupons +"  from {0}Coupons ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.Coupons model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= Coupons_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int Coupons_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}Coupons ",sPre);
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
		public DataSet Coupons_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldCoupons );
			strSql.AppendFormat(" FROM {0}Coupons ",sPre);
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
		public List<Entity.Coupons> Coupons_GetListArray(string strWhere)
		{
			return Coupons_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.Coupons> Coupons_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldCoupons );
			strSql.AppendFormat(" FROM {0}Coupons ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.Coupons> list = new List<Entity.Coupons>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(Coupons_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.Coupons> Coupons_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.Coupons> list = new List<Entity.Coupons>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"Coupons", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(Coupons_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.Coupons Coupons_ReaderBind(IDataReader dataReader)
		{
			Entity.Coupons model=new Entity.Coupons();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.CouponName=dataReader["CouponName"].ToString();
			ojb = dataReader["EndDateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EndDateTime=(DateTime)ojb;
			}
			ojb = dataReader["Amount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Amount=(decimal)ojb;
			}
			ojb = dataReader["DiscountPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DiscountPrice=(decimal)ojb;
			}
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["SentCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SentCount=(int)ojb;
			}
			ojb = dataReader["UsedCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UsedCount=(int)ojb;
			}
			ojb = dataReader["NeedPoint"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NeedPoint=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

