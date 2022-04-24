using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Data.User.SqlServer
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
    public partial class DataProviderUser : Interface.IDataProviderUser
	{
		private string sFieldOrderOptionValue = "id,OrderId,LookupListId,LookupItemId,ListDescription,ItemDescription,AdjustedPrice,CustomerTitle,CustomerDescription";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int OrderOptionValue_GetMaxId()
		{
			return DbHelperUser.Instance.GetMaxID("id", string.Format("{0}OrderOptionValue",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool OrderOptionValue_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}OrderOptionValue",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperUser.Instance.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int OrderOptionValue_Add(Entity.OrderOptionValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}OrderOptionValue(",sPre);
			strSql.Append("OrderId,LookupListId,LookupItemId,ListDescription,ItemDescription,AdjustedPrice,CustomerTitle,CustomerDescription)");
			strSql.Append(" values (");
			strSql.Append("@OrderId,@LookupListId,@LookupItemId,@ListDescription,@ItemDescription,@AdjustedPrice,@CustomerTitle,@CustomerDescription)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
				
					new SqlParameter("@OrderId", SqlDbType.VarChar,50),
					new SqlParameter("@LookupListId", SqlDbType.Int,4),
					new SqlParameter("@LookupItemId", SqlDbType.Int,4),
					new SqlParameter("@ListDescription", SqlDbType.VarChar,500),
					new SqlParameter("@ItemDescription", SqlDbType.VarChar,500),
					new SqlParameter("@AdjustedPrice", SqlDbType.Decimal,9),
					new SqlParameter("@CustomerTitle", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerDescription", SqlDbType.VarChar,500)};
		
			parameters[0].Value = model.OrderId;
			parameters[1].Value = model.LookupListId;
			parameters[2].Value = model.LookupItemId;
			parameters[3].Value = model.ListDescription;
			parameters[4].Value = model.ItemDescription;
			parameters[5].Value = model.AdjustedPrice;
			parameters[6].Value = model.CustomerTitle;
			parameters[7].Value = model.CustomerDescription;

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
		public void OrderOptionValue_Update(Entity.OrderOptionValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}OrderOptionValue set ",sPre);
			strSql.Append("OrderId=@OrderId,");
			strSql.Append("LookupListId=@LookupListId,");
			strSql.Append("LookupItemId=@LookupItemId,");
			strSql.Append("ListDescription=@ListDescription,");
			strSql.Append("ItemDescription=@ItemDescription,");
			strSql.Append("AdjustedPrice=@AdjustedPrice,");
			strSql.Append("CustomerTitle=@CustomerTitle,");
			strSql.Append("CustomerDescription=@CustomerDescription");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@OrderId", SqlDbType.VarChar,50),
					new SqlParameter("@LookupListId", SqlDbType.Int,4),
					new SqlParameter("@LookupItemId", SqlDbType.Int,4),
					new SqlParameter("@ListDescription", SqlDbType.VarChar,500),
					new SqlParameter("@ItemDescription", SqlDbType.VarChar,500),
					new SqlParameter("@AdjustedPrice", SqlDbType.Decimal,9),
					new SqlParameter("@CustomerTitle", SqlDbType.VarChar,50),
					new SqlParameter("@CustomerDescription", SqlDbType.VarChar,500)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.OrderId;
			parameters[2].Value = model.LookupListId;
			parameters[3].Value = model.LookupItemId;
			parameters[4].Value = model.ListDescription;
			parameters[5].Value = model.ItemDescription;
			parameters[6].Value = model.AdjustedPrice;
			parameters[7].Value = model.CustomerTitle;
			parameters[8].Value = model.CustomerDescription;

			DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void OrderOptionValue_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}OrderOptionValue ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperUser.Instance.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.OrderOptionValue OrderOptionValue_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldOrderOptionValue +"  from {0}OrderOptionValue ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.OrderOptionValue model=null;
			using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= OrderOptionValue_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int OrderOptionValue_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}OrderOptionValue ",sPre);
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
		public DataSet OrderOptionValue_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
			strSql.Append(sFieldOrderOptionValue );
			strSql.AppendFormat(" FROM {0}OrderOptionValue ",sPre);
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
		public List<Entity.OrderOptionValue> OrderOptionValue_GetListArray(string strWhere)
		{
			return OrderOptionValue_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.OrderOptionValue> OrderOptionValue_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
			strSql.Append(sFieldOrderOptionValue );
			strSql.AppendFormat(" FROM {0}OrderOptionValue ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
           
			List<Entity.OrderOptionValue> list = new List<Entity.OrderOptionValue>();
			using (IDataReader dataReader = DbHelperUser.Instance.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(OrderOptionValue_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.OrderOptionValue> OrderOptionValue_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{

            List<Entity.OrderOptionValue> list = new List<Entity.OrderOptionValue>();
            using (IDataReader dataReader = SplitPages.GetListPages_SP(DbHelperUser.Instance, "OrderOptionValue", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount, sPre))
            {
                while (dataReader.Read())
                {
                    list.Add(OrderOptionValue_ReaderBind(dataReader));
                }
            }
            return list;	
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.OrderOptionValue OrderOptionValue_ReaderBind(IDataReader dataReader)
		{
			Entity.OrderOptionValue model=new Entity.OrderOptionValue();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.OrderId=dataReader["OrderId"].ToString();
			ojb = dataReader["LookupListId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LookupListId=(int)ojb;
			}
			ojb = dataReader["LookupItemId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LookupItemId=(int)ojb;
			}
			model.ListDescription=dataReader["ListDescription"].ToString();
			model.ItemDescription=dataReader["ItemDescription"].ToString();
			ojb = dataReader["AdjustedPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AdjustedPrice=(decimal)ojb;
			}
			model.CustomerTitle=dataReader["CustomerTitle"].ToString();
			model.CustomerDescription=dataReader["CustomerDescription"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

