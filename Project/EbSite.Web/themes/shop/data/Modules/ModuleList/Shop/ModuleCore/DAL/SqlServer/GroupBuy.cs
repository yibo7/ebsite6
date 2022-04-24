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
		private string sFieldGroupBuy = "id,ProductID,NeedPrice,StartDate,EndDate,MaxCount,Content,Status,OrderID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GroupBuy_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}GroupBuy",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool GroupBuy_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}GroupBuy",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int GroupBuy_Add(Entity.GroupBuy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}GroupBuy(",sPre);
			strSql.Append("ProductID,NeedPrice,StartDate,EndDate,MaxCount,Content,Status,OrderID)");
			strSql.Append(" values (");
			strSql.Append("@ProductID,@NeedPrice,@StartDate,@EndDate,@MaxCount,@Content,@Status,@OrderID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@ProductID",SqlDbType.Int,4),
					new SqlParameter("@NeedPrice", SqlDbType.Decimal,9),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@MaxCount",SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.VarChar),
					new SqlParameter("@Status",SqlDbType.Int,4),
					new SqlParameter("@OrderID",SqlDbType.Int,4)};
			
			parameters[0].Value = model.ProductID;
			parameters[1].Value = model.NeedPrice;
			parameters[2].Value = model.StartDate;
			parameters[3].Value = model.EndDate;
			parameters[4].Value = model.MaxCount;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.OrderID;

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
		public void GroupBuy_Update(Entity.GroupBuy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}GroupBuy set ",sPre);
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("NeedPrice=@NeedPrice,");
			strSql.Append("StartDate=@StartDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("MaxCount=@MaxCount,");
			strSql.Append("Content=@Content,");
			strSql.Append("Status=@Status,");
			strSql.Append("OrderID=@OrderID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4),
					new SqlParameter("@ProductID",SqlDbType.Int,4),
					new SqlParameter("@NeedPrice", SqlDbType.Decimal,9),
					new SqlParameter("@StartDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@MaxCount",SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.VarChar),
					new SqlParameter("@Status",SqlDbType.Int,4),
					new SqlParameter("@OrderID",SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductID;
			parameters[2].Value = model.NeedPrice;
			parameters[3].Value = model.StartDate;
			parameters[4].Value = model.EndDate;
			parameters[5].Value = model.MaxCount;
			parameters[6].Value = model.Content;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.OrderID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void GroupBuy_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}GroupBuy ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.GroupBuy GroupBuy_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldGroupBuy +"  from {0}GroupBuy ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.GroupBuy model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= GroupBuy_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int GroupBuy_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}GroupBuy ",sPre);
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
		public DataSet GroupBuy_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldGroupBuy );
			strSql.AppendFormat(" FROM {0}GroupBuy ",sPre);
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
		public List<Entity.GroupBuy> GroupBuy_GetListArray(string strWhere)
		{
			return GroupBuy_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.GroupBuy> GroupBuy_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldGroupBuy );
			strSql.AppendFormat(" FROM {0}GroupBuy ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.GroupBuy> list = new List<Entity.GroupBuy>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(GroupBuy_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.GroupBuy> GroupBuy_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.GroupBuy> list = new List<Entity.GroupBuy>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"GroupBuy", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(GroupBuy_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.GroupBuy GroupBuy_ReaderBind(IDataReader dataReader)
		{
			Entity.GroupBuy model=new Entity.GroupBuy();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
			}
			ojb = dataReader["NeedPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NeedPrice=(decimal)ojb;
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
			ojb = dataReader["MaxCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MaxCount=(int)ojb;
			}
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=(int)ojb;
			}
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

