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
		private string sFieldCountDownBuy = "id,ProductId,StartDate,EndDate,Content,OrderID,CountDownPrice";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int CountDownBuy_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}CountDownBuy",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool CountDownBuy_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}CountDownBuy",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int CountDownBuy_Add(Entity.CountDownBuy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}CountDownBuy(",sPre);
			strSql.Append("ProductId,StartDate,EndDate,Content,OrderID,CountDownPrice)");
			strSql.Append(" values (");
			strSql.Append("@ProductId,@StartDate,@EndDate,@Content,@OrderID,@CountDownPrice)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Content", SqlDbType.VarChar),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@CountDownPrice", SqlDbType.Decimal,9)};
			
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.StartDate;
			parameters[2].Value = model.EndDate;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.OrderID;
			parameters[5].Value = model.CountDownPrice;

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
		public void CountDownBuy_Update(Entity.CountDownBuy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}CountDownBuy set ",sPre);
			strSql.Append("ProductId=@ProductId,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Content=@Content,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("CountDownPrice=@CountDownPrice");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Content", SqlDbType.VarChar),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@CountDownPrice", SqlDbType.Decimal,9)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductId;
			parameters[2].Value = model.StartDate;
			parameters[3].Value = model.EndDate;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.OrderID;
			parameters[6].Value = model.CountDownPrice;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void CountDownBuy_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}CountDownBuy ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.CountDownBuy CountDownBuy_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldCountDownBuy +"  from {0}CountDownBuy ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.CountDownBuy model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= CountDownBuy_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int CountDownBuy_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}CountDownBuy ",sPre);
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
		public DataSet CountDownBuy_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldCountDownBuy );
			strSql.AppendFormat(" FROM {0}CountDownBuy ",sPre);
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
		public List<Entity.CountDownBuy> CountDownBuy_GetListArray(string strWhere)
		{
			return CountDownBuy_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.CountDownBuy> CountDownBuy_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldCountDownBuy );
			strSql.AppendFormat(" FROM {0}CountDownBuy ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.CountDownBuy> list = new List<Entity.CountDownBuy>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(CountDownBuy_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.CountDownBuy> CountDownBuy_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.CountDownBuy> list = new List<Entity.CountDownBuy>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"CountDownBuy", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(CountDownBuy_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.CountDownBuy CountDownBuy_ReaderBind(IDataReader dataReader)
		{
			Entity.CountDownBuy model=new Entity.CountDownBuy();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProductId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductId=(int)ojb;
			}
			ojb = dataReader["StartDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StartDate=(DateTime)ojb;
			}
			ojb = dataReader["EndDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EndDate=(DateTime)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}
			ojb = dataReader["CountDownPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CountDownPrice=(decimal)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

