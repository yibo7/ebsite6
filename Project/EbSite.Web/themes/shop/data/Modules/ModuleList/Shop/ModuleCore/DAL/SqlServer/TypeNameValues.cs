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
		private string sFieldTypeNameValues = "ID,TypeValueName,OrderID,TValues,TypeNameValueID,ProductID";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int TypeNameValues_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}TypeNameValues",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool TypeNameValues_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}TypeNameValues",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int TypeNameValues_Add(Entity.TypeNameValues model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}TypeNameValues(",sPre);
			strSql.Append("TypeValueName,OrderID,TValues,TypeNameValueID,ProductID)");
			strSql.Append(" values (");
			strSql.Append("@TypeValueName,@OrderID,@TValues,@TypeNameValueID,@ProductID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@TypeValueName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@TValues", SqlDbType.VarChar,100),
					new SqlParameter("@TypeNameValueID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4)};
			
			parameters[0].Value = model.TypeValueName;
			parameters[1].Value = model.OrderID;
			parameters[2].Value = model.TValues;
			parameters[3].Value = model.TypeNameValueID;
			parameters[4].Value = model.ProductID;

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
		public void TypeNameValues_Update(Entity.TypeNameValues model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}TypeNameValues set ",sPre);
			strSql.Append("TypeValueName=@TypeValueName,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("TValues=@TValues,");
			strSql.Append("TypeNameValueID=@TypeNameValueID,");
			strSql.Append("ProductID=@ProductID");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TypeValueName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@TValues", SqlDbType.VarChar,100),
					new SqlParameter("@TypeNameValueID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.TypeValueName;
			parameters[2].Value = model.OrderID;
			parameters[3].Value = model.TValues;
			parameters[4].Value = model.TypeNameValueID;
			parameters[5].Value = model.ProductID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void TypeNameValues_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}TypeNameValues ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.TypeNameValues TypeNameValues_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldTypeNameValues +"  from {0}TypeNameValues ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;
			Entity.TypeNameValues model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= TypeNameValues_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int TypeNameValues_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}TypeNameValues ",sPre);
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
		public DataSet TypeNameValues_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldTypeNameValues );
			strSql.AppendFormat(" FROM {0}TypeNameValues ",sPre);
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
		public List<Entity.TypeNameValues> TypeNameValues_GetListArray(string strWhere)
		{
			return TypeNameValues_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.TypeNameValues> TypeNameValues_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldTypeNameValues );
			strSql.AppendFormat(" FROM {0}TypeNameValues ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.TypeNameValues> list = new List<Entity.TypeNameValues>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(TypeNameValues_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.TypeNameValues> TypeNameValues_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.TypeNameValues> list = new List<Entity.TypeNameValues>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"TypeNameValues", PageSize, PageIndex, Fileds, "ID", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(TypeNameValues_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.TypeNameValues TypeNameValues_ReaderBind(IDataReader dataReader)
		{
			Entity.TypeNameValues model=new Entity.TypeNameValues();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.TypeValueName=dataReader["TypeValueName"].ToString();
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}
			model.TValues=dataReader["TValues"].ToString();
			ojb = dataReader["TypeNameValueID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TypeNameValueID=(int)ojb;
			}
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

