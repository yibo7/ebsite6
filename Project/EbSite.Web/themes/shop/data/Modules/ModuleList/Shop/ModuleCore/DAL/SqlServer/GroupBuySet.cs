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
		private string sFieldGroupBuySet = "id,GroupBuyId,BuyCount,BuyPrice";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GroupBuySet_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}GroupBuySet",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool GroupBuySet_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}GroupBuySet",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int GroupBuySet_Add(Entity.GroupBuySet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}GroupBuySet(",sPre);
			strSql.Append("GroupBuyId,BuyCount,BuyPrice)");
			strSql.Append(" values (");
			strSql.Append("@GroupBuyId,@BuyCount,@BuyPrice)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@GroupBuyId",SqlDbType.Int,4),
					new SqlParameter("@BuyCount",SqlDbType.Int,4),
					new SqlParameter("@BuyPrice", SqlDbType.Decimal,9)};
			
			parameters[0].Value = model.GroupBuyId;
			parameters[1].Value = model.BuyCount;
			parameters[2].Value = model.BuyPrice;

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
		public void GroupBuySet_Update(Entity.GroupBuySet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}GroupBuySet set ",sPre);
			strSql.Append("GroupBuyId=@GroupBuyId,");
			strSql.Append("BuyCount=@BuyCount,");
			strSql.Append("BuyPrice=@BuyPrice");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4),
					new SqlParameter("@GroupBuyId",SqlDbType.Int,4),
					new SqlParameter("@BuyCount",SqlDbType.Int,4),
					new SqlParameter("@BuyPrice", SqlDbType.Decimal,9)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.GroupBuyId;
			parameters[2].Value = model.BuyCount;
			parameters[3].Value = model.BuyPrice;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void GroupBuySet_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}GroupBuySet ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.GroupBuySet GroupBuySet_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldGroupBuySet +"  from {0}GroupBuySet ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.GroupBuySet model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= GroupBuySet_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int GroupBuySet_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}GroupBuySet ",sPre);
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
		public DataSet GroupBuySet_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldGroupBuySet );
			strSql.AppendFormat(" FROM {0}GroupBuySet ",sPre);
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
		public List<Entity.GroupBuySet> GroupBuySet_GetListArray(string strWhere)
		{
			return GroupBuySet_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.GroupBuySet> GroupBuySet_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldGroupBuySet );
			strSql.AppendFormat(" FROM {0}GroupBuySet ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.GroupBuySet> list = new List<Entity.GroupBuySet>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(GroupBuySet_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.GroupBuySet> GroupBuySet_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.GroupBuySet> list = new List<Entity.GroupBuySet>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"GroupBuySet", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(GroupBuySet_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.GroupBuySet GroupBuySet_ReaderBind(IDataReader dataReader)
		{
			Entity.GroupBuySet model=new Entity.GroupBuySet();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["GroupBuyId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GroupBuyId=(int)ojb;
			}
			ojb = dataReader["BuyCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BuyCount=(int)ojb;
			}
			ojb = dataReader["BuyPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.BuyPrice=(decimal)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

