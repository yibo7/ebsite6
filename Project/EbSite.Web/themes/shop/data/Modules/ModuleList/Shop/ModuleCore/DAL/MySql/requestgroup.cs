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
		private string sFieldrequestgroup = "id,UserID,UserName,ProductID,RequestPrice,AddDateTime,Mobile,Email,IsNotice";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int requestgroup_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}requestgroup",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool requestgroup_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}requestgroup",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int requestgroup_Add(Entity.requestgroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}requestgroup(",sPre);
			strSql.Append("UserID,UserName,ProductID,RequestPrice,AddDateTime,Mobile,Email,IsNotice)");
			strSql.Append(" values (");
			strSql.Append("?UserID,?UserName,?ProductID,?RequestPrice,?AddDateTime,?Mobile,?Email,?IsNotice)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,11),
					new MySqlParameter("?RequestPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
					new MySqlParameter("?Mobile", MySqlDbType.VarChar,20),
					new MySqlParameter("?Email", MySqlDbType.VarChar,200),
					new MySqlParameter("?IsNotice", MySqlDbType.Int32,11)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.ProductID;
			parameters[3].Value = model.RequestPrice;
			parameters[4].Value = model.AddDateTime;
			parameters[5].Value = model.Mobile;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.IsNotice;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return requestgroup_GetMaxId();
			}
			return 0;		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void requestgroup_Update(Entity.requestgroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}requestgroup set ",sPre);
			strSql.Append("UserID=?UserID,");
			strSql.Append("UserName=?UserName,");
			strSql.Append("ProductID=?ProductID,");
			strSql.Append("RequestPrice=?RequestPrice,");
			strSql.Append("AddDateTime=?AddDateTime,");
			strSql.Append("Mobile=?Mobile,");
			strSql.Append("Email=?Email,");
			strSql.Append("IsNotice=?IsNotice");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?UserID", MySqlDbType.Int32,11),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ProductID", MySqlDbType.Int32,11),
					new MySqlParameter("?RequestPrice", MySqlDbType.Decimal,10),
					new MySqlParameter("?AddDateTime", MySqlDbType.DateTime),
					new MySqlParameter("?Mobile", MySqlDbType.VarChar,20),
					new MySqlParameter("?Email", MySqlDbType.VarChar,200),
					new MySqlParameter("?IsNotice", MySqlDbType.Int32,11)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.UserID;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.ProductID;
			parameters[4].Value = model.RequestPrice;
			parameters[5].Value = model.AddDateTime;
			parameters[6].Value = model.Mobile;
			parameters[7].Value = model.Email;
			parameters[8].Value = model.IsNotice;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void requestgroup_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}requestgroup ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.requestgroup requestgroup_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldrequestgroup +"  from {0}requestgroup ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.requestgroup model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= requestgroup_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int requestgroup_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}requestgroup ",sPre);
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
		public DataSet requestgroup_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldrequestgroup );
			strSql.AppendFormat(" FROM {0}requestgroup ",sPre);
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
		public List<Entity.requestgroup> requestgroup_GetListArray(string strWhere)
		{
			return requestgroup_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.requestgroup> requestgroup_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldrequestgroup );
			strSql.AppendFormat(" FROM {0}requestgroup ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.requestgroup> list = new List<Entity.requestgroup>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(requestgroup_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.requestgroup> requestgroup_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.requestgroup> list = new List<Entity.requestgroup>();
			RecordCount = requestgroup_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "requestgroup", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(requestgroup_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.requestgroup requestgroup_ReaderBind(IDataReader dataReader)
		{
			Entity.requestgroup model=new Entity.requestgroup();
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
			model.UserName=dataReader["UserName"].ToString();
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
			}
			ojb = dataReader["RequestPrice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RequestPrice=(decimal)ojb;
			}
			ojb = dataReader["AddDateTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddDateTime=(DateTime)ojb;
			}
			model.Mobile=dataReader["Mobile"].ToString();
			model.Email=dataReader["Email"].ToString();
			ojb = dataReader["IsNotice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsNotice=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

