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
		private string sFieldProductParts = "ID,ProductID,PartsName,PartsID,PartsSmallImg";
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int ProductParts_GetMaxId()
		{
			return DB.GetMaxID("ID", string.Format("{0}ProductParts",sPre)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ProductParts_Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(1) from {0}ProductParts",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DB.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int ProductParts_Add(Entity.ProductParts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("insert into {0}ProductParts(",sPre);
			strSql.Append("ProductID,PartsName,PartsID,PartsSmallImg)");
			strSql.Append(" values (");
			strSql.Append("@ProductID,@PartsName,@PartsID,@PartsSmallImg)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@PartsName", SqlDbType.NVarChar,250),
					new SqlParameter("@PartsID", SqlDbType.Int,4),
					new SqlParameter("@PartsSmallImg", SqlDbType.NVarChar,250)};
			parameters[0].Value = model.ProductID;
			parameters[1].Value = model.PartsName;
			parameters[2].Value = model.PartsID;
			parameters[3].Value = model.PartsSmallImg;

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
		public void ProductParts_Update(Entity.ProductParts model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("update {0}ProductParts set ",sPre);
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("PartsName=@PartsName,");
			strSql.Append("PartsID=@PartsID,");
			strSql.Append("PartsSmallImg=@PartsSmallImg");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@PartsName", SqlDbType.NVarChar,250),
					new SqlParameter("@PartsID", SqlDbType.Int,4),
					new SqlParameter("@PartsSmallImg", SqlDbType.NVarChar,250)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.ProductID;
			parameters[2].Value = model.PartsName;
			parameters[3].Value = model.PartsID;
			parameters[4].Value = model.PartsSmallImg;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void ProductParts_Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("delete from {0}ProductParts ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DB.ExecuteNonQuery(CommandType.Text,strSql.ToString(),parameters);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Entity.ProductParts ProductParts_GetEntity(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select "+ sFieldProductParts +"  from {0}ProductParts ",sPre);
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;
			Entity.ProductParts model=null;
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString(),parameters))
			{
				if(dataReader.Read())
				{
					model= ProductParts_ReaderBind(dataReader);
				}
			}
			return model;
		}
		/// <summary>
		/// 获取统计
		/// </summary>
		public int ProductParts_GetCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.AppendFormat("select count(*)  from {0}ProductParts ",sPre);
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
		public DataSet ProductParts_GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldProductParts );
			strSql.AppendFormat(" FROM {0}ProductParts ",sPre);
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
		public List<Entity.ProductParts> ProductParts_GetListArray(string strWhere)
		{
			return ProductParts_GetListArray(0,strWhere,""); 
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public List<Entity.ProductParts> ProductParts_GetListArray(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(sFieldProductParts );
			strSql.AppendFormat(" FROM {0}ProductParts ",sPre);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
				strSql.Append(" order by  "+filedOrder);
			}
			List<Entity.ProductParts> list = new List<Entity.ProductParts>();
			using (IDataReader dataReader = DB.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ProductParts_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 获得分页数据
		/// </summary>
		public List<Entity.ProductParts> ProductParts_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount)
		{
			List<Entity.ProductParts> list = new List<Entity.ProductParts>();
			using (IDataReader dataReader = SplitPages.GetListPages_SP(DB,"ProductParts", PageSize, PageIndex, Fileds, "ID", oderby, strWhere, out RecordCount,sPre))
			{
				while (dataReader.Read())
				{
					list.Add(ProductParts_ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// 对象实体绑定数据
		/// </summary>
		public Entity.ProductParts ProductParts_ReaderBind(IDataReader dataReader)
		{
			Entity.ProductParts model=new Entity.ProductParts();
			object ojb; 
			ojb = dataReader["ID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["ProductID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProductID=(int)ojb;
			}
			model.PartsName=dataReader["PartsName"].ToString();
			ojb = dataReader["PartsID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PartsID=(int)ojb;
			}
			model.PartsSmallImg=dataReader["PartsSmallImg"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

