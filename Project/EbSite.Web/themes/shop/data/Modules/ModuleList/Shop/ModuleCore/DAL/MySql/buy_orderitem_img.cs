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
		private string sFieldbuy_orderitem_img = "id,orderitemid,bigimg,smallimg,typeid";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int buy_orderitem_img_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}buy_orderitem_img",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool buy_orderitem_img_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}buy_orderitem_img",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int buy_orderitem_img_Add(Entity.buy_orderitem_img model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}buy_orderitem_img(",sPre);
			strSql.Append("orderitemid,bigimg,smallimg,typeid)");
			strSql.Append(" values (");
			strSql.Append("?orderitemid,?bigimg,?smallimg,?typeid)");
			 strSql.Append(";SELECT @@session.identity");
			MySqlParameter[] parameters = {
					new MySqlParameter("?orderitemid", MySqlDbType.Int32,11),
					new MySqlParameter("?bigimg", MySqlDbType.VarChar,200),
					new MySqlParameter("?smallimg", MySqlDbType.VarChar,200),
					new MySqlParameter("?typeid", MySqlDbType.Int32,11)};
			parameters[0].Value = model.orderitemid;
			parameters[1].Value = model.bigimg;
			parameters[2].Value = model.smallimg;
			parameters[3].Value = model.typeid;

			object obj = DB.ExecuteScalar(CommandType.Text,strSql.ToString(),parameters);
			if (obj == null)
			{
				return buy_orderitem_img_GetMaxId();
			}
			return 0;		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void buy_orderitem_img_Update(Entity.buy_orderitem_img model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}buy_orderitem_img set ",sPre);
			strSql.Append("orderitemid=?orderitemid,");
			strSql.Append("bigimg=?bigimg,");
			strSql.Append("smallimg=?smallimg,");
			strSql.Append("typeid=?typeid");
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32,11),
					new MySqlParameter("?orderitemid", MySqlDbType.Int32,11),
					new MySqlParameter("?bigimg", MySqlDbType.VarChar,200),
					new MySqlParameter("?smallimg", MySqlDbType.VarChar,200),
					new MySqlParameter("?typeid", MySqlDbType.Int32,11)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.orderitemid;
			parameters[2].Value = model.bigimg;
			parameters[3].Value = model.smallimg;
			parameters[4].Value = model.typeid;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void buy_orderitem_img_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}buy_orderitem_img ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.buy_orderitem_img buy_orderitem_img_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldbuy_orderitem_img +"  from {0}buy_orderitem_img ",sPre);
			strSql.Append(" where id=?id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?id", MySqlDbType.Int32)};
			parameters[0].Value = id;
			Entity.buy_orderitem_img model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= buy_orderitem_img_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int buy_orderitem_img_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}buy_orderitem_img ",sPre);
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
		public DataSet buy_orderitem_img_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldbuy_orderitem_img );
			strSql.AppendFormat(" FROM {0}buy_orderitem_img ",sPre);
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
		public List<Entity.buy_orderitem_img> buy_orderitem_img_GetListArray(string strWhere)
		{
			return buy_orderitem_img_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.buy_orderitem_img> buy_orderitem_img_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldbuy_orderitem_img );
			strSql.AppendFormat(" FROM {0}buy_orderitem_img ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.buy_orderitem_img> list = new List<Entity.buy_orderitem_img>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(buy_orderitem_img_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.buy_orderitem_img> buy_orderitem_img_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.buy_orderitem_img> list = new List<Entity.buy_orderitem_img>();
			RecordCount = buy_orderitem_img_GetCount(strWhere);
			string strSql = SplitPages.GetSplitPagesMySql(DbHelperCms.Instance, "buy_orderitem_img", PageSize, PageIndex, Fileds, "id",  oderby, strWhere, sPre);
			using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, strSql))
			{
				while (dataReader.Read())
				{
					list.Add(buy_orderitem_img_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.buy_orderitem_img buy_orderitem_img_ReaderBind(IDataReader dataReader)
		{
			Entity.buy_orderitem_img model=new Entity.buy_orderitem_img();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["orderitemid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.orderitemid=(int)ojb;
			}
			model.bigimg=dataReader["bigimg"].ToString();
			model.smallimg=dataReader["smallimg"].ToString();
			ojb = dataReader["typeid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.typeid=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

