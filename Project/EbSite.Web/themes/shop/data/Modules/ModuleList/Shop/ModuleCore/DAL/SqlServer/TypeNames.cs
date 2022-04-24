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
		private string sFieldTypeNames = "ID,TypeName,OrderID,BrandIDs";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int TypeNames_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}TypeNames",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool TypeNames_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}TypeNames",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int TypeNames_Add(Entity.TypeNames model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}TypeNames(",sPre);
			strSql.Append("TypeName,OrderID,BrandIDs)");
			strSql.Append(" values (");
			strSql.Append("@TypeName,@OrderID,@BrandIDs)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					
					new SqlParameter("@TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@BrandIDs", SqlDbType.VarChar,200)};
		
			parameters[0].Value = model.TypeName;
			parameters[1].Value = model.OrderID;
			parameters[2].Value = model.BrandIDs;

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
		public void TypeNames_Update(Entity.TypeNames model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}TypeNames set ",sPre);
			strSql.Append("TypeName=@TypeName,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("BrandIDs=@BrandIDs");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@BrandIDs", SqlDbType.VarChar,200)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.TypeName;
			parameters[2].Value = model.OrderID;
			parameters[3].Value = model.BrandIDs;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void TypeNames_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}TypeNames ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.TypeNames TypeNames_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldTypeNames +"  from {0}TypeNames ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;
			Entity.TypeNames model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= TypeNames_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int TypeNames_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}TypeNames ",sPre);
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
		public DataSet TypeNames_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldTypeNames );
			strSql.AppendFormat(" FROM {0}TypeNames ",sPre);
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
		public List<Entity.TypeNames> TypeNames_GetListArray(string strWhere)
		{
			return TypeNames_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.TypeNames> TypeNames_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldTypeNames );
			strSql.AppendFormat(" FROM {0}TypeNames ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.TypeNames> list = new List<Entity.TypeNames>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(TypeNames_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.TypeNames> TypeNames_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.TypeNames> list = new List<Entity.TypeNames>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"TypeNames", PageSize, PageIndex, Fileds, "ID", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(TypeNames_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.TypeNames TypeNames_ReaderBind(IDataReader dataReader)
		{
			Entity.TypeNames model=new Entity.TypeNames();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.TypeName=dataReader["TypeName"].ToString();
			ojb = dataReader["OrderID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrderID=(int)ojb;
			}
			model.BrandIDs=dataReader["BrandIDs"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

