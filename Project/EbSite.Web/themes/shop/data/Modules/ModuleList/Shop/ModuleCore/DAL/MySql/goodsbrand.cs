using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;
namespace EbSite.Modules.Shop.ModuleCore.DAL.MySql
{
	/// <summary>
	/// 数据访问类Shop。
	/// </summary>
	public partial class Shop
	{
		private string sFieldgoodsbrand = "id,BrandName,Logo,Description,OrderID,GroupID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int goodsbrand_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}GoodsBrand",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool goodsbrand_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}GoodsBrand",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int goodsbrand_Add(Entity.GoodsBrand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}GoodsBrand(",sPre);
			strSql.Append("BrandName,Logo,Description,OrderID,GroupID)");
			strSql.Append(" values (");
			strSql.Append("?BrandName,?Logo,?Description,?OrderID,?GroupID)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?BrandName", MySqlDbType.VarChar,100),
					new MySqlParameter("?Logo", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11),
					new MySqlParameter("?GroupID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.BrandName;
			parameters[1].Value = model.Logo;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.OrderID;
			parameters[4].Value = model.GroupID;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return goodsbrand_GetMaxId();
			}
			return 0;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void goodsbrand_Update(Entity.GoodsBrand model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}GoodsBrand set ",sPre);
			strSql.Append("BrandName=?BrandName,");
			strSql.Append("Logo=?Logo,");
			strSql.Append("Description=?Description,");
			strSql.Append("OrderID=?OrderID,");
			strSql.Append("GroupID=?GroupID");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?BrandName", MySqlDbType.VarChar,100),
					new MySqlParameter("?Logo", MySqlDbType.VarChar,200),
					new MySqlParameter("?Description", MySqlDbType.VarChar,500),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11),
					new MySqlParameter("?GroupID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.BrandName;
			parameters[2].Value = model.Logo;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.OrderID;
			parameters[5].Value = model.GroupID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void goodsbrand_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}GoodsBrand ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.GoodsBrand goodsbrand_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldgoodsbrand +"  from {0}GoodsBrand ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.GoodsBrand model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= goodsbrand_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int goodsbrand_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}GoodsBrand ",sPre);
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
		public DataSet goodsbrand_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldgoodsbrand );
			strSql.AppendFormat(" FROM {0}GoodsBrand ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			if(Top>0)
			{
				strSql.Append(" limit "+Top.ToString());
			}
			return DB.ExecuteDataset(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Entity.GoodsBrand> goodsbrand_GetListArray(string strWhere)
		{
			return goodsbrand_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.GoodsBrand> goodsbrand_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldgoodsbrand );
			strSql.AppendFormat(" FROM {0}GoodsBrand ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.GoodsBrand> list = new List<Entity.GoodsBrand>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(goodsbrand_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.GoodsBrand> goodsbrand_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.GoodsBrand> list = new List<Entity.GoodsBrand>();
			RecordCount = goodsbrand_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "GoodsBrand", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(goodsbrand_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.GoodsBrand goodsbrand_ReaderBind(IDataReader dataReader)
		{
			Entity.GoodsBrand model=new Entity.GoodsBrand();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.BrandName=dataReader["BrandName"].ToString();
			model.Logo=dataReader["Logo"].ToString();
			model.Description=dataReader["Description"].ToString();
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}
			ojb = dataReader["GroupID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.GroupID=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

