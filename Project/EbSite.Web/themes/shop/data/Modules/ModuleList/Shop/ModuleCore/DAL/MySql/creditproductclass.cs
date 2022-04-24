using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using EbSite.Base.DataProfile;


namespace EbSite.Modules.Shop.ModuleCore.DAL.MySql
{
	/// <summary>
	/// 数据访问类shop。
	/// </summary>
    public partial class Shop
	{
		private string sFieldcreditproductclass = "id,ClassName,AddTime,OrderID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int creditproductclass_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}creditproductclass",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool creditproductclass_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}creditproductclass",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int creditproductclass_Add(Entity.creditproductclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}creditproductclass(",sPre);
			strSql.Append("ClassName,AddTime,OrderID)");
			strSql.Append(" values (");
			strSql.Append("?ClassName,?AddTime,?OrderID)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.ClassName;
			parameters[1].Value = model.AddTime;
			parameters[2].Value = model.OrderID;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return creditproductclass_GetMaxId();
			}
			return 0;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void creditproductclass_Update(Entity.creditproductclass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}creditproductclass set ",sPre);
			strSql.Append("ClassName=?ClassName,");
			strSql.Append("AddTime=?AddTime,");
			strSql.Append("OrderID=?OrderID");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,50),
					new MySqlParameter("?AddTime", MySqlDbType.DateTime),
					new MySqlParameter("?OrderID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ClassName;
			parameters[2].Value = model.AddTime;
			parameters[3].Value = model.OrderID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void creditproductclass_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}creditproductclass ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.creditproductclass creditproductclass_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldcreditproductclass +"  from {0}creditproductclass ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.creditproductclass model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= creditproductclass_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int creditproductclass_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}creditproductclass ",sPre);
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
		public DataSet creditproductclass_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			strSql.Append(sFieldcreditproductclass );
			strSql.AppendFormat(" FROM {0}creditproductclass ",sPre);
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
		public List<Entity.creditproductclass> creditproductclass_GetListArray(string strWhere)
		{
			return creditproductclass_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.creditproductclass> creditproductclass_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(sFieldcreditproductclass );
			strSql.AppendFormat(" FROM {0}creditproductclass ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}

            if (Top > 0)
            {
                strSql.Append(" limit " + Top.ToString());
            }
			List<Entity.creditproductclass> list = new List<Entity.creditproductclass>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(creditproductclass_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.creditproductclass> creditproductclass_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.creditproductclass> list = new List<Entity.creditproductclass>();
			RecordCount = creditproductclass_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "creditproductclass", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(creditproductclass_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.creditproductclass creditproductclass_ReaderBind(IDataReader dataReader)
		{
			Entity.creditproductclass model=new Entity.creditproductclass();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.ClassName=dataReader["ClassName"].ToString();
			ojb = dataReader["AddTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddTime=(DateTime)ojb;
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

