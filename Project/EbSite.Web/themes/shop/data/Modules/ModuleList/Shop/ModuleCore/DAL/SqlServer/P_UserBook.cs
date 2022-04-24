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
		private string sFieldP_UserBook = "id,Title,Url,ProductID,OrderID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int P_UserBook_GetMaxId()
		{
			return DB.GetMaxID("id", string.Format("{0}P_UserBook",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool P_UserBook_Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}P_UserBook",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int P_UserBook_Add(Entity.P_UserBook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}P_UserBook(",sPre);
			strSql.Append("Title,Url,ProductID,OrderID)");
			strSql.Append(" values (");
			strSql.Append("@Title,@Url,@ProductID,@OrderID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Url", SqlDbType.NVarChar,200),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Url;
			parameters[2].Value = model.ProductID;
			parameters[3].Value = model.OrderID;

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
		public void P_UserBook_Update(Entity.P_UserBook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}P_UserBook set ",sPre);
			strSql.Append("Title=@Title,");
			strSql.Append("Url=@Url,");
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("OrderID=@OrderID");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Url", SqlDbType.NVarChar,200),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Url;
			parameters[3].Value = model.ProductID;
			parameters[4].Value = model.OrderID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void P_UserBook_Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}P_UserBook ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.P_UserBook P_UserBook_GetEntity(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldP_UserBook +"  from {0}P_UserBook ",sPre);
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;
			Entity.P_UserBook model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= P_UserBook_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int P_UserBook_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}P_UserBook ",sPre);
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
		public DataSet P_UserBook_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldP_UserBook );
			strSql.AppendFormat(" FROM {0}P_UserBook ",sPre);
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
		public List<Entity.P_UserBook> P_UserBook_GetListArray(string strWhere)
		{
			return P_UserBook_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.P_UserBook> P_UserBook_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldP_UserBook );
			strSql.AppendFormat(" FROM {0}P_UserBook ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.P_UserBook> list = new List<Entity.P_UserBook>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(P_UserBook_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.P_UserBook> P_UserBook_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.P_UserBook> list = new List<Entity.P_UserBook>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"P_UserBook", PageSize, PageIndex, Fileds, "id", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(P_UserBook_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.P_UserBook P_UserBook_ReaderBind(IDataReader dataReader)
		{
			Entity.P_UserBook model=new Entity.P_UserBook();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.Title=dataReader["Title"].ToString();
			model.Url=dataReader["Url"].ToString();
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
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

